using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp48.Resources;
using WpfApp48.ViewModels;

namespace WpfApp48.Services
{
    public class ExcelDataService
    {
        OleDbConnection conn;
        OleDbCommand Command;
        private static ObservableCollection<ArticleDisplayVM> Articles = new ObservableCollection<ArticleDisplayVM>();
        PosSectorContext appContext = new PosSectorContext();
        public static string excelFile = null;


        public ArticleDisplayVM ManageModal(Modal modal)
        {
            if(Modal.columns == null)
            {
                MessageBox.Show(Translations.MapErrorMessage);
                return null;
            }

            ArticleDisplayVM columns = new ArticleDisplayVM
            {
                ID = Modal.columns.ID,
                ItemName = Modal.columns.ItemName,
                ItemSize = Modal.columns.ItemSize,
                So_Price = Modal.columns.So_Price,
                Gender = Modal.columns.Gender,
                BarCode = Modal.columns.BarCode,
                CollectionCategory = Modal.columns.CollectionCategory
            };
            return columns;


        }

        public async Task<ObservableCollection<ArticleDisplayVM>> ReadFromExcel(ArticleDisplayVM viewModel)
        {
            if (excelFile == null || viewModel == null)
                return null;
            
         
                try
                {
                    var con = Helpers.Extensions.SetOleDbCon(excelFile);
                    conn = new OleDbConnection(con);


                    await conn.OpenAsync();
                    Command = new OleDbCommand();
                    Command.Connection = conn;
                    Command.CommandText = Translations.SelectCommand;


                    var Reader = await Command.ExecuteReaderAsync();

                    while (Reader.Read())
                    {
                        Articles.Add(new ArticleDisplayVM()
                        {
                            ID = Reader[viewModel.ID].ToString(),
                            BarCode = Reader[viewModel.BarCode].ToString(),
                            ItemName = Reader[viewModel.ItemName].ToString(),
                            Gender = Reader[viewModel.Gender].ToString(),
                            CollectionCategory = Reader[viewModel.CollectionCategory].ToString(),
                            So_Price = Reader[viewModel.So_Price].ToString(),
                            ItemSize = Reader[viewModel.ItemSize].ToString()
                        });
                    }

                    Reader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    
                }

            if(Articles.Count > 0)
            {
                MessageBox.Show(Articles.Count + Translations.CountArticlesMessage);
            }
            else
            {
                MessageBox.Show(Translations.NoDataMessage);
            }

            return Articles;
        }

        public bool OpenDialog()
        {
            OpenFileDialog openFileDialog = Helpers.Extensions.CreateOFDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                excelFile= openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public int ImportToDatabase()
        {
            var culture = new CultureInfo(Translations.CultureInfo);
            var counter = 0;

            for (int i = 0; i < Articles.Count(); i++)
            {
                var value = Articles[i].BarCode;
                Article temp = appContext.Articles.FirstOrDefault(x => x.BarCode == value);

                if (temp == null)
                {
                    counter++;
                    appContext.Articles.Add(new Article
                    {
                        Name = Articles[i].ItemName,
                        Price = Helpers.Extensions.GetDecimal(Articles[i].So_Price),
                        BarCode = Articles[i].BarCode,
                        ArticleNumber = 123,
                        SubCategory_Id = Helpers.Extensions.ManageSubcategory(Articles[i].Gender, Articles[i].CollectionCategory),
                        Deleted = false,
                        ReturnFee = 1,
                        Id = Guid.NewGuid(),
                        Order = 1
                    });
                }

            }
            appContext.SaveChanges();
            return counter;
        }


        //public async Task<Rule> RuleAsync()
        //{

        //}

    }
}


using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp48.Modals;
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


        public async Task<ArticleDisplayVM> ManageModal(Modal modal)
        {
            if (Modal.columns == null)
            {
                MessageBox.Show(Translations.MapErrorMessage);
                return null;
            }

            ArticleDisplayVM columns = new ArticleDisplayVM
            {
                ID = Guid.NewGuid(),
                ItemName = Modal.columns.ItemName,
                ItemSize = Modal.columns.ItemSize,
                So_Price = Modal.columns.So_Price,
                Gender = Modal.columns.Gender,
                BarCode = Modal.columns.BarCode,
                CollectionCategory = Modal.columns.CollectionCategory
            };
            return await Task.FromResult(columns);

        }

        public string GetSheetName(ModalSheets modal)
        {
            if (ModalSheets.sheetName == null)
            {
                MessageBox.Show(Translations.MapErrorMessage);
                return null;
            }

            var sheetName = ModalSheets.sheetName;
            return sheetName;
        }

        public async Task<List<string>> GetData()
        {
            var con = Helpers.Extensions.SetOleDbCon(excelFile);
            conn = new OleDbConnection(con);
            var lines = new List<string>();


            await conn.OpenAsync();
            Command = new OleDbCommand();
            Command.Connection = conn;
            Command.CommandText = "select top 1 * from ["+ App.Current.Properties["SheetName"]+ "]";


            var Reader = await Command.ExecuteReaderAsync();

            while (Reader.Read())
            {
                var fieldCount = Reader.FieldCount;

                var fieldIncrementor = 1;
                var fields = new List<string>();
                while (fieldCount >= fieldIncrementor)
                {
                    string test = Reader[fieldIncrementor - 1].ToString();
                    fields.Add(test);
                    fieldIncrementor++;
                }

                lines = fields;
            }

            Reader.Close();
            conn.Close();

            return await Task.FromResult(lines);
        }

        public async Task<DiscountDisplayVM> ManageDiscount(Discounts modal)
        {
            if (Discounts.viewmodel == null)
            {
                MessageBox.Show(Translations.MapErrorMessage);
                return null;
            }

            DiscountDisplayVM rule = new DiscountDisplayVM
            {
                Id = Discounts.viewmodel.Id,
                Value = Discounts.viewmodel.Value,
                Type = Discounts.viewmodel.Type,
                isActive = Discounts.viewmodel.isActive,
                isExecuted = Discounts.viewmodel.isExecuted,
                validFrom = Discounts.viewmodel.validFrom,
                validTo = Discounts.viewmodel.validTo
            };
            return await Task.FromResult(rule);


        }

        public async Task<ObservableCollection<ArticleDisplayVM>> ReadFromExcel(ArticleDisplayVM viewModel)
        {
            if (excelFile == null || viewModel == null)
                return null;

            try
            {
                string con =
      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + ";" +
      @"Extended Properties='Excel 8.0;HDR=Yes;'";
                conn = new OleDbConnection(con);


                await conn.OpenAsync();
                Command = new OleDbCommand();
                Command.Connection = conn;
                Command.CommandText = "select * from [" + App.Current.Properties["SheetName"] + "]";


                var Reader = await Command.ExecuteReaderAsync();

                while (Reader.Read())
                {
                    Articles.Add(new ArticleDisplayVM()
                    {
                        ID = Guid.NewGuid(),
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
                throw e;
            }

            if (Articles.Count > 0)
            {
                MessageBox.Show(Articles.Count + Translations.CountArticlesMessage);
            }
            else
            {
                MessageBox.Show(Translations.NoDataMessage);
                
                
            }

            return Articles;
        }

        public void AddDiscountToArticle(List<ArticleDisplayVM> temp, string discName)
        {
            Rule disc = appContext.Rules.Where(x => x.Name == discName).FirstOrDefault();

            if(disc != null)
            {
                var discPrice = Int32.TryParse(disc.Type, out int rulePrice);
                for (int i = 0; i < temp.Count; i++)
                {
                    var oldPrice = Int32.TryParse(temp[i].So_Price, out int res);

                    RuleItem ruleItem = new RuleItem()
                    {
                        Id = Guid.NewGuid(),
                        Article_Id = temp[i].ID,
                        Rule_Id = disc.Id,
                        NewPrice = res - (rulePrice * res % 100)
                    };
                    appContext.RuleItems.Add(ruleItem);
                }

                appContext.SaveChanges();
                MessageBox.Show("Successfully saved.");
            }
            else
            {
                MessageBox.Show("Discount is not selected. Try Again.");
            }
            
        }

        public async Task<bool> OpenDialog()
        {
            OpenFileDialog openFileDialog = Helpers.Extensions.CreateOFDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                excelFile = openFileDialog.FileName;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<int> ImportToDatabase()
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
                        Id = Articles[i].ID,
                        Order = 1
                    });
                }

            }
            appContext.SaveChanges();
            return await Task.FromResult(counter);
        }

        public void SaveDiscountToDatabase(DiscountDisplayVM viewModel)
        {
            Rule rule = new Rule
            {
                Id = viewModel.Id,
                Active = (bool)viewModel.isActive,
                IsExecuted = (bool)viewModel.isExecuted,
                ValidFrom = viewModel.validFrom,
                ValidTo = viewModel.validTo,
                Type = viewModel.Type,
                Name = viewModel.Value,
                Taxes = null
            };

            appContext.Rules.Add(rule);
            appContext.SaveChanges();
        }

        public async Task<List<string>> ListSheetInExcel()
        {
            OleDbConnectionStringBuilder sbConnection = new OleDbConnectionStringBuilder();
            String strExtendedProperties = String.Empty;
            sbConnection.DataSource = excelFile;
            if (Path.GetExtension(excelFile).Equals(".xls"))//for 97-03 Excel file
            {
                sbConnection.Provider = "Microsoft.Jet.OLEDB.4.0";
                strExtendedProperties = "Excel 8.0;HDR=Yes;IMEX=1";//HDR=ColumnHeader,IMEX=InterMixed
            }
            else if (Path.GetExtension(excelFile).Equals(".xlsx"))  //for 2007 Excel file
            {
                sbConnection.Provider = "Microsoft.ACE.OLEDB.12.0";
                strExtendedProperties = "Excel 12.0;HDR=Yes;IMEX=1";
            }
            sbConnection.Add("Extended Properties", strExtendedProperties);

            List<string> listSheet = new List<string>();
            using (OleDbConnection conn = new OleDbConnection(sbConnection.ToString()))
            {
               await conn.OpenAsync();
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                foreach (DataRow drSheet in dtSheet.Rows)
                {
                    if (drSheet["TABLE_NAME"].ToString().Contains("$"))//checks whether row contains '_xlnm#_FilterDatabase' or sheet name(i.e. sheet name always ends with $ sign)
                    {
                        listSheet.Add(drSheet["TABLE_NAME"].ToString());
                    }
                }
            }
            return await Task.FromResult(listSheet);
        }


        public async Task<List<string>> GetDiscountList()
        {
            var tempList = new List<string>();
            foreach(var item in appContext.Rules)
            {
                tempList.Add(item.Name);
            }

            return await Task.FromResult(tempList);
        }

        
    }
}


﻿using Microsoft.Win32;
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

        public ExcelDataService()
        {
        }
        public async Task<ObservableCollection<ArticleDisplayVM>> ReadFromExcel()
        {

            string excelfile = OpenDialog();
            if (excelfile != null)
            {
                try
                {
                    var con = Helpers.Extensions.SetOleDbCon(excelfile);
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
                            ID = Reader["ITEM"].ToString(),
                            BarCode = Reader["BARCODE"].ToString(),
                            ItemName = Reader["BARCODE"].ToString() + " " + Reader["ITEM"].ToString() + " "
                            + Reader["prijevodi HRVATSKI"].ToString() + " " + Reader["COLOR_DESCRIPTION"].ToString() + " " + Reader["ITEM_SIZE"].ToString(),
                            Gender = Reader["GENDER"].ToString(),
                            Collection = Reader["SEASON"].ToString(),
                            So_Price = Reader["SO_PRICE"].ToString(),
                            ItemSize = Reader["ITEM_SIZE"].ToString()
                        });
                    }

                    Reader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw;
                }

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

        public string OpenDialog()
        {
            OpenFileDialog openFileDialog = Helpers.Extensions.CreateOFDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
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
                        SubCategory_Id = Helpers.Extensions.ManageSubcategory(Articles[i].Gender, Articles[i].Collection),
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

    }
}


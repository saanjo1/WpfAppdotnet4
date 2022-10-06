using Microsoft.Win32;
using System;
using System.Data.OleDb;
using System.Linq;
using WpfApp48.Resources;
using WpfApp48.ViewModels;

namespace WpfApp48.Helpers
{
    public class Extensions
    {
       private static PosSectorContext appContext = new PosSectorContext();

        public static Guid ManageCategories(string col)
        {
            var x = appContext.Categories.Where(x => x.Name == col).FirstOrDefault();

            if (x == null)
            {
                Category category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = col,
                    Deleted = false,
                    Order = 1,
                    Storage_Id = null
                };
                var id = category.Id;
                appContext.Categories.Add(category);
                appContext.SaveChanges();
                return id;
            }
            else
            {
                return x.Id;
            }

        }
        public static Guid ManageSubcategory(string gender, string collection)
        {
            SubCategory x = appContext.SubCategories.Where(x => x.Name == gender).FirstOrDefault();
            var season = ManageCategories(collection);
            if (x == null)
            {
                SubCategory subCategory = new SubCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = gender,
                    Deleted = false,
                    Category_Id = season
                };
                var id = subCategory.Id;
                appContext.SubCategories.Add(subCategory);
                appContext.SaveChanges();
                return id;
            }
            else
            {
                return x.Id;
            }
        }

       

        public static decimal GetDecimal(string value)
        {
            decimal decimalValue;
            if (value == "" || value == null)
                decimalValue = decimal.Parse("0");
            else
                decimalValue = decimal.Parse(value);

            return decimalValue;
        }

        public static OpenFileDialog CreateOFDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:";
            openFileDialog.Title = Translations.OpenDialogTitle;
            openFileDialog.Filter = Translations.OpenDialogFilter;

           return openFileDialog;
        }

        public static string SetOleDbCon(string excelfile)
        {
            string con =
      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfile + ";" +
      @"Extended Properties='Excel 8.0;HDR=Yes;'";
            return con;
        }
    }
}

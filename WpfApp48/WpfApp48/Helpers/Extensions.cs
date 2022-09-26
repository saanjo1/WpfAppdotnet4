using Microsoft.Win32;
using System;
using System.Data.OleDb;
using System.Linq;


namespace WpfApp48.Helpers
{
    public class Extensions
    {
       private static PosSectorContext appContext = new PosSectorContext();

        public static void ManageCategories()
        {
            if (!appContext.Categories.Any())
            {
                appContext.Categories.Add(new Category
                {
                    Id = new Guid("59f06472-79f7-4fda-a2d4-f24f1eae6e1b"),
                    Name = "default",
                    Deleted = false,
                    Order = 1
                });
                appContext.SaveChanges();
            }
        }
        public static Guid ManageSubcategory(string gender)
        {
            var x = appContext.SubCategories.Where(x => x.Name == gender).FirstOrDefault();
            ManageCategories();
            if (x == null)
            {
                SubCategory subCategory = new SubCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = gender,
                    Deleted = false,
                    Category_Id = new Guid("59f06472-79f7-4fda-a2d4-f24f1eae6e1b")
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
            openFileDialog.Title = "Browse Excel Files";
            openFileDialog.Filter = "Excel Worksheets|*.xls;*.xlsx;*.xlsm";

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

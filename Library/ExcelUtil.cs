using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using DataTable = System.Data.DataTable;

namespace ODMSinavYazilimi.Library
{
    public static class ExcelUtil
    {
        public static DataTable ExcelToDataTable(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    DataTableCollection table = result.Tables;
                    DataTable resultTable = table[reader.Name];
                    return resultTable;
                }
            }
        }
        public static void HucreSitili(Worksheet calismaSayfasi, int satirBaslangici, int satirGenisligi, int kayitSayisi)
        {
            Range baslik2 = calismaSayfasi.Range[calismaSayfasi.Cells[1, 1], calismaSayfasi.Cells[satirBaslangici, satirGenisligi]];
            baslik2.EntireRow.Font.Bold = true; //bold yap
            baslik2.Font.Size = 10;
            baslik2.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            baslik2.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            baslik2.Cells.WrapText = true; //Metni kaydır
            baslik2.Borders.LineStyle = XlLineStyle.xlContinuous;

            Range veriler = calismaSayfasi.Range[calismaSayfasi.Cells[satirBaslangici + 1, 1], calismaSayfasi.Cells[kayitSayisi + satirBaslangici, satirGenisligi]];
            veriler.Font.Size = 9;
            veriler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            veriler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            veriler.Borders.LineStyle = XlLineStyle.xlContinuous;
        }
        public static void HucreBirlesitir(Worksheet calismaSayfasi, int satirNo, int sutunNo, int dikeySira, int yataySira, int height = 20)
        {
            Range ing = calismaSayfasi.Range[calismaSayfasi.Cells[satirNo, sutunNo], calismaSayfasi.Cells[dikeySira, yataySira]]; //hücreleri birleştir
            ing.EntireRow.Font.Bold = true; //bold yap
            ing.Font.Size = 12;
            ing.Merge(); //birleştir
            ing.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            ing.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            ing.RowHeight = height;
            ing.Cells.WrapText = true;
        }

    }

}

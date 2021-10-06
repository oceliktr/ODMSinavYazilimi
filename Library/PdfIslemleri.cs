using System;
using System.Collections.Generic;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using ODMSinavYazilimi.Models;

namespace ODMSinavYazilimi.Library
{
    public class PdfIslemleri
    {
        public enum Renkler
        {
            Siyah = 1,
            Beyaz = 2,
            Gri = 3

        }

        private BaseColor Renklendirme(Renkler bgColor)
        {
            BaseColor bgc;
            switch (bgColor)
            {
                case Renkler.Siyah:
                    bgc = BaseColor.BLACK;
                    break;
                case Renkler.Beyaz:
                    bgc = BaseColor.WHITE;
                    break;
                case Renkler.Gri:
                    bgc = BaseColor.GRAY;
                    break;
                default:
                    bgc = BaseColor.BLACK;
                    break;
            }

            return bgc;
        }

        public void addCell(PdfPTable table, string text, int rowspan = 1, int colspan = 1, int hizalama = Element.ALIGN_LEFT, int fontSize = 7, Renkler fontColor = Renkler.Siyah, Renkler bgColor = Renkler.Beyaz, float yukseklik = 10, int vertical = Element.ALIGN_MIDDLE, int fontStyle = Font.NORMAL)
        {
            BaseColor fc = Renklendirme(fontColor);
            BaseColor bgc = Renklendirme(bgColor);

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, "CP1254", BaseFont.NOT_EMBEDDED);
            Font times = new Font(bfTimes, fontSize, fontStyle, fc);


            PdfPCell cell = new PdfPCell(new Phrase(text, times))
            {
                BackgroundColor = bgc,
                Rowspan = rowspan,
                Colspan = colspan,
                HorizontalAlignment = hizalama,
                VerticalAlignment = vertical,
                MinimumHeight = yukseklik
            };
            table.AddCell(cell);
        }

        public void addParagraph(Document doc, string metin, int fontSize = 10, int hizalama = Element.ALIGN_LEFT, int fontStil = Font.NORMAL)
        {
            BaseFont helveticaTurkish = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);
            Font fontNormal = new Font(helveticaTurkish, fontSize, fontStil);

            Paragraph result = new Paragraph(new Phrase(metin, fontNormal)) { Alignment = hizalama };

            doc.Add(result);
        }


        public void PdfBilgiYaz(Document document, PdfWriter writer, TestKutukInfo ogr, TestOturumlarInfo oturum, string kagitBoyutu,bool sablon,string baslik, List<TestBransInfo> branslar)
        {
            Image jpg = null;
            if (sablon)
            {
                jpg = Image.GetInstance(baslik);
                jpg.ScaleToFit(document.PageSize.Width, document.PageSize.Height); //fotoğrafın boyutu
                jpg.SetAbsolutePosition(-2, 4); //başlangıç pozisyonu
                jpg.SpacingBefore = 0f; //Görüntüden önce boşluk boyutu
                jpg.SpacingAfter = 0f; //Görüntüden sonra boşluk boyutu
                jpg.Alignment = Element.ALIGN_LEFT;
            }
            //Full path to the Unicode Arial file
            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");

            //Create a base font object making sure to specify IDENTITY-H
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //Create a specific font object
            Font f = new Font(bf, 8, Font.NORMAL);

            if (!sablon) //BAŞLIK KISMI ŞABLONDA GEREK YOK
            {
                PdfPTable tableBaslik = new PdfPTable(1)
                {
                    TotalWidth = 348f, // float cinsinden tablonun gerçek genişliği
                    LockedWidth = true, // tablonun mutlak genişliğini sabitle
                    SpacingBefore = 0f, //öncesinde boşluk miktarı
                    SpacingAfter = 0f, //sonrasında boşluk miktarı
                };
                //tableBaslik.DefaultCell.Border = Rectangle.NO_BORDER;
                tableBaslik.AddCell(GetCellBaslik(baslik, bf));
                tableBaslik.WriteSelectedRows(0, -1, 37, 573f, writer.DirectContent);
            }

            float x = kagitBoyutu == KagitBoyutu.A5.ToString() ? 99f : 110f;
            float y = kagitBoyutu == KagitBoyutu.A5.ToString() ? 513f : 655f;
            float aralik = 14.6f;
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_TOP, new Phrase(ogr.Adi + " " + ogr.Soyadi, f), x, y, 0);
            //ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_TOP, new Phrase(ogr.OgrenciNo.ToString(), f), x, y - aralik, 0);
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_TOP, new Phrase(ogr.Sinifi + " / " + ogr.Sube, f), x, y - (aralik * 2), 0);
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_TOP, new Phrase(ogr.KurumAdi, f), x, y - (aralik * 3), 0);
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_TOP, new Phrase(ogr.IlceAdi, f), x, y - (aralik * 4), 0);



            PdfContentByte cb = writer.DirectContent;

            if (!sablon)//şablon seçili değil ise ders adlarını yaz
            {
               
                PdfPTable table = new PdfPTable(branslar.Count)
                {
                    TotalWidth = 71.25f * branslar.Count, // puan cinsinden tablonun gerçek genişliği
                    //   // LockedWidth = true, // tablonun mutlak genişliğini sabitle
                    //    //SpacingBefore = 320f, //öncesinde boşluk miktarı
                    //   // SpacingAfter =300f, //sonrasında boşluk miktarı
                };

                //Ders bilgisini yaz
                foreach (var ders in branslar)
                {
                    table.AddCell(GetCell(ders.BransAdi, bf));
                }

                table.WriteSelectedRows(0, -1, 32, 433.0f, cb);
            }
            //buble işlemleri


            string opaqId = ogr.Id.ToString();

            int baslangic = 11 - opaqId.Length;


            float opx = kagitBoyutu == KagitBoyutu.A5.ToString() ? 255f : 398f; //yatay
            float opy = kagitBoyutu == KagitBoyutu.A5.ToString() ? 146.5f : 333f;//dikey;
            //Opaq rakamla yazma işlemi
            for (int i = 0; i < opaqId.Length; i++)
            {
                ColumnText.ShowTextAligned(writer.DirectContent,
                    Element.ALIGN_TOP,
                    new Phrase(opaqId.Substring(i, 1), f), opx + ((baslangic + i) * 12), opy, 0);
            }


            //booble işleri
            int indis = 0;

            float bx = kagitBoyutu == KagitBoyutu.A5.ToString() ? 257f : 400f; //yatay
            float by = kagitBoyutu == KagitBoyutu.A5.ToString() ? 136.5f : 323f;//dikey;
            const float fark = 12f;
            const float cap = 4.7f;


            //İŞARET KONULACAK OTURUM
            if (oturum.SiraNo == 2)
            {
                cb.Circle(bx + (fark * 10), @by + (fark * 3), cap);
            }
            //TODO:oturum numarası 3-4 olanlar için daha sonra çözüm üretilecek

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int opid = indis < opaqId.Length ? opaqId.Substring(indis, 1).ToInt32() : 11;
                    if (i == indis && j == opid)
                    {
                        cb.Circle(bx + (fark * (i + baslangic)), @by - (fark * j), cap);

                        indis++;
                    }
                }
            }

            cb.SetColorFill(BaseColor.BLACK);
            cb.Fill();
            cb.Stroke();
            //buble işlemleri


            if (sablon)
            {
                document.Add(jpg);
            }
        }
        public static PdfPCell GetCell(string text, BaseFont bf)
        {
            float fontSize = text.Length > 16 ? 5 : 7;//uzun dersler için küçük font kullanmak istedim
            Font font = new Font(bf, fontSize, Font.NORMAL);
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.MinimumHeight = 13.5f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.PaddingLeft = 6;
            cell.PaddingRight = 6;
            cell.Border = (int)BorderStyle.None;
            //cell.Rowspan = rowSpan;
            //cell.Colspan = colSpan;
            return cell;
        }
        public static PdfPCell GetCellBaslik(string text, BaseFont bf)
        {
            Font font = new Font(bf, 7, Font.NORMAL);
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            // cell.CalculatedHeight = 100.0f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_TOP;
            //cell.PaddingLeft = 6;
            //cell.PaddingRight = 6;
            cell.Border = (int)BorderStyle.None;
            //cell.Rowspan = rowSpan;
            //cell.Colspan = colSpan;
            return cell;
        }

    }

}

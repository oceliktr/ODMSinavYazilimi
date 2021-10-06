using ODMSinavYazilimi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ODMSinavYazilimi.Library;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;

namespace ODMSinavYazilimi
{
    public partial class FormKutukIslemleri : Form
    {
        private List<TestKutukInfo> ogrenciList = new List<TestKutukInfo>();
        public FormKutukIslemleri()
        {
            InitializeComponent();
        }
        private void FormKutukIslemleri_Load(object sender, EventArgs e)
        {
            lblId.Text = Bellek.SeciliSinav.Id.ToString();
            lblSinavAdi.Text = Bellek.SeciliSinav.SinavAdi;
            lblSinif.Text = Bellek.SeciliSinav.Sinif.ToString();
            KutukListesiniGetir();
        }
        private void KutukListesiniGetir()
        {
            JsonOperations json = new JsonOperations();

            string kutukFilename = Bellek.KutukFileNameGet(Bellek.SeciliSinav.Id, Bellek.SeciliSinav.Sinif);
            //Dosya indirilmiş mi kontrol et.
            if (!DizinIslemleri.DosyaKontrol(kutukFilename))
            {
                //json dosyası yoksa listeyi getir ve json dosyasına kaydet.
                MessageBox.Show("Kütük dosyası bulunamadı. Kütük listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            //json dosyası varsa göster.
            List<TestKutukInfo> list = json.GetListJsonFile<TestKutukInfo>(kutukFilename);

            if (list.Count == 0)
            {
                MessageBox.Show("Kütük listesinde bilgi bulunamadı. Kütük listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            lblOgrSayisi.Text = list.Count.ToString();
            ogrenciList = list;
            KayitlariListele(list);

        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            string ara = txtAra.Text;
            var ogrenciListesi = ogrenciList.FindAll(x =>
                x.Id.ToString().Contains(ara, StringComparison.OrdinalIgnoreCase) ||
                x.Adi.Contains(ara, StringComparison.OrdinalIgnoreCase) ||
                x.Soyadi.Contains(ara, StringComparison.OrdinalIgnoreCase) ||
                x.IlceAdi.Contains(ara, StringComparison.OrdinalIgnoreCase) ||
                x.KurumKodu.ToString().Contains(ara, StringComparison.OrdinalIgnoreCase) ||
                x.KurumAdi.Contains(ara, StringComparison.OrdinalIgnoreCase)).ToList();
            KayitlariListele(ogrenciListesi);
        }
        private void KayitlariListele(List<TestKutukInfo> ogrenciListesi)
        {
            dgvKutuk.DataSource = ogrenciListesi;

            dgvKutuk.Columns[0].HeaderText = "Opaq Id";
            dgvKutuk.Columns[0].Width = 80;
            dgvKutuk.Columns[1].HeaderText = "İlçe";
            dgvKutuk.Columns[1].Width = 100;
            dgvKutuk.Columns[2].HeaderText = "Kurum Kodu";
            dgvKutuk.Columns[2].Width = 80;
            dgvKutuk.Columns[3].HeaderText = "Kurum Adı";
            dgvKutuk.Columns[3].Width = 280;
            dgvKutuk.Columns[4].HeaderText = "Adı";
            dgvKutuk.Columns[4].Width = 150;
            dgvKutuk.Columns[5].HeaderText = "Soyadı";
            dgvKutuk.Columns[5].Width = 150;
            dgvKutuk.Columns[6].HeaderText = "Sınıf";
            dgvKutuk.Columns[6].Width = 50;
            dgvKutuk.Columns[7].HeaderText = "Şube";
            dgvKutuk.Columns[7].Width = 50;
            dgvKutuk.Columns[8].Visible = false;
            dgvKutuk.Columns[9].Visible = false;
        }
        private void btnSinifSubetoExcel_Click(object sender, EventArgs e)
        {
            if (dgvKutuk.RowCount == 0)
            {
                MessageBox.Show("Kütük seçmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                SaveFileDialog xlsFile = new SaveFileDialog
                {
                    Filter = "Microsoft Excel Çalışma Kitabı (*.xls;*.xlsx)|*.xls;*.xlsx",
                    FileName = $"{lblSinavAdi.Text} - Öğrenci Sayıları.xls",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };

                if (xlsFile.ShowDialog() == DialogResult.OK)
                {
                    ExportarDataGridViewExcel(xlsFile.FileName);
                }
                lblBilgi.Text = "Şube listesi oluşturuldu.";
            }
        }
        private void ExportarDataGridViewExcel(string dosyaAdi)
        {

            Stopwatch watch = new Stopwatch();
            watch.Start();

            lblBilgi.Text = "Şube listesi oluşturuluyor.";
            int s = 0;
            int o = 0;
            // int il = 0;
            List<SinifSube> ilceBilgi = new List<SinifSube>();
            List<SinifSube> okulBilgi = new List<SinifSube>();
            List<SinifSube> subeBilgi = new List<SinifSube>();

            var siniflar = (from ogr in ogrenciList select ogr).GroupBy(x => x.Sinifi).Select(x => x.First()).OrderBy(x => x.Sinifi);
            foreach (var sinif in siniflar)
            {
                var ilceler = (from ogr in ogrenciList select ogr).GroupBy(x => x.IlceAdi).Select(x => x.First()).OrderBy(x => x.IlceAdi);
                foreach (var ilce in ilceler)
                {
                    o++;
                    int ilceOgrSayisi = (from ogr in ogrenciList select ogr).GroupBy(x => x.Id).Select(x => x.First()).Count(x => x.IlceAdi == ilce.IlceAdi && x.Sinifi == sinif.Sinifi);
                    ilceBilgi.Add(new SinifSube(o, ilce.IlceAdi, 0, "", sinif.Sinifi, "", ilceOgrSayisi));

                    var okullar = (from ogr in ogrenciList select ogr).Where(x => x.IlceAdi == ilce.IlceAdi).GroupBy(x => x.KurumKodu).Select(x => x.First()).OrderBy(x => x.KurumAdi);
                    foreach (var okul in okullar)
                    {
                        o++;
                        int okulOgrSayisi = (from ogr in ogrenciList select ogr).GroupBy(x => x.Id).Select(x => x.First()).Count(x => x.KurumKodu == okul.KurumKodu && x.Sinifi == sinif.Sinifi);
                        okulBilgi.Add(new SinifSube(o, okul.IlceAdi, okul.KurumKodu, okul.KurumAdi, sinif.Sinifi,
                            "", okulOgrSayisi));
                        var subeler = (from ogr in ogrenciList select ogr).Where(x => x.KurumKodu == sinif.KurumKodu && x.Sinifi == sinif.Sinifi).GroupBy(x => x.Sube).Select(x => x.First()).OrderBy(x => x.Sube);
                        foreach (var sube in subeler)
                        {
                            int ogrSayisi = (from ogr in ogrenciList select ogr).GroupBy(x => x.Id)
                                .Select(x => x.First()).Count(x =>
                                    x.KurumKodu == sube.KurumKodu && x.Sinifi == sube.Sinifi && x.Sube == sube.Sube);
                            s++;
                            subeBilgi.Add(new SinifSube(s, sube.IlceAdi, sube.KurumKodu, sube.KurumAdi, sube.Sinifi,
                                sube.Sube, ogrSayisi));
                        }
                    }
                }
            }

            int a = 0;
            int ilceSayisi = ilceBilgi.Count;
            int okulSayisi = okulBilgi.Count;
            int subeSayisi = subeBilgi.Count;
            int islemSayisi = subeSayisi + okulSayisi + ilceSayisi + (okulSayisi);
            progressBar1.Maximum = islemSayisi;
            progressBar1.Value = 0;

            lblBilgi.Text = "Şube öğrenci sayıları listesi oluşturuluyor.";

            Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
            Workbook calismaKitabi = aplicacion.Workbooks.Add();
            Worksheet calismaSayfasi = (Worksheet)calismaKitabi.Worksheets.Item[1];

            calismaSayfasi.Name = "Şube Öğrenci Sayıları";

            calismaSayfasi.Cells[1, 1] = "Sıra No";
            calismaSayfasi.Cells[1, 2] = "İlçe Adı";
            calismaSayfasi.Cells[1, 3] = "Kurum Kodu";
            calismaSayfasi.Cells[1, 4] = "Kurum Adı";
            calismaSayfasi.Cells[1, 5] = "Sınıf";
            calismaSayfasi.Cells[1, 6] = "Şube";
            calismaSayfasi.Cells[1, 7] = "Şube Ö. Sayısı";

            for (int i = 0; i < subeSayisi; i++)
            {

                calismaSayfasi.Cells[i + 2, 1] = i + 1;
                calismaSayfasi.Cells[i + 2, 2] = subeBilgi[i].IlceAdi;
                calismaSayfasi.Cells[i + 2, 3] = subeBilgi[i].KurumKodu;
                calismaSayfasi.Cells[i + 2, 4] = subeBilgi[i].KurumAdi;
                calismaSayfasi.Cells[i + 2, 5] = subeBilgi[i].Sinif;
                calismaSayfasi.Cells[i + 2, 6] = subeBilgi[i].Sube;
                calismaSayfasi.Cells[i + 2, 7] = subeBilgi[i].OgrenciSayisi;

                a++;
                progressBar1.Value = a;

                try
                {
                    lblBilgi.Text = islemSayisi.KalanSureHesapla(a, watch);
                }
                catch (Exception)
                {
                    lblBilgi.Text = "Hesaplanıyor...";
                }
            }
            calismaSayfasi.Cells[subeSayisi + 2, 2] = "TOPLAM";
            calismaSayfasi.Cells[subeSayisi + 2, 7] = subeBilgi.Sum(x => x.OgrenciSayisi);
            ExcelUtil.HucreSitili(calismaSayfasi, 1, 7, (subeSayisi + 1));

            //Yeni Sayfa Ekle
            Sheets xlSheets = calismaKitabi.Sheets;
            var calismaSayfasi2 = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

            //  Worksheet calismaSayfasi2 = (Worksheet)calismaKitabi.Worksheets.Item[1];


            calismaSayfasi2.Name = "Okul Öğrenci Sayıları";

            calismaSayfasi2.Cells[1, 1] = "Sıra No";
            calismaSayfasi2.Cells[1, 2] = "İlçe Adı";
            calismaSayfasi2.Cells[1, 3] = "Kurum Kodu";
            calismaSayfasi2.Cells[1, 4] = "Kurum Adı";
            calismaSayfasi2.Cells[1, 5] = "Sınıf";
            calismaSayfasi2.Cells[1, 6] = "Ö. Sayısı";

            for (int i = 0; i < okulSayisi; i++)
            {

                calismaSayfasi2.Cells[i + 2, 1] = i + 1;
                calismaSayfasi2.Cells[i + 2, 2] = okulBilgi[i].IlceAdi;
                calismaSayfasi2.Cells[i + 2, 3] = okulBilgi[i].KurumKodu;
                calismaSayfasi2.Cells[i + 2, 4] = okulBilgi[i].KurumAdi;
                calismaSayfasi2.Cells[i + 2, 5] = okulBilgi[i].Sinif;
                calismaSayfasi2.Cells[i + 2, 6] = okulBilgi[i].OgrenciSayisi;

                a++;
                progressBar1.Value = a;

                try
                {
                    lblBilgi.Text = islemSayisi.KalanSureHesapla(a, watch);
                }
                catch (Exception)
                {
                    lblBilgi.Text = "Hesaplanıyor...";
                }
            }
            calismaSayfasi2.Cells[okulSayisi + 2, 2] = "TOPLAM";
            calismaSayfasi2.Cells[okulSayisi + 2, 6] = okulBilgi.Sum(x => x.OgrenciSayisi);
            ExcelUtil.HucreSitili(calismaSayfasi2, 1, 6, (okulSayisi + 1));


            var calismaSayfasi3 = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

            calismaSayfasi3.Name = "İlçe Öğrenci Sayıları";

            calismaSayfasi3.Cells[1, 1] = "Sıra No";
            calismaSayfasi3.Cells[1, 2] = "İlçe Adı";
            calismaSayfasi3.Cells[1, 3] = "Sınıf";
            calismaSayfasi3.Cells[1, 4] = "Ö. Sayısı";

            for (int i = 0; i < ilceSayisi; i++)
            {

                calismaSayfasi3.Cells[i + 2, 1] = i + 1;
                calismaSayfasi3.Cells[i + 2, 2] = ilceBilgi[i].IlceAdi;
                calismaSayfasi3.Cells[i + 2, 3] = ilceBilgi[i].Sinif;
                calismaSayfasi3.Cells[i + 2, 4] = ilceBilgi[i].OgrenciSayisi;

                a++;
                progressBar1.Value = a;

                try
                {
                    lblBilgi.Text = islemSayisi.KalanSureHesapla(a, watch);
                }
                catch (Exception)
                {
                    lblBilgi.Text = "Hesaplanıyor...";
                }
            }
            calismaSayfasi3.Cells[ilceSayisi + 2, 2] = "TOPLAM";
            calismaSayfasi3.Cells[ilceSayisi + 2, 4] = ilceBilgi.Sum(x => x.OgrenciSayisi);
            ExcelUtil.HucreSitili(calismaSayfasi3, 1, 4, ilceSayisi + 1);

            //ilçe ilçe okul öğrenci sayıları

            foreach (var ilce in ilceBilgi)
            {
                var calismaSayfasi4 = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

                //  Worksheet calismaSayfasi2 = (Worksheet)calismaKitabi.Worksheets.Item[1];


                calismaSayfasi4.Name = ilce.IlceAdi;

                calismaSayfasi4.Cells[1, 1] = "Sıra No";
                calismaSayfasi4.Cells[1, 2] = "İlçe Adı";
                calismaSayfasi4.Cells[1, 3] = "Kurum Kodu";
                calismaSayfasi4.Cells[1, 4] = "Kurum Adı";
                calismaSayfasi4.Cells[1, 5] = "Sınıf";
                calismaSayfasi4.Cells[1, 6] = "Ö. Sayısı";

                var okulBilgiIlce = okulBilgi.Where(x => x.IlceAdi == ilce.IlceAdi).ToList();
                var okulSayisiIlce = okulBilgiIlce.Count;
                for (int i = 0; i < okulSayisiIlce; i++)
                {

                    calismaSayfasi4.Cells[i + 2, 1] = i + 1;
                    calismaSayfasi4.Cells[i + 2, 2] = okulBilgiIlce[i].IlceAdi;
                    calismaSayfasi4.Cells[i + 2, 3] = okulBilgiIlce[i].KurumKodu;
                    calismaSayfasi4.Cells[i + 2, 4] = okulBilgiIlce[i].KurumAdi;
                    calismaSayfasi4.Cells[i + 2, 5] = okulBilgiIlce[i].Sinif;
                    calismaSayfasi4.Cells[i + 2, 6] = okulBilgiIlce[i].OgrenciSayisi;

                    a++;
                    progressBar1.Value = a;

                    try
                    {
                        lblBilgi.Text = islemSayisi.KalanSureHesapla(a, watch);
                    }
                    catch (Exception)
                    {
                        lblBilgi.Text = "Hesaplanıyor...";
                    }
                }
                calismaSayfasi4.Cells[okulSayisiIlce + 2, 2] = "TOPLAM";
                calismaSayfasi4.Cells[okulSayisiIlce + 2, 6] = okulBilgiIlce.Sum(x => x.OgrenciSayisi);

                ExcelUtil.HucreSitili(calismaSayfasi4, 1, 6, (okulSayisiIlce + 1));

            }

            lblBilgi.Text = "Tamamlandı...";

            calismaKitabi.SaveAs(dosyaAdi, XlFileFormat.xlWorkbookNormal);
            calismaKitabi.Close(true);
            aplicacion.Quit();

            lblBilgi.Text = "Şube öğrenci sayıları listesi oluşturuldu.";

            Process.Start(dosyaAdi);

            progressBar1.Value = 0;
            watch.Stop();

        }
        private void btnExceldenAktar_Click(object sender, EventArgs e)
        {
          
        }
    }
}

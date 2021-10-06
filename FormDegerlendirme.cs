using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;

namespace ODMSinavYazilimi
{
    public partial class FormDegerlendirme : Form
    {
        string dosyaAdi = "";
        private string raporDizinAdresi = "";
        private bool islemiDurdur;

        private int saat;
        private int dakika;
        private int saniye;

        //Bu dizi ile optik formu gelmeyen öğrencileri tespit edeceğiz
        private int anaBar;
        private List<TestKutukInfo> ogrencilerKutuk = new List<TestKutukInfo>();
        private List<TestBransInfo> branslarList = new List<TestBransInfo>();
        private List<TestSorularInfo> sorularList = new List<TestSorularInfo>();
        private AktifDonemSinavlar donemveSinavlar = new AktifDonemSinavlar();
        private List<TestOturumlarInfo> oturumlar = new List<TestOturumlarInfo>();
        private List<OgrenciCevapModel> ayaGoreOgrenciCevaplari = new List<OgrenciCevapModel>();//a kitapçığına göre
        private readonly List<TestOgrCevapInfo> testOgrCevaplar = new List<TestOgrCevapInfo>();
        private readonly List<TestOgrPuanInfo> testOgrPuanlar = new List<TestOgrPuanInfo>();
        private readonly List<TestOkulPuanInfo> testOkulPuanList = new List<TestOkulPuanInfo>();
        private readonly List<TestIlcePuanInfo> testIlcePuanList = new List<TestIlcePuanInfo>();
        public FormDegerlendirme()
        {
            InitializeComponent();
        }
        private void FormDegerlendirme_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            lblId.Text = Bellek.SeciliSinav.Id.ToString();
            lblSinavAdi.Text = Bellek.SeciliSinav.SinavAdi;
            lblSinif.Text = Bellek.SeciliSinav.Sinif.ToString();
            JsonVerileriniGetir();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblGecenSure.Text = string.Format("Geçen süre: {0}:{1}:{2}", saat.ToString("D2"), dakika.ToString("D2"), saniye.ToString("D2"));
            saniye++;
            if (saniye == 59)
            {
                saniye = 0;
                dakika++;
                if (dakika == 59)
                {
                    saat++;
                    dakika = 0;
                }
            }
        }
        private void btnABKitapcigi_Click(object sender, EventArgs e)
        {
            FormABKitapcik frm = new FormABKitapcik();
            frm.ShowDialog();
        }

        private void btnDegerlendirme1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofData = new OpenFileDialog())
            {
                ofData.Reset();
                ofData.ReadOnlyChecked = true;
                ofData.Multiselect = true;
                ofData.ShowReadOnly = true;
                ofData.Filter = "Cevap text dosyası (*.txt;*.dat)|*.txt;*.dat";
                ofData.Title = "Cevap text dosyasını seçiniz.";
                ofData.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofData.CheckPathExists = true;
                if (ofData.ShowDialog() == DialogResult.OK)
                {
                    dosyaAdi = ofData.FileName;

                    //Mükerrer kayıtlar kütükte olmayan öğrenciler gibi kayıtların tutulacağı dizini seçtiren işlemler
                    using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.ShowNewFolderButton = true; //yeni klasör oluşturmayı kapat
                        folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                        folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        folderDialog.Description = @"Rapor dosyalarının saklanacağı dizini seçiniz.";
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            raporDizinAdresi = folderDialog.SelectedPath + "\\";
                            timer1.Enabled = true; //sayaç başlasın

                            //Birinci aşamada cevapları alıp cevapların kontrolünü yaparak kütüğe kaydeder.
                            Degerlendirme();
                            // bgwDegerlendirme1.RunWorkerAsync();
                        }
                        folderDialog.Dispose();
                    }
                }
                ofData.Dispose();
            }
        }
        private void bgwDegerlendirme1_DoWork(object sender, DoWorkEventArgs e)
        {
            Degerlendirme();
        }

        private void Degerlendirme()
        {
            anaBar = 0;
            ayaGoreOgrenciCevaplari.Clear();
            testOgrCevaplar.Clear();
            testOkulPuanList.Clear();
            testIlcePuanList.Clear();

            pbAna.Maximum = 16;
            pbAna.Value = 0;
            string raporUrl = raporDizinAdresi + "Rapor.txt";

            var lines = File.ReadLines(dosyaAdi, Encoding.UTF8).ToList();

            #region ÖĞRENCİ CEVAPLARI OKUNUYOR

            anaBar++;
            pbAna.Value = anaBar;
            progressBar1.Maximum = lines.Count;
            progressBar1.Value = 0;
            List<OgrenciCevapModel> ogrenciCevaplari = new List<OgrenciCevapModel>();
            //Diziye al.
            int l = 0;
            foreach (string file in lines)
            {
                l++;
                progressBar1.Value = l;
                toolSslKalanSure.Text = "Öğrenci cevapların okunuyor.";

                string[] cevapBilgisi = file.Split('#');
                int opaqId = cevapBilgisi[0].Trim().ToInt32();
                if (opaqId == 0)
                {
                    GecenSureyiDurdur(cevapBilgisi[0] + " içerisinde sayılsal olmayan değerler var.");
                    MessageBox.Show(cevapBilgisi[0] + " içerisinde sayılsal olmayan değerler var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DersCevap> dersCevaplari = new List<DersCevap>();
                for (int i = 1; i < cevapBilgisi.Length; i = i + 3)
                {
                    int dersId = cevapBilgisi[i].ToInt32();
                    if (dersId == 0)
                    {
                        GecenSureyiDurdur("İşlem durduruldu.");
                        MessageBox.Show(opaqId + " Opaq Id nolu kayıtta Ders Id (" + cevapBilgisi[i] + ") içerisinde sayılsal olmayan değerler var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    string kitapcikTuru = cevapBilgisi[i + 1];
                    string cevaplar = cevapBilgisi[i + 2];
                    //if (kitapcikTuru == " ")
                    //{
                    //    GecenSureyiDurdur("İşlem durduruldu.");
                    //    MessageBox.Show(opaqId + " Opaq Id nolu kayıtta Kitapçık türü işaretlenmemiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //    return;
                    //}

                    // if (kitapcikTuru != " " && dersId != 0)
                    //  {
                    dersCevaplari.Add(new DersCevap()
                    {
                        DersId = dersId,
                        KitapcikTuru = kitapcikTuru,
                        Cevaplar = cevaplar
                    });
                    //  }
                }

                //   var kutuk = ogrencilerKutuk.Find(x => x.Id == opaqId);
                ogrenciCevaplari.Add(new OgrenciCevapModel()
                {
                    Id = opaqId,
                    //IlceAdi = kutuk.IlceAdi,
                    //KurumKodu = kutuk.KurumKodu,
                    //KurumAdi = kutuk.KurumAdi,
                    //Adi = kutuk.Adi,
                    //Soyadi = kutuk.Soyadi,
                    //Sinifi = kutuk.Sinifi,
                    //Sube = kutuk.Sube,
                    DersCevaplari = dersCevaplari
                });
            }



            #endregion

            #region MÜKERRER KAYIT KONTROLÜ

            anaBar++;
            pbAna.Value = anaBar;
            MukerrerKayitKontrol(ogrenciCevaplari, raporUrl);
            if (islemiDurdur)
            {
                Process.Start("notepad.exe", raporUrl);

                GecenSureyiDurdur("Cevap text dosyasında mükerrer kayıtlar bulunduğundan işlem durduruldu.");

                return; //mükerrer kayıtları göster ve işlemi durdur
            }
            #endregion

            #region KÜTÜKTE OLMAYAN KAYITLARI KONTROL ET


            anaBar++;
            pbAna.Value = anaBar;
            TextListesiniKutuktenKontrolEt(ogrenciCevaplari, raporUrl);
            //Kütükte bilgisi olmayan öğrenciler ve hatalı işaretlemelerin raporu varsa yazdır.
            if (islemiDurdur)
            {
                Process.Start("notepad.exe", raporUrl);

                GecenSureyiDurdur("Raporda düzeltilmesi gerekenleri bulunduğundan işlem durduruldu.");

                return; //mükerrer kayıtları göster ve işlemi durdur
            }


            #endregion

            #region ÖĞRENCİ CEVAPLARINDA B KİTAPÇIĞI VARMI

            anaBar++;
            pbAna.Value = anaBar;
            bool bKitapcik = false;
            foreach (var cvp in ogrenciCevaplari)
            {
                var kontrol = cvp.DersCevaplari.Count(x => x.KitapcikTuru == "B");
                if (kontrol > 0)
                {
                    bKitapcik = true;
                    break;
                }
            }

            //B Kitapçığı varsa A-B Kitapçığı soru numaraları tanımlanmış mı?
            if (bKitapcik)
            {
                string aBKitapcikSorularFileName = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);
                if (!DizinIslemleri.DosyaKontrol(aBKitapcikSorularFileName))
                {
                    //dosya yoksa uyar.
                    GecenSureyiDurdur("A-B Kitapçığı soru numaraları tanımlanmamış.");
                    MessageBox.Show("A-B Kitapçığı soru numaraları tanımlanmamış. Önce A-B Kitapçığı soru numaralarını tamamlayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                //dosya varsa veri var mı kontrol et
                JsonOperations json = new JsonOperations();
                List<SoruSiralari> sorusiralariGelen = json.GetListJsonFile<SoruSiralari>(aBKitapcikSorularFileName);
                if (sorusiralariGelen.Count != sorularList.Count)
                {
                    GecenSureyiDurdur("A-B Kitapçığı soru numaraları tüm dersler için tanımlanmamış.");
                    MessageBox.Show("A-B Kitapçığı soru numaraları tüm dersler için tanımlanmamış. Önce A-B Kitapçığı soru numaralarını tamamlayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                BKitapciginiAKitapciginaCevir(ogrenciCevaplari);
            }
            else
            {
                ayaGoreOgrenciCevaplari = ogrenciCevaplari;
            }
            #endregion

            #region TESTOGR TABLOSU OLUŞTURULUYOR

            anaBar++;
            pbAna.Value = anaBar;

            TestOgrCevapTablosunuOlustur();

            #endregion

            #region ÖĞRENCİ PUANLAR HESAPLANIYOR

            anaBar++;
            pbAna.Value = anaBar;

            progressBar1.Maximum = ayaGoreOgrenciCevaplari.Count;
            progressBar1.Value = 0;
            int ay = 0;
            foreach (var ogr in ayaGoreOgrenciCevaplari)
            {
                toolSslKalanSure.Text = "Öğrenci puanları hesaplanıyor. " + ay + "/" + ayaGoreOgrenciCevaplari.Count;
                ay++;
                progressBar1.Value = ay;
                PuanlamaHesapla(ogr);

                Application.DoEvents();
            }

            #endregion

            #region OKUL PUANLARI HESAPLANIYOR
            anaBar++;
            pbAna.Value = anaBar;

            var okulListesi = ayaGoreOgrenciCevaplari.GroupBy(x => x.KurumKodu).Select(x => x.First()).ToList();
            progressBar1.Maximum = okulListesi.Count;
            progressBar1.Value = 0;
            ay = 0;

            foreach (var okul in okulListesi)
            {
                toolSslKalanSure.Text = "Okul puanları hesaplanıyor. " + ay + "/" + okulListesi.Count;
                ay++;
                progressBar1.Value = ay;
                int sinavId = Bellek.SeciliSinav.Id;

                List<OgrDogruYanlisSayilariModel> okulOrtalamasi = OkulNetOrtalamasi(okul.KurumKodu, Bellek.SeciliSinav.Sinif);

                foreach (OgrDogruYanlisSayilariModel p in okulOrtalamasi)
                {

                    testOkulPuanList.Add(new TestOkulPuanInfo()
                    {
                        BransId = p.BransId,
                        Bos = p.Bos,
                        Dogru = p.Dogru,
                        Yanlis = p.Yanlis,
                        KurumKodu = okul.KurumKodu,
                        SinavId = sinavId
                    });

                }

                Application.DoEvents();
            }
            #endregion

            #region İLÇE PUANLARI HESAPLANIYOR

            anaBar++;
            pbAna.Value = anaBar;

            var ilcelerListesi = ayaGoreOgrenciCevaplari.GroupBy(x => x.IlceAdi).Select(x => x.First()).ToList();
            progressBar1.Maximum = ilcelerListesi.Count;
            progressBar1.Value = 0;
            ay = 0;
            foreach (var ilce in ilcelerListesi)
            {
                toolSslKalanSure.Text = "İlçe puanları hesaplanıyor. " + ay + "/" + ilcelerListesi.Count;
                ay++;
                progressBar1.Value = ay;
                IlcePuanHesaplama(ilce);
                Application.DoEvents();
            }

            #endregion
            anaBar++;
            pbAna.Value = anaBar;
            JsonveSqlDosyalariOlustur();

            anaBar++;
            pbAna.Value = anaBar;

            if (cbExceleAktar.Checked)
            {
                ExcelDosyasinaAktar();
            }

            GecenSureyiDurdur("Tamamlandı " + anaBar);
        }
        private void JsonveSqlDosyalariOlustur()
        {
            toolSslKalanSure.Text = "Json dosyalar oluşturuluyor";
            progressBar1.Maximum = Bellek.SeciliSinav.Manuel == 0?5:9;
            progressBar1.Value = 0;
            //testogrcevaplar json oluştur
            DizinIslemleri.JsonDosyaOlustur(Bellek.TestOgrCevaplarFileNameGet(Bellek.SeciliSinav.Id), testOgrCevaplar);
            progressBar1.Value = 1;

            //testogrpuanlar json oluştur
            DizinIslemleri.JsonDosyaOlustur(Bellek.TestOgrPuanlarFileNameGet(Bellek.SeciliSinav.Id), testOgrPuanlar);
            progressBar1.Value = 2;

            //testokulpuanlar json oluştur
            DizinIslemleri.JsonDosyaOlustur(Bellek.TestOkulPuanlarFileNameGet(Bellek.SeciliSinav.Id), testOkulPuanList);
            progressBar1.Value = 3;

            //testilçepuanlar json oluştur
            DizinIslemleri.JsonDosyaOlustur(Bellek.TestIlcePuanlarFileNameGet(Bellek.SeciliSinav.Id), testIlcePuanList);
            progressBar1.Value = 4;
            //a kitapçığına göre cevapları ders ders json oluştur
            DizinIslemleri.JsonDosyaOlustur(Bellek.DersBazliCevaplariFileNameGet(Bellek.SeciliSinav.Id), ayaGoreOgrenciCevaplari);
            progressBar1.Value = 5;


            //manuel sınav ise sql oluşturma
            if (Bellek.SeciliSinav.Manuel==0)
            {
                StreamWriter resultYaz = new StreamWriter(Bellek.TestOgrCevaplarSqlFileNameGet(Bellek.SeciliSinav.Id, raporDizinAdresi));

                resultYaz.WriteLine("DELETE FROM testogrcevaplar WHERE SinavId=" + Bellek.SeciliSinav.Id + ";");
                foreach (var model in testOgrCevaplar)
                {
                    string sql =
                        "INSERT INTO `testogrcevaplar` (`SinavId`, `OturumId`, `OpaqId`, `Cevap`, `Dogru`, `Yanlis`, `Bitti`, `Baslangic`, `Bitis`, `SonIslem`) " +
                        "VALUES (" + Bellek.SeciliSinav.Id + "," + model.OturumId + ",'" + model.OpaqId + "','" + model.Cevap + "'," + model.Dogru + "," + model.Yanlis + "," + model.Bitti + ",'" + model.Baslangic + "','" + model.Bitis + "','" + model.SonIslem + "');";
                    resultYaz.WriteLine(sql);
                }
                // resultYaz.Close();
                resultYaz.Dispose();
                progressBar1.Value = 6;


                resultYaz = new StreamWriter(Bellek.TestOgrPuanlarSqlFileNameGet(Bellek.SeciliSinav.Id, raporDizinAdresi));

                resultYaz.WriteLine("DELETE FROM testogrpuanlar WHERE SinavId=" + Bellek.SeciliSinav.Id + ";");
                foreach (var model in testOgrPuanlar)
                {
                    string sql = "INSERT INTO `testogrpuanlar` (`SinavId`, `KurumKodu`, `OpaqId`, `Dogru`, `Yanlis`, `Bos`, `Puan`) " +
                                 "VALUES (" + Bellek.SeciliSinav.Id + "," + model.KurumKodu + ", " + model.OpaqId + ", " + model.Dogru + ", " + model.Yanlis + ", " + model.Bos + ", " + decimal.Round(model.Puan, 3, MidpointRounding.AwayFromZero).ToString().Replace(",", ".") + ");";
                    resultYaz.WriteLine(sql);
                }
                // resultYaz.Close();
                resultYaz.Dispose();
                progressBar1.Value = 7;



                resultYaz = new StreamWriter(Bellek.TestOkulPuanlarSqlFileNameGet(Bellek.SeciliSinav.Id, raporDizinAdresi));

                resultYaz.WriteLine("DELETE FROM testokulpuanlar WHERE SinavId=" + Bellek.SeciliSinav.Id + ";");
                foreach (var model in testOkulPuanList)
                {
                    string sql =
                        "INSERT INTO `testokulpuanlar` (`SinavId`, `KurumKodu`, `BransId`, `Dogru`, `Yanlis`, `Bos`) " +
                        "VALUES (" + Bellek.SeciliSinav.Id + ", " + model.KurumKodu + ", " + model.BransId + ", " + model.Dogru + ", " + model.Yanlis + ", " + model.Bos + ");";
                    resultYaz.WriteLine(sql);
                }
                resultYaz.Dispose();
                progressBar1.Value = 8;

                resultYaz = new StreamWriter(Bellek.TestIlcePuanlarSqlFileNameGet(Bellek.SeciliSinav.Id, raporDizinAdresi));

                resultYaz.WriteLine("DELETE FROM testilcepuanlar WHERE SinavId=" + Bellek.SeciliSinav.Id + ";");
                foreach (var model in testIlcePuanList)
                {
                    string sql = "INSERT INTO `testilcepuanlar` (`SinavId`, `IlceAdi`, `KurumKodu`, `OgrSayisi`, `Dogru`, `Yanlis`, `Bos`, `Puan`) " +
                                 "VALUES (" + Bellek.SeciliSinav.Id + ", '" + model.IlceAdi + "', " + model.KurumKodu + ", " + model.OgrSayisi + ", " + model.Dogru + ", " + model.Yanlis + ", " + model.Bos + ", " + decimal.Round(model.Puan, 3, MidpointRounding.AwayFromZero).ToString().Replace(",", ".") + ");";
                    resultYaz.WriteLine(sql);
                }
                resultYaz.Dispose();
                resultYaz.Close();
                progressBar1.Value = 9;
            }


        }
        private void TestOgrCevapTablosunuOlustur()
        {
            testOgrCevaplar.Clear();
            progressBar1.Maximum = oturumlar.Count * ayaGoreOgrenciCevaplari.Count;
            progressBar1.Value = 0;
            int a = 0;
            toolSslKalanSure.Text = "Öğrenci cevapları tablosu hazırlanıyor.";
            foreach (var ot in oturumlar)
            {
                foreach (var ogr in ayaGoreOgrenciCevaplari)
                {
                    a++;
                    progressBar1.Value = a;

                    string cevap = "";
                    var oturumBranslari = sorularList.Where(x => x.OturumId == ot.Id).OrderBy(x => x.SoruNo)
                        .GroupBy(x => x.BransId).Select(x => x.First()).ToList();
                    foreach (var s in oturumBranslari)
                    {
                        var al = ogr.DersCevaplari.Find(x => x.DersId == s.BransId);
                        if (al != null)
                            cevap += al.Cevaplar;
                    }

                    //doğru yanlış hesapla
                    int dogru = 0;
                    int yanlis = 0;
                    int bos = 0;
                    for (int i = 0; i < cevap.Length; i++)
                    {
                        var dogruCvp = sorularList.FirstOrDefault(x => x.SoruNo == i + 1 && x.OturumId == ot.Id);
                        try
                        {
                            string ogrCvp = cevap.Substring(dogruCvp.SoruNo - 1, 1);
                            if (ogrCvp == " ")
                            {
                                bos++;
                            }
                            if (dogruCvp.Cevap == ogrCvp)
                            {
                                dogru++;
                            }
                            if (dogruCvp.Cevap != ogrCvp)
                            {
                                yanlis++;
                            }

                        }
                        catch
                        {
                            //
                        }
                    }

                    //tüm sruları boş bırakanları es geçmek için sadece doğru veya yanlışı olanları ekle
                    if (dogru != 0 || yanlis != 0)
                    {
                        var simdi = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":00";

                        testOgrCevaplar.Add(new TestOgrCevapInfo()
                        {
                            SinavId = Bellek.SeciliSinav.Id,
                            OturumId = ot.Id,
                            OpaqId = ogr.Id,
                            Cevap = cevap,
                            Dogru = dogru,
                            Yanlis = yanlis,
                            Bitti = 1,
                            Baslangic = simdi,
                            Bitis = simdi,
                            SonIslem = simdi,
                        });
                    }

                }
            }
            progressBar1.Value = 0;
        }
        private void BKitapciginiAKitapciginaCevir(List<OgrenciCevapModel> ogrenciCevaplari)
        {
            progressBar1.Maximum = ogrenciCevaplari.Count;
            progressBar1.Value = 0;
            int a = 0;

            foreach (var cvp in ogrenciCevaplari)
            {
                if (cvp.Id == 33479)
                {

                }
                a++;
                progressBar1.Value = a;
                toolSslKalanSure.Text = $"B kitapçığı cevapları A kitapçığına göre dönüştürülüyor. {a}/{ogrenciCevaplari.Count}";

                string aBKitapcikSorularFileName = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);
                JsonOperations json = new JsonOperations();
                List<SoruSiralari> sorusiralariGelen = json.GetListJsonFile<SoruSiralari>(aBKitapcikSorularFileName);

                List<DersCevap> dersCevapList = new List<DersCevap>();
                foreach (var dc in cvp.DersCevaplari)
                {
                    string cevapA = "";
                    if (dc.KitapcikTuru == "B")
                    {
                        try
                        {
                            string eskiCevap = dc.Cevaplar;
                            string[] yenicevap = new string[eskiCevap.Length];
                            for (int j = 0; j < eskiCevap.Length; j++)
                            {
                                char cvpChr = eskiCevap[j];
                                //oturum sırası 1 ise sözel
                                int soruno = j + 1;
                                var ilksoruNo = sorularList.OrderBy(x => x.SoruNo).FirstOrDefault(x => x.BransId == dc.DersId)
                                    .SoruNo;

                                var sonuc = sorusiralariGelen.FirstOrDefault(x =>
                                    x.BransId == dc.DersId && x.BSoruNo == (soruno + (ilksoruNo - 1)));
                                if (sonuc != null)
                                {
                                    int konum = sonuc.ASoruNo - (ilksoruNo - 1);
                                    //DCBDCADBD --- gelen cevap
                                    yenicevap[konum - 1] = cvpChr.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("OpaqId:" + cvp.Id + " Cevap:" + eskiCevap + " Soru No:" + soruno +
                                                    " Ders Kodu:" + dc.DersId + " bulunamadı.");
                                    GecenSureyiDurdur("OpaqId:" + cvp.Id + " Cevap:" + eskiCevap + " Soru No:" + soruno +
                                                      " Ders Kodu:" + dc.DersId + " bulunamadı.");
                                    return;
                                }
                            }

                            cevapA += string.Join("", yenicevap.ToArray());

                            dersCevapList.Add(new DersCevap()
                            {
                                DersId = dc.DersId,
                                KitapcikTuru = "A",
                                Cevaplar = cevapA
                            });
                        }
                        catch (Exception)
                        {
                            //
                        }
                    }
                    else if (dc.KitapcikTuru == "A")
                    {
                        cevapA = dc.Cevaplar;
                        dersCevapList.Add(new DersCevap()
                        {
                            DersId = dc.DersId,
                            KitapcikTuru = "A",
                            Cevaplar = cevapA
                        });
                    }


                }
                //Öğrenci tüm derslerden cevabı var mı(kitapçık türü işaretlenmemiş öğrencileri çıkarmak için bu kontrolü yaptım)
                if (cvp.DersCevaplari.Count == dersCevapList.Count)
                {
                    ayaGoreOgrenciCevaplari.Add(new OgrenciCevapModel()
                    {
                        Id = cvp.Id,
                        IlceAdi = cvp.IlceAdi,
                        KurumKodu = cvp.KurumKodu,
                        KurumAdi = cvp.KurumAdi,
                        Sinifi = cvp.Sinifi,
                        Adi = cvp.Adi,
                        Soyadi = cvp.Soyadi,
                        Sube = cvp.Sube,
                        DersCevaplari = dersCevapList
                    });
                }
            }
            progressBar1.Value = 0;
        }
        private void JsonVerileriniGetir()
        {
            JsonOperations json = new JsonOperations();
            if (!DizinIslemleri.DosyaKontrol(Bellek.AktifDonemveSinavlarFilename))
            {
                //json dosyası yoksa listeyi getir ve json dosyasına kaydet.
                MessageBox.Show("Aktif dönem dosyası bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            donemveSinavlar = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);

            if (donemveSinavlar == null)
            {
                MessageBox.Show("Aktif dönem bilgisi bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }


            oturumlar = donemveSinavlar.Oturumlar.Where(x => x.SinavId == Bellek.SeciliSinav.Id).ToList();

            if (!DizinIslemleri.DosyaKontrol(Bellek.BranslarFilename))
            {
                MessageBox.Show("Ders listesi bulunamadı. Ders listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }


            string sorularFileName = Bellek.SorularFileNameGet(Bellek.SeciliSinav.Id);
            if (!DizinIslemleri.DosyaKontrol(sorularFileName))
            {
                MessageBox.Show("Sorular listesi bulunamadı. Soruları indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            sorularList = json.GetListJsonFile<TestSorularInfo>(sorularFileName);
            if (sorularList.Count == 0)
            {
                MessageBox.Show("Sorular listesi bulunamadı. Soruları indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            var branslarGet = json.GetListJsonFile<TestBransInfo>(Bellek.BranslarFilename);
            if (branslarGet.Count == 0)
            {
                MessageBox.Show("Ders listesi bulunamadı. Ders listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            //sorun yoksa sınavın branşlarını listele

            SinavBranslar sinavBranslar = new SinavBranslar();
            branslarList = sinavBranslar.SinavinBranslari(oturumlar, branslarGet, sorularList);




            string kutukFilename = Bellek.KutukFileNameGet(Bellek.SeciliSinav.Id, Bellek.SeciliSinav.Sinif);
            if (!DizinIslemleri.DosyaKontrol(kutukFilename))
            {
                MessageBox.Show("Kütük listesinde bilgi bulunamadı. Kütük listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            ogrencilerKutuk = json.GetListJsonFile<TestKutukInfo>(kutukFilename);

            if (ogrencilerKutuk.Count == 0)
            {
                MessageBox.Show("Kütük listesinde bilgi bulunamadı. Kütük listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }

        }
        private void MukerrerKayitKontrol(List<OgrenciCevapModel> ogrenciCevaplari, string raporUrl)
        {
            islemiDurdur = false; //değerlendirme tekrar çalıştırıldığında mükerrer kayıt kontrolunden önce true değerini false yapalım


            StreamWriter yaz = new StreamWriter(raporUrl);

            var mukerrer = ogrenciCevaplari.GroupBy(x => x.Id)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            int islemSayisi = mukerrer.Count;
            progressBar1.Maximum = islemSayisi;
            int a = 0;
            progressBar1.Value = 0;

            foreach (var item in mukerrer)
            {
                a++;
                progressBar1.Value = a;
                toolSslKalanSure.Text = $"Mükerrer kayıtlar yazdırılıyor. {a} / {islemSayisi}";

                islemiDurdur = true;
                yaz.WriteLine(item + " nolu OpaqId mükerrerdir.");
            }
            progressBar1.Value = 0;
            yaz.Close();
            yaz.Dispose();
            toolSslKalanSure.Text = "Tamamlandı";
        }
        private void GecenSureyiDurdur(string mesaj)
        {
            timer1.Enabled = false; //geçen süreyi durdur
            saat = 0;
            dakika = 0;
            saniye = 0;
            pbAna.Value = 0;
            progressBar1.Value = 0;
            toolSslKalanSure.Text = mesaj;
        }
        private void TextListesiniKutuktenKontrolEt(List<OgrenciCevapModel> ogrenciCevaplari, string raporUrl)
        {
            islemiDurdur = false; //daha önce true yapılmış olabilir.

            int islemSayisi = ogrenciCevaplari.Count;
            progressBar1.Maximum = islemSayisi;
            int a = 0;
            progressBar1.Value = 0;

            StreamWriter resultYaz = new StreamWriter(raporUrl);

            //Öğrenci cevaplarını text dosyasından alıp veritabanında kontrol aşama.
            foreach (var file in ogrenciCevaplari)
            {
                a++;
                progressBar1.Value = a;

                toolSslKalanSure.Text = $"Text kütük eşleştirmesi yapılıyor. {a} / {islemSayisi}";


                TestKutukInfo kutuk = ogrencilerKutuk.Find(x => x.Id == file.Id);

                if (kutuk == null)
                {
                    resultYaz.WriteLine(file.Id + " Kütükte bulunamadı. Değerlendirmeye devam etmek için bu kaydı düzeltiniz.");
                    //Kütükte yoksa dizie al.
                    islemiDurdur = true;
                }
                else
                {

                    file.IlceAdi = kutuk.IlceAdi;
                    file.KurumKodu = kutuk.KurumKodu;
                    file.KurumAdi = kutuk.KurumAdi;
                    file.Adi = kutuk.Adi;
                    file.Soyadi = kutuk.Soyadi;
                    file.Sinifi = kutuk.Sinifi;
                    file.Sube = kutuk.Sube;
                }

                Application.DoEvents();
            }

            resultYaz.Close();
            resultYaz.Dispose();
        }

        private List<OgrDogruYanlisSayilariModel> OkulNetOrtalamasi(int kurumKodu, int sinifi)
        {
            //doğru yanlış ve net sayılarını gösteren repeat
            List<OgrDogruYanlisSayilariModel> ogrDYList = new List<OgrDogruYanlisSayilariModel>();

            //birden fazla oturum olan sınavlarda opaq id mükerrer gelecektir.
            List<TestKutukInfo> ogrenciListesi = ogrencilerKutuk.Where(x => x.KurumKodu == kurumKodu).ToList();

            if (ogrenciListesi.Count > 0)
            {
                //   decimal netT = 0;
                foreach (var brans in branslarList)
                {
                    int dogru = 0;
                    int yanlis = 0;
                    int bos = 0;
                    var sorular = sorularList.Where(x => x.BransId == brans.Id);


                    foreach (var soru in sorular)
                    {
                        foreach (var ogrenci in ogrenciListesi)
                        {

                            var ogrCevap = testOgrCevaplar.FirstOrDefault(x => x.OturumId == soru.OturumId && x.OpaqId == ogrenci.Id);
                            if (ogrCevap != null)
                            {
                                try
                                {
                                    string cvp = ogrCevap.Cevap.Substring(soru.SoruNo - 1, 1);
                                    if (cvp != " ")
                                    {
                                        if (soru.Cevap == cvp)
                                        {
                                            dogru++;
                                        }
                                        else
                                        {
                                            yanlis++;
                                        }
                                    }
                                    else
                                    {
                                        bos++;
                                    }
                                }
                                catch (Exception)
                                {
                                    //
                                }
                            }
                        }

                    }
                    int dogruYanlisOrani = DegerlendirmeSinifi.DogruYanlisOrani(sinifi);

                    decimal net = (dogru - ((decimal)yanlis / dogruYanlisOrani)) / ogrenciListesi.Count();

                    ogrDYList.Add(new OgrDogruYanlisSayilariModel() { BransId = brans.Id, Dogru = dogru, Yanlis = yanlis, Bos = bos });

                    Application.DoEvents();
                }
            }

            return ogrDYList;

        }
        private void IlcePuanHesaplama(OgrenciCevapModel ilce)
        {
            var okullar = ayaGoreOgrenciCevaplari.Where(x => x.IlceAdi == ilce.IlceAdi);
            foreach (var okul in okullar)
            {
                var okulPuanOrtalamasi = okullar.Where(x => x.KurumKodu == okul.KurumKodu).Average(x => x.Puan);
                var ogrenciSayisi = okullar.Count(x => x.KurumKodu == okul.KurumKodu); //+1 bu öğrenci
                // toplamKatsayiPuani öğrenci sayısıyla çarpılmalı

                int toplamDogruSayisi = okul.DersCevaplari.Sum(x => x.Dogru);
                int toplamYanlisSayisi = okul.DersCevaplari.Sum(x => x.Yanlis);
                int toplamBosSayisi = okul.DersCevaplari.Sum(x => x.Bos);

                var okulKontrol = testIlcePuanList.Find(x => x.KurumKodu == okul.KurumKodu);
                if (okulKontrol == null)
                {
                    testIlcePuanList.Add(new TestIlcePuanInfo()
                    {
                        Bos = toplamBosSayisi,
                        Dogru = toplamDogruSayisi,
                        Yanlis = toplamYanlisSayisi,
                        KurumKodu = okul.KurumKodu,
                        SinavId = Bellek.SeciliSinav.Id,
                        IlceAdi = ilce.IlceAdi,
                        Puan = okulPuanOrtalamasi,
                        OgrSayisi = ogrenciSayisi
                    });
                }

                Application.DoEvents();
            }
        }

        private void PuanlamaHesapla(OgrenciCevapModel ogr)
        {

            int sinavId = Bellek.SeciliSinav.Id;

            int kurumKodu = ogr.KurumKodu;
            int sinifi = ogr.Sinifi;

            int dogruYanlisOrani = DegerlendirmeSinifi.DogruYanlisOrani(sinifi);

            //Oturumları listele ve bu öğrenci tüm oturumlara katılmış mı kontrol et
            int kalanOturumSayisi = 0; //girmediği oturumları kontrol için gerekli
            var res1 = testOgrCevaplar.Where(x => x.OpaqId == ogr.Id);

            foreach (TestOturumlarInfo o in oturumlar)
            {
                //var res = testOgrCevaplar.Count(x=>x.OpaqId==ogr.Id && x.OturumId == o.Id && (x.Dogru != 0 || x.Yanlis != 0));
                int res = res1.Count(x => x.OturumId == o.Id && (x.Dogru != 0 || x.Yanlis != 0));
                //sınavı tamamlanmış
                if (res == 0)
                {
                    kalanOturumSayisi++;//sınava girmediği oturumu var.
                }
            }

            if (kalanOturumSayisi == 0)
            {
                //doğru yanlış ve net sayılarını gösteren repeat

                List<OgrDogruYanlisSayilariModel> ogrDYList = new List<OgrDogruYanlisSayilariModel>();

                decimal toplamKatsayiPuani = DegerlendirmeSinifi.ToplamKatsayiPuani(branslarList, sorularList);


                foreach (var brans in branslarList)
                {
                    int dogru = 0;
                    int yanlis = 0;
                    int bos = 0;
                    var sorular = sorularList.Where(x => x.BransId == brans.Id);


                    foreach (var soru in sorular)
                    {
                        try
                        {
                            TestOgrCevapInfo ogrCevap = testOgrCevaplar.Find(x => x.OturumId == soru.OturumId && x.OpaqId == ogr.Id);
                            if (ogrCevap != null)
                            {
                                string cvp = ogrCevap.Cevap.Substring(soru.SoruNo - 1, 1);
                                if (cvp != " ")
                                {
                                    if (soru.Cevap == cvp)
                                    {
                                        dogru++;
                                    }
                                    else
                                    {
                                        yanlis++;
                                    }
                                }
                                else
                                {
                                    bos++;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //
                        }
                    }

                    if (dogru != 0 || yanlis != 0)
                    {
                        decimal net = (dogru - ((decimal)yanlis / dogruYanlisOrani));

                        ogrDYList.Add(new OgrDogruYanlisSayilariModel() { Dogru = dogru, Yanlis = yanlis, Bos = bos, KatSayi = brans.KatSayi });

                        var ayg = ayaGoreOgrenciCevaplari.Find(x => x.Id == ogr.Id);
                        var res = ayg.DersCevaplari.Find(x => x.DersId == brans.Id);
                        res.Dogru = dogru;
                        res.Yanlis = yanlis;
                        res.Bos = bos;
                        res.Net = net;
                    }

                    Application.DoEvents();
                }

                Application.DoEvents();


                int toplamDogruSayisi = ogrDYList.Sum(x => x.Dogru);
                int toplamYanlisSayisi = ogrDYList.Sum(x => x.Yanlis);
                int toplamBosSayisi = ogrDYList.Sum(x => x.Bos);
                decimal toplamBransPuan = 0;
                foreach (var odys in ogrDYList)
                {
                    decimal net = (odys.Dogru - ((decimal)odys.Yanlis / dogruYanlisOrani));
                    toplamBransPuan += net * odys.KatSayi;
                }
                //32696
                decimal toplamPuan = DegerlendirmeSinifi.PuanHesapla(sinifi, Bellek.SeciliSinav.Puanlama, toplamBransPuan, toplamKatsayiPuani);

                ogr.Puan = toplamPuan;
                ogr.Net = (toplamDogruSayisi - ((decimal)toplamYanlisSayisi / dogruYanlisOrani));

                testOgrPuanlar.Add(new TestOgrPuanInfo()
                {
                    Dogru = toplamDogruSayisi,
                    Yanlis = toplamYanlisSayisi,
                    Bos = toplamBosSayisi,
                    OpaqId = ogr.Id,
                    Puan = toplamPuan,
                    SinavId = sinavId,
                    KurumKodu = kurumKodu
                });

            }

        }
        private void ExcelDosyasinaAktar()
        {
            //excel baş

            string excelDosyaAdi = raporDizinAdresi + Bellek.SeciliSinav.SinavAdi + "_Rapor.xlsx";
            DizinIslemleri.DosyaSil(excelDosyaAdi);
            Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
            Workbook calismaKitabi = aplicacion.Workbooks.Add();

            ExcelOgrenciSayfasi("", calismaKitabi);

            ExcelOkulSayfasi("", calismaKitabi);

            ExcelIlceSayfasi("", calismaKitabi);


            calismaKitabi.SaveAs(excelDosyaAdi, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);


            // calismaKitabi.SaveAs(excelDosyaAdi, XlFileFormat.xlWorkbookNormal);
            calismaKitabi.Close(true);
            aplicacion.Quit();

            Process.Start(excelDosyaAdi);

        }
        private void ExcelOgrenciSayfasi(string ilceAdi, Workbook calismaKitabi)
        {
            anaBar++;
            pbAna.Value = anaBar;
            var ogrenciListesi = ilceAdi == ""
                ? ayaGoreOgrenciCevaplari
                : ayaGoreOgrenciCevaplari.Where(x => x.IlceAdi == ilceAdi);
            int z = 11;
            int kayma = 3;

            Worksheet calismaSayfasi = (Worksheet)calismaKitabi.Worksheets.Item[1];

            Range baslik = calismaSayfasi.Range[calismaSayfasi.Cells[1, 1], calismaSayfasi.Cells[1, 11]]; //hücreleri birleştir
            baslik.EntireRow.Font.Bold = true; //bold yap
            baslik.Font.Size = 12;
            baslik.Merge();
            baslik.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            baslik.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            baslik.RowHeight = 60;
            baslik.Cells.WrapText = true;

            calismaSayfasi.Cells[1, 1] = Bellek.SeciliSinav.SinavAdi;

            calismaSayfasi.Name = "OGRENCI";
            calismaSayfasi.Cells[2, 1] = "No";
            calismaSayfasi.Cells[2, 2] = "İlçe Adı";
            calismaSayfasi.Cells[2, 3] = "Kurum Kodu";
            calismaSayfasi.Cells[2, 4] = "Kurum Adı";
            calismaSayfasi.Cells[2, 5] = "Adı";
            calismaSayfasi.Cells[2, 6] = "Soyadı";
            calismaSayfasi.Cells[2, 7] = "Sınıfı";
            calismaSayfasi.Cells[2, 8] = "Şubesi";
            calismaSayfasi.Cells[2, 9] = "Yüzdelik Dilimi";
            calismaSayfasi.Cells[2, 10] = "Puan";
            calismaSayfasi.Cells[2, 11] = "Toplam Net";

            var ogrenciCevaplarList = ogrenciListesi.FirstOrDefault(x => x.Id != 0);

            foreach (var ogrCvp in ogrenciCevaplarList.DersCevaplari)
            {
                Range dersler = calismaSayfasi.Range[calismaSayfasi.Cells[1, z + 1], calismaSayfasi.Cells[1, z + 3]];
                dersler.EntireRow.Font.Bold = true; //bold yap
                dersler.Font.Size = 10;
                dersler.Merge();
                dersler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
                dersler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
                dersler.RowHeight = 60;
                dersler.Cells.WrapText = true; //Metni kaydır
                dersler.Borders.LineStyle = XlLineStyle.xlContinuous;

                calismaSayfasi.Cells[1, z + 1] = branslarList.Find(x => x.Id == ogrCvp.DersId).BransAdi;

                calismaSayfasi.Cells[2, z + 1] = "NET";
                calismaSayfasi.Cells[2, z + 2] = "D";
                calismaSayfasi.Cells[2, z + 3] = "Y";
                z += kayma;
            }

            Application.DoEvents();

            //başlık2 exceldeki ikinci satır net doğru yanlış bilgilerinin olduğu satır
            int satirGenisligi = 11;

            //öğrenci listesini puana göre yeniden sıralama yap.
            var ogrenciXls = ogrenciListesi.OrderByDescending(x => x.Puan).ToList();

            int ogrenciSayisi = ogrenciXls.Count;
            progressBar1.Maximum = ogrenciSayisi;

            for (var i = 0; i < ogrenciSayisi; i++)
            {
                progressBar1.Value = i;
                satirGenisligi = 11;
                decimal yuzdelikDilim = (i + 1) / ((decimal)ogrenciSayisi / 100);
                toolSslKalanSure.Text = $"{(ilceAdi != "" ? ilceAdi : "")} Öğrenci sonuçları excele işleniyor. {i + 1}/{ogrenciSayisi}";

                int opaqId = ogrenciXls[i].Id;
                var ogrenciBilgi = ogrencilerKutuk.Find(x => x.Id == opaqId);
                int dogruYanlisOrani = DegerlendirmeSinifi.DogruYanlisOrani(ogrenciBilgi.Sinifi);

                calismaSayfasi.Cells[3 + i, 1] = i + 1;
                calismaSayfasi.Cells[3 + i, 2] = ogrenciBilgi.IlceAdi;
                calismaSayfasi.Cells[3 + i, 3] = ogrenciBilgi.KurumKodu;
                calismaSayfasi.Cells[3 + i, 4] = ogrenciBilgi.KurumAdi;
                calismaSayfasi.Cells[3 + i, 5] = ogrenciBilgi.Adi;
                calismaSayfasi.Cells[3 + i, 6] = ogrenciBilgi.Soyadi;
                calismaSayfasi.Cells[3 + i, 7] = ogrenciBilgi.Sinifi;
                calismaSayfasi.Cells[3 + i, 8] = ogrenciBilgi.Sube;
                calismaSayfasi.Cells[3 + i, 9] = decimal.Round(yuzdelikDilim, 3, MidpointRounding.AwayFromZero);
                calismaSayfasi.Cells[3 + i, 10] = decimal.Round(ogrenciXls[i].Puan, 3, MidpointRounding.AwayFromZero);

                decimal toplamNet = 0;
                int xd = 0; //excelte bir derse ait net doğru yanlış diye üç alan olduğu için hücreler arasında dolaşmak için  ayrı bir değişken tanımladım
                foreach (var ogrCvp in ogrenciXls[i].DersCevaplari)
                {
                    decimal dogruSayisi = ogrCvp.Dogru.ToDecimal();
                    decimal yanlisSayisi = ogrCvp.Yanlis.ToDecimal();
                    decimal net = dogruSayisi - (yanlisSayisi / dogruYanlisOrani);
                    toplamNet += net;
                    calismaSayfasi.Cells[3 + i, xd + 12] = decimal.Round(net, 2, MidpointRounding.ToEven);

                    //Net alanını biçimlendir
                    Range netler = calismaSayfasi.Range[calismaSayfasi.Cells[3 + i], calismaSayfasi.Cells[xd + 12]];
                    netler.NumberFormat = "#,###,###.00";

                    calismaSayfasi.Cells[3 + i, xd + 13] = dogruSayisi;
                    calismaSayfasi.Cells[3 + i, xd + 14] = yanlisSayisi;
                    xd += 3;
                    satirGenisligi += 3;
                }
                calismaSayfasi.Cells[3 + i, 11] = decimal.Round(toplamNet, 2, MidpointRounding.AwayFromZero);
                Application.DoEvents();
            }

            Range baslik2 = calismaSayfasi.Range[calismaSayfasi.Cells[2, 1], calismaSayfasi.Cells[2, satirGenisligi]];
            baslik2.EntireRow.Font.Bold = true; //bold yap
            baslik2.Font.Size = 10;
            baslik2.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            baslik2.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            baslik2.Cells.WrapText = true; //Metni kaydır
            baslik2.Borders.LineStyle = XlLineStyle.xlContinuous;

            Range veriler = calismaSayfasi.Range[calismaSayfasi.Cells[3, 1], calismaSayfasi.Cells[ogrenciSayisi + 2, satirGenisligi]];
            veriler.Font.Size = 9;
            veriler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            veriler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            veriler.Borders.LineStyle = XlLineStyle.xlContinuous;


            Range toplamNetAlani = calismaSayfasi.Range[calismaSayfasi.Cells[3, 12], calismaSayfasi.Cells[ogrenciSayisi + 2, 12]];
            toplamNetAlani.NumberFormat = "#,###,###.00";

            Range yuzdelikPuanToplam = calismaSayfasi.Range[calismaSayfasi.Cells[3, 10], calismaSayfasi.Cells[ogrenciSayisi + 2, 11]];
            yuzdelikPuanToplam.NumberFormat = "#,###,###.000";

        }
        private void ExcelOkulSayfasi(string ilceAdi, Workbook calismaKitabi)
        {
            anaBar++;
            pbAna.Value = anaBar;
            var ogrenciListesi = ilceAdi == ""
                ? ayaGoreOgrenciCevaplari
                : ayaGoreOgrenciCevaplari.Where(x => x.IlceAdi == ilceAdi);
            int z = 8;
            int satirGenisligi = 8;

            Sheets xlSheets = calismaKitabi.Sheets;
            var calismaSayfasi = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);


            calismaSayfasi.Name = "OKUL";

            Range baslik = calismaSayfasi.Range[calismaSayfasi.Cells[1, 1], calismaSayfasi.Cells[1, 8]]; //hücreleri birleştir
            baslik.EntireRow.Font.Bold = true; //bold yap
            baslik.Font.Size = 12;
            baslik.Merge();
            baslik.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            baslik.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            baslik.RowHeight = 60;
            baslik.Cells.WrapText = true;


            calismaSayfasi.Cells[1, 1] = Bellek.SeciliSinav.SinavAdi + " Okul Sıralaması";

            calismaSayfasi.Cells[2, 1] = "NO";
            calismaSayfasi.Cells[2, 2] = "İLÇE";
            calismaSayfasi.Cells[2, 3] = "KURUM KODU";
            calismaSayfasi.Cells[2, 4] = "OKUL ADI";
            calismaSayfasi.Cells[2, 5] = "SINIF";
            calismaSayfasi.Cells[2, 6] = "ÖĞ. SAYISI";
            calismaSayfasi.Cells[2, 7] = "PUAN";
            calismaSayfasi.Cells[2, 8] = "TOPLAM NET";


            var ogrenciCevaplarList = ogrenciListesi.FirstOrDefault(x => x.Id != 0);
            int dogruYanlisOrani = DegerlendirmeSinifi.DogruYanlisOrani(ogrenciCevaplarList.Sinifi);
            foreach (var ogrCvp in ogrenciCevaplarList.DersCevaplari)
            {
                Range dersler = calismaSayfasi.Range[calismaSayfasi.Cells[1, z + 1], calismaSayfasi.Cells[1, z + 1]];
                dersler.EntireRow.Font.Bold = true; //bold yap
                dersler.Font.Size = 10;
                dersler.Merge();
                dersler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
                dersler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
                dersler.RowHeight = 60;
                dersler.ColumnWidth = 11;
                dersler.Cells.WrapText = true; //Metni kaydır
                dersler.Borders.LineStyle = XlLineStyle.xlContinuous;

                calismaSayfasi.Cells[1, z + 1] = branslarList.FirstOrDefault(x => x.Id == ogrCvp.DersId.ToInt32()).BransAdi;

                calismaSayfasi.Cells[2, z + 1] = "NET";

                z += 1;
                satirGenisligi += 1;
            }
            Application.DoEvents();

            var okullar = ogrenciListesi.GroupBy(x => x.KurumKodu).Select(x => x.First()).ToList();
            for (var i = 0; i < okullar.Count; i++)
            {
                int kurumKodu = okullar[i].KurumKodu;
                var okulBilgiList = ogrenciListesi.Where(x => x.KurumKodu == kurumKodu);
                toolSslKalanSure.Text = $"{(ilceAdi != "" ? ilceAdi : "")} Okul sonuçları excele işleniyor {i + 1}/{okullar.Count}";
                calismaSayfasi.Cells[3 + i, 1] = i + 1;
                calismaSayfasi.Cells[3 + i, 2] = okullar[i].IlceAdi;
                calismaSayfasi.Cells[3 + i, 3] = kurumKodu;
                calismaSayfasi.Cells[3 + i, 4] = okullar[i].KurumAdi;
                calismaSayfasi.Cells[3 + i, 5] = okullar[i].Sinifi;
                calismaSayfasi.Cells[3 + i, 6] = okulBilgiList.Count();
                calismaSayfasi.Cells[3 + i, 7] = decimal.Round(okulBilgiList.Average(x => x.Puan), 3, MidpointRounding.AwayFromZero);
                calismaSayfasi.Cells[3 + i, 8] = decimal.Round(okulBilgiList.Average(x => x.Net), 2, MidpointRounding.AwayFromZero);

                int xd = 0;
                foreach (var ders in ogrenciCevaplarList.DersCevaplari)
                {

                    decimal dogruSayisi = 0;
                    decimal yanlisSayisi = 0;
                    foreach (var okul in okulBilgiList)
                    {
                        dogruSayisi += okul.DersCevaplari.Where(x => x.DersId == ders.DersId).Sum(x => x.Dogru);
                        yanlisSayisi += okul.DersCevaplari.Where(x => x.DersId == ders.DersId).Sum(x => x.Yanlis);

                    }
                    decimal netSayisi = (dogruSayisi - (yanlisSayisi / dogruYanlisOrani)) / okulBilgiList.Count();

                    calismaSayfasi.Cells[3 + i, xd + 9] = decimal.Round(netSayisi, 2, MidpointRounding.AwayFromZero);

                    xd += 1;
                }

                Application.DoEvents();
            }

            int okulSayisi = okullar.Count + 2;

            Range baslik2 = calismaSayfasi.Range[calismaSayfasi.Cells[2, 1], calismaSayfasi.Cells[2, satirGenisligi]];
            baslik2.EntireRow.Font.Bold = true; //bold yap
            baslik2.Font.Size = 10;
            baslik2.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            baslik2.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            baslik2.Cells.WrapText = true; //Metni kaydır
            baslik2.Borders.LineStyle = XlLineStyle.xlContinuous;

            Range veriler = calismaSayfasi.Range[calismaSayfasi.Cells[3, 1], calismaSayfasi.Cells[okulSayisi, satirGenisligi]];
            veriler.Font.Size = 9;
            veriler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            veriler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            veriler.Borders.LineStyle = XlLineStyle.xlContinuous;

        }
        private void ExcelIlceSayfasi(string ilceAdi, Workbook calismaKitabi)
        {
            anaBar++;
            pbAna.Value = anaBar;
            var ogrenciListesi = ilceAdi == ""
                ? ayaGoreOgrenciCevaplari
                : ayaGoreOgrenciCevaplari.Where(x => x.IlceAdi == ilceAdi);
            int z = 6;
            int satirGenisligi = 6;

            Sheets xlSheets = calismaKitabi.Sheets;
            var calismaSayfasi = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);


            calismaSayfasi.Name = "ILCE";

            Range baslik = calismaSayfasi.Range[calismaSayfasi.Cells[1, 1], calismaSayfasi.Cells[1, satirGenisligi]]; //hücreleri birleştir
            baslik.EntireRow.Font.Bold = true; //bold yap
            baslik.Font.Size = 12;
            baslik.Merge();
            baslik.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            baslik.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi ortala
            baslik.RowHeight = 60;
            baslik.Cells.WrapText = true;


            calismaSayfasi.Cells[1, 1] = Bellek.SeciliSinav.SinavAdi + " İlçe Sıralaması";

            calismaSayfasi.Cells[2, 1] = "NO";
            calismaSayfasi.Cells[2, 2] = "İLÇE";
            calismaSayfasi.Cells[2, 3] = "SINIF";
            calismaSayfasi.Cells[2, 4] = "ÖĞ. SAYISI";
            calismaSayfasi.Cells[2, 5] = "PUAN";
            calismaSayfasi.Cells[2, 6] = "TOPLAM NET";


            var ogrenciCevaplarList = ogrenciListesi.FirstOrDefault(x => x.Id != 0);
            int dogruYanlisOrani = DegerlendirmeSinifi.DogruYanlisOrani(ogrenciCevaplarList.Sinifi);
            foreach (var ogrCvp in ogrenciCevaplarList.DersCevaplari)
            {
                Range dersler = calismaSayfasi.Range[calismaSayfasi.Cells[1, z + 1], calismaSayfasi.Cells[1, z + 1]];
                dersler.EntireRow.Font.Bold = true; //bold yap
                dersler.Font.Size = 10;
                dersler.Merge();
                dersler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
                dersler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
                dersler.RowHeight = 60;
                dersler.ColumnWidth = 11;
                dersler.Cells.WrapText = true; //Metni kaydır
                dersler.Borders.LineStyle = XlLineStyle.xlContinuous;

                calismaSayfasi.Cells[1, z + 1] = branslarList.FirstOrDefault(x => x.Id == ogrCvp.DersId.ToInt32()).BransAdi;

                calismaSayfasi.Cells[2, z + 1] = "NET";

                z += 1;
                satirGenisligi += 1;
            }
            Application.DoEvents();

            var ilceler = ogrenciListesi.GroupBy(x => x.IlceAdi).Select(x => x.First()).ToList();
            for (var i = 0; i < ilceler.Count; i++)
            {
                var ilceBilgiList = ogrenciListesi.Where(x => x.IlceAdi == ilceler[i].IlceAdi);
                toolSslKalanSure.Text = $"{(ilceAdi != "" ? ilceAdi : "")} İlçe sonuçları excele işleniyor {i + 1}/{ilceler.Count}";
                calismaSayfasi.Cells[3 + i, 1] = i + 1;
                calismaSayfasi.Cells[3 + i, 2] = ilceler[i].IlceAdi;
                calismaSayfasi.Cells[3 + i, 3] = ilceler[i].Sinifi;
                calismaSayfasi.Cells[3 + i, 4] = ilceBilgiList.Count();
                calismaSayfasi.Cells[3 + i, 5] = decimal.Round(ilceBilgiList.Average(x => x.Puan), 3, MidpointRounding.AwayFromZero);
                calismaSayfasi.Cells[3 + i, 6] = decimal.Round(ilceBilgiList.Average(x => x.Net), 2, MidpointRounding.AwayFromZero);

                int xd = 0;
                foreach (var ders in ogrenciCevaplarList.DersCevaplari)
                {

                    decimal dogruSayisi = 0;
                    decimal yanlisSayisi = 0;
                    foreach (var okul in ilceBilgiList)
                    {
                        dogruSayisi += okul.DersCevaplari.Where(x => x.DersId == ders.DersId).Sum(x => x.Dogru);
                        yanlisSayisi += okul.DersCevaplari.Where(x => x.DersId == ders.DersId).Sum(x => x.Yanlis);

                    }
                    decimal netSayisi = (dogruSayisi - (yanlisSayisi / dogruYanlisOrani)) / ilceBilgiList.Count();

                    calismaSayfasi.Cells[3 + i, xd + 7] = decimal.Round(netSayisi, 2, MidpointRounding.AwayFromZero);

                    xd += 1;
                }

                Application.DoEvents();
            }

            int ilceSayisi = ilceler.Count + 2;

            //il puan hesaplama

            calismaSayfasi.Cells[ilceSayisi + 1, 1] = "";
            calismaSayfasi.Cells[ilceSayisi + 1, 2] = "Erzurum";
            calismaSayfasi.Cells[ilceSayisi + 1, 3] = Bellek.SeciliSinav.Sinif;
            calismaSayfasi.Cells[ilceSayisi + 1, 4] = ayaGoreOgrenciCevaplari.Count;
            calismaSayfasi.Cells[ilceSayisi + 1, 5] = decimal.Round(ayaGoreOgrenciCevaplari.Average(x => x.Puan), 3, MidpointRounding.AwayFromZero);
            calismaSayfasi.Cells[ilceSayisi + 1, 6] = decimal.Round(ayaGoreOgrenciCevaplari.Average(x => x.Net), 2, MidpointRounding.AwayFromZero);

            int il = 0;
            foreach (var ders in ayaGoreOgrenciCevaplari.First().DersCevaplari)
            {
                decimal dogruSayisi = 0;
                decimal yanlisSayisi = 0;
                foreach (var okul in ayaGoreOgrenciCevaplari)
                {
                    dogruSayisi += okul.DersCevaplari.Where(x => x.DersId == ders.DersId).Sum(x => x.Dogru);
                    yanlisSayisi += okul.DersCevaplari.Where(x => x.DersId == ders.DersId).Sum(x => x.Yanlis);

                }
                decimal netSayisi = (dogruSayisi - (yanlisSayisi / dogruYanlisOrani)) / ayaGoreOgrenciCevaplari.Count();

                calismaSayfasi.Cells[ilceSayisi + 1, il + 7] = decimal.Round(netSayisi, 2, MidpointRounding.AwayFromZero);

                il++;//net doğru yanlış
            }

            Application.DoEvents();


            Range baslik2 = calismaSayfasi.Range[calismaSayfasi.Cells[2, 1], calismaSayfasi.Cells[2, satirGenisligi]];
            baslik2.EntireRow.Font.Bold = true; //bold yap
            baslik2.Font.Size = 10;
            baslik2.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            baslik2.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            baslik2.Cells.WrapText = true; //Metni kaydır
            baslik2.Borders.LineStyle = XlLineStyle.xlContinuous;

            Range veriler = calismaSayfasi.Range[calismaSayfasi.Cells[3, 1], calismaSayfasi.Cells[ilceSayisi + 1, satirGenisligi]];
            veriler.Font.Size = 9;
            veriler.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; //hücreyi yatay ortala
            veriler.Style.VerticalAlignment = XlHAlign.xlHAlignCenter; //hücreyi dikey ortala
            veriler.Borders.LineStyle = XlLineStyle.xlContinuous;

        }

        private void IlceIlceExcelDosyasinaAktar()
        {
            if (!DizinIslemleri.DizinKontrol(raporDizinAdresi + "Ilce"))
                DizinIslemleri.DizinOlustur(raporDizinAdresi + "Ilce");
            DizinIslemleri.DizinIceriginiSil(raporDizinAdresi + "Ilce");

            var ilceler = ayaGoreOgrenciCevaplari.GroupBy(x => x.IlceAdi).Select(x => x.First()).ToList();
            foreach (var ilceXl in ilceler)
            {
                string excelDosyaAdi = raporDizinAdresi + "Ilce\\" + ilceXl.IlceAdi + ".xlsx";

                Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
                Workbook calismaKitabi = aplicacion.Workbooks.Add();


                ExcelOgrenciSayfasi(ilceXl.IlceAdi, calismaKitabi);

                ExcelOkulSayfasi(ilceXl.IlceAdi, calismaKitabi);

                ExcelIlceSayfasi(ilceXl.IlceAdi, calismaKitabi);

                calismaKitabi.SaveAs(excelDosyaAdi, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                calismaKitabi.Close(true);
                aplicacion.Quit();
            }
        }

        private void btnDogruCevaplar_Click(object sender, EventArgs e)
        {
            string dersBazliCevaplariFileNameGet = Bellek.DersBazliCevaplariFileNameGet(Bellek.SeciliSinav.Id);
            if (!DizinIslemleri.DosyaKontrol(dersBazliCevaplariFileNameGet))
            {
                MessageBox.Show("Daha önce bir değerlendirme yapılmamış önce değerlendirme işlemini tamamlayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            JsonOperations json = new JsonOperations();
            ayaGoreOgrenciCevaplari = json.GetListJsonFile<OgrenciCevapModel>(dersBazliCevaplariFileNameGet);
            if (ayaGoreOgrenciCevaplari.Count == 0)
            {
                MessageBox.Show("Daha önce bir değerlendirme yapılmamış önce değerlendirme işlemini tamamlayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }


            //Mükerrer kayıtlar kütükte olmayan öğrenciler gibi kayıtların tutulacağı dizini seçtiren işlemler
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = true; //yeni klasör oluşturmayı kapat
                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                folderDialog.Description = @"Rapor dosyalarının saklanacağı dizini seçiniz.";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    raporDizinAdresi = folderDialog.SelectedPath + "\\";
                    timer1.Enabled = true; //sayaç başlasın

                    //Birinci aşamada cevapları alıp cevapların kontrolünü yaparak kütüğe kaydeder.
                    bgwDegerlendirmeIlce.RunWorkerAsync();
                }
                folderDialog.Dispose();
            }


        }

        private void bgwDegerlendirmeIlce_DoWork(object sender, DoWorkEventArgs e)
        {

            pbAna.Maximum = 20;
            anaBar = 0;
            pbAna.Value = anaBar;
            ExcelDosyasinaAktar();
            if (cbExcelIlce.Checked)
            {
                var ilceSayisi = ayaGoreOgrenciCevaplari.GroupBy(x => x.IlceAdi).Select(x => x.First()).Count();
                pbAna.Maximum = pbAna.Maximum + (ilceSayisi * 3);
                anaBar++;
                pbAna.Value = anaBar;
                IlceIlceExcelDosyasinaAktar();
            }
            else
            {
                anaBar = anaBar + 3;
                pbAna.Value = anaBar;
            }
            GecenSureyiDurdur("Tamamlandı " + anaBar);
        }
    }
}

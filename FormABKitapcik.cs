using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ODMSinavYazilimi
{
    public partial class FormABKitapcik : Form
    {
        private List<TestKutukInfo> ogrencilerKutuk = new List<TestKutukInfo>();
        private List<TestBransInfo> branslarList = new List<TestBransInfo>();
        private List<TestSorularInfo> sorularList = new List<TestSorularInfo>();
        private AktifDonemSinavlar donemveSinavlar = new AktifDonemSinavlar();
        private List<TestOturumlarInfo> oturumlar = new List<TestOturumlarInfo>();
        public FormABKitapcik()
        {
            InitializeComponent();
        }
        private void FormABKitapcik_Load(object sender, EventArgs e)
        {
            lblId.Text = Bellek.SeciliSinav.Id.ToString();
            lblSinavAdi.Text = Bellek.SeciliSinav.SinavAdi;
            lblSinif.Text = Bellek.SeciliSinav.Sinif.ToString();
            //background nesnesi sağlıklı çalışması için gerekli. 
            CheckForIllegalCrossThreadCalls = false;


            JsonVerileriniGetir();

            if (oturumlar.Count == 0)
            {
                MessageBox.Show("Oturum bilgisi bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }



            List<TestBransInfo> branslar = new List<TestBransInfo>();
            foreach (var oturum in oturumlar.OrderBy(x => x.SiraNo))
            {
                var oturumDersleri = sorularList.Where(x => x.OturumId == oturum.Id).ToList()
                    .GroupBy(x => x.BransId)
                    .Select(x => x.First()).OrderBy(x => x.SoruNo).ToList();
                foreach (var brans in oturumDersleri)
                {
                    var bransGet = branslarList.FirstOrDefault(x => x.Id == brans.BransId);
                    branslar.Add(bransGet);
                }

            }

            dgBranslar.DataSource = branslar.OrderBy(x => x.Id).ToList();

            dgBranslar.Columns[0].HeaderText = "Ders Kodu";
            dgBranslar.Columns[0].Width = 50;
            dgBranslar.Columns[1].Visible = false;//branş katsayı
            dgBranslar.Columns[2].HeaderText = "Ders Adı";
            dgBranslar.Columns[2].Width = 215;

            string dersAdi = dgBranslar.CurrentRow?.Cells[2].Value.ToString() ?? "";
            lblDersAdi.Text = "Seçili Ders : " + dersAdi;
            int ekliSoruSayisi = 0;
            string abKitapcikSorularFileNamelGet = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);
            if (DizinIslemleri.DosyaKontrol(abKitapcikSorularFileNamelGet))
            {
                int bransId = dgBranslar.CurrentRow?.Cells[0].Value.ToInt32() ?? 0;
          
                JsonOperations json = new JsonOperations();
                List<SoruSiralari> sorusiralariGelen = json.GetListJsonFile<SoruSiralari>(abKitapcikSorularFileNamelGet);
                ekliSoruSayisi = sorusiralariGelen.Count;

                DersSorulariniListele(sorusiralariGelen,bransId);
            }
            lblSoruSayisi.Text = "Soru Sayısı : "+ ekliSoruSayisi+"/" + sorularList.Count;
        }
        private void dgBranslar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblDersAdi.Text = "Seçili Ders : " + dgBranslar[2, e.RowIndex].Value;

            string abKitapcikSorularFileNameGet = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);
            if (DizinIslemleri.DosyaKontrol(abKitapcikSorularFileNameGet))
            {
                int bransId = dgBranslar[0, e.RowIndex].Value.ToInt32();
                JsonOperations json = new JsonOperations();
                List<SoruSiralari> sorusiralariGelen = json.GetListJsonFile<SoruSiralari>(abKitapcikSorularFileNameGet);
                DersSorulariniListele(sorusiralariGelen, bransId);
            }
        }
       
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string dersAdi = dgBranslar.CurrentRow?.Cells[2].Value.ToString() ?? "";
            int bransId = dgBranslar.CurrentRow?.Cells[0].Value.ToInt32() ?? 0;
            if (bransId == 0)
            {
                MessageBox.Show("Ders seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soruSayisi = sorularList.Count(x => x.BransId == bransId);
            int textRow = textBox1.Lines.Length;
            if (textRow==0)
            {
                MessageBox.Show("Her satıra bir soru olacak şekilde A ve B kitapçığındaki soru numaralarını A1,B5 formatında giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soruSayisi != textRow)
            {
                MessageBox.Show("Girilen soru sayısı (" + textRow + " satır) ile sınavdaki soru sayısı  (" + soruSayisi + " soru) aynı değil. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //ilk dizi. Burada soruların kontrolü yapılıyor. Eksik veya mükerrer soru var mı.
            //İkinci soruSiralari dizisın de ise sorular yeniden diziye alınarak gerçek soru numaraları girilecek 
            List<SoruSiralari> soruSiralari = new List<SoruSiralari>();
            foreach (var s in textBox1.Lines)
            {
               string line = s.Replace(".", ",");

                var str = line.Split(',');
                int aSoruNo = 0;
                int bSoruNo = 0;
                if (str[0].Substring(0, 1) == "A")
                    aSoruNo = str[0].Replace(str[0].Substring(0, 1), "").ToInt32();
                if (str[0].Substring(0, 1) == "B")
                    bSoruNo = str[0].Replace(str[0].Substring(0, 1), "").ToInt32();
                if (str[1].Substring(0, 1) == "A")
                    aSoruNo = str[1].Replace(str[1].Substring(0, 1), "").ToInt32();
                if (str[1].Substring(0, 1) == "B")
                    bSoruNo = str[1].Replace(str[1].Substring(0, 1), "").ToInt32();

                soruSiralari.Add(new SoruSiralari
                {
                    BransId = bransId,
                    ASoruNo = aSoruNo,
                    BSoruNo = bSoruNo,
                    DersAdi = dersAdi
                });
            }

            #region MÜKERRER SORULARI TESPİT

            var mukerrerA = (from x in soruSiralari
                             group new { x.ASoruNo }
                                 by new { x.ASoruNo }
                into g
                             where g.Count() > 1
                             select new { g.Key }).ToList();

            if (mukerrerA.Count > 0)
            {
                foreach (var m in mukerrerA)
                {
                    MessageBox.Show("A Kitapçığı " + m.Key.ASoruNo + ". soru mükerrer.", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                return;
            }

            var mukerrerB = (from x in soruSiralari
                             group new { x.BSoruNo }
                                 by new { x.BSoruNo }
                into g
                             where g.Count() > 1
                             select new { g.Key }).ToList();

            if (mukerrerB.Count > 0)
            {
                foreach (var m in mukerrerB)
                {
                    MessageBox.Show("B Kitapçığı " + m.Key.BSoruNo + ". soru mükerrer.", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                return;
            }


            #endregion

            #region EKSİK SORULARI TESPİT

            for (int i = 1; i <= soruSayisi; i++)
            {
                var kontrolA = soruSiralari.FirstOrDefault(x => x.ASoruNo == i);
                if (kontrolA == null)
                {
                    MessageBox.Show("A Kitapçığı " + i + ". soru bulunamadı.", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                var kontrolB = soruSiralari.FirstOrDefault(x => x.BSoruNo == i);
                if (kontrolB == null)
                {
                    MessageBox.Show("B Kitapçığı " + i + ". soru bulunamadı.", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            #endregion

            #region SORU SIRALARINI YENİDEN OLUŞTURMA
            //Kitapçıklarda soru numaraları her ders için 1 den başlar ancak bizim yazılımda dersler sırasına göre sorular artarak devam eder.
            //öreneğin lgs de Türkçe ilk sorusu 1. soru iken inkılap tarihinde 21, din kültüründe 31 ingilizce 41 dir.

            soruSiralari.Clear();

            
            var oturumNo = sorularList.FirstOrDefault(x => x.BransId == bransId).OturumId;
            var ilksoruNo = sorularList.OrderBy(x=>x.SoruNo).FirstOrDefault(x => x.BransId == bransId).SoruNo;
            foreach (var s in textBox1.Lines)
            {
                string line = s.Replace(".", ",");

                var str = line.Split(',');
                int aSoruNo = 0;
                int bSoruNo = 0;
                if (str[0].Substring(0, 1) == "A")
                    aSoruNo = str[0].Replace(str[0].Substring(0, 1), "").ToInt32();
                if (str[0].Substring(0, 1) == "B")
                    bSoruNo = str[0].Replace(str[0].Substring(0, 1), "").ToInt32();
                if (str[1].Substring(0, 1) == "A")
                    aSoruNo = str[1].Replace(str[1].Substring(0, 1), "").ToInt32();
                if (str[1].Substring(0, 1) == "B")
                    bSoruNo = str[1].Replace(str[1].Substring(0, 1), "").ToInt32();

                soruSiralari.Add(new SoruSiralari
                {
                    BransId = bransId,
                    ASoruNo = aSoruNo + (ilksoruNo - 1),
                    BSoruNo = bSoruNo + (ilksoruNo - 1),
                    DersAdi = dersAdi,
                    OturumNo = oturumNo
                });
            }

            #endregion

            #region JSON KAYIT İŞLEMİ

            string abKitapcikSorularFileName = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);
            if (!DizinIslemleri.DosyaKontrol(abKitapcikSorularFileName))
            {
                //dosya yoksa ilk defa oluşturulacak.
                DizinIslemleri.JsonDosyaOlustur(abKitapcikSorularFileName, soruSiralari);
            }
            else
            {
                //varsa yenisi ile değiştirilecek
                JsonOperations json = new JsonOperations();
                List<SoruSiralari> sorusiralariGelen = json.GetListJsonFile<SoruSiralari>(abKitapcikSorularFileName);
                if (sorusiralariGelen.Count > 0)
                {
                    //seçili branş daha önce eklenmiş mi?
                    var bransControl = sorusiralariGelen.Count(x => x.BransId == bransId);
                    if (bransControl > 0)
                    {
                        MessageBox.Show("Bu ders için veriler daha önce eklenmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        DersSorulariniListele(sorusiralariGelen, bransId);

                        return;
                    }

                    sorusiralariGelen.AddRange(soruSiralari);

                }
                DizinIslemleri.JsonDosyaOlustur(abKitapcikSorularFileName, sorusiralariGelen);

                lblSoruSayisi.Text = "Soru Sayısı : " + sorusiralariGelen.Count + "/" + sorularList.Count;
            }

            #endregion

            DersSorulariniListele(soruSiralari, bransId);


            textBox1.Text = "";
            MessageBox.Show("Kayıtlar eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnDersiSil_Click(object sender, EventArgs e)
        {
            string dersAdi = dgBranslar.CurrentRow?.Cells[2].Value.ToString() ?? "";
            int bransId = dgBranslar.CurrentRow?.Cells[0].Value.ToInt32() ?? 0;
            DialogResult dialog = MessageBox.Show(dersAdi + " dersi A - B Kitapçık numaralarını silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                string abKitapcikSorularFileName = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);

                JsonOperations json = new JsonOperations();
                List<SoruSiralari> sorusiralariGelen = json.GetListJsonFile<SoruSiralari>(abKitapcikSorularFileName);
                if (sorusiralariGelen.Count > 0)
                {
                    //seçili branş daha önce eklenmiş mi?
                    var bransControl = sorusiralariGelen.Count(x => x.BransId == bransId);
                    if (bransControl == 0)
                    {
                        MessageBox.Show("Bu ders için zaten veri bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    List<SoruSiralari> sorusiralariYeni = new List<SoruSiralari>();
                    foreach (var sira in sorusiralariGelen.Where(x => x.BransId != bransId))
                    {
                        sorusiralariYeni.Add(sira);
                    }
                    DizinIslemleri.JsonDosyaOlustur(abKitapcikSorularFileName, sorusiralariYeni);

                    DersSorulariniListele(new List<SoruSiralari>(), 0);


                    lblSoruSayisi.Text = "Soru Sayısı : " + sorusiralariYeni.Count + "/" + sorularList.Count;
                    MessageBox.Show(dersAdi + " dersi A - B Kitapçık numaraları silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Bu ders için zaten veri bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnTumunuSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Tüm derslerin A - B Kitapçık numaralarını silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                string abKitapcikSorularFileName = Bellek.ABKitapcikSorularFileNameGet(Bellek.SeciliSinav.Id);

                if (DizinIslemleri.DosyaKontrol(abKitapcikSorularFileName))
                {
                    DizinIslemleri.DosyaSil(abKitapcikSorularFileName);
                    DersSorulariniListele(new List<SoruSiralari>(), 0);

                    lblSoruSayisi.Text = "Soru Sayısı : " + 0 + "/" + sorularList.Count;

                    MessageBox.Show("Tüm derslerin A - B Kitapçık numaraları silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DersSorulariniListele(List<SoruSiralari> sorusiralariGelen, int bransId)
        {
            dgvSoruKarsilastirma.DataSource = sorusiralariGelen.Where(x => x.BransId == bransId).ToList();

            dgvSoruKarsilastirma.Columns[0].HeaderText = "Ders Adı";
            dgvSoruKarsilastirma.Columns[0].Width = 180;
            dgvSoruKarsilastirma.Columns[1].Visible = false; //oturum
            dgvSoruKarsilastirma.Columns[2].Visible = false; //branş id
            dgvSoruKarsilastirma.Columns[3].HeaderText = "A - Soru No";
            dgvSoruKarsilastirma.Columns[3].Width = 140;
            dgvSoruKarsilastirma.Columns[4].HeaderText = "B - Soru No";
            dgvSoruKarsilastirma.Columns[4].Width = 140;
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

            branslarList = json.GetListJsonFile<TestBransInfo>(Bellek.BranslarFilename);
            if (branslarList.Count == 0)
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

        
    }
}

using Newtonsoft.Json;
using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ODMSinavYazilimi
{
    public partial class FormAna : Form
    {

        public FormAna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AktifDonemveSinavListesiniGetir();
        }

        public void EkranaYaz(AktifDonemSinavlar val)
        {
            lblId.Text = val.DonemInfo.Id.ToString();
            lblDonemAdi.Text = val.DonemInfo.Donem;
            lblVeriGirisi.Text = val.DonemInfo.VeriGirisi == 0 ? "Kapalı" : "Açık";
            Bellek.DonemId = val.DonemInfo.Id;
            List<TestSinavlarInfo> snv = new List<TestSinavlarInfo>
            {
                new TestSinavlarInfo(0, "Sınav Seçiniz")
            };
            foreach (var s in val.Sinavlar)
            {
                snv.Add(new TestSinavlarInfo(s.Id, s.SinavAdi));
            }

            cbSinavlar.DataSource = snv;

            cbSinavlar.ValueMember = "Id";
            cbSinavlar.DisplayMember = "SinavAdi";
            cbSinavlar.Refresh();
        }


        private void AktifDonemveSinavListesiniGetir()
        {
            try
            {
                JsonOperations json = new JsonOperations();

                //Dizin yoksa dizin oluştur
                if (!DizinIslemleri.DizinKontrol(Bellek.Dizin))
                {
                    DizinIslemleri.DizinOlustur(Bellek.Dizin);

                    MessageBox.Show("Aktif dönem dosyası bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    //Dizin varsa dosya indirilmiş mi kontrol et.
                    if (!DizinIslemleri.DosyaKontrol(Bellek.AktifDonemveSinavlarFilename))
                    {
                        //json dosyası yoksa listeyi getir ve json dosyasına kaydet.
                        MessageBox.Show("Aktif dönem dosyası bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //json dosyası varsa göster.
                        AktifDonemSinavlar val = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);

                        if (val.DonemInfo == null)
                        {
                            MessageBox.Show("Aktif dönem bilgisi bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            EkranaYaz(val);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata:" + exception.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void cbSinavlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sinavId = cbSinavlar.SelectedValue.ToInt32();

            string json2 = System.IO.File.ReadAllText(Bellek.AktifDonemveSinavlarFilename);
            AktifDonemSinavlar list = JsonConvert.DeserializeObject<AktifDonemSinavlar>(json2);
            var sinav = list.Sinavlar.FirstOrDefault(x => x.Id == sinavId);
            Bellek.SeciliSinav = sinav ?? null;

            btnCkOlustur.Enabled = sinavId != 0;
            btnDegerlenirmeKarne.Enabled = sinavId != 0;
            btnKutuk.Enabled = sinavId != 0;
            btnSorular.Enabled = sinavId != 0;
        }
        private void btnKutuk_Click(object sender, EventArgs e)
        {
            if (Bellek.SeciliSinav.Id == 0)
            {
                MessageBox.Show("Sınav seçiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormKutukIslemleri frm = new FormKutukIslemleri();
            frm.ShowDialog();

        }
        private void btnCkOlustur_Click(object sender, EventArgs e)
        {
            int sinavId = cbSinavlar.SelectedValue.ToInt32();
            if (sinavId == 0)
            {
                MessageBox.Show("Sınav seçiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormPdfCkOlustur frm = new FormPdfCkOlustur();
            frm.ShowDialog();
        }
        private void btnTextOlustur_Click(object sender, EventArgs e)
        {
            FormTxtOlustur frm = new FormTxtOlustur();
            frm.ShowDialog();
        }

        private void btnDegerlenirmeKarne_Click(object sender, EventArgs e)
        {
            int sinavId = cbSinavlar.SelectedValue.ToInt32();
            if (sinavId == 0)
            {
                MessageBox.Show("Sınav seçiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormDegerlendirme frm = new FormDegerlendirme();
            frm.ShowDialog();
        }

        private void lnkLblDonemveSinavBilgileri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JsonOperations json = new JsonOperations();
            AktifDonemSinavlar val = json.GetJsonUrl<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarUrl);

            if (val == null)
            {
                MessageBox.Show("Bilgi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //manuel sınavlar varsa belleğe al ve gelen aktif dönemler verisine ekle.
                AktifDonemSinavlar mevcutSinavlar = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);

                if (mevcutSinavlar.DonemInfo!=null)
                {
                    foreach (var snv in mevcutSinavlar.Sinavlar.Where(x=>x.Manuel==1))
                    {
                        val.Sinavlar.Add(snv);
                        foreach (var otrm in mevcutSinavlar.Oturumlar.Where(x=>x.SinavId==snv.Id))
                        {
                            val.Oturumlar.Add(otrm);
                        }
                    }
                }

                json.JsonSaveFile(val, Bellek.AktifDonemveSinavlarFilename);

                EkranaYaz(val);
                MessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkLblDersler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JsonOperations json = new JsonOperations();
            List<TestBransInfo> val = json.GetListJsonUrl<TestBransInfo>(Bellek.BranslarUrl);

            if (val == null)
            {
                MessageBox.Show("Bilgi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                json.JsonSaveFile(val, Bellek.BranslarFilename);

                MessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkLblKutuk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JsonOperations json = new JsonOperations();
            AktifDonemSinavlar val = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);
            if (val == null)
            {
                MessageBox.Show("Dönem bilgisi bulunamadı. Önce dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Bellek.SeciliSinav == null)
                {
                    MessageBox.Show("Önce sınav seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string kutukUrl = Bellek.KutukUrlGet(val.DonemInfo.Id, Bellek.SeciliSinav.Sinif);
                List<TestKutukInfo> kutuk = json.GetListJsonUrl<TestKutukInfo>(kutukUrl);
                if (kutuk.Count == 0)
                {
                    MessageBox.Show(Bellek.SeciliSinav.SinavAdi + " için kütük listesi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    json.JsonSaveFile(kutuk, Bellek.KutukFileNameGet(Bellek.SeciliSinav.Id, Bellek.SeciliSinav.Sinif));
                }

                MessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void lnbLblSorular_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JsonOperations json = new JsonOperations();
            AktifDonemSinavlar val = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);
            if (val == null)
            {
                MessageBox.Show("Dönem bilgisi bulunamadı. Önce dönem ve sınav bilgilerini indiriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Bellek.SeciliSinav == null)
                {
                    MessageBox.Show("Önce sınav seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string soruUrl = Bellek.SorularUrlGet(Bellek.SeciliSinav.Id);
                List<TestSorularInfo> sorular = json.GetListJsonUrl<TestSorularInfo>(soruUrl);
                if (sorular.Count == 0)
                {
                    MessageBox.Show(Bellek.SeciliSinav.SinavAdi + " için sorular bulunamadı.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    json.JsonSaveFile(sorular, Bellek.SorularFileNameGet(Bellek.SeciliSinav.Id));
                }
                
                MessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }
        }

        private void btnDersler_Click(object sender, EventArgs e)
        {
            FormDersler frm = new FormDersler();
            frm.ShowDialog();
        }

        private void btnSorular_Click(object sender, EventArgs e)
        {
            FormSorular frm = new FormSorular();
            frm.ShowDialog();
        }

        private void btnManuelSinav_Click(object sender, EventArgs e)
        {
            FormManuelSinavlar frm = new FormManuelSinavlar();
            frm.ShowDialog();
        }

        private void lnkManuelKutukEkle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofData = new OpenFileDialog())
            {
                ofData.Reset();
                ofData.ReadOnlyChecked = true;
                ofData.Multiselect = true;
                ofData.ShowReadOnly = true;
                ofData.Filter = "Excel dosyası (*.xls;*.xlsx)|*.xls;*.xlsx";
                ofData.Title = "Excel dosyasını seçiniz.";
                ofData.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofData.CheckPathExists = true;
                if (ofData.ShowDialog() == DialogResult.OK)
                {

                    System.Data.DataTable table = ExcelUtil.ExcelToDataTable(ofData.FileName);
                    List<TestKutukInfo> kutuk = new List<TestKutukInfo>();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        string[] subeGet = table.Rows[i][14].ToString().Split('/');
                        string sube = subeGet[1].Replace("Şubesi", "").Trim();
                        kutuk.Add(new TestKutukInfo()
                        {
                            Id = table.Rows[i][0].ToInt32(),
                            IlceAdi = table.Rows[i][3].ToString(),
                            KurumKodu = table.Rows[i][4].ToInt32(),
                            KurumAdi = table.Rows[i][6].ToString(),
                            Adi = table.Rows[i][10].ToString(),
                            Soyadi = table.Rows[i][12].ToString(),
                            Sinifi = table.Rows[i][15].ToInt32(),
                            Sube = sube,
                        });
                    }
                    Application.DoEvents();

                    JsonOperations json = new JsonOperations();
                    AktifDonemSinavlar val = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);
                    if (val == null)
                    {
                        MessageBox.Show("Dönem bilgisi bulunamadı. Önce dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Bellek.SeciliSinav == null)
                        {
                            MessageBox.Show("Önce sınav seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    //    string kutukUrl = Bellek.KutukUrlGet(val.DonemInfo.Id, Bellek.SeciliSinav.Sinif);
                        // List<TestKutukInfo> kutuk = json.GetListJsonUrl<TestKutukInfo>(kutukUrl);
                        if (kutuk.Count == 0)
                        {
                            MessageBox.Show(Bellek.SeciliSinav.SinavAdi + " için kütük listesi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            json.JsonSaveFile(kutuk, Bellek.KutukFileNameGet(Bellek.SeciliSinav.Id, Bellek.SeciliSinav.Sinif));
                        }

                        MessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

                ofData.Dispose();
            }
        }

        private void lnkJsonFolderOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", Bellek.Dizin);
        }
    }
}

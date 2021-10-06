using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ODMSinavYazilimi
{
    public partial class FormPdfCkOlustur : Form
    {
        private string ckDizinAdresi = "";
        private List<TestKutukInfo> ogrencilerKutuk = new List<TestKutukInfo>();
        private List<TestBransInfo> branslarList = new List<TestBransInfo>();
        private List<TestSorularInfo> sorularList = new List<TestSorularInfo>();
        private AktifDonemSinavlar donemveSinavlar = new AktifDonemSinavlar();
        private List<TestOturumlarInfo> oturumlar = new List<TestOturumlarInfo>();
        public FormPdfCkOlustur()
        {
            InitializeComponent();
        }

        private void btnCkPdfOlustur_Click(object sender, EventArgs e)
        {

            if (cbKagitBoyutu.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Kağıt boyutu seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;

            }

            if (ogrencilerKutuk.Count == 0)
            {
                MessageBox.Show("Kütük listesi boş. Önce kütük oluşturunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = true; //yeni klasör oluşturmayı kapat
                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                folderDialog.Description = @"CK dosyalarının saklanacağı dizini seçiniz.";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    ckDizinAdresi = folderDialog.SelectedPath + "\\";

                    BgwPdfOlustur.RunWorkerAsync();

                }
            }
        }

        private void BgwPdfOlustur_DoWork(object sender, DoWorkEventArgs e)
        {
            List<TestKutukInfo> ogrencilerList = OgrenciListesi();

            string kagitBoyutu = cbKagitBoyutu.SelectedValue.ToString();
            //List<string> oturumlar = new List<string>();
            //oturumlar.Add("BIRINCI_OTURUM");
            //if (cbOturumlar.SelectedValue.ToString() == "2")
            //{
            //    oturumlar.Add("IKINCI_OTURUM");
            //}
            List<TestKutukInfo> ilceler = ogrencilerList.GroupBy(x => x.IlceAdi).Select(x => x.First())
            .OrderBy(x => x.IlceAdi).ToList();

            List<TestKutukInfo> siniflar = ogrencilerList.GroupBy(x => x.Sinifi).Select(x => x.First()).ToList();


            progressBar1.Value = 0;
            progressBar1.Maximum = ogrencilerList.Count * oturumlar.Count;
            int a = 0;
            foreach (var oturum in oturumlar)
            {
                // int dersSayisi = oturumNo == "IKINCI_OTURUM" ? lbIkinciOturum.Items.Count : lbBirinciOturum.Items.Count;


                List<TestBransInfo> branslar = new List<TestBransInfo>();
                var oturumDersleri = sorularList.Where(x => x.OturumId == oturum.Id).ToList()
                    .GroupBy(x => x.BransId)
                    .Select(x => x.First()).OrderBy(x => x.SoruNo).ToList();
                foreach (var brans in oturumDersleri)
                {
                    var bransGet = branslarList.FirstOrDefault(x => x.Id == brans.BransId);
                    branslar.Add(bransGet);
                }

                foreach (var sinif in siniflar)
                {
                    foreach (var t in ilceler)
                    {
                        string path = $"{ckDizinAdresi}{sinif.Sinifi}_SINIF_{oturum.OturumAdi}_{t.IlceAdi.ToUpper()}.pdf";

                        iTextSharp.text.Document document = new iTextSharp.text.Document(kagitBoyutu == "A5" ? iTextSharp.text.PageSize.A5 : iTextSharp.text.PageSize.A4);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                        document.Open();

                        List<TestKutukInfo> ogrenciler = ogrencilerKutuk.Where(x => x.IlceAdi == t.IlceAdi)
                            .OrderBy(x => x.KurumAdi)
                            .ThenBy(x => x.Sinifi)
                            .ThenBy(x => x.Sube)
                            .ThenBy(x => x.Adi).ToList();
                        for (int j = 0; j < ogrenciler.Count; j++)
                        {
                            try
                            {
                                PdfIslemleri pdf = new PdfIslemleri();

                                pdf.PdfBilgiYaz(document, writer, ogrenciler[j], oturum, kagitBoyutu, cboxSablon.Checked, txtBaslik.Text, branslar);

                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show("Hata:" + exception.Message);
                                return;
                            }
                            if (j < ogrenciler.Count)
                                document.NewPage();
                            lblBilgi.Text = t.IlceAdi + " - " + ogrenciler[j].KurumAdi;
                            progressBar1.Value = a;
                            a++;
                        }

                        document.Close();

                        // System.Diagnostics.Process.Start(path);
                    }
                }

            }
            progressBar1.Value = 0;
            lblBilgi.Text = "Tamamlandı";

            Process.Start("explorer.exe", Path.GetDirectoryName(ckDizinAdresi));

        }


        private void FormPdfCkOlustur_Load(object sender, EventArgs e)
        {

            //background nesnesi sağlıklı çalışması için gerekli. 
            CheckForIllegalCrossThreadCalls = false;


            JsonVerileriniGetir();

            if (oturumlar.Count == 0)
            {
                MessageBox.Show("Oturum bilgisi bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }

            bool sorularYuklu = false;
            string sorularFileName = Bellek.SorularFileNameGet(Bellek.SeciliSinav.Id);
            if (DizinIslemleri.DosyaKontrol(sorularFileName))
            {
                JsonOperations json = new JsonOperations();
                sorularList = json.GetListJsonFile<TestSorularInfo>(sorularFileName);
                if (sorularList.Count > 0)
                {
                    sorularYuklu = true;
                }
            }
            //sorular yüklenmiş ise oturum derslerini sorulara göre yükle
            if (sorularYuklu)
            {
                foreach (var oturum in oturumlar.OrderBy(x => x.SiraNo))
                {
                    if (oturum.SiraNo == 1)
                    {
                        lbBirinciOturum.DataSource = OturumBranslari(oturum);
                        lbBirinciOturum.DisplayMember = "BransAdi";
                        lbBirinciOturum.ValueMember = "Id";

                        lbBirinciOturum.Enabled = true;
                    }
                    if (oturum.SiraNo == 2)
                    {
                        lbIkinciOturum.DataSource = OturumBranslari(oturum);
                        lbIkinciOturum.DisplayMember = "BransAdi";
                        lbIkinciOturum.ValueMember = "Id";

                        lbIkinciOturum.Enabled = true;
                    }
                    if (oturum.SiraNo == 3)
                    {
                        lbUcuncuOturum.DataSource = OturumBranslari(oturum);
                        lbUcuncuOturum.DisplayMember = "BransAdi";
                        lbUcuncuOturum.ValueMember = "Id";

                        lbUcuncuOturum.Enabled = true;
                    }
                    if (oturum.SiraNo == 4)
                    {
                        lbDorduncuOturum.DataSource = OturumBranslari(oturum);
                        lbDorduncuOturum.DisplayMember = "BransAdi";
                        lbDorduncuOturum.ValueMember = "Id";

                        lbDorduncuOturum.Enabled = true;
                    }
                }
            }
            else
            {
                //sorular yüklenmiş ise manuel yüklenmek üzere tümünü ilk oturuma yükle.
                foreach (var item in branslarList)
                {
                    lbBirinciOturum.Items.Add(item.BransAdi);
                }
                
                lbBirinciOturum.Enabled = true;
            }

            List<ComboboxItem> item2 = new List<ComboboxItem>
            {
                new ComboboxItem("Seçiniz", ""),
                new ComboboxItem("A5", "A5"),
                new ComboboxItem("A4", "A4")
            };
            cbKagitBoyutu.DataSource = item2;
            cbKagitBoyutu.DisplayMember = "text";
            cbKagitBoyutu.ValueMember = "value";



            cbIlceler.DataSource = null;
            List<TestKutukInfo> ilceler = ogrencilerKutuk.GroupBy(x => x.IlceAdi).Select(x => x.First()).OrderBy(x => x.IlceAdi).ToList();

            List<TestKutukInfo> ogr = new List<TestKutukInfo> { new TestKutukInfo("0", "İlçe Seçiniz") };
            ogr.AddRange(ilceler.Select(t => new TestKutukInfo(t.IlceAdi, t.IlceAdi)));

            cbIlceler.ValueMember = "Text";
            cbIlceler.DisplayMember = "Value";
            foreach (var o in ogr)
            {
                cbIlceler.Items.Add(new TestKutukInfo(o.IlceAdi, o.IlceAdi));
            }
            cbIlceler.DataSource = ogr;

            List<TestKutukInfo> okul = new List<TestKutukInfo> { new TestKutukInfo("0", "İlçe Seçiniz") };

            cbOkullar.ValueMember = "Text";
            cbOkullar.DisplayMember = "Value";
            cbOkullar.DataSource = okul;
        }

        private List<TestBransInfo> OturumBranslari(TestOturumlarInfo oturum)
        {
            List<TestBransInfo> branslar = new List<TestBransInfo>();

            var oturumDersleri = sorularList.Where(x => x.OturumId == oturum.Id).ToList()
                .GroupBy(x => x.BransId)
                .Select(x => x.First()).OrderBy(x => x.SoruNo).ToList();
            foreach (var brans in oturumDersleri)
            {
                var bransGet = branslarList.FirstOrDefault(x => x.Id == brans.BransId);
                branslar.Add(bransGet);
            }

            return branslar;
        }


        private void btnGozat_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    string startPath = Application.StartupPath + "\\Files";
                    string dosyaAdi = startPath + "\\" + Path.GetFileName(ofd.FileName.ToUrl());

                    //klasör yoksa oluştur
                    if (!DizinIslemleri.DizinKontrol(startPath))
                        DizinIslemleri.DizinOlustur(startPath);


                    DizinIslemleri.DosyaKopyala(ofd.FileName, dosyaAdi, true);
                    txtSablon.Text = dosyaAdi;

                }
            }
        }

        private void cbIlceler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ilceAdi = "";
            if (cbIlceler.SelectedValue != null)
                ilceAdi = cbIlceler.SelectedValue.ToString();
            cbOkullar.DataSource = null;
            if (ilceAdi != "0" && !string.IsNullOrEmpty(ilceAdi))
            {
                var okullar = ogrencilerKutuk.Where(x => x.IlceAdi.Equals(ilceAdi)).GroupBy(x => x.KurumKodu)
                    .Select(x => x.First()).OrderBy(x => x.KurumAdi).ToList();
                List<TestKutukInfo> ogr = new List<TestKutukInfo> { new TestKutukInfo("0", "Okul Seçiniz") };
                ogr.AddRange(okullar.Select(t => new TestKutukInfo(t.KurumKodu.ToString(), t.KurumAdi)));

                cbOkullar.ValueMember = "Text";
                cbOkullar.DisplayMember = "Value";

                foreach (var o in ogr)
                {
                    cbOkullar.Items.Add(o);
                }
                cbOkullar.DataSource = ogr;

                lblBilgi.Text = cbIlceler.Text + " ilçesi için CK oluşturabilirsiniz.";
            }
            else
            {
                lblBilgi.Text = "Tüm il için CK oluşturabilirsiniz";
                List<TestKutukInfo> okul = new List<TestKutukInfo> { new TestKutukInfo("0", "İlçe Seçiniz") };

                cbOkullar.ValueMember = "Text";
                cbOkullar.DisplayMember = "Value";
                cbOkullar.DataSource = okul;
            }
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
        private List<TestKutukInfo> OgrenciListesi()
        {
            string ilceAdi = cbIlceler.SelectedValue == null ? "0" : cbIlceler.SelectedValue.ToString();
            int kurumKodu = cbOkullar.SelectedValue == null ? 0 : cbOkullar.SelectedValue.ToInt32();

            var ogrList = from o in ogrencilerKutuk select o;

            if (ilceAdi != "0") ogrList = ogrList.Where(p => p.IlceAdi == ilceAdi);
            if (kurumKodu != 0) ogrList = ogrList.Where(p => p.KurumKodu == kurumKodu);

            List<TestKutukInfo> ogrencilerInfos = ogrList.OrderBy(x => x.IlceAdi).ThenBy(x => x.KurumAdi)
                .ThenBy(x => x.Sinifi)
                .ThenBy(x => x.Adi).ThenBy(x => x.Soyadi).ToList();
            return ogrencilerInfos;
        }

        private void cbOkullar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOkullar.SelectedValue != null)
            {
                if (cbOkullar.SelectedValue.ToString() != "0" && !string.IsNullOrEmpty(cbOkullar.Text))
                    lblBilgi.Text = cbIlceler.Text + " ilçesi " + cbOkullar.Text + " için CK oluşturabilirsiniz.";
                else
                    lblBilgi.Text = cbIlceler.Text + " ilçesi için CK oluşturabilirsiniz.";
            }

        }

        private void cboxSablon_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxSablon.Checked)
            {
                txtSablon.Enabled = true;
                btnGozat.Enabled = true;

                groupBox1.Visible = false;
            }
            else
            {
                txtSablon.Enabled = false;
                btnGozat.Enabled = false;
                groupBox1.Visible = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbBirinciOturum.SelectedIndex < 0)
                return;

            var gelenVeri = lbBirinciOturum.Items[lbBirinciOturum.SelectedIndex].ToString();

            lbBirinciOturum.Items.Remove(gelenVeri);
        }

        private void sağaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbBirinciOturum.SelectedIndex < 0)
                return;

            var gelenVeri = lbBirinciOturum.Items[lbBirinciOturum.SelectedIndex].ToString();


            lbIkinciOturum.Items.Add(gelenVeri);
            lbBirinciOturum.Items.Remove(gelenVeri);
            lbIkinciOturum.Enabled = true;

        }

        private void aşağıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListboxYonlendirme(lbBirinciOturum,true);
        }
        private void yukarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListboxYonlendirme(lbBirinciOturum, false);
        }

        private void ListboxYonlendirme(ListBox listbox,bool asagi)
        {
            int index = listbox.SelectedIndex;
            if (asagi)
            {
                if (index != -1 & index < listbox.Items.Count - 1)
                {
                    listbox.Items.Insert(index + 2, listbox.Items[index]);
                    listbox.Items.RemoveAt(index);
                    listbox.SelectedIndex = index + 1;
                }
            }
            else
            {
                if (index > 0 & index != -1)
                {
                    listbox.Items.Insert(index - 1, listbox.Items[index]);
                    listbox.Items.RemoveAt(index + 1);
                    listbox.SelectedIndex = index - 1;
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ListboxYonlendirme(lbIkinciOturum, false);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ListboxYonlendirme(lbIkinciOturum, true);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (lbIkinciOturum.SelectedIndex < 0)
                return;

            var gelenVeri = lbIkinciOturum.Items[lbIkinciOturum.SelectedIndex].ToString();
            
            lbUcuncuOturum.Items.Add(gelenVeri);
            lbIkinciOturum.Items.Remove(gelenVeri);
            lbUcuncuOturum.Enabled = true;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (lbIkinciOturum.SelectedIndex < 0)
                return;

            var gelenVeri = lbIkinciOturum.Items[lbIkinciOturum.SelectedIndex].ToString();

            lbBirinciOturum.Items.Add(gelenVeri);
            lbIkinciOturum.Items.Remove(gelenVeri);
            lbBirinciOturum.Enabled = true;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (lbIkinciOturum.SelectedIndex < 0)
                return;

            var gelenVeri = lbIkinciOturum.Items[lbIkinciOturum.SelectedIndex].ToString();

            lbIkinciOturum.Items.Remove(gelenVeri);
        }
    }
}

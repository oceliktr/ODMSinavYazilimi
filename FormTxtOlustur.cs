using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ODMSinavYazilimi
{
    public partial class FormTxtOlustur : Form
    {
        private string seciliDosya = "";

        public FormTxtOlustur()
        {
            InitializeComponent();
            lvBolumler.Columns.Add("Açıklama", 100);
            lvBolumler.Columns.Add("Başlangıç", 80);
            lvBolumler.Columns.Add("Karakter", 70);
            lvBolumler.Columns.Add("Değer", 70);
            lvBolumler.Activation = ItemActivation.OneClick;
            //Listview tek tıklamada aktif hale gelir.

            lvBolumler.View = View.Details;
            // Listview üzerindeki sütun isimleri görünmesi için değiştirilmesi gereklidir.

            lvBolumler.GridLines = true;
            //Listview üzerinde ayırt edici çizgilerin görünmesi için gereklidir.

            lvBolumler.FullRowSelect = true;
            // Listview üzerinde satırın tamamını seçebilmek için bu özelliğin true olması gerekir.
        }
        private void FormTxtOlustur_Load(object sender, EventArgs e)
        {
            JsonOperations json = new JsonOperations();

            if (!DizinIslemleri.DosyaKontrol(Bellek.BranslarFilename))
            {
                MessageBox.Show("Ders listesi bulunamadı. Ders listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            List<TestBransInfo> branslarList = json.GetListJsonFile<TestBransInfo>(Bellek.BranslarFilename);
            if (branslarList.Count == 0)
            {
                MessageBox.Show("Ders listesi bulunamadı. Ders listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            dgBranslar.DataSource = branslarList.OrderBy(x => x.Id).ToList();

            dgBranslar.Columns[0].HeaderText = "Ders Kodu";
            dgBranslar.Columns[0].Width = 50;
            dgBranslar.Columns[1].Visible = false;//branş katsayı
            dgBranslar.Columns[2].HeaderText = "Ders Adı";
            dgBranslar.Columns[2].Width = 123;
        }

        private void txtData_KeyUp(object sender, KeyEventArgs e)
        {
            if (ndKarakter.Maximum > txtData.SelectionLength)
                ndKarakter.Value = txtData.SelectionLength;

            if (ndSutun.Maximum > txtData.SelectionStart)
                ndSutun.Value = txtData.SelectionStart;
        }
        private void txtData_MouseDown(object sender, MouseEventArgs e)
        {
            if (ndSutun.Maximum > txtData.SelectionStart)
                ndSutun.Value = txtData.SelectionStart;
        }
        private void txtData_MouseUp(object sender, MouseEventArgs e)
        {
            if (ndKarakter.Maximum > txtData.SelectionLength)
                ndKarakter.Value = txtData.SelectionLength;
        }
        private void txtData_Click(object sender, EventArgs e)
        {
            if (txtData.SelectionStart < ndSutun.Maximum)
                ndSutun.Value = txtData.SelectionStart;
        }
        private void btnDataAc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofData = new OpenFileDialog())
            {
                ofData.Reset();
                ofData.ReadOnlyChecked = true;
                ofData.Multiselect = true;
                ofData.ShowReadOnly = true;
                ofData.Filter = "Veri dosyası (*.txt;*.dat)|*.txt;*.dat";
                ofData.Title = "Veri dosyasını seçiniz.";
                ofData.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofData.CheckPathExists = true;
                txtData.Text = "";
                if (ofData.ShowDialog() == DialogResult.OK)
                {
                    seciliDosya = ofData.FileName;
                    if (seciliDosya.Length > 0)
                        txtData.Text = File.ReadLines(seciliDosya).First();
                }
                this.Text = seciliDosya;

                ndSutun.Value = 0;
                ndKarakter.Value = 0;
                lvBolumler.Items.Clear();
                cbAlanAdi.Text = "";

                ofData.Dispose();
            }


            int sonSatirIndexi = txtData.TextLength;
            ndSutun.Maximum = ndKarakter.Maximum = sonSatirIndexi;
        }
        private void ndSutun_ValueChanged(object sender, EventArgs e)
        {
            OrnekOlustur();
        }
        private void ndKarakter_ValueChanged(object sender, EventArgs e)
        {
            OrnekOlustur();
        }
        private void txtAraKarakter_TextChanged(object sender, EventArgs e)
        {
            OrnekOlustur();
        }
        private void cbSonunaEkle_CheckedChanged(object sender, EventArgs e)
        {
            OrnekOlustur();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (ndKarakter.Value == 0 && txtSabitDeger.Text == "") //herhangi bir karakter seçilmemiş veya sabit değer girilmemiş ise
            {
                MessageBox.Show("Herhangi bir aralık seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (txtSabitDeger.Text != "") //eğer sabit değer girilmemişse karakter ve sutun değerlerini sıfırla
                {
                    ndSutun.Value = ndKarakter.Value = 0;
                }
                string sabitDeger = txtSabitDeger.Text;
                if (sabitDeger == "")
                    sabitDeger = "null";

                string[] row = { cbAlanAdi.Text, ndSutun.Value.ToInt32().ToString(), ndKarakter.Value.ToInt32().ToString(), sabitDeger };
                var satir = new ListViewItem(row);
                lvBolumler.Items.Add(satir);

                //seçili değerleri sil
                cbAlanAdi.Text = "";
                txtSabitDeger.Text = "";
                ndSutun.Value = ndKarakter.Value = 0;


                OrnekOlustur();
            }
        }
        private void lvBolumler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem bilgi in lvBolumler.SelectedItems)
                {
                    bilgi.Remove();
                    OrnekOlustur();
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                ListViewElemanTasi(lvBolumler, TasimaYonu.Yukari);
                OrnekOlustur();
            }
            if (e.KeyCode == Keys.Down)
            {
                ListViewElemanTasi(lvBolumler, TasimaYonu.Asagi);
                OrnekOlustur();
            }
        }
        private void ListViewElemanTasi(ListView sender, TasimaYonu yon)
        {
            //listenin içini kontrol et
            //listede değer yoksa false dön
            //aşağı yönde listenin en sonunda ise false dön
            //yukarı yönde listenin başında ise false dön
            //taşına bilir ise true dön
            bool kontrol = sender.SelectedItems.Count > 0 && (yon == TasimaYonu.Asagi || yon == TasimaYonu.Yukari) &&
                           ((yon == TasimaYonu.Asagi && sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1) ||
                            (yon == TasimaYonu.Yukari && sender.SelectedItems[0].Index > 0));
            if (kontrol)
            {
                bool start = true;
                int first_idx = 0;
                List<ListViewItem> items = new List<ListViewItem>();

                // ambil data
                foreach (ListViewItem i in sender.SelectedItems)
                {
                    if (start)
                    {
                        first_idx = i.Index;
                        start = false;
                    }
                    items.Add(i);
                }

                sender.BeginUpdate();

                // hapus
                foreach (ListViewItem i in sender.SelectedItems) i.Remove();

                // insert
                if (yon == TasimaYonu.Yukari)
                {
                    int insert_to = first_idx - 1;
                    foreach (ListViewItem i in items)
                    {
                        sender.Items.Insert(insert_to, i);
                        insert_to++;
                    }
                }
                else
                {
                    int insert_to = first_idx + 1;
                    foreach (ListViewItem i in items)
                    {
                        sender.Items.Insert(insert_to, i);
                        insert_to++;
                    }
                }
                sender.EndUpdate();
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem bilgi in lvBolumler.SelectedItems)
            {
                bilgi.Remove();
                OrnekOlustur();
            }
        }
        private void yukarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewElemanTasi(lvBolumler, TasimaYonu.Yukari);
            OrnekOlustur();
        }
        private void aşağıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewElemanTasi(lvBolumler, TasimaYonu.Asagi);
            OrnekOlustur();
        }
        private void dgBranslar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbAlanAdi.Text = dgBranslar[2, e.RowIndex].Value.ToString();
                txtSabitDeger.Text = dgBranslar[0, e.RowIndex].Value.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnTextOlustur_Click(object sender, EventArgs e)
        {
            if (lvBolumler.Items.Count == 0)
            {
                MessageBox.Show("Herhangi bir aralık seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.DefaultExt = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveFileDialog1.Title = @"Txt dosyalarının oluşturulacağı dizini seçiniz.";

                    saveFileDialog1.FileName = "Dosya Adı.txt";
                    saveFileDialog1.Filter = "Text Dosyası | *.txt";


                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());

                        try
                        {
                            string[] lines = File.ReadAllLines(seciliDosya, Encoding.UTF8);
                            foreach (string file in lines)
                            {
                                string yeniData = "";
                                for (int i = 0; i < lvBolumler.Items.Count; i++)
                                {

                                    if (lvBolumler.Items[i].SubItems[3].Text != "null") //sabit değer tanımlanmış ise
                                    {
                                        yeniData += lvBolumler.Items[i].SubItems[3].Text + txtAraKarakter.Text;
                                    }
                                    else //sabit değer tanımlanmamış ise kesme noktalarından kopyala
                                    {
                                        string deger = file.Substring(lvBolumler.Items[i].SubItems[1].Text.ToInt32(), lvBolumler.Items[i].SubItems[2].Text.ToInt32());

                                        if (lvBolumler.Items[i].SubItems[0].Text == "Girmedi") //Girmedi ise
                                        {
                                            //Gelen değer G ise 0, yoksa 1 yaz.
                                            if (deger == "G")
                                                yeniData += "0" + txtAraKarakter.Text;
                                            else
                                                yeniData += "1" + txtAraKarakter.Text;
                                        }
                                        else
                                        {
                                            yeniData += deger + txtAraKarakter.Text;
                                        }
                                    }

                                }

                                //sonunda karakter olmasın denilmiş ise sondaki karakteri sil
                                if (txtAraKarakter.Text != "" && cbSonunaEkle.Checked == false && yeniData.Length > 0)
                                    yeniData = yeniData.Substring(0, yeniData.Length - 1);

                                writer.WriteLine(yeniData);
                                Application.DoEvents();
                            }
                        }
                        catch (Exception)
                        {
                            //  MessageBox.Show("Hata: " + ex.Message);
                        }

                        writer.Dispose();
                        writer.Close();

                        DialogResult dialog = MessageBox.Show("Txt Dosyaları oluşturuldu. Dosyayı açmak ister misiniz?", @"Bilgi", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                            Process.Start("explorer.exe", Path.GetFileName(saveFileDialog1.FileName));
                    }
                }

            }
        }
        private void btnOturumlariBirlestir_Click(object sender, EventArgs e)
        {

            if (lvBolumler.Items.Count == 0)
            {
                MessageBox.Show("Herhangi bir aralık seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (txtAraKarakter.Text == "")
            {
                MessageBox.Show("Ara karakter giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAraKarakter.Focus();
            }
            else if (lvBolumler.Items.Count > 4)
            {
                MessageBox.Show("OpaqId#Oturum#KTür#Cevaplar formatında olmalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAraKarakter.Focus();
            }
            else
            {
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.DefaultExt = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveFileDialog1.Title = @"Txt dosyalarının oluşturulacağı dizini seçiniz.";

                    saveFileDialog1.FileName = "Dosya Adı.txt";
                    saveFileDialog1.Filter = "Text Dosyası | *.txt";


                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        List<OturumBirlestir> txtVerileri = CevaplariDizeyeAl();

                        //Mükerrer kontrolü yap. Varsa çık.
                        if (MukerrerKontrol(txtVerileri, saveFileDialog1)) return;


                        //her oturumu bir opaq id değerine toplayan medot
                        CevaplariOpaqIdyeBirlestir(saveFileDialog1, txtVerileri);

                        seciliDosya = saveFileDialog1.FileName;
                        this.Text = seciliDosya;
                        lvBolumler.Items.Clear();

                        DialogResult dialog = MessageBox.Show("Txt Dosyaları oluşturuldu. Dosyayı açmak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                            Process.Start("explorer.exe", Path.GetFileName(saveFileDialog1.FileName));
                    }
                }

            }
        }

        private void OrnekOlustur()
        {
            if (lvBolumler.Items.Count > 0)
            {
                string ornekMetin = "";

                for (int i = 0; i < lvBolumler.Items.Count; i++)
                {
                    if (lvBolumler.Items[i].SubItems[3].Text != "null") //null değil ise sabit değeri yaz
                    {
                        ornekMetin += lvBolumler.Items[i].SubItems[3].Text + txtAraKarakter.Text;
                    }
                    else //null ise kesme noktlarından al
                    {
                        string deger = txtData.Text.Substring(lvBolumler.Items[i].SubItems[1].Text.ToInt32(), lvBolumler.Items[i].SubItems[2].Text.ToInt32());

                        if (lvBolumler.Items[i].SubItems[0].Text == "Girmedi") //Girmedi ise
                        {
                            //Gelen değer G ise 0, yoksa 1 yaz.
                            if (deger == "G")
                                ornekMetin += "0" + txtAraKarakter.Text;
                            else
                                ornekMetin += "1" + txtAraKarakter.Text;
                        }
                        else
                        {
                            ornekMetin += deger + txtAraKarakter.Text;
                        }
                    }
                }

                if (txtAraKarakter.Text == "")
                    label1.Text = "Örnek :" + ornekMetin;
                else
                {
                    if (cbSonunaEkle.Checked == false)
                        label1.Text = "Örnek :" + ornekMetin.Substring(0, ornekMetin.Length - 1);
                    else
                        label1.Text = "Örnek :" + ornekMetin;

                }
            }
        }
        private static bool MukerrerKontrol(List<OturumBirlestir> txtVerileri, SaveFileDialog saveFileDialog1)
        {
            var mukerrerList = txtVerileri.GroupBy(x => new { x.OpaqId, x.Oturum, x.KitTur })
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            if (mukerrerList.Count > 0)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());

                writer.WriteLine("------- MÜKERRER KAYITLAR -------");
                writer.WriteLine("------- BU KAYITLARI KAYNAK DOSYADAN SİLİP TEKRAR ÇALIŞTIRIN -------");

                foreach (var q in mukerrerList)
                {
                    writer.WriteLine("Kayıt:" + q.OpaqId + q.KitTur + q.Oturum);
                }

                writer.Dispose();
                writer.Close();
                Process.Start("explorer.exe", Path.GetFileName(saveFileDialog1.FileName));
                return true;
            }

            return false;
        }
        /// <summary>
        /// Diziye alınan cevapları birleştiren medot.
        /// </summary>
        /// <param name="saveFileDialog1"></param>
        /// <param name="txtVerileri"></param>
        private void CevaplariOpaqIdyeBirlestir(SaveFileDialog saveFileDialog1, List<OturumBirlestir> txtVerileri)
        {
            StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());

            int cevapUzunluk = lvBolumler.Items[3].SubItems[2].Text.ToInt32();
            List<OturumBirlestir> oturumSayisi = txtVerileri.DistinctBy(x => x.Oturum).OrderBy(x => x.Oturum).ToList();
            string yeniTxt = "";

            string cevapBosluk = ""; //oturuma katılmamış ise cevaplar bölümünün uzunluğu kadar ara bırakalım.
            for (int i = 0; i < cevapUzunluk; i++)
                cevapBosluk += " ";

            foreach (var opaq in txtVerileri.DistinctBy(x => x.OpaqId).ToList())
            {
                if (opaq.OpaqId == "21984")
                {

                }
                string kitTuru = "";
                string yeniCevaplar = "";

                foreach (var otrm in oturumSayisi)
                {
                    //opaqId ve oturum kontrolü yapmak gerekiyor. Çünkü oturumu yoksa o alanın boşlukla doldurulması gerekiyor. Aksi halde halde ders cevapları bölerken kaymalar olacaktr.
                    var cvplar = txtVerileri.FirstOrDefault(x => x.OpaqId == opaq.OpaqId && x.Oturum == otrm.Oturum);

                    if (cvplar == null) //eğer öğrencinin oturumu yoksa alanı boş bırakacağım
                    {
                        kitTuru += " ";
                        yeniCevaplar += cevapBosluk;
                    }
                    else
                    {
                        kitTuru += cvplar.KitTur;
                        yeniCevaplar += cvplar.Cevaplar;
                    }
                }

                //Çıkacak veri=> OpaqId#KTürKTür#CevaplarCevaplar
                string sonuc = opaq.OpaqId + kitTuru + yeniCevaplar;
                yeniTxt = sonuc; //en son satırı txtData alanına eklemek için gerekli
                writer.WriteLine(sonuc);
            }

            writer.Dispose();
            writer.Close();
            txtData.Text = yeniTxt;
        }
        /// <summary>
        /// Txt dosyasından gelen cevapları parçalayıp diziye alan metod.
        /// </summary>
        /// <returns></returns>
        private List<OturumBirlestir> CevaplariDizeyeAl()
        {
            List<OturumBirlestir> txtVerileri = new List<OturumBirlestir>();

            string[] lines = File.ReadAllLines(seciliDosya, Encoding.UTF8);
            foreach (string file in lines)
            {
                try
                {
                    string yeniData = "";
                    for (int i = 0; i < lvBolumler.Items.Count; i++)
                    {
                        if (lvBolumler.Items[i].SubItems[3].Text != "null") //sabit değer tanımlanmış ise
                        {
                            yeniData += lvBolumler.Items[i].SubItems[3].Text + txtAraKarakter.Text;
                        }
                        else //sabit değer tanımlanmamış ise kesme noktalarından kopyala
                        {
                            string deger = file.Substring(lvBolumler.Items[i].SubItems[1].Text.ToInt32(),
                                lvBolumler.Items[i].SubItems[2].Text.ToInt32());

                            yeniData += deger + txtAraKarakter.Text;
                        }
                    }

                    //sonunda karakter olmasın denilmiş ise sondaki karakteri sil
                    if (txtAraKarakter.Text != "" && yeniData.Length > 0)
                        yeniData = yeniData.Substring(0, yeniData.Length - 1);

                    string[] yeniDataArray = yeniData.Split(txtAraKarakter.Text.ToCharArray(0, 1));

                    //Gelen veri=> OpaqId#Oturum#KTür#Cevaplar
                    string opaqId = yeniDataArray[0];
                    int oturum = yeniDataArray[1] == " " ? 0 : yeniDataArray[1].ToInt32();
                    string kTur = yeniDataArray[2];
                    string cevaplar = yeniDataArray[3];

                    txtVerileri.Add(new OturumBirlestir(opaqId, oturum, kTur, cevaplar));
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data dosyasında bir hata oluştu. Butün satırlar aynı uzunlukta olmalı. Satır uzunluklarını kontrol ediniz.\nHata oluşan satır: " + file + "\n Hata Mesajı: " + ex.Message);
                }
            }


            return txtVerileri;
        }
    }
}

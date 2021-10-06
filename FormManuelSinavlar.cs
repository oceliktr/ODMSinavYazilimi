using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;

namespace ODMSinavYazilimi
{
    public partial class FormManuelSinavlar : Form
    {
        private AktifDonemSinavlar val = new AktifDonemSinavlar();
        private List<TestBransInfo> branslarList = new List<TestBransInfo>();
        public FormManuelSinavlar()
        {
            InitializeComponent();
        }

        private void FormManuelSinavlar_Load(object sender, EventArgs e)
        {
            if (!DizinIslemleri.DosyaKontrol(Bellek.AktifDonemveSinavlarFilename))
            {
                //json dosyası yoksa listeyi getir ve json dosyasına kaydet.
                MessageBox.Show("Aktif dönem dosyası bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                JsonOperations json = new JsonOperations();

                val = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);
                if (val.DonemInfo == null)
                {
                    MessageBox.Show("Aktif dönem bilgisi bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    KayitlariListele();
                }
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


            }
        }

        private void KayitlariListele()
        {
            List<SinavOturumModel> sinavlar = new List<SinavOturumModel>();
            var liste = val.Sinavlar.Where(x => x.Manuel == 1).ToList();
            foreach (var snv in liste)
            {
                foreach (var otr in val.Oturumlar.Where(x => x.SinavId == snv.Id))
                {
                    sinavlar.Add(new SinavOturumModel()
                    {
                        OturumAdi = otr.OturumAdi,
                        OturumId = otr.Id,
                        Puanlama = snv.Puanlama,
                        SinavAdi = snv.SinavAdi,
                        SinavId = snv.Id,
                        Sinif = snv.Sinif,
                        SiraNo = otr.SiraNo,
                        Sure = otr.Sure
                    });
                }
            }
            dgSinavlar.DataSource = sinavlar.ToList();
            dgSinavlar.Columns[0].HeaderText = "Sınav No";
            dgSinavlar.Columns[0].Width = 50;
            dgSinavlar.Columns[1].HeaderText = "Oturum No";
            dgSinavlar.Columns[1].Width = 50;
            dgSinavlar.Columns[2].HeaderText = "Sınav Adı";
            dgSinavlar.Columns[2].Width = 250;
            dgSinavlar.Columns[3].HeaderText = "S No";
            dgSinavlar.Columns[3].Width = 40;
            dgSinavlar.Columns[4].HeaderText = "Oturum Adı";
            dgSinavlar.Columns[4].Width = 135;
            dgSinavlar.Columns[5].HeaderText = "Sınıf";
            dgSinavlar.Columns[5].Width = 50;
            dgSinavlar.Columns[6].HeaderText = "Süre";
            dgSinavlar.Columns[6].Width = 50;
            dgSinavlar.Columns[7].HeaderText = "Puanlama";
            dgSinavlar.Columns[7].Width = 50;
        }
        private void dgSinavlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int sinavId = dgSinavlar[0, e.RowIndex].Value.ToInt32();

                if (!DizinIslemleri.DosyaKontrol(Bellek.SorularFileNameGet(sinavId)))
                {
                    StreamWriter yaz = new StreamWriter(Bellek.SorularFileNameGet(sinavId));

                    yaz.WriteLine("[]");
                    yaz.Close();
                    yaz.Dispose();
                }

                JsonOperations json = new JsonOperations();
                List<TestSorularInfo> sorularList = json.GetListJsonFile<TestSorularInfo>(Bellek.SorularFileNameGet(sinavId));


                int a = 0;
                List<TestSorularViewModel> sorular = new List<TestSorularViewModel>();
                foreach (var otr in val.Oturumlar.Where(x => x.SinavId == sinavId).OrderBy(x => x.SiraNo))
                {
                    foreach (var item in sorularList.Where(x => x.OturumId == otr.Id).OrderBy(x => x.SoruNo).ToList())
                    {
                        a++;
                        sorular.Add(new TestSorularViewModel()
                        {
                            Id = a,
                            SoruNo = item.SoruNo,
                            Cevap = item.Cevap,
                            DersAdi = branslarList.Find(x => x.Id == item.BransId).BransAdi,
                            Iptal = item.Iptal == 0 ? "" : "İPTAL",
                            Oturum = otr.OturumAdi
                        });
                    }
                }
                dgSorular.DataSource = sorular;

                dgSorular.Columns[0].HeaderText = "No";
                dgSorular.Columns[0].Width = 50;
                dgSorular.Columns[1].HeaderText = "Oturum";
                dgSorular.Columns[1].Width = 90;
                dgSorular.Columns[2].HeaderText = "Ders Adı";
                dgSorular.Columns[2].Width = 190;
                dgSorular.Columns[3].HeaderText = "Soru No";
                dgSorular.Columns[3].Width = 80;
                dgSorular.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSorular.Columns[4].HeaderText = "Cevap";
                dgSorular.Columns[4].Width = 80;
                dgSorular.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSorular.Columns[5].HeaderText = "Durum";
                dgSorular.Columns[5].Width = 88;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnExceldenYukle_Click(object sender, EventArgs e)
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
                    int sinavId = GenelIslemler.RastgeleSayiUret(5).ToInt32();
                    while (true)
                    {
                        if (val.Sinavlar.Find(x => x.Id == sinavId) == null)
                        {
                            break;
                        }

                        sinavId = GenelIslemler.RastgeleSayiUret(5).ToInt32();
                    }
                    DataTable table = ExcelUtil.ExcelToDataTable(ofData.FileName);
                    string sinavAdi = table.Rows[0][1].ToString();
                    int sinif = table.Rows[1][1].ToInt32();
                    if (sinif == 0)
                    {
                        MessageBox.Show("Sınıf alanında yalnızca sayısal değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int puanlama = table.Rows[2][1].ToInt32();
                    if (puanlama != 100 && puanlama != 500)
                    {
                        MessageBox.Show("Puanlama alanında yalnızca 100 veya 500 değerini giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    List<TestSorularInfo> sorular = new List<TestSorularInfo>();
                    List<TestOturumlarInfo> oturumlar = new List<TestOturumlarInfo>();
                    for (int i = 4; i < table.Rows.Count; i++)
                    {
                        int oturumId = GenelIslemler.RastgeleSayiUret(5).ToInt32();
                        while (true)
                        {
                            if (val.Oturumlar.Find(x => x.Id == oturumId) == null)
                            {
                                break;
                            }

                            oturumId = GenelIslemler.RastgeleSayiUret(5).ToInt32();
                        }
                        string oturumNoStr = table.Rows[i][0].ToString();
                        string oturumAdi = table.Rows[i][1].ToString();
                        if (oturumAdi != "")
                        {

                            oturumlar.Add(new TestOturumlarInfo()
                            {
                                Id = oturumId,
                                OturumAdi = oturumAdi,
                                SinavId = sinavId,
                                SiraNo = i - 3,
                                Sure = 0
                            });

                            for (int j = 1; j < table.Rows.Count; j++)
                            {
                                string dersOturumNoStr = table.Rows[j][2].ToString();
                                if (dersOturumNoStr == oturumNoStr)
                                {
                                    int dersKodu = table.Rows[j][3].ToInt32();
                                    string cevaplar = table.Rows[j][4].ToString();
                                    string[] iptal = table.Rows[j][5].ToString().Split(',');

                                    for (int k = 0; k < cevaplar.Length; k++)
                                    {
                                        var oturumSorulari = sorular.Where(x => x.OturumId == oturumId);
                                        int buyukSoruNo = oturumSorulari.Count() == 0 ? 0 : oturumSorulari.Max(x => x.SoruNo);
                                        int soruIptal = 0;
                                        if (iptal.Contains((k + 1).ToString()))
                                        {
                                            soruIptal = 1;
                                        }
                                        sorular.Add(new TestSorularInfo
                                        {
                                            BransId = dersKodu,
                                            Cevap = cevaplar.Substring(k, 1),
                                            Id = 0,
                                            SoruNo = buyukSoruNo + 1,
                                            Iptal = soruIptal,
                                            OturumId = oturumId
                                        });
                                    }
                                }
                            }
                        }

                    }

                    TestSinavlarInfo sinavlar = new TestSinavlarInfo
                    {
                        Id = sinavId,
                        SinavAdi = sinavAdi,
                        Manuel = 1,
                        Aktif = 1,
                        DonemId = val.DonemInfo.Id,
                        Puanlama = puanlama,
                        Sinif = sinif
                    };

                    JsonOperations json = new JsonOperations();
                    val.Sinavlar.Add(sinavlar);
                    foreach (var ot in oturumlar)
                    {
                        val.Oturumlar.Add(ot);
                    }
                    json.JsonSaveFile(val, Bellek.AktifDonemveSinavlarFilename);
                    json.JsonSaveFile(sorular, Bellek.SorularFileNameGet(sinavId));

                    KayitlariListele();

                }

                ofData.Dispose();
            }
        }

        private void seçiliSınavıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sinavId = dgSinavlar.SelectedRows[0].Cells[0].Value.ToInt32();
            DialogResult dialog = MessageBox.Show("Seçili sınava ait kayıtları silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                DialogResult dialog2 = MessageBox.Show("Sınav soru karı dahil tüm kayıtlar silinsin mi?", "Uyarı", MessageBoxButtons.YesNo);
                if (dialog2 == DialogResult.Yes)
                {
                    DizinIslemleri.DosyaSil(Bellek.SorularFileNameGet(sinavId));

                    AktifDonemSinavlar yeniVal = new AktifDonemSinavlar();
                    yeniVal.DonemInfo = val.DonemInfo;
                    yeniVal.Sinavlar = val.Sinavlar.Where(x => x.Id != sinavId).ToList();
                    yeniVal.Oturumlar = val.Oturumlar.Where(x => x.SinavId != sinavId).ToList();

                    JsonOperations json = new JsonOperations();
                    json.JsonSaveFile(yeniVal, Bellek.AktifDonemveSinavlarFilename);
                    val = yeniVal;
                    FormAna frm = new FormAna();
                    frm.EkranaYaz(val);

                    dgSorular.DataSource = null;
                    KayitlariListele();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Bellek.Dizin + "\\OrnekSinav.xlsx");
        }
    }
}

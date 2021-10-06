using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ODMSinavYazilimi.Library;
using ODMSinavYazilimi.Models;

namespace ODMSinavYazilimi
{
    public partial class FormSorular : Form
    {
        public FormSorular()
        {
            InitializeComponent();
        }

        private void FormSorular_Load(object sender, EventArgs e)
        {
            Text = Bellek.SeciliSinav.SinavAdi + " Soruları";
            JsonOperations json = new JsonOperations();
            var donemveSinavlar = json.GetJsonFile<AktifDonemSinavlar>(Bellek.AktifDonemveSinavlarFilename);

            if (donemveSinavlar == null)
            {
                Close();
                MessageBox.Show("Aktif dönem bilgisi bulunamadı. Dönem ve sınav bilgilerini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var oturumlar = donemveSinavlar.Oturumlar.Where(x => x.SinavId == Bellek.SeciliSinav.Id).ToList();

            if (!DizinIslemleri.DosyaKontrol(Bellek.BranslarFilename))
            {
                MessageBox.Show("Ders listesi bulunamadı. Ders listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            var branslarGet = json.GetListJsonFile<TestBransInfo>(Bellek.BranslarFilename);
            if (branslarGet.Count == 0)
            {
                Close();
                MessageBox.Show("Ders listesi bulunamadı. Ders listesini indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DizinIslemleri.DosyaKontrol(Bellek.SorularFileNameGet(Bellek.SeciliSinav.Id)))
            {
                Close();
                MessageBox.Show("Sorular listesi bulunamadı. Soruları indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<TestSorularInfo> sorularList = json.GetListJsonFile<TestSorularInfo>(Bellek.SorularFileNameGet(Bellek.SeciliSinav.Id));
            if (sorularList.Count == 0)
            {
                Close();
                MessageBox.Show("Sorular listesi bulunamadı. Soruları indiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int a = 0;
            List<TestSorularViewModel> sorular = new List<TestSorularViewModel>();

            foreach (var otr in oturumlar.Where(x => x.SinavId == Bellek.SeciliSinav.Id).OrderBy(x => x.SiraNo))
            {
                foreach (var item in sorularList.Where(x => x.OturumId == otr.Id).OrderBy(x => x.SoruNo).ToList())
                {
                    a++;
                    sorular.Add(new TestSorularViewModel()
                    {
                        Id = a,
                        SoruNo = item.SoruNo,
                        Cevap = item.Cevap,
                        DersAdi = branslarGet.Find(x => x.Id == item.BransId).BransAdi,
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
    }
}

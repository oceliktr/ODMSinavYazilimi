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
    public partial class FormDersler : Form
    {
        public FormDersler()
        {
            InitializeComponent();
        }

        private void FormDersler_Load(object sender, EventArgs e)
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
            dgBranslar.Columns[1].HeaderText = "Katsayı";
            dgBranslar.Columns[1].Width = 50;
            dgBranslar.Columns[2].HeaderText = "Ders Adı";
            dgBranslar.Columns[2].Width = 200;
        }
    }
}

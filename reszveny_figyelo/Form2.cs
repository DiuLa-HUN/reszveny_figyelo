using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;

namespace reszveny_figyelo
{
    public partial class frm_ujreszveny : Form
    {

        public frm_ujreszveny()
        {
            InitializeComponent();
            tb_nev.Tag = "Név";
            tb_azonosito.Tag = "Azonosító";
            tb_ar.Tag = "Ár";
            tb_db.Tag = "Darab";
            tb_oszt.Tag = "Osztalék";
            tb_dev.Tag = "Deviza";
        }

        private void Placeholder_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.Text == tb.Tag.ToString())
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void Placeholder_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = Color.Gray;
            }
        }

        private void bt_mentes_Click(object sender, EventArgs e)
        {
            if (tb_nev.Text == "Név" || tb_azonosito.Text == "Azonosító" || tb_ar.Text == "Ár" ||
                tb_db.Text == "Darab" || tb_oszt.Text == "Osztalék" || tb_dev.Text == "Deviza")
            {
                MessageBox.Show("Kérlek, töltsd ki az összes mezőt!");
                return;
            }
            else
            {
                try
                {
                    string ujID = Guid.NewGuid().ToString();
                    string ujSor = string.Join(";",
                        ujID,
                        tb_nev.Text,
                        tb_azonosito.Text,
                        double.Parse(tb_ar.Text, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture),
                        double.Parse(tb_ar.Text, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture),
                        tb_db.Text,
                        double.Parse(tb_oszt.Text, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture),
                        tb_dev.Text,
                        DateTime.Now.ToString("yyyy.MM.dd HH:mm")
                    );

                    using (StreamWriter sw = new StreamWriter("Részvények.csv", append: true, Encoding.UTF8))
                    {
                        sw.WriteLine(ujSor);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a mentés során:\n" + ex.Message);
                }
            }
        }

        private void frm_ujreszveny_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb && tb.Tag != null)
                {
                    tb.Text = tb.Tag.ToString();
                    tb.ForeColor = Color.Gray;
                }
            }
        }

        private void frm_ujreszveny_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
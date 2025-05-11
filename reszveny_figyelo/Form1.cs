using System.Text.Json;
using System.Globalization;
using System.Text;
using System.Diagnostics;

namespace reszveny_figyelo
{
    public partial class frm_foablak : Form
    {
        public frm_foablak()
        {
            InitializeComponent();
        }

        Process pythonServer;

        //Python server az árfolyamok lekérdezéséhez
        private void StartPythonServer()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\zghun\AppData\Local\Programs\Python\Python313\python.exe";
            start.Arguments = "server.py";
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;

            pythonServer = new Process();
            pythonServer.StartInfo = start;
            pythonServer.Start();
        }
        //A fõablak betöltésekor már betölti a .csv-ben tárolt adatokat
        private async void frm_foablak_Load(object sender, EventArgs e)
        {
            StartPythonServer();
            BetoltReszvenyek();
        }

        //Data Grid cellaformázása
        private void dgw_reszvenyek_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgw_reszvenyek.Columns[e.ColumnIndex].Name == "Kulonbseg" && e.Value != null)
            {
                string ertekSzoveg = e.Value.ToString().Replace("%", "").Trim();
                if (double.TryParse(ertekSzoveg, out double ertek))
                {
                    if (ertek >= 100)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
            }

            if (dgw_reszvenyek.Columns[e.ColumnIndex].Name == "Nev" && e.RowIndex >= 0)
            {
                string deviza = dgw_reszvenyek.Rows[e.RowIndex].Cells["Deviza"].Value?.ToString();

                switch (deviza)
                {
                    case "HUF":
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case "USD":
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                    case "GBP":
                        e.CellStyle.ForeColor = Color.LightSkyBlue;
                        break;
                    case "EUR":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        //Részvény keresés, hogy megtudjuk az árfolyamot
        private async void bt_kereses_Click(object sender, EventArgs e)
        {
            string ticker = tb_reszveny_kereso.Text.Trim();
            double? aktualisAr = await LekerdezArfolyamAsync(ticker);
            if (aktualisAr.HasValue)
                tb_reszveny_arfolyam.Text = aktualisAr.Value.ToString();
        }

        public async Task<double?> LekerdezArfolyamAsync(string ticker)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"http://127.0.0.1:5000/api/arfolyam?ticker={ticker}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        ArfolyamValasz data = JsonSerializer.Deserialize<ArfolyamValasz>(json);

                        return data?.arfolyam;
                    }
                    else
                    {
                        MessageBox.Show("Hiba a lekérdezés során.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
                return null;
            }
        }

        //A lekérdezés gomb, lekérdez... :)
        private async void bt_lekerdezes_Click(object sender, EventArgs e)
        {
            if (dgw_reszvenyek.SelectedRows.Count == 0 && dgw_reszvenyek.SelectedRows.Count > 1)
                return;
            string ticker = dgw_reszvenyek.SelectedRows[0].Cells["Azonosito"].Value.ToString();

            double? aktualisAr = await LekerdezArfolyamAsync(ticker);

            if (aktualisAr.HasValue)
            {
                dgw_reszvenyek.SelectedRows[0].Cells["Arfolyam"].Value = aktualisAr.Value;
                dgw_reszvenyek.SelectedRows[0].Cells["UtolsolekDatum"].Value = DateTime.Now.ToString("yyyy.MM.dd HH:mm");
                MentsdFrissitettCsvt();
                BetoltReszvenyek();
            }
        }

        //Menti a .csv fájlba az új adatokat
        private void MentsdFrissitettCsvt()
        {
            string csvFilePath = @"Részvények.csv";

            List<string> sorok = new List<string>();

            foreach (DataGridViewRow row in dgw_reszvenyek.Rows)
            {
                if (!row.IsNewRow)
                {
                    string id = row.Cells["ID"].Value?.ToString() ?? "";
                    string nev = row.Cells["Nev"].Value?.ToString() ?? "";
                    string azonosito = row.Cells["Azonosito"].Value?.ToString() ?? "";
                    string veteli = Convert.ToDouble(row.Cells["VeteliArfolyam"].Value).ToString(CultureInfo.InvariantCulture);
                    string utolso = Convert.ToDouble(row.Cells["Arfolyam"].Value).ToString(CultureInfo.InvariantCulture);
                    string darab = row.Cells["DB"].Value?.ToString() ?? "";
                    string osztalek = Convert.ToDouble(row.Cells["Osztalek"].Value).ToString(CultureInfo.InvariantCulture);
                    string deviza = row.Cells["Deviza"].Value?.ToString() ?? "";
                    string datum = row.Cells["UtolsoLekDatum"].Value?.ToString() ?? "";

                    string sor = $"{id};{nev};{azonosito};{veteli};{utolso};{darab};{osztalek};{deviza};{datum}";
                    sorok.Add(sor);
                }
            }
            File.WriteAllLines(csvFilePath, sorok, Encoding.UTF8);
        }

        //Ha van kijelölt elem a Data Grid-ben, akkor aktív a lekérdezés gomb
        private void dgw_reszvenyek_SelectionChanged(object sender, EventArgs e)
        {
            bt_lekerdezes.Enabled = dgw_reszvenyek.SelectedRows.Count > 0 && dgw_reszvenyek.SelectedRows.Count < 2;
            bt_torles.Enabled = dgw_reszvenyek.SelectedRows.Count > 0 && dgw_reszvenyek.SelectedRows.Count < 2;
        }

        //Leállítja a python servert, amikor bezárjuk a programot
        private void frm_foablak_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pythonServer != null && !pythonServer.HasExited)
            {
                pythonServer.Kill();
            }
        }

        private void BetoltReszvenyek()
        {
            List<Reszveny> Reszvenyek = new List<Reszveny>();
            
            // .csv fájl kiolvasás
            try
            {
                using (StreamReader sr = new StreamReader("Részvények.csv", System.Text.Encoding.UTF8))
                {
                    string sor;
                    while ((sor = sr.ReadLine()) != null)
                    {
                        try
                        {
                            Reszveny ujreszveny = new Reszveny(sor);
                            Reszvenyek.Add(ujreszveny);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba a sor feldolgozásakor: " + sor + "\n" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a fájl feldolgozásában! Hibakód: " + ex.ToString());
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = Reszvenyek.OrderBy(x => x.Nev).ToList();

            dgw_reszvenyek.DataSource = null;
            dgw_reszvenyek.DataSource = bs;
            dgw_reszvenyek.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_reszvenyek.CellFormatting += dgw_reszvenyek_CellFormatting;
            dgw_reszvenyek.Columns["ID"].Visible = false;
            dgw_reszvenyek.Columns.Remove("Arfolyamk");
        }

        private void tb_reszveny_kereso_Enter(object sender, EventArgs e)
        {
            if (tb_reszveny_kereso.Text == "Részvény neve")
            {
                tb_reszveny_kereso.Text = "";
            }
        }

        private void tb_reszveny_kereso_Leave(object sender, EventArgs e)
        {
            if (tb_reszveny_kereso.Text == "")
            {
                tb_reszveny_kereso.Text = "Részvény neve";
            }
        }

        private void tb_reszveny_arfolyam_Enter(object sender, EventArgs e)
        {
            if (tb_reszveny_arfolyam.Text == "Árfolyam")
            {
                tb_reszveny_arfolyam.Text = "";
            }
        }

        private void tb_reszveny_arfolyam_Leave(object sender, EventArgs e)
        {
            if (tb_reszveny_arfolyam.Text == "")
            {
                tb_reszveny_arfolyam.Text = "Árfolyam";
            }
        }

        private void bt_ujreszveny_Click(object sender, EventArgs e)
        {
            frm_ujreszveny ujReszvenyForm = new frm_ujreszveny();
            if (ujReszvenyForm.ShowDialog() == DialogResult.OK)
            {
                BetoltReszvenyek();
            }
        }

        private void bt_torles_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Biztosan törölni szeretnéd a kiválasztott részvényt?", "Megerõsítés", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            // A kiválasztott részvény lekérése
            Reszveny kivalasztott = (Reszveny)dgw_reszvenyek.SelectedRows[0].DataBoundItem;

            // Beolvassuk újra az összes sort a fájlból, kivéve amit törölni akarunk
            List<string> megmaradtSorok = new List<string>();



            
            using (StreamReader sr = new StreamReader("Részvények.csv", System.Text.Encoding.UTF8))
            {
                string sor;
                while ((sor = sr.ReadLine()) != null)
                {
                    try
                    {
                        Reszveny r = new Reszveny(sor);

                        // Akkor adjuk hozzá, ha nem az a sor, amit törölni akarunk
                        if (!(r.ID == kivalasztott.ID))
                        {
                            megmaradtSorok.Add(sor);
                        }
                    }
                    catch { /* Hibás sort kihagyhatjuk vagy logolhatjuk */ }
                }
            }

            
            File.WriteAllLines("Részvények.csv", megmaradtSorok, System.Text.Encoding.UTF8);  // Visszaírjuk a megmaradt sorokat a fájlba

            // Újratöltjük a DataGridView-t
            BetoltReszvenyek();
        }
    }

    //Itt rakódik össze a tömb a Data Gridhez
    public class Reszveny
    {
        public string ID { get; set; }

        public string Nev { get; set; }

        public string Azonosito { get; set; }

        public double VeteliArfolyam { get; set; }

        public double Arfolyam { get; set; }

        public string DB { get; set; }

        public double Osztalek { get; set; }

        public string Deviza { get; set; }

        public double Arfolyamk { get; set; }

        public string Kulonbseg
        {
            get
            {
                return Arfolyamk.ToString("0.00") + " %";
            }
        }
        public string UtolsoLekDatum { get; set; }

        public Reszveny(string sor) {
            string[] adatmezok = sor.Split(';');
            ID = adatmezok[0];
            Nev = adatmezok[1];
            Azonosito = adatmezok[2];
            VeteliArfolyam = double.Parse(adatmezok[3], CultureInfo.InvariantCulture);
            Arfolyam = double.Parse(adatmezok[4], CultureInfo.InvariantCulture);
            DB = adatmezok[5];
            Osztalek = double.Parse(adatmezok[6], CultureInfo.InvariantCulture);
            Deviza = adatmezok[7];
            UtolsoLekDatum = adatmezok[8];
            FrissitArfolyamKulonbseg();
        }

        public void FrissitArfolyamKulonbseg()
        {
            if (double.TryParse(VeteliArfolyam.ToString(), out double veteli) &&
                double.TryParse(Arfolyam.ToString(), out double utolso))
            {
                Arfolyamk = (utolso / veteli) * 100;
            }
        }
    }

    public class ArfolyamValasz
    {
        public string ticker { get; set; }
        public double arfolyam { get; set; }
    }
}
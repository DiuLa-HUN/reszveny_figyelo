using System;
using System.Windows.Forms;

public partial class FrmBetoltes : Form
{
    private int pontSzamlalo = 0;
    private string alapSzoveg = "Lekérdezés folyamatban";

    public FrmBetoltes()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Width = 100;
        this.Height = 50;
        this.ControlBox = false;

        Label lblStatus = new Label();
        lblStatus.Name = "lblStatus";
        lblStatus.AutoSize = false;
        lblStatus.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus.Dock = DockStyle.Fill;
        lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        this.Controls.Add(lblStatus);

        Timer timer = new Timer();
        timer.Interval = 200; // 0.2 másodperc
        timer.Tick += (s, e) =>
        {
            pontSzamlalo = (pontSzamlalo + 1) % 4; // 0, 1, 2, 3
            string pontok = new string('.', pontSzamlalo);
            lblStatus.Text = alapSzoveg + pontok;
        };
        timer.Start();
    }
}
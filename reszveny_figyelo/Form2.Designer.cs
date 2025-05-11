namespace reszveny_figyelo
{
    partial class frm_ujreszveny
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_nev = new TextBox();
            tb_azonosito = new TextBox();
            tb_ar = new TextBox();
            tb_db = new TextBox();
            tb_oszt = new TextBox();
            tb_dev = new TextBox();
            bt_mentes = new Button();
            SuspendLayout();
            // 
            // tb_nev
            // 
            tb_nev.Location = new Point(12, 12);
            tb_nev.Name = "tb_nev";
            tb_nev.Size = new Size(100, 23);
            tb_nev.TabIndex = 0;
            tb_nev.Text = "Név";
            tb_nev.Enter += Placeholder_Enter;
            tb_nev.Leave += Placeholder_Leave;
            // 
            // tb_azonosito
            // 
            tb_azonosito.Location = new Point(118, 12);
            tb_azonosito.Name = "tb_azonosito";
            tb_azonosito.Size = new Size(100, 23);
            tb_azonosito.TabIndex = 1;
            tb_azonosito.Text = "Azonosító";
            tb_azonosito.Enter += Placeholder_Enter;
            tb_azonosito.Leave += Placeholder_Leave;
            // 
            // tb_ar
            // 
            tb_ar.Location = new Point(224, 12);
            tb_ar.Name = "tb_ar";
            tb_ar.Size = new Size(100, 23);
            tb_ar.TabIndex = 2;
            tb_ar.Text = "Ár";
            tb_ar.Enter += Placeholder_Enter;
            tb_ar.Leave += Placeholder_Leave;
            // 
            // tb_db
            // 
            tb_db.Location = new Point(12, 41);
            tb_db.Name = "tb_db";
            tb_db.Size = new Size(100, 23);
            tb_db.TabIndex = 3;
            tb_db.Text = "Darab";
            tb_db.Enter += Placeholder_Enter;
            tb_db.Leave += Placeholder_Leave;
            // 
            // tb_oszt
            // 
            tb_oszt.Location = new Point(118, 41);
            tb_oszt.Name = "tb_oszt";
            tb_oszt.Size = new Size(100, 23);
            tb_oszt.TabIndex = 4;
            tb_oszt.Text = "Osztalék";
            tb_oszt.Enter += Placeholder_Enter;
            tb_oszt.Leave += Placeholder_Leave;
            // 
            // tb_dev
            // 
            tb_dev.Location = new Point(224, 41);
            tb_dev.Name = "tb_dev";
            tb_dev.Size = new Size(100, 23);
            tb_dev.TabIndex = 5;
            tb_dev.Text = "Deviza";
            tb_dev.Enter += Placeholder_Enter;
            tb_dev.Leave += Placeholder_Leave;
            // 
            // bt_mentes
            // 
            bt_mentes.Location = new Point(12, 70);
            bt_mentes.Name = "bt_mentes";
            bt_mentes.Size = new Size(312, 29);
            bt_mentes.TabIndex = 6;
            bt_mentes.Text = "Metés";
            bt_mentes.UseVisualStyleBackColor = true;
            bt_mentes.Click += bt_mentes_Click;
            // 
            // frm_ujreszveny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 111);
            Controls.Add(bt_mentes);
            Controls.Add(tb_dev);
            Controls.Add(tb_oszt);
            Controls.Add(tb_db);
            Controls.Add(tb_ar);
            Controls.Add(tb_azonosito);
            Controls.Add(tb_nev);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frm_ujreszveny";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Új részvény hozzáadása";
            FormClosing += frm_ujreszveny_FormClosing;
            Load += frm_ujreszveny_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_nev;
        private TextBox tb_azonosito;
        private TextBox tb_ar;
        private TextBox tb_db;
        private TextBox tb_oszt;
        private TextBox tb_dev;
        private Button bt_mentes;
    }
}
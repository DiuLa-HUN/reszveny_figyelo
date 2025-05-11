namespace reszveny_figyelo
{
    partial class frm_foablak
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_reszveny_kereso = new TextBox();
            bt_kereses = new Button();
            tb_reszveny_arfolyam = new TextBox();
            lb_folyamat = new Label();
            lb_reszvenyeim = new Label();
            dgw_reszvenyek = new DataGridView();
            bt_lekerdezes = new Button();
            bt_ujreszveny = new Button();
            bt_torles = new Button();
            tb_hufbef = new TextBox();
            lb_hufbef = new Label();
            lb_hufjelenlegi = new Label();
            tb_hufjelenlegi = new TextBox();
            lb_gbp = new Label();
            lb_usd = new Label();
            lb_huf = new Label();
            tb_gbp = new TextBox();
            tb_usd = new TextBox();
            tb_huf = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgw_reszvenyek).BeginInit();
            SuspendLayout();
            // 
            // tb_reszveny_kereso
            // 
            tb_reszveny_kereso.Location = new Point(12, 12);
            tb_reszveny_kereso.Name = "tb_reszveny_kereso";
            tb_reszveny_kereso.Size = new Size(100, 23);
            tb_reszveny_kereso.TabIndex = 0;
            tb_reszveny_kereso.Text = "Részvény neve";
            tb_reszveny_kereso.Enter += tb_reszveny_kereso_Enter;
            tb_reszveny_kereso.Leave += tb_reszveny_kereso_Leave;
            // 
            // bt_kereses
            // 
            bt_kereses.Location = new Point(118, 12);
            bt_kereses.Name = "bt_kereses";
            bt_kereses.Size = new Size(75, 23);
            bt_kereses.TabIndex = 1;
            bt_kereses.Text = "Keresés";
            bt_kereses.UseVisualStyleBackColor = true;
            bt_kereses.Click += bt_kereses_Click;
            // 
            // tb_reszveny_arfolyam
            // 
            tb_reszveny_arfolyam.Location = new Point(12, 41);
            tb_reszveny_arfolyam.Name = "tb_reszveny_arfolyam";
            tb_reszveny_arfolyam.Size = new Size(100, 23);
            tb_reszveny_arfolyam.TabIndex = 3;
            tb_reszveny_arfolyam.Text = "Árfolyam";
            tb_reszveny_arfolyam.Enter += tb_reszveny_arfolyam_Enter;
            tb_reszveny_arfolyam.Leave += tb_reszveny_arfolyam_Leave;
            // 
            // lb_folyamat
            // 
            lb_folyamat.AutoSize = true;
            lb_folyamat.Location = new Point(12, 38);
            lb_folyamat.Name = "lb_folyamat";
            lb_folyamat.Size = new Size(0, 15);
            lb_folyamat.TabIndex = 4;
            // 
            // lb_reszvenyeim
            // 
            lb_reszvenyeim.AutoSize = true;
            lb_reszvenyeim.Location = new Point(12, 115);
            lb_reszvenyeim.Name = "lb_reszvenyeim";
            lb_reszvenyeim.Size = new Size(98, 15);
            lb_reszvenyeim.TabIndex = 5;
            lb_reszvenyeim.Text = "Saját Részvények:";
            // 
            // dgw_reszvenyek
            // 
            dgw_reszvenyek.AllowUserToOrderColumns = true;
            dgw_reszvenyek.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgw_reszvenyek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgw_reszvenyek.Location = new Point(12, 133);
            dgw_reszvenyek.Name = "dgw_reszvenyek";
            dgw_reszvenyek.RowHeadersWidth = 30;
            dgw_reszvenyek.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgw_reszvenyek.Size = new Size(860, 316);
            dgw_reszvenyek.TabIndex = 6;
            dgw_reszvenyek.SelectionChanged += dgw_reszvenyek_SelectionChanged;
            // 
            // bt_lekerdezes
            // 
            bt_lekerdezes.Enabled = false;
            bt_lekerdezes.Location = new Point(116, 107);
            bt_lekerdezes.Name = "bt_lekerdezes";
            bt_lekerdezes.Size = new Size(140, 23);
            bt_lekerdezes.TabIndex = 7;
            bt_lekerdezes.Text = "Lekérdezés";
            bt_lekerdezes.UseVisualStyleBackColor = true;
            bt_lekerdezes.Click += bt_lekerdezes_Click;
            // 
            // bt_ujreszveny
            // 
            bt_ujreszveny.Location = new Point(262, 107);
            bt_ujreszveny.Name = "bt_ujreszveny";
            bt_ujreszveny.Size = new Size(140, 23);
            bt_ujreszveny.TabIndex = 8;
            bt_ujreszveny.Text = "Új részvény hozzáadása";
            bt_ujreszveny.UseVisualStyleBackColor = true;
            bt_ujreszveny.Click += bt_ujreszveny_Click;
            // 
            // bt_torles
            // 
            bt_torles.Enabled = false;
            bt_torles.Location = new Point(408, 107);
            bt_torles.Name = "bt_torles";
            bt_torles.Size = new Size(126, 23);
            bt_torles.TabIndex = 9;
            bt_torles.Text = "Részvény törlése";
            bt_torles.UseVisualStyleBackColor = true;
            bt_torles.Click += bt_torles_Click;
            // 
            // tb_hufbef
            // 
            tb_hufbef.Enabled = false;
            tb_hufbef.Location = new Point(341, 12);
            tb_hufbef.Name = "tb_hufbef";
            tb_hufbef.Size = new Size(100, 23);
            tb_hufbef.TabIndex = 10;
            // 
            // lb_hufbef
            // 
            lb_hufbef.AutoSize = true;
            lb_hufbef.Location = new Point(199, 15);
            lb_hufbef.Name = "lb_hufbef";
            lb_hufbef.Size = new Size(128, 15);
            lb_hufbef.TabIndex = 11;
            lb_hufbef.Text = "Befektetések forintban:";
            // 
            // lb_hufjelenlegi
            // 
            lb_hufjelenlegi.AutoSize = true;
            lb_hufjelenlegi.Location = new Point(199, 44);
            lb_hufjelenlegi.Name = "lb_hufjelenlegi";
            lb_hufjelenlegi.Size = new Size(136, 15);
            lb_hufjelenlegi.TabIndex = 12;
            lb_hufjelenlegi.Text = "Jelenlegi érték forintban:";
            // 
            // tb_hufjelenlegi
            // 
            tb_hufjelenlegi.Enabled = false;
            tb_hufjelenlegi.Location = new Point(341, 41);
            tb_hufjelenlegi.Name = "tb_hufjelenlegi";
            tb_hufjelenlegi.Size = new Size(100, 23);
            tb_hufjelenlegi.TabIndex = 13;
            // 
            // lb_gbp
            // 
            lb_gbp.AutoSize = true;
            lb_gbp.Location = new Point(447, 15);
            lb_gbp.Name = "lb_gbp";
            lb_gbp.Size = new Size(61, 15);
            lb_gbp.TabIndex = 14;
            lb_gbp.Text = "Érték GBP:";
            // 
            // lb_usd
            // 
            lb_usd.AutoSize = true;
            lb_usd.Location = new Point(447, 44);
            lb_usd.Name = "lb_usd";
            lb_usd.Size = new Size(61, 15);
            lb_usd.TabIndex = 15;
            lb_usd.Text = "Érték USD:";
            // 
            // lb_huf
            // 
            lb_huf.AutoSize = true;
            lb_huf.Location = new Point(447, 73);
            lb_huf.Name = "lb_huf";
            lb_huf.Size = new Size(62, 15);
            lb_huf.TabIndex = 16;
            lb_huf.Text = "Érték HUF:";
            // 
            // tb_gbp
            // 
            tb_gbp.Enabled = false;
            tb_gbp.Location = new Point(514, 12);
            tb_gbp.Name = "tb_gbp";
            tb_gbp.Size = new Size(100, 23);
            tb_gbp.TabIndex = 17;
            // 
            // tb_usd
            // 
            tb_usd.Enabled = false;
            tb_usd.Location = new Point(514, 41);
            tb_usd.Name = "tb_usd";
            tb_usd.Size = new Size(100, 23);
            tb_usd.TabIndex = 18;
            // 
            // tb_huf
            // 
            tb_huf.Enabled = false;
            tb_huf.Location = new Point(514, 70);
            tb_huf.Name = "tb_huf";
            tb_huf.Size = new Size(100, 23);
            tb_huf.TabIndex = 19;
            // 
            // frm_foablak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 461);
            Controls.Add(tb_huf);
            Controls.Add(tb_usd);
            Controls.Add(tb_gbp);
            Controls.Add(lb_huf);
            Controls.Add(lb_usd);
            Controls.Add(lb_gbp);
            Controls.Add(tb_hufjelenlegi);
            Controls.Add(lb_hufjelenlegi);
            Controls.Add(lb_hufbef);
            Controls.Add(tb_hufbef);
            Controls.Add(bt_torles);
            Controls.Add(bt_ujreszveny);
            Controls.Add(bt_lekerdezes);
            Controls.Add(dgw_reszvenyek);
            Controls.Add(lb_reszvenyeim);
            Controls.Add(lb_folyamat);
            Controls.Add(tb_reszveny_arfolyam);
            Controls.Add(bt_kereses);
            Controls.Add(tb_reszveny_kereso);
            MaximizeBox = false;
            MinimumSize = new Size(900, 500);
            Name = "frm_foablak";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Részvény figyelő v1.0";
            FormClosing += frm_foablak_FormClosing;
            Load += frm_foablak_Load;
            ((System.ComponentModel.ISupportInitialize)dgw_reszvenyek).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_reszveny_kereso;
        private Button bt_kereses;
        private TextBox tb_reszveny_neve1;
        private TextBox tb_reszveny_arfolyam;
        private Label lb_folyamat;
        private Label lb_reszvenyeim;
        private TextBox tb_reszveny_v_arf1;
        private Label lb_reszveny_neve;
        private Label lb_reszveny_v_arf;
        private TextBox tb_reszveny_lu_lek_arf1;
        private Label lb_reszveny_leg_lek_arf;
        private TextBox tb_reszveny_szazalek1;
        private Label lb_reszveny_szazalek;
        private TextBox tb_reszveny_osztalek1;
        private Label lb_reszveny_osztalek;
        private TextBox tb_reszveny_deviza1;
        private Label lb_reszveny_deviza;
        private DataGridView dgw_reszvenyek;
        private Button bt_lekerdezes;
        private Button bt_ujreszveny;
        private Button bt_torles;
        private TextBox tb_hufbef;
        private Label lb_hufbef;
        private Label lb_hufjelenlegi;
        private TextBox tb_hufjelenlegi;
        private Label lb_gbp;
        private Label lb_usd;
        private Label lb_huf;
        private TextBox tb_gbp;
        private TextBox tb_usd;
        private TextBox tb_huf;
    }
}

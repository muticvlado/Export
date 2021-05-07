namespace IzvozKalkulacija_MPP2
{
    partial class Izvoz
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOd = new System.Windows.Forms.TextBox();
            this.txtDo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIzvezi = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dgwZaglavlja = new System.Windows.Forms.DataGridView();
            this.dgwStavke = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUcitaj = new System.Windows.Forms.Button();
            this.bsZaglavlje = new System.Windows.Forms.BindingSource(this.components);
            this.bsStavke = new System.Windows.Forms.BindingSource(this.components);
            this.bsPartneri = new System.Windows.Forms.BindingSource(this.components);
            this.tbPutanja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPlus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIzvoz = new System.Windows.Forms.TextBox();
            this.btnLokacijaIzvoz = new System.Windows.Forms.Button();
            this.openFileDialogIzvoz = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogIzvoz = new System.Windows.Forms.FolderBrowserDialog();
            this.tbProdavnica = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwZaglavlja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsZaglavlje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartneri)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj kalkulacije";
            // 
            // txtOd
            // 
            this.txtOd.Location = new System.Drawing.Point(112, 10);
            this.txtOd.Name = "txtOd";
            this.txtOd.Size = new System.Drawing.Size(100, 20);
            this.txtOd.TabIndex = 2;
            // 
            // txtDo
            // 
            this.txtDo.Location = new System.Drawing.Point(668, 13);
            this.txtDo.Name = "txtDo";
            this.txtDo.Size = new System.Drawing.Size(100, 20);
            this.txtDo.TabIndex = 4;
            this.txtDo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do kalkulacije broj";
            this.label2.Visible = false;
            // 
            // btnIzvezi
            // 
            this.btnIzvezi.Location = new System.Drawing.Point(352, 8);
            this.btnIzvezi.Name = "btnIzvezi";
            this.btnIzvezi.Size = new System.Drawing.Size(75, 24);
            this.btnIzvezi.TabIndex = 8;
            this.btnIzvezi.Text = "Izvezi";
            this.btnIzvezi.UseVisualStyleBackColor = true;
            this.btnIzvezi.Click += new System.EventHandler(this.btnIzvezi_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Izaberite bazu";
            // 
            // dgwZaglavlja
            // 
            this.dgwZaglavlja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwZaglavlja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgwZaglavlja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwZaglavlja.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgwZaglavlja.Location = new System.Drawing.Point(15, 111);
            this.dgwZaglavlja.Name = "dgwZaglavlja";
            this.dgwZaglavlja.Size = new System.Drawing.Size(757, 112);
            this.dgwZaglavlja.TabIndex = 6;
            // 
            // dgwStavke
            // 
            this.dgwStavke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwStavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgwStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwStavke.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwStavke.Location = new System.Drawing.Point(15, 243);
            this.dgwStavke.Name = "dgwStavke";
            this.dgwStavke.Size = new System.Drawing.Size(757, 203);
            this.dgwStavke.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Zaglavlja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stavke";
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.Location = new System.Drawing.Point(272, 8);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Size = new System.Drawing.Size(75, 24);
            this.btnUcitaj.TabIndex = 6;
            this.btnUcitaj.Text = "Učitaj";
            this.btnUcitaj.UseVisualStyleBackColor = true;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // tbPutanja
            // 
            this.tbPutanja.Location = new System.Drawing.Point(112, 38);
            this.tbPutanja.Name = "tbPutanja";
            this.tbPutanja.Size = new System.Drawing.Size(656, 20);
            this.tbPutanja.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Putanja do baze";
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(218, 8);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(31, 24);
            this.btnPlus.TabIndex = 12;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Folder za izvoz";
            // 
            // tbIzvoz
            // 
            this.tbIzvoz.Location = new System.Drawing.Point(112, 64);
            this.tbIzvoz.Name = "tbIzvoz";
            this.tbIzvoz.Size = new System.Drawing.Size(532, 20);
            this.tbIzvoz.TabIndex = 13;
            // 
            // btnLokacijaIzvoz
            // 
            this.btnLokacijaIzvoz.Location = new System.Drawing.Point(650, 62);
            this.btnLokacijaIzvoz.Name = "btnLokacijaIzvoz";
            this.btnLokacijaIzvoz.Size = new System.Drawing.Size(118, 23);
            this.btnLokacijaIzvoz.TabIndex = 15;
            this.btnLokacijaIzvoz.Text = "Folder za izvoz";
            this.btnLokacijaIzvoz.UseVisualStyleBackColor = true;
            this.btnLokacijaIzvoz.Click += new System.EventHandler(this.btnLokacijaIzvoz_Click);
            // 
            // openFileDialogIzvoz
            // 
            this.openFileDialogIzvoz.Title = "Izaberite lokaciju za izvoz kalkulacija";
            // 
            // tbProdavnica
            // 
            this.tbProdavnica.Location = new System.Drawing.Point(502, 12);
            this.tbProdavnica.Name = "tbProdavnica";
            this.tbProdavnica.Size = new System.Drawing.Size(46, 20);
            this.tbProdavnica.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Prodavnica";
            // 
            // Izvoz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 458);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbProdavnica);
            this.Controls.Add(this.btnLokacijaIzvoz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbIzvoz);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPutanja);
            this.Controls.Add(this.btnUcitaj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgwStavke);
            this.Controls.Add(this.dgwZaglavlja);
            this.Controls.Add(this.btnIzvezi);
            this.Controls.Add(this.txtDo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOd);
            this.Controls.Add(this.label1);
            this.Name = "Izvoz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izvoz kalkulacija";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgwZaglavlja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsZaglavlje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartneri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOd;
        private System.Windows.Forms.TextBox txtDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIzvezi;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dgwZaglavlja;
        private System.Windows.Forms.DataGridView dgwStavke;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUcitaj;
        private System.Windows.Forms.BindingSource bsZaglavlje;
        private System.Windows.Forms.BindingSource bsStavke;
        private System.Windows.Forms.BindingSource bsPartneri;
        private System.Windows.Forms.TextBox tbPutanja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbIzvoz;
        private System.Windows.Forms.Button btnLokacijaIzvoz;
        private System.Windows.Forms.OpenFileDialog openFileDialogIzvoz;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogIzvoz;
        private System.Windows.Forms.TextBox tbProdavnica;
        private System.Windows.Forms.Label label7;
    }
}


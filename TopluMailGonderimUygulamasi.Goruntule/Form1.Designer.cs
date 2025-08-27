namespace TopluMailGonderimUygulamasi.Goruntule
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grd_musteri = new System.Windows.Forms.DataGridView();
            this.btn_ornek_data = new System.Windows.Forms.Button();
            this.btn_yenile = new System.Windows.Forms.Button();
            this.btn_kuponTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_musteri)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grd_musteri);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Müşteri Kayıt Listesi Oluştur ";
            // 
            // grd_musteri
            // 
            this.grd_musteri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_musteri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_musteri.Location = new System.Drawing.Point(3, 18);
            this.grd_musteri.Name = "grd_musteri";
            this.grd_musteri.RowHeadersWidth = 51;
            this.grd_musteri.RowTemplate.Height = 24;
            this.grd_musteri.Size = new System.Drawing.Size(1032, 385);
            this.grd_musteri.TabIndex = 0;
            // 
            // btn_ornek_data
            // 
            this.btn_ornek_data.Location = new System.Drawing.Point(12, 424);
            this.btn_ornek_data.Name = "btn_ornek_data";
            this.btn_ornek_data.Size = new System.Drawing.Size(736, 23);
            this.btn_ornek_data.TabIndex = 0;
            this.btn_ornek_data.Text = "Örnek Data Oluştur";
            this.btn_ornek_data.UseVisualStyleBackColor = true;
            this.btn_ornek_data.Click += new System.EventHandler(this.btn_ornek_data_Click);
            // 
            // btn_yenile
            // 
            this.btn_yenile.Location = new System.Drawing.Point(754, 424);
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.Size = new System.Drawing.Size(296, 23);
            this.btn_yenile.TabIndex = 1;
            this.btn_yenile.Text = "Yenile";
            this.btn_yenile.UseVisualStyleBackColor = true;
            this.btn_yenile.Click += new System.EventHandler(this.btn_yenile_Click);
            // 
            // btn_kuponTest
            // 
            this.btn_kuponTest.Location = new System.Drawing.Point(201, 454);
            this.btn_kuponTest.Name = "btn_kuponTest";
            this.btn_kuponTest.Size = new System.Drawing.Size(609, 23);
            this.btn_kuponTest.TabIndex = 2;
            this.btn_kuponTest.Text = "Metotlar Test";
            this.btn_kuponTest.UseVisualStyleBackColor = true;
            this.btn_kuponTest.Click += new System.EventHandler(this.btn_kuponTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 508);
            this.Controls.Add(this.btn_kuponTest);
            this.Controls.Add(this.btn_yenile);
            this.Controls.Add(this.btn_ornek_data);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_musteri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ornek_data;
        private System.Windows.Forms.Button btn_yenile;
        private System.Windows.Forms.DataGridView grd_musteri;
        private System.Windows.Forms.Button btn_kuponTest;
    }
}


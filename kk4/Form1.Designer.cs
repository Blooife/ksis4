namespace kk4
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
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.butOk = new System.Windows.Forms.Button();
            this.tbOut = new System.Windows.Forms.RichTextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.org = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(12, 192);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1112, 396);
            this.map.TabIndex = 0;
            this.map.Zoom = 0D;
            this.map.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(142, 139);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 1;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // tbOut
            // 
            this.tbOut.Location = new System.Drawing.Point(223, 12);
            this.tbOut.Name = "tbOut";
            this.tbOut.Size = new System.Drawing.Size(224, 150);
            this.tbOut.TabIndex = 2;
            this.tbOut.Text = "";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Num, this.IP, this.ms, this.dns, this.city, this.region, this.org });
            this.grid.Location = new System.Drawing.Point(453, 12);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(640, 150);
            this.grid.TabIndex = 4;
            // 
            // Num
            // 
            this.Num.HeaderText = "Num";
            this.Num.Name = "Num";
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            // 
            // ms
            // 
            this.ms.HeaderText = "ms";
            this.ms.Name = "ms";
            // 
            // dns
            // 
            this.dns.HeaderText = "dns";
            this.dns.Name = "dns";
            // 
            // city
            // 
            this.city.HeaderText = "city";
            this.city.Name = "city";
            // 
            // region
            // 
            this.region.HeaderText = "region";
            this.region.Name = "region";
            // 
            // org
            // 
            this.org.HeaderText = "org";
            this.org.Name = "org";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(99, 113);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(118, 20);
            this.tbIP.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 600);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.map);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tbIP;

        private System.Windows.Forms.DataGridViewTextBoxColumn org;

        private System.Windows.Forms.DataGridViewTextBoxColumn dns;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn region;

        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ms;

        private System.Windows.Forms.DataGridView grid;

        private System.Windows.Forms.RichTextBox tbOut;

        private System.Windows.Forms.Button butOk;

        private GMap.NET.WindowsForms.GMapControl map;

        #endregion
    }
}
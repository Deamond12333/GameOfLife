namespace TestingSoftwareLab1
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.start = new System.Windows.Forms.Button();
            this.glider = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.block = new System.Windows.Forms.PictureBox();
            this.blinker = new System.Windows.Forms.PictureBox();
            this.boat = new System.Windows.Forms.PictureBox();
            this.tub = new System.Windows.Forms.PictureBox();
            this.lwss = new System.Windows.Forms.PictureBox();
            this.mwss = new System.Windows.Forms.PictureBox();
            this.hwss = new System.Windows.Forms.PictureBox();
            this.field = new System.Windows.Forms.PictureBox();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.glider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blinker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lwss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mwss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hwss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.field)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.Location = new System.Drawing.Point(9, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(97, 34);
            this.start.TabIndex = 6;
            this.start.Text = "Start life";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // glider
            // 
            this.glider.Image = ((System.Drawing.Image)(resources.GetObject("glider.Image")));
            this.glider.Location = new System.Drawing.Point(9, 150);
            this.glider.Name = "glider";
            this.glider.Size = new System.Drawing.Size(30, 30);
            this.glider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.glider.TabIndex = 7;
            this.glider.TabStop = false;
            this.glider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Basic figures";
            // 
            // block
            // 
            this.block.Image = ((System.Drawing.Image)(resources.GetObject("block.Image")));
            this.block.Location = new System.Drawing.Point(79, 210);
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(20, 20);
            this.block.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.block.TabIndex = 9;
            this.block.TabStop = false;
            this.block.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // blinker
            // 
            this.blinker.Image = ((System.Drawing.Image)(resources.GetObject("blinker.Image")));
            this.blinker.Location = new System.Drawing.Point(69, 190);
            this.blinker.Name = "blinker";
            this.blinker.Size = new System.Drawing.Size(30, 10);
            this.blinker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.blinker.TabIndex = 10;
            this.blinker.TabStop = false;
            this.blinker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // boat
            // 
            this.boat.Image = ((System.Drawing.Image)(resources.GetObject("boat.Image")));
            this.boat.Location = new System.Drawing.Point(69, 150);
            this.boat.Name = "boat";
            this.boat.Size = new System.Drawing.Size(30, 30);
            this.boat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boat.TabIndex = 11;
            this.boat.TabStop = false;
            this.boat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // tub
            // 
            this.tub.Image = ((System.Drawing.Image)(resources.GetObject("tub.Image")));
            this.tub.Location = new System.Drawing.Point(117, 210);
            this.tub.Name = "tub";
            this.tub.Size = new System.Drawing.Size(30, 30);
            this.tub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tub.TabIndex = 12;
            this.tub.TabStop = false;
            this.tub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // lwss
            // 
            this.lwss.Image = ((System.Drawing.Image)(resources.GetObject("lwss.Image")));
            this.lwss.Location = new System.Drawing.Point(9, 190);
            this.lwss.Name = "lwss";
            this.lwss.Size = new System.Drawing.Size(50, 40);
            this.lwss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lwss.TabIndex = 13;
            this.lwss.TabStop = false;
            this.lwss.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // mwss
            // 
            this.mwss.Image = ((System.Drawing.Image)(resources.GetObject("mwss.Image")));
            this.mwss.Location = new System.Drawing.Point(9, 236);
            this.mwss.Name = "mwss";
            this.mwss.Size = new System.Drawing.Size(60, 50);
            this.mwss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mwss.TabIndex = 14;
            this.mwss.TabStop = false;
            this.mwss.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // hwss
            // 
            this.hwss.Image = ((System.Drawing.Image)(resources.GetObject("hwss.Image")));
            this.hwss.Location = new System.Drawing.Point(117, 150);
            this.hwss.Name = "hwss";
            this.hwss.Size = new System.Drawing.Size(70, 50);
            this.hwss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hwss.TabIndex = 15;
            this.hwss.TabStop = false;
            this.hwss.MouseDown += new System.Windows.Forms.MouseEventHandler(this.figure_MouseDown);
            // 
            // field
            // 
            this.field.BackColor = System.Drawing.Color.White;
            this.field.Location = new System.Drawing.Point(193, 12);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(751, 521);
            this.field.TabIndex = 16;
            this.field.TabStop = false;
            this.field.DragDrop += new System.Windows.Forms.DragEventHandler(this.field_DragDrop);
            this.field.DragEnter += new System.Windows.Forms.DragEventHandler(this.field_DragEnter);
            this.field.Paint += new System.Windows.Forms.PaintEventHandler(this.field_Paint);
            this.field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.field_MouseClick);
            this.field.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.field_MouseDoubleClick);
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear.ForeColor = System.Drawing.Color.DarkRed;
            this.clear.Location = new System.Drawing.Point(112, 12);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 34);
            this.clear.TabIndex = 19;
            this.clear.Text = "Clear field";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 544);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.field);
            this.Controls.Add(this.hwss);
            this.Controls.Add(this.mwss);
            this.Controls.Add(this.lwss);
            this.Controls.Add(this.tub);
            this.Controls.Add(this.boat);
            this.Controls.Add(this.blinker);
            this.Controls.Add(this.block);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glider);
            this.Controls.Add(this.start);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Life";
            ((System.ComponentModel.ISupportInitialize)(this.glider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blinker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lwss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mwss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hwss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.PictureBox glider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox block;
        private System.Windows.Forms.PictureBox blinker;
        private System.Windows.Forms.PictureBox boat;
        private System.Windows.Forms.PictureBox tub;
        private System.Windows.Forms.PictureBox lwss;
        private System.Windows.Forms.PictureBox mwss;
        private System.Windows.Forms.PictureBox hwss;
        public System.Windows.Forms.PictureBox field;
        private System.Windows.Forms.Button clear;
    }
}
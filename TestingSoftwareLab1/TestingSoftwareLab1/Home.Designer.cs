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
            this.start = new System.Windows.Forms.Button();
            this.field = new System.Windows.Forms.PictureBox();
            this.clear = new System.Windows.Forms.Button();
            this.speed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.figures = new System.Windows.Forms.ComboBox();
            this.figurevisible = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minus90 = new System.Windows.Forms.Button();
            this.plus90 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.figurevisible)).BeginInit();
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
            // field
            // 
            this.field.BackColor = System.Drawing.Color.White;
            this.field.Location = new System.Drawing.Point(193, 12);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(751, 521);
            this.field.TabIndex = 16;
            this.field.TabStop = false;
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
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(9, 105);
            this.speed.Maximum = 300;
            this.speed.Minimum = 1;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(178, 45);
            this.speed.TabIndex = 20;
            this.speed.Value = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "+            Speed            -";
            // 
            // figures
            // 
            this.figures.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.figures.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.figures.FormattingEnabled = true;
            this.figures.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.figures.Location = new System.Drawing.Point(9, 151);
            this.figures.Name = "figures";
            this.figures.Size = new System.Drawing.Size(178, 26);
            this.figures.TabIndex = 22;
            this.figures.Text = "Select basic figure:";
            this.figures.SelectedIndexChanged += new System.EventHandler(this.figures_SelectedIndexChanged);
            // 
            // figurevisible
            // 
            this.figurevisible.BackColor = System.Drawing.Color.White;
            this.figurevisible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.figurevisible.Location = new System.Drawing.Point(9, 183);
            this.figurevisible.Name = "figurevisible";
            this.figurevisible.Size = new System.Drawing.Size(178, 136);
            this.figurevisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.figurevisible.TabIndex = 15;
            this.figurevisible.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Rotation";
            // 
            // minus90
            // 
            this.minus90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minus90.Location = new System.Drawing.Point(81, 325);
            this.minus90.Name = "minus90";
            this.minus90.Size = new System.Drawing.Size(50, 29);
            this.minus90.TabIndex = 24;
            this.minus90.Text = "-90";
            this.minus90.UseVisualStyleBackColor = true;
            this.minus90.Click += new System.EventHandler(this.minus90_Click);
            // 
            // plus90
            // 
            this.plus90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus90.Location = new System.Drawing.Point(137, 325);
            this.plus90.Name = "plus90";
            this.plus90.Size = new System.Drawing.Size(50, 29);
            this.plus90.TabIndex = 25;
            this.plus90.Text = "+90";
            this.plus90.UseVisualStyleBackColor = true;
            this.plus90.Click += new System.EventHandler(this.plus90_Click);
            // 
            // Home
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 544);
            this.Controls.Add(this.plus90);
            this.Controls.Add(this.minus90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.figures);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.field);
            this.Controls.Add(this.figurevisible);
            this.Controls.Add(this.start);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Life";
            ((System.ComponentModel.ISupportInitialize)(this.field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.figurevisible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        public System.Windows.Forms.PictureBox field;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox figures;
        private System.Windows.Forms.PictureBox figurevisible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button minus90;
        private System.Windows.Forms.Button plus90;
    }
}
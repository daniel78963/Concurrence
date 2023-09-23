namespace Concurrence.Desktop
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStart = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnStartAsync = new Button();
            lblProcesing = new Label();
            txtInput = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            btnCancel = new Button();
            pgProcess = new ProgressBar();
            GetCreditCards = new Button();
            panel2 = new Panel();
            progressBar1 = new ProgressBar();
            btnStart2 = new Button();
            loadingGif = new PictureBox();
            gbReintento = new GroupBox();
            btnReintent = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingGif).BeginInit();
            gbReintento.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(13, 75);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(117, 25);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 124);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(167, 124);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(261, 172);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // btnStartAsync
            // 
            btnStartAsync.Location = new Point(205, 75);
            btnStartAsync.Name = "btnStartAsync";
            btnStartAsync.Size = new Size(117, 25);
            btnStartAsync.TabIndex = 3;
            btnStartAsync.Text = "Start async";
            btnStartAsync.UseVisualStyleBackColor = true;
            btnStartAsync.Click += btnStartAsync_Click;
            // 
            // lblProcesing
            // 
            lblProcesing.AutoSize = true;
            lblProcesing.Location = new Point(336, 80);
            lblProcesing.Name = "lblProcesing";
            lblProcesing.Size = new Size(81, 17);
            lblProcesing.TabIndex = 4;
            lblProcesing.Text = "processing...";
            lblProcesing.Visible = false;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(128, 33);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(191, 25);
            txtInput.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 35);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(pgProcess);
            panel1.Controls.Add(GetCreditCards);
            panel1.Location = new Point(13, 320);
            panel1.Name = "panel1";
            panel1.Size = new Size(415, 110);
            panel1.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(154, 16);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 25);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pgProcess
            // 
            pgProcess.Location = new Point(13, 54);
            pgProcess.Name = "pgProcess";
            pgProcess.Size = new Size(391, 25);
            pgProcess.TabIndex = 5;
            pgProcess.Visible = false;
            // 
            // GetCreditCards
            // 
            GetCreditCards.Location = new Point(18, 16);
            GetCreditCards.Name = "GetCreditCards";
            GetCreditCards.Size = new Size(117, 25);
            GetCreditCards.TabIndex = 4;
            GetCreditCards.Text = "Get Credit Cards";
            GetCreditCards.UseVisualStyleBackColor = true;
            GetCreditCards.Click += GetCreditCards_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(progressBar1);
            panel2.Controls.Add(btnStart2);
            panel2.Location = new Point(434, 320);
            panel2.Name = "panel2";
            panel2.Size = new Size(354, 110);
            panel2.TabIndex = 8;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(13, 54);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(299, 25);
            progressBar1.TabIndex = 5;
            progressBar1.Visible = false;
            // 
            // btnStart2
            // 
            btnStart2.Location = new Point(18, 16);
            btnStart2.Name = "btnStart2";
            btnStart2.Size = new Size(117, 25);
            btnStart2.TabIndex = 4;
            btnStart2.Text = "Start";
            btnStart2.UseVisualStyleBackColor = true;
            btnStart2.Click += btnStart2_Click;
            // 
            // loadingGif
            // 
            loadingGif.Image = (Image)resources.GetObject("loadingGif.Image");
            loadingGif.Location = new Point(434, 161);
            loadingGif.Name = "loadingGif";
            loadingGif.Size = new Size(135, 135);
            loadingGif.SizeMode = PictureBoxSizeMode.StretchImage;
            loadingGif.TabIndex = 9;
            loadingGif.TabStop = false;
            loadingGif.Visible = false;
            // 
            // gbReintento
            // 
            gbReintento.Controls.Add(btnReintent);
            gbReintento.Location = new Point(434, 12);
            gbReintento.Name = "gbReintento";
            gbReintento.Size = new Size(354, 143);
            gbReintento.TabIndex = 10;
            gbReintento.TabStop = false;
            gbReintento.Text = "Reintento";
            // 
            // btnReintent
            // 
            btnReintent.Location = new Point(13, 24);
            btnReintent.Name = "btnReintent";
            btnReintent.Size = new Size(117, 25);
            btnReintent.TabIndex = 6;
            btnReintent.Text = "Start";
            btnReintent.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbReintento);
            Controls.Add(loadingGif);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(txtInput);
            Controls.Add(lblProcesing);
            Controls.Add(btnStartAsync);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loadingGif).EndInit();
            gbReintento.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnStartAsync;
        private Label lblProcesing;
        private TextBox txtInput;
        private Label label1;
        private Panel panel1;
        private Button button1;
        private Button GetCreditCards;
        private ProgressBar pgProcess;
        private Button btnCancel;
        private Panel panel2;
        private ProgressBar progressBar1;
        private Button btnStart2;
        private PictureBox loadingGif;
        private GroupBox gbReintento;
        private Button btnReintent;
    }
}
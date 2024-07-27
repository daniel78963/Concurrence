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
            btnRetry = new Button();
            groupBox1 = new GroupBox();
            btnOneTask = new Button();
            groupBox2 = new GroupBox();
            txtInputStatusValue = new TextBox();
            btnStartStatusControlled = new Button();
            groupBox3 = new GroupBox();
            btnCancelTask = new Button();
            btnCancellAnyTask = new Button();
            groupBox4 = new GroupBox();
            btnIEnumerableAsync = new Button();
            btnIEnumerable = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingGif).BeginInit();
            gbReintento.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
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
            loadingGif.Location = new Point(794, 22);
            loadingGif.Name = "loadingGif";
            loadingGif.Size = new Size(50, 46);
            loadingGif.SizeMode = PictureBoxSizeMode.StretchImage;
            loadingGif.TabIndex = 9;
            loadingGif.TabStop = false;
            loadingGif.Visible = false;
            // 
            // gbReintento
            // 
            gbReintento.Controls.Add(btnRetry);
            gbReintento.Location = new Point(434, 12);
            gbReintento.Name = "gbReintento";
            gbReintento.Size = new Size(354, 56);
            gbReintento.TabIndex = 10;
            gbReintento.TabStop = false;
            gbReintento.Text = "Reintento";
            // 
            // btnRetry
            // 
            btnRetry.Location = new Point(13, 24);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(117, 25);
            btnRetry.TabIndex = 6;
            btnRetry.Text = "Start";
            btnRetry.UseVisualStyleBackColor = true;
            btnRetry.Click += btnRetry_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnOneTask);
            groupBox1.Location = new Point(434, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(354, 56);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Only one task";
            // 
            // btnOneTask
            // 
            btnOneTask.Location = new Point(13, 24);
            btnOneTask.Name = "btnOneTask";
            btnOneTask.Size = new Size(117, 25);
            btnOneTask.TabIndex = 6;
            btnOneTask.Text = "Start";
            btnOneTask.UseVisualStyleBackColor = true;
            btnOneTask.Click += btnOneTask_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtInputStatusValue);
            groupBox2.Controls.Add(btnStartStatusControlled);
            groupBox2.Location = new Point(434, 137);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(354, 56);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Status Controlado";
            // 
            // txtInputStatusValue
            // 
            txtInputStatusValue.Location = new Point(146, 25);
            txtInputStatusValue.Name = "txtInputStatusValue";
            txtInputStatusValue.Size = new Size(191, 25);
            txtInputStatusValue.TabIndex = 7;
            // 
            // btnStartStatusControlled
            // 
            btnStartStatusControlled.Location = new Point(13, 24);
            btnStartStatusControlled.Name = "btnStartStatusControlled";
            btnStartStatusControlled.Size = new Size(117, 25);
            btnStartStatusControlled.TabIndex = 6;
            btnStartStatusControlled.Text = "Start";
            btnStartStatusControlled.UseVisualStyleBackColor = true;
            btnStartStatusControlled.Click += btnStartStatusControlled_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnCancelTask);
            groupBox3.Controls.Add(btnCancellAnyTask);
            groupBox3.Location = new Point(434, 199);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(354, 56);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Cancelando Cualquier Tarea";
            // 
            // btnCancelTask
            // 
            btnCancelTask.Location = new Point(146, 24);
            btnCancelTask.Name = "btnCancelTask";
            btnCancelTask.Size = new Size(117, 25);
            btnCancelTask.TabIndex = 7;
            btnCancelTask.Text = "Cancel";
            btnCancelTask.UseVisualStyleBackColor = true;
            btnCancelTask.Click += btnCancelTask_Click;
            // 
            // btnCancellAnyTask
            // 
            btnCancellAnyTask.Location = new Point(13, 24);
            btnCancellAnyTask.Name = "btnCancellAnyTask";
            btnCancellAnyTask.Size = new Size(117, 25);
            btnCancellAnyTask.TabIndex = 6;
            btnCancellAnyTask.Text = "Start";
            btnCancellAnyTask.UseVisualStyleBackColor = true;
            btnCancellAnyTask.Click += button2_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(btnIEnumerableAsync);
            groupBox4.Controls.Add(btnIEnumerable);
            groupBox4.Location = new Point(12, 436);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(416, 56);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "IEnumerable / Yield";
            // 
            // btnIEnumerableAsync
            // 
            btnIEnumerableAsync.Location = new Point(146, 24);
            btnIEnumerableAsync.Name = "btnIEnumerableAsync";
            btnIEnumerableAsync.Size = new Size(117, 25);
            btnIEnumerableAsync.TabIndex = 7;
            btnIEnumerableAsync.Text = "Start Async";
            btnIEnumerableAsync.UseVisualStyleBackColor = true;
            btnIEnumerableAsync.Click += btnIEnumerableAsync_Click;
            // 
            // btnIEnumerable
            // 
            btnIEnumerable.Location = new Point(13, 24);
            btnIEnumerable.Name = "btnIEnumerable";
            btnIEnumerable.Size = new Size(117, 25);
            btnIEnumerable.TabIndex = 6;
            btnIEnumerable.Text = "Start";
            btnIEnumerable.UseVisualStyleBackColor = true;
            btnIEnumerable.Click += btnIEnumerable_Click;
            // 
            // button2
            // 
            button2.Location = new Point(269, 24);
            button2.Name = "button2";
            button2.Size = new Size(117, 25);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 522);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
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
        private Button btnRetry;
        private GroupBox groupBox1;
        private Button btnOneTask;
        private GroupBox groupBox2;
        private Button btnStartStatusControlled;
        private TextBox txtInputStatusValue;
        private GroupBox groupBox3;
        private Button btnCancellAnyTask;
        private Button btnCancelTask;
        private GroupBox groupBox4;
        private Button btnIEnumerableAsync;
        private Button btnIEnumerable;
        private Button button2;
    }
}
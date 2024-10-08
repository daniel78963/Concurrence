﻿namespace Concurrence.Desktop
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
            button3 = new Button();
            button2 = new Button();
            btnIEnumerableAsync = new Button();
            btnIEnumerable = new Button();
            groupBox5 = new GroupBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            groupBox6 = new GroupBox();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            label2 = new Label();
            groupBox7 = new GroupBox();
            button18 = new Button();
            button17 = new Button();
            button15 = new Button();
            button16 = new Button();
            button21 = new Button();
            button19 = new Button();
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
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 43);
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
            pictureBox1.Location = new Point(12, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(110, 74);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(138, 98);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // btnStartAsync
            // 
            btnStartAsync.Location = new Point(148, 43);
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
            lblProcesing.Location = new Point(271, 47);
            lblProcesing.Name = "lblProcesing";
            lblProcesing.Size = new Size(81, 17);
            lblProcesing.TabIndex = 4;
            lblProcesing.Text = "processing...";
            lblProcesing.Visible = false;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(61, 6);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(191, 25);
            txtInput.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
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
            panel1.Location = new Point(13, 178);
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
            panel2.Location = new Point(434, 261);
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
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(btnIEnumerableAsync);
            groupBox4.Controls.Add(btnIEnumerable);
            groupBox4.Location = new Point(12, 377);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(416, 84);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "IEnumerable / Yield";
            // 
            // button3
            // 
            button3.Location = new Point(136, 53);
            button3.Name = "button3";
            button3.Size = new Size(117, 25);
            button3.TabIndex = 9;
            button3.Text = "Start Async";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(259, 24);
            button2.Name = "button2";
            button2.Size = new Size(117, 25);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // btnIEnumerableAsync
            // 
            btnIEnumerableAsync.Location = new Point(136, 24);
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
            // groupBox5
            // 
            groupBox5.Controls.Add(button4);
            groupBox5.Controls.Add(button5);
            groupBox5.Controls.Add(button6);
            groupBox5.Controls.Add(button7);
            groupBox5.Location = new Point(434, 377);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(416, 84);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Antipatrones";
            // 
            // button4
            // 
            button4.Location = new Point(136, 53);
            button4.Name = "button4";
            button4.Size = new Size(117, 25);
            button4.TabIndex = 9;
            button4.Text = "Start Async";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(259, 24);
            button5.Name = "button5";
            button5.Size = new Size(117, 25);
            button5.TabIndex = 8;
            button5.Text = "Cancel";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(136, 24);
            button6.Name = "button6";
            button6.Size = new Size(117, 25);
            button6.TabIndex = 7;
            button6.Text = "Start Async";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(13, 24);
            button7.Name = "button7";
            button7.Size = new Size(117, 25);
            button7.TabIndex = 6;
            button7.Text = "Start";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button14);
            groupBox6.Controls.Add(button13);
            groupBox6.Controls.Add(button12);
            groupBox6.Controls.Add(button8);
            groupBox6.Controls.Add(button9);
            groupBox6.Controls.Add(button10);
            groupBox6.Controls.Add(button11);
            groupBox6.Location = new Point(13, 482);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(416, 114);
            groupBox6.TabIndex = 16;
            groupBox6.TabStop = false;
            groupBox6.Text = "Paralelismo";
            // 
            // button14
            // 
            button14.Location = new Point(136, 83);
            button14.Name = "button14";
            button14.Size = new Size(240, 25);
            button14.TabIndex = 12;
            button14.Text = "Parallel Max Degree";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button13
            // 
            button13.Location = new Point(12, 53);
            button13.Name = "button13";
            button13.Size = new Size(117, 25);
            button13.TabIndex = 11;
            button13.Text = "Cancel";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.Location = new Point(259, 53);
            button12.Name = "button12";
            button12.Size = new Size(117, 25);
            button12.TabIndex = 10;
            button12.Text = "Parallel.Invoke";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button8
            // 
            button8.Location = new Point(136, 53);
            button8.Name = "button8";
            button8.Size = new Size(117, 25);
            button8.TabIndex = 9;
            button8.Text = "Parallel.ForEach";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(259, 24);
            button9.Name = "button9";
            button9.Size = new Size(117, 25);
            button9.TabIndex = 8;
            button9.Text = "Parallel.For speed";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(136, 24);
            button10.Name = "button10";
            button10.Size = new Size(117, 25);
            button10.TabIndex = 7;
            button10.Text = "ParallelFor";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(13, 24);
            button11.Name = "button11";
            button11.Size = new Size(117, 25);
            button11.TabIndex = 6;
            button11.Text = "Start";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 464);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 17;
            label2.Text = "Paralelismo";
            label2.Visible = false;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(button19);
            groupBox7.Controls.Add(button18);
            groupBox7.Controls.Add(button17);
            groupBox7.Controls.Add(button15);
            groupBox7.Controls.Add(button16);
            groupBox7.Controls.Add(button21);
            groupBox7.Location = new Point(437, 482);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(416, 114);
            groupBox7.TabIndex = 17;
            groupBox7.TabStop = false;
            groupBox7.Text = "Seguridad ";
            // 
            // button18
            // 
            button18.Location = new Point(256, 53);
            button18.Name = "button18";
            button18.Size = new Size(117, 25);
            button18.TabIndex = 14;
            button18.Text = "PLINQ Agregado";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button17
            // 
            button17.Location = new Point(133, 53);
            button17.Name = "button17";
            button17.Size = new Size(117, 25);
            button17.TabIndex = 13;
            button17.Text = "PLINQ";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button15
            // 
            button15.Location = new Point(133, 24);
            button15.Name = "button15";
            button15.Size = new Size(117, 25);
            button15.TabIndex = 12;
            button15.Text = "lock";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(12, 53);
            button16.Name = "button16";
            button16.Size = new Size(117, 25);
            button16.TabIndex = 11;
            button16.Text = "Cancel";
            button16.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            button21.Location = new Point(13, 24);
            button21.Name = "button21";
            button21.Size = new Size(117, 25);
            button21.TabIndex = 6;
            button21.Text = "Interlock";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // button19
            // 
            button19.Location = new Point(256, 83);
            button19.Name = "button19";
            button19.Size = new Size(117, 25);
            button19.TabIndex = 15;
            button19.Text = "PLINQ ForAll";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 608);
            Controls.Add(groupBox7);
            Controls.Add(label2);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
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
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
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
        private Button button3;
        private GroupBox groupBox5;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private GroupBox groupBox6;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Label label2;
        private Button button12;
        private Button button13;
        private Button button14;
        private GroupBox groupBox7;
        private Button button16;
        private Button button21;
        private Button button15;
        private Button button17;
        private Button button18;
        private Button button19;
    }
}
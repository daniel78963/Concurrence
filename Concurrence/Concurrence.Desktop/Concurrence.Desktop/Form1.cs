namespace Concurrence.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000); 
        }

        private async void btnStartAsync_Click(object sender, EventArgs e)
        {
            this.lblProcesing.Visible = true;
            await Task.Delay(TimeSpan.FromSeconds(5));
            this.lblProcesing.Visible = false;
        }
    }
}
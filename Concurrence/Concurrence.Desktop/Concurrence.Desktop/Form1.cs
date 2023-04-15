using System.Runtime.CompilerServices;

namespace Concurrence.Desktop
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpCLient;

        public Form1()
        {
            InitializeComponent();
            apiURL = "https://localhost:7091";
            httpCLient = new HttpClient();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
        }

        private async void btnStartAsync_Click(object sender, EventArgs e)
        {
            //Es void, pq estamos ante un event hander (manejador de eventos)
            this.lblProcesing.Visible = true;
            //con el await le estamos diciendo al hilo principal, que se puede ir a hacer otra
            // cosa mientras lo del await termina
            await Wait();
            var name = txtInput.Text;
            var greetings = await GetGreetings(name);
            //MessageBox.Show("pasaron los 5 seg");
            MessageBox.Show(greetings);
            this.lblProcesing.Visible = false;
        }

        private async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        private async Task<string> GetGreetings(string name)
        {
            using (var response = await httpCLient.GetAsync($"{apiURL}/greetings/{name}"))
            {
                var saludo = await response.Content.ReadAsStringAsync();
                return saludo;
            }
        }
    }
}
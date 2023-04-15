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
            try
            {
               //Si ocurre una excepción dentro de la llamada al servicio y no tiene el await, la excepción nunca se va a ver
                var greetings = await GetGreetings(name);
                MessageBox.Show(greetings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

            //MessageBox.Show("pasaron los 5 seg");
            this.lblProcesing.Visible = false;
        }

        private async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(0));
        }

        private async Task<string> GetGreetings(string name)
        {
            using (var response = await httpCLient.GetAsync($"{apiURL}/greetings/{name}"))
            {
                response.EnsureSuccessStatusCode();
                var saludo = await response.Content.ReadAsStringAsync();
                return saludo;
            }
        }
    }
}
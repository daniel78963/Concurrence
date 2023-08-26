using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Concurrence.Desktop
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            apiURL = "https://localhost:7091";
            httpClient = new HttpClient();
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
            using (var response = await httpClient.GetAsync($"{apiURL}/greetings/{name}"))
            {
                response.EnsureSuccessStatusCode();
                var saludo = await response.Content.ReadAsStringAsync();
                return saludo;
            }
        }

        private List<string> GetCreditCardsList(int quantityCards)
        {
            var creditCards = new List<string>();
            for (int i = 0; i < quantityCards; i++)
            {
                creditCards.Add(i.ToString().PadLeft(16, '0'));
            }
            return creditCards;
        }

        private async Task<List<string>> GetCreditCardsListAsync(int quantityCards)
        {
            return await Task.Run(() =>
                {
                    var creditCards = new List<string>();
                    for (int i = 0; i < quantityCards; i++)
                    {
                        creditCards.Add(i.ToString().PadLeft(16, '0'));
                    }
                    return creditCards;
                });
        }

        private async void GetCreditCards_Click(object sender, EventArgs e)
        {
            lblProcesing.Visible = true;
            var cards = await GetCreditCardsListAsync(100);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                //await ProcessCards(cards);
                //await ProcessCardsRunAsync(cards);
                await ProcessCardsSemaphoreAsync(cards);
            }
            catch (Exception)
            {

                throw;
            }
            lblProcesing.Visible = false;
            MessageBox.Show($"Operation finalized in {stopWatch.ElapsedMilliseconds / 1000.0} segundos");
        }

        private async Task ProcessCards(List<string> cards)
        {
            //Esto esta corriendo en el hilo UI
            //Por eso se demora en iniciar el loading,
            //pq el hilo principal se desbloquea cuando llega a await Task.WhenAll(tasks);
            var tasks = new List<Task>();
            foreach (var card in cards)
            {
                var json = JsonConvert.SerializeObject(card);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var answerTask = httpClient.PostAsync($"{apiURL}/creditcards", content);
                tasks.Add(answerTask);
            }
            await Task.WhenAll(tasks);
        }

        private async Task ProcessCardsRunAsync(List<string> cards)
        {
            var tasks = new List<Task>();
            //Liberamos el hilo UI
            await Task.Run(() =>
            {
                foreach (var card in cards)
                {
                    var json = JsonConvert.SerializeObject(card);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var answerTask = httpClient.PostAsync($"{apiURL}/creditcards", content);
                    tasks.Add(answerTask);
                }
            });

            await Task.WhenAll(tasks);
        }

        private async Task ProcessCardsSemaphoreAsync(List<string> cards)
        {
            var semaphore = new SemaphoreSlim(10);

            var tasks = new List<Task<HttpResponseMessage>>();

            tasks = cards.Select(async card =>
            {
                var json = JsonConvert.SerializeObject(card);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //Entramos al semaforo para que controle la cantidad de tareas
                //y no deja pasar mas tareas nuevas hasta que las anteriores
                //sean todas ejecutadas
                await semaphore.WaitAsync();
                try
                {
                    return await httpClient.PostAsync($"{apiURL}/creditcards", content);
                }
                finally { semaphore.Release(); }
            }).ToList();

            //await Task.WhenAll(tasks);
            //Vid 21
            var answers = await Task.WhenAll(tasks);
            var cardsRejected = new List<string>();
            foreach (var answer in answers)
            {

            }
        }
    }
}
using Concurrence.Desktop.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace Concurrence.Desktop
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpClient;
        private CancellationTokenSource cancellationTokenSource;

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

        private async Task<string> GetGreetingsDelay(string name)
        {
            using (var response = await httpClient.GetAsync($"{apiURL}/greetings/delay/{name}"))
            {
                response.EnsureSuccessStatusCode();
                var saludo = await response.Content.ReadAsStringAsync();
                return saludo;
            }
        }

        /// <summary>
        /// Enviar varias peticiones y con la primera que se procese, cancelar las demás
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<string> GetGreetingsDelayCancel(string name, CancellationToken cancellationToken)
        {
            using (var response = await httpClient.GetAsync($"{apiURL}/greetings/delayCancell/{name}", cancellationToken))
            {
                //response.EnsureSuccessStatusCode();
                var saludo = await response.Content.ReadAsStringAsync();
                Console.WriteLine(saludo);
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
            return await Task.Run(async () =>
                {
                    var creditCards = new List<string>();
                    for (int i = 0; i < quantityCards; i++)
                    {
                        creditCards.Add(i.ToString().PadLeft(16, '0'));
                    }
                    return creditCards;
                });
        }

        private Task<List<string>> GetCreditCardsMock(int quantityCards
         , CancellationToken cancellationToken = default)
        {
            var cards = new List<string>();
            cards.Add("0000000001");
            return Task.FromResult(cards);
        }

        private Task GetTaskErrorMock(int quantityCards
        , CancellationToken cancellationToken = default)
        {
            return Task.FromException(new ApplicationException());
        }

        private Task GetTaskCancelledMock(int quantityCards
       , CancellationToken cancellationToken = default)
        {
            cancellationTokenSource = new CancellationTokenSource();
            return Task.FromCanceled(cancellationTokenSource.Token);
        }

        private async Task<List<string>> GetCreditCardsCancellationAsync(int quantityCards
        , CancellationToken cancellationToken = default)
        {
            return await Task.Run(async () =>
            {
                var creditCards = new List<string>();
                for (int i = 0; i < quantityCards; i++)
                {
                    //creditCards.Add(i.ToString().PadLeft(16, '0'));
                    //Vid 25 cancelando bucles
                    await Task.Delay(1000);
                    creditCards.Add(i.ToString().PadLeft(16, '0'));

                    Console.WriteLine($"Han sido generadas {creditCards.Count} tarjetas");

                    if (cancellationToken.IsCancellationRequested)
                    {
                        //Me dice si el generador de tokens ha solicitado la cancelación del token
                        //break;
                        ////or
                        throw new TaskCanceledException();
                    }
                }
                return creditCards;
            });
        }

        private async void GetCreditCards_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(3));
            lblProcesing.Visible = true;
            pgProcess.Visible = true;
            var reportProgress = new Progress<int>(ReportProgressCards);

            var cards = await GetCreditCardsListAsync(100);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                //vid 25
                //var cards = await GetCreditCardsCancellationAsync(100, cancellationTokenSource.Token);

                //await ProcessCards(cards);
                //await ProcessCardsRunAsync(cards);
                //await ProcessCardsSemaphoreAsync(cards);
                //await ProcessCardsSemaphoreProgressAsync(cards, reportProgress);
                //await ProcessCardsRunProgressAsync(cards, reportProgress);
                await ProcessCardsWhenAnyAsync(cards, reportProgress, cancellationTokenSource.Token);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show($"The operation was canceled. {ex.Message}");
            }
            lblProcesing.Visible = false;
            pgProcess.Visible = false;
            pgProcess.Value = 0;
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
                    var taskInternal = await httpClient.PostAsync($"{apiURL}/creditcards", content);

                    return taskInternal;
                }
                finally { semaphore.Release(); }
            }).ToList();

            //await Task.WhenAll(tasks);
            //Vid 21
            var answers = await Task.WhenAll(tasks);
            var cardsRejected = new List<string>();
            foreach (var answer in answers)
            {
                var content = await answer.Content.ReadAsStringAsync();
                var answerCard = JsonConvert.DeserializeObject<AnswerCard>(content);
                if (!answerCard.IsApproved)
                {
                    cardsRejected.Add(answerCard.Card);
                }
            }
            Console.WriteLine("Cards rejected:");
            foreach (var card in cardsRejected)
            {
                Console.WriteLine(card);
            }
        }

        private async Task ProcessCardsSemaphoreProgressAsync(List<string> cards, IProgress<int> progress = null)
        {
            var semaphore = new SemaphoreSlim(10);
            var tasks = new List<Task<HttpResponseMessage>>();
            int index = 0;
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
                    var taskInternal = await httpClient.PostAsync($"{apiURL}/creditcards", content);
                    if (progress != null)
                    {
                        index++;
                        var percentage = (double)index / cards.Count;
                        var percentageRounded = (int)Math.Round(percentage * 100, 0);
                        //Report se encarga de ejecutar el método ReportProgressCards
                        progress.Report(percentageRounded);
                    }
                    return taskInternal;
                }
                finally { semaphore.Release(); }
            }).ToList();

            //await Task.WhenAll(tasks);
            //Vid 21
            var answers = await Task.WhenAll(tasks);
            var cardsRejected = new List<string>();
            foreach (var answer in answers)
            {
                var content = await answer.Content.ReadAsStringAsync();
                var answerCard = JsonConvert.DeserializeObject<AnswerCard>(content);
                if (!answerCard.IsApproved)
                {
                    cardsRejected.Add(answerCard.Card);
                }
            }
            Console.WriteLine("Cards rejected:");
            foreach (var card in cardsRejected)
            {
                Console.WriteLine(card);
            }
        }

        private async Task ProcessCardsRunProgressAsync(List<string> cards, IProgress<int> progress = null)
        {
            var tasks = new List<Task>();
            int index = 0;
            //Liberamos el hilo UI
            await Task.Run(() =>
            {
                foreach (var card in cards)
                {
                    var json = JsonConvert.SerializeObject(card);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var answerTask = httpClient.PostAsync($"{apiURL}/creditcards", content);
                    if (progress != null)
                    {
                        index++;
                        var percentage = (double)index / cards.Count;
                        var percentageRounded = (int)Math.Round(percentage * 100, 0);
                        //Report se encarga de ejecutar el método ReportProgressCards
                        progress.Report(percentageRounded);
                    }
                    tasks.Add(answerTask);
                }
            });

            await Task.WhenAll(tasks);
        }

        private Task ProcessCardsMock(List<string> cards
          , IProgress<int> progress = null,
          CancellationToken cancellationToken = default)
        {

            return Task.CompletedTask;
        }

        private async Task ProcessCardsWhenAnyAsync(List<string> cards
        , IProgress<int> progress = null,
        CancellationToken cancellationToken = default)
        {
            //El default sirve para que sea una variable opcional
            var semaphore = new SemaphoreSlim(10);
            var tasks = new List<Task<HttpResponseMessage>>();
            int index = 0;
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
                    var taskInternal = await httpClient.PostAsync($"{apiURL}/creditcards", content, cancellationToken);
                    //if (progress != null)
                    //{
                    //    index++;
                    //    var percentage = (double)index / cards.Count;
                    //    var percentageRounded = (int)Math.Round(percentage * 100, 0);
                    //    //Report se encarga de ejecutar el método ReportProgressCards
                    //    progress.Report(percentageRounded);
                    //}
                    return taskInternal;
                }
                finally { semaphore.Release(); }
            }).ToList();

            //await Task.WhenAll(tasks);
            //Vid 21
            //Vid 23
            //Ya no vamos a esperar a que finalicen todas las tareas
            //var answers = await Task.WhenAll(tasks);
            var answersTasks = Task.WhenAll(tasks);

            if (progress != null)
            {
                while (await Task.WhenAny(answersTasks, Task.Delay(1000)) != answersTasks)
                {
                    //el != compara si ya se terminaron las tareas (answerTask) y finaliza el while
                    //el WhenAny compara cual tarea está mas demorada y devuelve la de menos tiempo y sigue ejecutandose el While
                    var taskCompleted = tasks.Where(task => task.IsCompleted).Count();
                    var percentage = (double)taskCompleted / cards.Count;
                    var percentageRounded = (int)Math.Round(percentage * 100, 0);
                    //Report se encarga de ejecutar el método ReportProgressCards
                    progress.Report(percentageRounded);
                }
            }

            //Si ya las tareas fueron completadas, no significa que con el await de abajo
            //se va a volver a realizar la tarea. Esperar una tarea dos veces no significa
            //que se va a ejecutar dos veces
            var answers = await answersTasks;
            var cardsRejected = new List<string>();
            foreach (var answer in answers)
            {
                var content = await answer.Content.ReadAsStringAsync();
                var answerCard = JsonConvert.DeserializeObject<AnswerCard>(content);
                if (!answerCard.IsApproved)
                {
                    cardsRejected.Add(answerCard.Card);
                }
            }
            Console.WriteLine("Cards rejected:");
            foreach (var card in cardsRejected)
            {
                Console.WriteLine(card);
            }
        }

        private void ReportProgressCards(int percentage)
        {
            pgProcess.Value = percentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //el ? sirve para validar que no sea nulo
            cancellationTokenSource?.Cancel();
        }

        private async void btnStart2_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = true;
            loadingGif.Visible = true;
            Console.WriteLine($"Thread before await: {Thread.CurrentThread.ManagedThreadId}");
            //await Task.Delay(500);
            await Task.Delay(500).ConfigureAwait(continueOnCapturedContext: false);
            Console.WriteLine($"Thread after await: {Thread.CurrentThread.ManagedThreadId}");

            await GetGreetingsDelay("Daniel");
            loadingGif.Visible = false;
        }

        private async void btnRetry_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            var retries = 3;
            var waitTime = 500;

            //for (int i = 0; i < retries; i++)
            //{
            //    try
            //    {

            //        break;//para salir del for, si la operation is successful
            //    }
            //    catch (Exception ex)
            //    {
            //        //Log exception
            //        Task.Delay(waitTime);
            //    }
            //}
            string name = "Daniel";
            //await Retry(async () =>
            //{
            //    //using (var answer = await httpClient.GetAsync($"{apiURL}/greetings/{name}"))
            //    using (var answer = await httpClient.GetAsync($"{apiURL}/greetings555/{name}"))
            //    {
            //        answer.EnsureSuccessStatusCode();//Sirve para lanzar una exception de donde se llama, cuando no haya una respuesta success
            //        var content = await answer.Content.ReadAsStringAsync();
            //        if (content != null)
            //        {
            //            Console.WriteLine(content); 
            //        }
            //    }
            //});

            //await Retry(ProcessGreetings);
            try
            {
                var content = await Retry(async () =>
                           {
                               string name = "Dani";
                               using (var answer = await httpClient.GetAsync($"{apiURL}/greetings555/{name}"))
                               {
                                   answer.EnsureSuccessStatusCode();//Sirve para lanzar una exception de donde se llama, cuando no haya una respuesta success
                                   return await answer.Content.ReadAsStringAsync();
                               }
                           });
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception controlled");
            }

            loadingGif.Visible = false;
        }

        private async Task Retry(Func<Task> f, int retries = 3, int waitTime = 500)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    await f();
                    break;//para salir del for, si la operation is successful
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(waitTime);
                }
            }
        }

        private async Task<T> Retry<T>(Func<Task<T>> f, int retries = 3, int waitTime = 500)
        {
            for (int i = 0; i < retries - 1; i++)
            {
                try
                {
                    return await f();
                    break;//para salir del for, si la operation is successful
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(waitTime);
                }
            }
            //Esta exception va por fuera del try y va a subir al cliente del método
            return await f();
        }

        private async Task ProcessGreetings()
        {
            string name = "Dani";
            using (var answer = await httpClient.GetAsync($"{apiURL}/greetings555/{name}"))
            {
                answer.EnsureSuccessStatusCode();//Sirve para lanzar una exception de donde se llama, cuando no haya una respuesta success
                var content = await answer.Content.ReadAsStringAsync();
                if (content != null)
                {
                    Console.WriteLine(content);
                }
            }
        }

        /// <summary>
        /// Only one taks, the first in end to complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOneTask_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            var names = new string[] { "Dani", "Rocko", "Camila", "Juan" };
            var taskHTTP = names.Select(x => GetGreetingsDelayCancel(x, token));
            var task = await Task.WhenAny(taskHTTP); //cualquiera de las tareas que termine
            var content = await task;
            Console.WriteLine(content.ToUpper());
            cancellationTokenSource.Cancel();
            loadingGif.Visible = false;
        }

        //private async Task(T) ExecuteTask<T>
    }
}
using Concurrence.Desktop.Helpers;
using Concurrence.Desktop.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Winforms;

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

        private async Task<string> GetGoodbyeDelayCancel(string name, CancellationToken cancellationToken)
        {
            using (var response = await httpClient.GetAsync($"{apiURL}/greetings/delaybye/{name}", cancellationToken))
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

            ///Comentamos esto y lo vamos a meter en un método general
            //var taskHTTP = names.Select(x => GetGreetingsDelayCancel(x, token));
            //var task = await Task.WhenAny(taskHTTP); //cualquiera de las tareas que termine
            //var content = await task;
            //Console.WriteLine(content.ToUpper());
            //cancellationTokenSource.Cancel();
            ///

            //var taskHTTP = names.Select(x =>
            //{
            //    Func<CancellationToken, Task<string>> function = (cancelT) => GetGreetingsDelayCancel(x, cancelT);
            //    return function;
            //});
            //var content = await ExecuteOneTask(taskHTTP);
            //Console.WriteLine(content.ToUpper());

            ///Ajustamos el llamado anterior y creamos un nuevo método para tener mas llamadas landa 
            ///para llamar distintas o varias funciones. Solo se va a ejecutar una sola tarea, una sola función
            var content = await ExecuteOneTask(
                  (ct) => GetGreetingsDelayCancel("Dani", ct),
                  (ct) => GetGoodbyeDelayCancel("Dani", ct)
                    );
            Console.WriteLine(content.ToUpper());

            loadingGif.Visible = false;
        }

        private async Task<T> ExecuteOneTask<T>(IEnumerable<Func<CancellationToken, Task<T>>> functions)
        {
            var cts = new CancellationTokenSource();
            var tasks = functions.Select(funcion => funcion(cts.Token));
            var task = await Task.WhenAny(tasks);
            cts.Cancel();
            return await task;
        }

        private async Task<T> ExecuteOneTask<T>(params Func<CancellationToken, Task<T>>[] functions)
        {
            var cts = new CancellationTokenSource();
            var tasks = functions.Select(funcion => funcion(cts.Token));
            var task = await Task.WhenAny(tasks);
            cts.Cancel();
            return await task;
        }

        private async void btnStartStatusControlled_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            var task = EvaluateValue(txtInputStatusValue.Text);

            Console.WriteLine("Begin");
            Console.WriteLine($"Is Completed {task.IsCompleted}");
            Console.WriteLine($"Is Canceled {task.IsCanceled}");
            Console.WriteLine($"Is Faulted {task.IsFaulted}");

            try
            {
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine("End");
            Console.WriteLine("");
            loadingGif.Visible = false;
        }

        public Task EvaluateValue(string value)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            if (value == "1")
            {
                tcs.SetResult(null);
            }
            else if (value == "2")
            {
                tcs.SetCanceled();
            }
            else
            {
                tcs.SetException(new ApplicationException($"Invalid value {value}"));
            }
            return tcs.Task;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                var result = await Task.Run(async () =>
                {
                    await Task.Delay(5000);
                    return 7;
                }).WithCancellation(cancellationTokenSource.Token);
                Console.WriteLine($"{result.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cancellationTokenSource.Dispose(); }

            loadingGif.Visible = false;
        }

        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private IEnumerable<string> GenerateNames()
        {
            yield return "Dani";
            yield return "Camilo";
        }

        private void btnIEnumerable_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = false;
            foreach (var name in GenerateNames())
            {
                Console.WriteLine(name);
            }
            loadingGif.Visible = false;
        }

        private async IAsyncEnumerable<string> GenerateNamesAsync(CancellationToken token = default)
        {
            yield return "Dani";
            await Task.Delay(500, token);
            yield return "Camilo 0.5 s";
            await Task.Delay(2000, token);
            yield return "Camilo 2 s";
            await Task.Delay(500, token);
            yield return "Camilo 0.5";
            await Task.Delay(300, token);
            yield return "Camilo 0.3";
        }

        private async void btnIEnumerableAsync_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = false;
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await foreach (var name in GenerateNamesAsync(cancellationTokenSource.Token))
                {
                    Console.WriteLine(name);
                }
            }
            catch (TaskCanceledException cex)
            {
                Console.WriteLine("Operation cancelled");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
            }

            Console.WriteLine("Finish");
            loadingGif.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private async Task ProcessNames(IAsyncEnumerable<string> names)
        {
            //EnumeratorCancellation: atributo especial para trabajar con el WithCancellation y que reconozca que es un método que recibe datos(parámetros) con cancelación de token.
            try
            {
                await foreach (var name in names.WithCancellation(cancellationTokenSource.Token))
                {
                    Console.WriteLine(name);
                }
            }
            catch (TaskCanceledException cex)
            {
                Console.WriteLine("Operation cancelled");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
            }
        }

        private async IAsyncEnumerable<string> GenerateNamesAsync2([EnumeratorCancellation] CancellationToken token = default)
        {
            //EnumeratorCancellation: atributo especial para trabajar con el WithCancellation y que reconozca que es un método que recibe datos(parámetros) con cancelación de token.
            yield return "Dani";
            await Task.Delay(500, token);
            yield return "Camilo 0.5 s";
            await Task.Delay(2000, token);
            yield return "Camilo 2 s";
            await Task.Delay(500, token);
            yield return "Camilo 0.5";
            await Task.Delay(300, token);
            yield return "Camilo 0.3";
        }

        /// <summary>
        /// esto es para cuando no tengo control del método para cancelar, si no que tengo es control sobre el retorno del método
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            cancellationTokenSource = new CancellationTokenSource();

            var namesEnumerable = GenerateNamesAsync2();
            await ProcessNames(namesEnumerable);
            Console.WriteLine("Finish");
            cancellationTokenSource = null;
            loadingGif.Visible = false;
        }

        //Antipatrones
        //Sincrono dentro de un asincrono
        private async Task<string> GetValue()
        {
            await Task.Delay(1000);
            ////2da Solución, con esto no se bloquea el hilo principal, animaciones y demás, 
            ////pero al menos no se crashea la app
            //await Task.Delay(1000).ConfigureAwait(false);
            return "Dani";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;

            var value = GetValue().Result;
            Console.WriteLine(value);

            ////1ra solución, no bloquar el hilo principal
            //var value = GetValue();
            //Console.WriteLine(value);

            loadingGif.Visible = false;
        }

        //Asincrono dentro de un síncrono
        private string GetValueSync()
        {
            return "Dani";
        }

        private async Task<string> GetValueAsync()
        {
            //Antipatrón
            return await Task.Run(() => GetValueSync());
        }

        private async void button39_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;

            //var resultStartNew = await await Task.Factory.StartNew(async () =>
            var resultStartNew = await Task.Factory.StartNew(async () =>
            {
                //Este delegado queda envuelto en otro Task. StarNew quedaria
                //Task<Task<int>>, hay que colcoar otro await
                // o utilizar unwrap
                await Task.Delay(1000);
                return 7;
            }).Unwrap();
            var resultRun = await Task.Run(async () =>
            {
                await Task.Delay(1000);
                return 7;
            });

            Console.WriteLine($"Result StartNew: {resultStartNew}");
            Console.WriteLine("----------------");
            Console.WriteLine($"Result Task.Run: {resultRun}");
            loadingGif.Visible = false;
        }

        //        3.5.	Hacer Dispose a los CancellationToken - Timers
        //Vid 46
        //A los timers debemos hacerles siempre dispose.Los cancellationToken internamente utilizan timers.
        //Por regla general, si algo hereda de dispose, deberíamos hacerles siempre dispose.

        //3 formas:
        //-	
        //Var tiempoLimitie = TimeSpan.FromSeconds(5);
        //        Try
        //{
        //cancellationTokenSource = new CancellationTokenSource(tiempoLimite);
        //    }
        //    Finally{
        //cancellationTokenSource.Dispose();
        //}

        //-Hacer uso de Using
        //Using(var cts2 = new CancellationTokenSource(tiempoLimite)){
        //}

        //-Hacer uso de using vble
        //Using var cts3 = new CancellationTokenSource(tiempoLimite);

        private async Task MethodAcyncEx()
        {
            Stream stream = new MemoryStream();
            using (var streamWriter = new StreamWriter(stream))
            {
                await streamWriter.WriteAsync("Hello world");
            }
            //es posible que cuando se haga el dispose aún existan datos en el buffer,
            //estos datos se van a transferir de manera sincrona

            //solution 1
            await using (var streamWriter = new StreamWriter(stream))
            {
                await streamWriter.WriteAsync("Hello world");
            }

            //solution 2
            using (var streamWriter = new StreamWriter(stream))
            {
                await streamWriter.WriteAsync("Hello world");
                await streamWriter.FlushAsync();
            }
            //Flush es la operación que hace el vaciado de toda la información que hay en el buffer hacia su destino.
            //Lo mejor es usar Flush
        }

        //PARALELISMO
        private void button11_Click(object sender, EventArgs e)
        {
            ProcessImagesParallel();
        }

        private async Task ProcessImagesParallel()
        {
            loadingGif.Visible = true;
            var directoryCurrent = AppDomain.CurrentDomain.BaseDirectory;
            var destionationBaseSecuential = Path.Combine(directoryCurrent, @"D:\tmpBlazorFiles\secuentialResult");
            var destionationBaseParallel = Path.Combine(directoryCurrent, @"D:\tmpBlazorFiles\parallelResult");
            PrepareExecution(destionationBaseParallel, destionationBaseSecuential);

            Console.WriteLine("begin");
            var images = GetImages();

            //Secuential
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var image in images)
            {
                await ProcesarImagen(destionationBaseSecuential, image);
            }
            var tiempoSecuencial = stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Secuencial - duración en segundos: {0}",
                    tiempoSecuencial);

            stopwatch.Restart();
            // Parte paralelo 

            var tareasEnumerable = images.Select(async imagen => await ProcesarImagen(destionationBaseParallel, imagen));
            await Task.WhenAll(tareasEnumerable);
            var tiempoEnParalelo = stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Paralelo - duración en segundos: {0}", tiempoEnParalelo);

            Utils.EscribirComparacion(tiempoSecuencial, tiempoEnParalelo);
            Console.WriteLine("fin");

            loadingGif.Visible = false;
        }

        private void PrepareExecution(string destinationBaseParallel
            , string destinationBaseSecuential)
        {
            if (!Directory.Exists(destinationBaseParallel))
            {
                Directory.CreateDirectory(destinationBaseParallel);
            }

            if (!Directory.Exists(destinationBaseSecuential))
            {
                Directory.CreateDirectory(destinationBaseSecuential);
            }

            DeleteFiles(destinationBaseSecuential);
            DeleteFiles(destinationBaseParallel);
        }

        private void DeleteFiles(string directory)
        {
            var files = Directory.EnumerateFiles(directory);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }

        private static List<ImageConcurrence> GetImages()
        {
            var images = new List<ImageConcurrence>();
            for (int i = 0; i < 5; i++)
            {
                {
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img1_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img2_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img3_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img4_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img5_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img6_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img7_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img8_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img9_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                    images.Add(new ImageConcurrence()
                    {
                        Name = $"Img10_{i.ToString()}.jpg",
                        URL = "https://images.cdn2.buscalibre.com/fit-in/360x360/db/2b/db2b538974143607a817fbc28577cb09.jpg"
                    });
                }
            }
            return images;
        }

        private async Task ProcesarImagen(string directorio, ImageConcurrence imagen)
        {
            var response = await httpClient.GetAsync(imagen.URL);
            var content = await response.Content.ReadAsByteArrayAsync();

            Bitmap bitmap;
            using (var ms = new MemoryStream(content))
            {
                bitmap = new Bitmap(ms);
            }

            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            var destino = Path.Combine(directorio, imagen.Name);
            bitmap.Save(destino);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            Console.WriteLine("Secuential");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Parallel");
            Parallel.For(0, 11, i => Console.WriteLine(i));

            loadingGif.Visible = false;
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            await ParallelForSpeed();
        }

        private async Task ParallelForSpeed()
        {
            loadingGif.Visible = true;

            var colMatrizA = 1110;
            var filas = 1000;
            var colMatrizB = 1750;
            var matrizA = Matrices.InicializarMatriz(filas, colMatrizA);
            var matrizB = Matrices.InicializarMatriz(colMatrizA, colMatrizB);
            var result = new double[filas, colMatrizB];

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await Task.Run(() => Matrices.MultiplicarMatricesSecuencial(matrizA, matrizB, result));
            var timeSecuencial = stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Secuencial - time elapsed in seconds: {0}", timeSecuencial);

            result = new double[filas, colMatrizB];
            stopwatch.Restart();
            await Task.Run(() => Matrices.MultiplicarMatricesParalelo(matrizA, matrizB, result));
            var timeParallel = stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Parallel - time elapsed in seconds: {0}", timeParallel);

            Utils.EscribirComparacion(timeSecuencial, timeParallel);
            Console.WriteLine("End");

            stopwatch.Stop();

            loadingGif.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _ = ParallelForEach();
        }

        public async Task ParallelForEach()
        {
            var directorioActual = AppDomain.CurrentDomain.BaseDirectory;
            //need images in next folder, previous exercise
            var carpetaOrigen = Path.Combine(directorioActual, @"D:\tmpBlazorFiles\secuentialResult");
            var carpetaDestinoSecuencial = Path.Combine(directorioActual, @"D:\tmpBlazorFiles\foreach-secuencial");
            var carpetaDestinoParalelo = Path.Combine(directorioActual, @"D:\tmpBlazorFiles\foreach-paralelo");
            Utils.PrepararEjecucion(carpetaDestinoSecuencial, carpetaDestinoParalelo);

            var archivos = Directory.EnumerateFiles(carpetaOrigen);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Algoritmo secuencial
            foreach (var archivo in archivos)
            {
                VoltearImagen(archivo, carpetaDestinoSecuencial);
            }

            var tiempoSecuencial = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine("Secuencial - duración en segundos: {0}",
                    tiempoSecuencial);

            stopwatch.Restart();

            // Algoritmo en paralelo
            Parallel.ForEach(archivos, archivo =>
            {
                VoltearImagen(archivo, carpetaDestinoParalelo);
            });

            var tiempoEnParalelo = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine("Paralelo - duración en segundos: {0}",
                   tiempoEnParalelo);

            Utils.EscribirComparacion(tiempoSecuencial, tiempoEnParalelo);

            Console.WriteLine("fin");
        }

        private void VoltearImagen(string archivo, string carpetaDestino)
        {
            using (var image = new Bitmap(archivo))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                var nombreArchivo = Path.GetFileName(archivo);
                var destino = Path.Combine(carpetaDestino, nombreArchivo);
                image.Save(destino);
            }
        }
    }
}
namespace Concurrence.Desktop.Helpers
{
    public static class TaskExtensionMethods
    {
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            //cancellationToken.Register Me permite tener un delegado, es decir, una función que va a
            //ejecutarse cuando el token sea cancelado
            using (cancellationToken.Register(state =>
            {
                ((TaskCompletionSource<object>)state).TrySetResult(null);
            }, tcs))
            {
                var taskResult = await Task.WhenAny(task, tcs.Task);
                if (taskResult == tcs.Task) //Significa que el usuario canceló la tarea
                {
                    throw new OperationCanceledException(cancellationToken);
                }
                return await task;
            }
        }
    }
}

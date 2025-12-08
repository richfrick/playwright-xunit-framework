using System.Runtime.CompilerServices;

namespace Framework.Driver;


//This is re-usable code created to support lazy loading in the constructor of Playwright Driver but can be re-used anywahere un the project

public class AsyncTask<T>: Lazy<Task<T>>
{
    public AsyncTask(Func<Task<T>> taskFactory) : base(() => Task.Factory.StartNew(taskFactory).Unwrap())
    {
        
    }

    public TaskAwaiter<T> GetAwaiter()
    {
        return Value.GetAwaiter();
    }
}
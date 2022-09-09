class Program
{

    static async Task Main(string[] args)
    {
         Deliver().Wait();
        Console.ReadKey();

    }
    static Task Deliver()
    {
        var task = Task
            .WhenAll(CourierA(), CourierB())
            .ContinueWith(t => Console.WriteLine("Done"));
        var awaits = task.GetAwaiter();

        return task;
    }
    static Task CourierA()
    {
        var task = Task.Delay(1000);
        var awaiters = task.GetAwaiter();
        awaiters.OnCompleted(() => Console.WriteLine("Courier A delivered")) ;
        return task;
    }

    static  Task CourierB()
    {
        var task = Task.Delay(1500).ContinueWith(s=> Task.WhenAll(Loader1(), Loader2())).Unwrap();
        
        var awaiters = task.GetAwaiter();
        awaiters.OnCompleted(() => Console.WriteLine("Courier B delivered"));
        return task;    
    }

    static  Task Loader1()
    {
        var task = Task.Delay(500);
        var awaiters = task.GetAwaiter();
       awaiters.OnCompleted(() => Console.WriteLine("Loader 1 delivered"));
        return task;
    }

    static  Task Loader2()
    {
        var task = Task.Delay(600);
        var awaiters = task.GetAwaiter();
        awaiters.OnCompleted(() => Console.WriteLine("Loader 2 delivered"));
        return task;
    }
  

}

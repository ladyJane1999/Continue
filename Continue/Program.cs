﻿class Program
{
    static async Task Main(string[] args)
    {
        await Deliver();
    }

    static async Task Deliver()
    {
        await Task.WhenAll(CourierA(), CourierB());
        Console.WriteLine("Delivered");
    }

    static async Task CourierA()
    {
        await Task.Delay(1000);
        Console.WriteLine("Courier A delivered");
    }

    static async Task CourierB()
    {
        await Task.Delay(1500);
        await Task.WhenAll(Loader1(), Loader2());
        Console.WriteLine("Courier B delivered");
    }

    static async Task Loader1()
    {
        await Task.Delay(500);
        Console.WriteLine("Loader 1 delivered");
    }

    static async Task Loader2()
    {
        await Task.Delay(600);
        Console.WriteLine("Loader 2 delivered");
    }
}
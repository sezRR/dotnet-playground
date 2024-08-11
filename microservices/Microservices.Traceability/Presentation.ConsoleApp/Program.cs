using System.Diagnostics;
using NLog;

var logger = LogManager.GetCurrentClassLogger();
Trace.CorrelationManager.ActivityId = Guid.NewGuid();

Work1();

void Work1()
{
    Console.WriteLine("Work1 triggered.");
    logger.Debug("Work1 triggered.");
    Work2();
}

void Work2()
{
    Console.WriteLine("Work2 triggered.");
    logger.Debug("Work2 triggered.");
    Work3();
}

void Work3()
{
    Console.WriteLine("Work3 triggered.");
    logger.Debug("Work3 triggered.");
}
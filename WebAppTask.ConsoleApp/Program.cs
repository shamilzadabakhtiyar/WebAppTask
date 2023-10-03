using System.Diagnostics;
using WebAppTask.ConsoleApp;

do
{
    AddLog("App is running...");

    Console.Write("Request type (Sync = 0, Async = 1): ");
    int requestType = int.Parse(Console.ReadLine());

    Console.Write("How many request: ");
    int requestCount = int.Parse(Console.ReadLine());

    var webApiClient = new WebApiClient();

    var sw = new Stopwatch();
    sw.Start();

    var tasks = requestType == 0 ? GetSyncTasks(requestCount) : GetAsyncTasks(requestCount);
    await Task.WhenAll(tasks);

    sw.Start();

    AddLog($"Total time: {sw.ElapsedMilliseconds} ms");

} while (Console.ReadKey().Key == ConsoleKey.R);

IEnumerable<Task> GetSyncTasks(int count)
{
    var result = new List<Task>();
    var client = new WebApiClient();
    for (int i = 0; i < count; i++)
        result.Add(client.CallSync());
    return result;
}

IEnumerable<Task> GetAsyncTasks(int count)
{
    var result = new List<Task>();
    var client = new WebApiClient();
    for (int i = 0; i < count; i++)
        result.Add(client.CallAsync());
    return result;
}

void AddLog(string logStr)
{
    logStr = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logStr}";
    Console.WriteLine(logStr);
}
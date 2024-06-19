using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CoroutineRunner
{
    private static List<Task> activeCoroutines = new List<Task>();

    public static Task Start(IEnumerator coroutine)
    {
        var task = RunCoroutine(coroutine);
        activeCoroutines.Add(task);
        return task;
    }

    private static async Task RunCoroutine(IEnumerator coroutine)
    {
        List<Task> tasks = new List<Task>();
        while (coroutine.MoveNext())
        {
            if (coroutine.Current is IEnumerator nested)
            {
                tasks.Add(RunCoroutine(nested));
            }
            else if (coroutine.Current is Task task)
            {
                tasks.Add(task);
            }
            else if (coroutine.Current is int milliseconds)
            {
                tasks.Add(Task.Delay(milliseconds));
            }
            else if (coroutine.Current is TimeSpan timeSpan)
            {
                tasks.Add(Task.Delay(timeSpan));
            }
            else
            {
                await Task.Yield(); // Yield execution for one frame
            }

            await Task.WhenAll(tasks); // Wait for all nested tasks
        }

        activeCoroutines.Remove(Task.CompletedTask);
    }

    public static void StopAllCoroutines()
    {
        activeCoroutines.Clear(); // This will stop tracking all coroutines
    }

    
}

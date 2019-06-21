using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSource
{
    public static class TaskExtensions
    {
        public static IEnumerable<Task<T>> OrderByCompletion<T>(this IEnumerable<Task<T>> initialTasks)
        {
            var inputTasks = initialTasks.ToList();
            var completions = new TaskCompletionSource<T>[inputTasks.Count];
            int currentIndex = -1;

            for (int i = 0; i < inputTasks.Count; i++)
            {
                completions[i] = new TaskCompletionSource<T>();
                inputTasks[i].ContinueWith(completed =>
                {
                    currentIndex = Interlocked.Increment(ref currentIndex);
                    switch (completed.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            completions[currentIndex].SetResult(completed.Result);
                            break;
                        case TaskStatus.Faulted:
                            completions[currentIndex].SetException(completed.Exception);
                            break;
                        case TaskStatus.Canceled:
                            completions[currentIndex].SetCanceled();
                            break;
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            }

            return completions.Select(x => x.Task);
        }
    }
}
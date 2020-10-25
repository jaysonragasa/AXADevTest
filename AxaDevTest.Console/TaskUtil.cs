using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AxaDevTest.Console
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex, object sender, [CallerMemberName] string name = "");
    }

    public static class TaskUtilities
    {
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null, object sender = null)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex, sender.ToString());
            }
        }
    }
}

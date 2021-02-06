using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.api.Invocables
{
    public class PrintToConsole : IInvocable
    {
        public Task Invoke()
        {
            Console.WriteLine("Hello world");
            return Task.CompletedTask;
        }
    }
}

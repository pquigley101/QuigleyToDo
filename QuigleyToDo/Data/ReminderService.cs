using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuigleyToDo.Data
{
    public class ReminderService : BackgroundService
    {
        public static event Func<string, Task,int>> UpdateEvent;
        protected override async Task<int> ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000);
                if (UpdateEvent != null)
                    await UpdateEvent.Invoke(DateTime.Now.ToString());

            }
        }
    }
}

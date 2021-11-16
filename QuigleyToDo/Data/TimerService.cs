using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuigleyToDo.Data
{
    public class TimerService : BackgroundService
    {
        public static event Func<DateTime, Task> UpdateEvent;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000 * 45);
                if (UpdateEvent != null)
                    await UpdateEvent.Invoke(DateTime.Now);

            }
        }

      
    }
}

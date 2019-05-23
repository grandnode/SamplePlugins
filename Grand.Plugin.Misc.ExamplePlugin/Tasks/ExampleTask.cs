using Grand.Core.Domain.Tasks;
using Grand.Services.Logging;
using Grand.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Tasks
{
    public class ExampleTask :  IScheduleTask
    {
        private readonly ILogger _logger;
        public ExampleTask(ILogger logger)
        {
            this._logger = logger;
        }

        public async Task Execute()
        {
            await _logger.InsertLog(Core.Domain.Logging.LogLevel.Information, "Example task executed");
        }
    }
}

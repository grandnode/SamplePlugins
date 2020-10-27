using Grand.Services.Logging;
using Grand.Services.Tasks;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Tasks
{
    public class ExampleTask :  IScheduleTask
    {
        private readonly ILogger _logger;
        public ExampleTask(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Execute()
        {
            await _logger.InsertLog(Grand.Domain.Logging.LogLevel.Information, "Example task executed");
        }
    }
}

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Phoenix.Common.Logging;

namespace Phoenix.Console
{
    public sealed class App
    {
        private readonly IAppService _appService;
        private readonly ILogger _logger;
        
        public App(IAppService appService)
        {
            _appService = appService;
            _logger = ApplicationLogging.CreateLogger<App>();
        }

        public void Run()
        {
            _logger.LogInformation("App::Run");
            _appService.Run();
        }

        public async Task RunAsync()
        {
            _logger.LogInformation("App::RunAsync");
            await _appService.RunAsync();
        }
    }
}
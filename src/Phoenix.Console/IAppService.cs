using System.Threading.Tasks;

namespace Phoenix.Console
{
    public interface IAppService
    {
        void Run();
        Task RunAsync();
    }
}
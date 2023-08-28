using Microsoft.AspNetCore.Mvc;

namespace HumanCapital.Controllers
{
    public abstract class ApiBaseController : ControllerBase, IDisposable
    {
        protected readonly CancellationTokenSource Cts;

        public ApiBaseController()
        {
            Cts = new CancellationTokenSource();
        }

        public void Dispose()
        {
            Cts.Cancel();
            Cts.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

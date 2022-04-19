using Caliburn.Micro;
using System.Threading;

namespace SimpleTabbedNavigation.ViewModels
{
    class ShellViewModel : Conductor<object>
    {

        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<DemoViewModel>(), new CancellationToken());
        }

    }
}

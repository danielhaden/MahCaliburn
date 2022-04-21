using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWindow.ViewModels
{
    public class DemoViewModel : PropertyChangedBase
    {

        /// <summary>
        /// Stores the events aggregator
        /// </summary>
        private readonly IEventAggregator events;

        public string ButtonDemoContent { get; set; } = "Hover mouse to see demo";

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_events"></param>
        public DemoViewModel(IEventAggregator _events)
        {

            events = _events;
            events.SubscribeOnPublishedThread(this);

        }

        public async void OnSeeDialogWindowClick()
        {
            await Task.Run(() => Console.WriteLine("GOT HERE"));
        }

        public async void OnMouseHover()
        {
            await Task.Run(() => ButtonDemoContent = "!!!!!");
            Refresh();
        }
    }
}

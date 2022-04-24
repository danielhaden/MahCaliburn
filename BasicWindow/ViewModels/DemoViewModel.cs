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


        #region Properties
        private string simpleButtonEventMessage;
        public string SimpleButtonEventMessage
        {
            get => simpleButtonEventMessage;
            set => Set(ref simpleButtonEventMessage, value);
        }

        private string button2EventMessage;
        public string Button2EventMessage
        {
            get => button2EventMessage;
            set => Set(ref button2EventMessage, value);
        }
        #endregion

        #region Constructors
        /// <summary>       
        /// Default constructor
        /// </summary>
        /// <param name="_events"></param>
        public DemoViewModel(IEventAggregator _events)
            {

                events = _events;
                events.SubscribeOnPublishedThread(this);

            }
        #endregion

        #region Actions
            public void SimpleButtonClick()
            {
                SimpleButtonEventMessage = "used cal:Message.Attach";
            }

            public void Button3MouseEnter()
            {
                Button2EventMessage = "Mouse hovered over button2";
            }

            public void Button3MouseLeave()
            {
                Button2EventMessage = "Mouse left button2";
            }

            public void Button3Click()
            {
                Button2EventMessage = "Mouse clicked button2";
            }

            public void ShowDialogWindow()
            {

            }

        #endregion

    }
}

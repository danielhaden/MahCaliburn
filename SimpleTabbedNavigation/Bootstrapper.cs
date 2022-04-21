using Caliburn.Micro;
using SimpleTabbedNavigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SimpleTabbedNavigation
{
    public class Bootstrapper : BootstrapperBase
    {

        private SimpleContainer container = new SimpleContainer();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Bootstrapper()
        {
            Initialize();
        }


        /// <summary>
        /// Builds up the IoC container
        /// </summary>
        /// <param name="instance">The object that should be added to the container</param>
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        /// <summary>
        /// Configures the IoC container and instantiates necessary objects
        /// </summary>
        protected override void Configure()
        {
            container
                .Singleton<IWindowManager, AppWindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

        }

        /// <summary>
        /// Retrieves the requested service from the IoC container
        /// </summary>
        /// <param name="service">The service to be retrieved</param>
        /// <param name="key">The name of the service</param>
        /// <returns></returns>
        protected override object GetInstance(Type service, string key)
        {
            var instance = this.container.GetInstance(service, key);
            if (instance != null)
            {
                return instance;
            }

            throw new Exception("Could not locate any instances.");
        }


        /// <summary>
        /// Called on application startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<DemoViewModel>();
        }

    }
}

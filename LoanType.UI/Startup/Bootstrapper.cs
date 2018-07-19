using Autofac;
using LoanType.DataService;
using LoanType.UI.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<LoanTypeService>().As<ILoanTypeService>();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<LoanTypesListViewModel>().AsSelf();
            builder.RegisterType<LoanTypesListItemViewModel>().AsSelf();
            builder.RegisterType<LoanTypesDetailViewModel>().AsSelf();
            return builder.Build();
        }
    }
}

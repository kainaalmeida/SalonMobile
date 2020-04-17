using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using SalonMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalonMobile.ViewModels
{
    public class DetailPageViewModel : ViewModelBase, IAutoInitialize
    {
        private Salon _selectedSalon;
        public Salon SelectedSalon
        {
            get { return _selectedSalon; }
            set { SetProperty(ref _selectedSalon, value); }
        }

        public List<Service> Services { get; } = new List<Service>();

        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(async () => await ExecuteCloseCommand()));

        public DetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Services.Add(new Service { Name = "Men’s Hair Cut", Time = "45 Min", Price = "$30" });
            Services.Add(new Service { Name = "Women’s Hair Cut", Time = "60 Min", Price = "$50" });
            Services.Add(new Service { Name = "Color & Blow Dry", Time = "90 Min", Price = "$75" });
            Services.Add(new Service { Name = "Oil Treatment", Time = "30 Min", Price = "$20" });
        }


        public async Task ExecuteCloseCommand()
        {
            await NavigationService.GoBackAsync();
        }
    }
}

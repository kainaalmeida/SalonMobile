using Prism.Commands;
using Prism.Navigation;
using SalonMobile.Models;
using SalonMobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalonMobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private int _selectedSalonId;
        public int SelectedSalonId
        {
            get { return _selectedSalonId; }
            set { SetProperty(ref _selectedSalonId, value); }
        }

        public List<Salon> Salons { get; } = new List<Salon>();

        private DelegateCommand<Salon> _salonCommand;
        public DelegateCommand<Salon> SalonCommand =>
            _salonCommand ?? (_salonCommand = new DelegateCommand<Salon>(async (item) => await ExecuteSalonCommand(item)));

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            LoadData();
        }

        void LoadData()
        {
            Salons.Add(new Salon { Id = 1, Client = "Cameron Jones", SalonName = "Super Cut Salon", Ranking = "4.8", Img = "user01.png", BgColor = "#FFF0EB" });
            Salons.Add(new Salon { Id = 2, Client = "Max Robertson", SalonName = "Rossano Ferretti Salon", Ranking = "4.7", Img = "user02.png", BgColor = "#EBF6FF" });
            Salons.Add(new Salon { Id = 3, Client = "Beth Watson", SalonName = "Neville Hair and Beauty", Ranking = "4.6", Img = "user03.png", BgColor = "#FFF0EB" });
        }

        public async Task ExecuteSalonCommand(Salon salon)
        {
            SelectedSalonId = salon.Id;
            var navParam = new NavigationParameters { { "SelectedSalon", salon } };
            await NavigationService.NavigateAsync($"{nameof(DetailPage)}", navParam);
        }
    }
}

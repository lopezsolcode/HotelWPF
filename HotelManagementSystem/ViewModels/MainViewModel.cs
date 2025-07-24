using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelManagementSystem.Commands;

namespace HotelManagementSystem.ViewModels
{
    class MainViewModel :ViewModelBase
    {
        private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(nameof(CurrentViewModel)); }
        }

        public ICommand ShowHabitacionesCommand { get; }
        public ICommand ShowClientesCommand { get; }
        public ICommand ShowReservasCommand { get; }

        public MainViewModel()
        {
            ShowHabitacionesCommand = new RelayCommand(_ => CurrentViewModel = new HabitacionesViewModel());
            ShowClientesCommand = new RelayCommand(_ => CurrentViewModel = new ClientesViewModel());
            ShowReservasCommand = new RelayCommand(_ => CurrentViewModel = new ReservasViewModel());

            // Vista inicial
            CurrentViewModel = new HabitacionesViewModel();
        }

    }
}

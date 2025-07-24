using HotelManagementSystem.Commands;
using HotelManagementSystem.Models; 
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModels
{
    public class HabitacionesViewModel : ViewModelBase
    {
        private string _searchText;
        private DboRoom _habitacionSeleccionada;

        public ObservableCollection<DboRoom> Habitaciones { get; set; }
        public ObservableCollection<DboRoom> HabitacionesFiltradas { get; set; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FiltrarHabitaciones();
                }
            }
        }

        public DboRoom HabitacionSeleccionada
        {
            get => _habitacionSeleccionada;
            set
            {
                _habitacionSeleccionada = value;
                OnPropertyChanged();
            }
        }

        public ICommand AgregarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }

        public HabitacionesViewModel()
        {
            using (var context = new HotelDbContext())
            {
                Habitaciones = new ObservableCollection<DboRoom>(context.DboRooms.ToList());
            }

            HabitacionesFiltradas = new ObservableCollection<DboRoom>(Habitaciones);

            AgregarCommand = new RelayCommand(_ => AgregarHabitacion());
            EditarCommand = new RelayCommand(_ => EditarHabitacion(), _ => HabitacionSeleccionada != null);
            EliminarCommand = new RelayCommand(_ => EliminarHabitacion(), _ => HabitacionSeleccionada != null);
        }

        private void FiltrarHabitaciones()
        {
            var texto = SearchText?.ToLower() ?? string.Empty;

            var filtradas = Habitaciones
                .Where(h => h.RoomNo.ToLower().Contains(texto)) // Cambia por campos reales
                .ToList();

            HabitacionesFiltradas.Clear();
            foreach (var habitacion in filtradas)
                HabitacionesFiltradas.Add(habitacion);
        }

        private void AgregarHabitacion()
        {
            var ventana = new Views.AgregarHabitacion();
            bool? resultado = ventana.ShowDialog();

            if (resultado == true && ventana.NuevaHabitacion != null)
            {
                var nueva = ventana.NuevaHabitacion;

                Habitaciones.Add(nueva);

                // Si hay texto de búsqueda, solo agregar si cumple filtro
                if (string.IsNullOrWhiteSpace(SearchText) || nueva.RoomNo.ToLower().Contains(SearchText.ToLower()))
                {
                    HabitacionesFiltradas.Add(nueva);
                }
            }
        }

        private void EditarHabitacion()
        {
            // Lógica para editar la seleccionada
        }

        private void EliminarHabitacion()
        {
            if (HabitacionSeleccionada == null)
                return;

            Habitaciones.Remove(HabitacionSeleccionada);
            HabitacionesFiltradas.Remove(HabitacionSeleccionada);

            // Y en base de datos:
            using (var context = new HotelDbContext())
            {
                var entity = context.DboRooms.Find(HabitacionSeleccionada.Roomid);
                if (entity != null)
                {
                    context.DboRooms.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
    }
}
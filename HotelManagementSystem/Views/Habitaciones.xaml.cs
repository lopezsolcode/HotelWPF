using HotelManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagementSystem.Views
{
    /// <summary>
    /// Lógica de interacción para Habitaciones.xaml
    /// </summary>
    public partial class Habitaciones : UserControl
    {
        public Habitaciones()
        {
            InitializeComponent();
            this.DataContext = new HabitacionesViewModel();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new AgregarHabitacion();
            var resultado = ventana.ShowDialog();

            if (resultado == true)
            {
                var habitacion = ventana.NuevaHabitacion;

                if (DataContext is HabitacionesViewModel vm)
                {
                    vm.Habitaciones.Add(habitacion);
                    vm.HabitacionesFiltradas.Add(habitacion);
                }
            }

        }

        private void Reserved_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Free_Click(object sender, RoutedEventArgs e)
        {

        }

        private void All_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

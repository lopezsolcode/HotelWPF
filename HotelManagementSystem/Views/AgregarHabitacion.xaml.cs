using HotelManagementSystem.Models;
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
using System.Windows.Shapes;

namespace HotelManagementSystem.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarHabitacion.xaml
    /// </summary>
    public partial class AgregarHabitacion : Window
    {
        public DboRoom NuevaHabitacion { get; private set; }
        public AgregarHabitacion()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        

        

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoHabitacion.Text) ||
                txtTipoHabitacion.SelectedItem == null ||
                txtTipoDeCama.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                !long.TryParse(txtPrecio.Text, out long precio))
            {
                MessageBox.Show("Por favor, completa todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var tipoHabitacion = ((ComboBoxItem)txtTipoHabitacion.SelectedItem).Content.ToString();
            var tipoCama = ((ComboBoxItem)txtTipoDeCama.SelectedItem).Content.ToString();

            NuevaHabitacion = new DboRoom
            {
                RoomNo = txtNoHabitacion.Text,
                RoomType = tipoHabitacion,
                Bed = tipoCama,
                Price = precio,
                Booked = "No"
            };

            // Guardar en base de datos
            using (var context = new HotelDbContext())
            {
                context.DboRooms.Add(NuevaHabitacion);
                context.SaveChanges();
            }

            DialogResult = true;
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}

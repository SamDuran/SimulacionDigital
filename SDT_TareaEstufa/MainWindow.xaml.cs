using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SDT_TareaEstufa
{
    public partial class MainWindow : Window
    {
        Dictionary<string, int> tiemposCoccion;
        private bool estamosCocinando;
        private int tiempoCoccion;
        private Thread? ProcesoCoccion;

        public MainWindow()
        {
            InitializeComponent();
            tiemposCoccion = new Dictionary<string, int>()
            {
                { "Pez", 20 },
                { "Res", 60 },
                { "Cerdo", 40 },
                { "Pollo", 30 }
            };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CustomMessageBox(@"Hacer un programa que simule una estufa que pueda decir el tiempo de cocción. Hacer una barra de aumentar la velocidad o disminuir. (0, 1/4, 1/2, full) 
Que diga el total de cocción al final de la simulación o que si pongo la barra o botón en 0 también termine.

Combustible: ( el suministro de combustible debe ser automático)
Madera (ejemplo: 1000 k/c/h)
Gas
Hoja
Electricidad 
Carbón mineral 

Productos:  (debemos de investigar el tiempo de cocción de cada producto)
Pez
Res
Cerdo
Pollo", "Mandato", MessageBoxButton.OK, MessageBoxImage.Information).Show();

        }


        private void SimularClick(object sender, RoutedEventArgs e)
        {
            if (SimularBTN.Content.ToString() == "Detener")
            {
                estamosCocinando = false;
                txtStatus.Text += Environment.NewLine + "La simulacion se detuvo";
                SimularBTN.Content = "Simular";
                return;
            }
            string? combustibleSeleccionado = ObtenerRadioButtonsSeleccionados(CombustibleContainer);
            string? productoSeleccionado = ObtenerRadioButtonsSeleccionados(ProductosContainer);

            if (!string.IsNullOrEmpty(combustibleSeleccionado) && !string.IsNullOrEmpty(productoSeleccionado) && (int)slider.Value>0)
            {
                tiempoCoccion = tiemposCoccion[productoSeleccionado];
                progressBar.Value = 0;
                txtStatus.Text = $"Simulando cocción de {productoSeleccionado} utilizando {combustibleSeleccionado}. Tiempo de cocción: {tiempoCoccion} minutos. \n(Se simularan en segundos)";

                estamosCocinando = true;
                ProcesoCoccion = new Thread(CocinarProducto);
                ProcesoCoccion.Start();
                SimularBTN.Content = "Detener";
            }else if ((int)slider.Value == 0)
            {
                MessageBox.Show("Debe seleccionar la intensidad de la llama", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Debe seleccionar el combustible y el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string? ObtenerRadioButtonsSeleccionados(StackPanel container)
        {
            foreach (UIElement element in container.Children)
            {
                if (element is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    return radioButton.Content.ToString();
                }
            }
            return null;
        }
        private void CocinarProducto()
        {
            int progresoActual = 0;
            int tiempoMaximo = tiempoCoccion;
            int velocidadCoccion;
            while (estamosCocinando && progresoActual < tiempoMaximo)
            {
                velocidadCoccion = (tiempoCoccion * 100) + 1000;
                Thread.Sleep(velocidadCoccion);
                progresoActual++;


                Dispatcher.Invoke(() =>
                {
                    progressBar.Value = (double)progresoActual / tiempoMaximo * 100;
                });
            }

            Dispatcher.Invoke(() =>
            {
                txtStatus.Text += Environment.NewLine + "La cocción ha finalizado.";
                estamosCocinando = false;
            });
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newTiempoCoccion = 0;
            var llama = "";
            if (estamosCocinando)
            {
                switch ((int)slider.Value)
                {
                    case 0:
                        {
                            newTiempoCoccion = 0;
                            llama = "Apagada";
                            break;
                        }
                    case 1:
                        {
                            newTiempoCoccion = 3;
                            llama = "Baja";
                            break;
                        }
                    case 2:
                        {
                            newTiempoCoccion = 6;
                            llama = "Media";
                            break;
                        }
                    case 3:
                        {
                            newTiempoCoccion = 10;
                            llama = "Alta";
                            break;
                        }

                }
                int currentProgress = (int)(progressBar.Value / 100 * (tiempoCoccion * 60));

                txtStatus.Text += Environment.NewLine + $"Simulando cocción con llama {llama}, Tiempo de cocción: {newTiempoCoccion} minutos. \nTiempo ocurrido: {currentProgress} segundos.";
                txtStatus.Text += Environment.NewLine + $"Progreso: {(currentProgress/tiempoCoccion)*100} %";

                tiempoCoccion = newTiempoCoccion;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            estamosCocinando = false;
            ProcesoCoccion?.Join();
            base.OnClosing(e);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace JsonConverter
{
    /// <summary>
    /// AcilisEkrani.xaml etkileşim mantığı
    /// </summary>
    public partial class AcilisEkrani : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var animation = (Storyboard)Resources["TransformImage"];
            animation.Begin();
        }

        private void TransformImage_Completed(object sender, EventArgs e)
        {      
            System.Threading.Thread.Sleep(2000);
            MainWindow mainDisplay = new MainWindow();
            mainDisplay.Show();
            this.Close();
        }

    }
}

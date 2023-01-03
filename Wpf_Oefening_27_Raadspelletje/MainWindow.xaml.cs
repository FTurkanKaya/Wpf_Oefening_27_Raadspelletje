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



namespace Wpf_Oefening_27_Raadspelletje
{
    using Microsoft.VisualBasic;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        string antwoord;
        private Random rd = new Random();
        int getal;
        int willekeurigeAntwoord;
        int beurt;
        

        public MainWindow()
        {
            InitializeComponent();
            rd = new Random();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            
            getal = rd.Next(0, 101);
            beurt = 0;

            do
            {
                beurt++;
                antwoord = Interaction.InputBox("Geef een getal tussen 1 en 100", "Raadspel", "Vb-1,2,3,4",500);
                willekeurigeAntwoord = Convert.ToInt32(antwoord);


                if (string.IsNullOrEmpty(antwoord))
                {
                    MessageBox.Show("Geef een getal in tussen 0 en 100", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    //antwoord = Interaction.InputBox("Geef een getal in tussen 0 en 100", "Raadspel", "Vb:1,2,3,4");

                }

                else if (willekeurigeAntwoord > getal)
                {
                    MessageBox.Show("Raad lager", "Raadspel");
                    Img.Source = new BitmapImage(new Uri("/Images/duim-omlaag.png", UriKind.Relative));
                    Img.Visibility = Visibility.Visible;
                }

                else if (willekeurigeAntwoord < getal)
                {
                    MessageBox.Show("Raad hoger", "Raadspel");
                    Img.Source = new BitmapImage(new Uri("/Images/omhoog.jpg", UriKind.Relative));
                    Img.Visibility = Visibility.Visible;
                }
                
            } while (willekeurigeAntwoord!= getal);


            if (willekeurigeAntwoord == getal)
            {
                MessageBox.Show(($"U heeft het getal geraden in {beurt} beurten."), "Proficiat!!");
                Img.Source = new BitmapImage(new Uri("/Images/proficiat.jpg", UriKind.Relative));
                Img.Visibility = Visibility.Visible;
            }






        }
    }
}

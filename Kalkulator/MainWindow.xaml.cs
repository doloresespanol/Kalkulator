using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Nowy_Click(object sender, RoutedEventArgs e)
        {
            //sprawdź czy coś jest zapisane w textbox
            //jeżeli tak to zapytac czy to wczesniej zapisac
            if (string.IsNullOrEmpty(tekst.Text))
            {
                tekst.Clear();
            }
            else
            {
                MessageBoxResult czyZapisac = MessageBox.Show("Masz niezapisany text, czy chciałbyś zapisać", "Wynik", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (czyZapisac == MessageBoxResult.Yes)
                {
                    SaveFileDialog a = new SaveFileDialog();
                    a.Filter = "PlainText | *.txt";
                    a.Title = "Zapisz jako";
                    if (a.ShowDialog() == true)
                    {
                        //zapisywanie do pliku
                        File.WriteAllText(a.FileName, tekst.Text);
                        //TODO nazwa pliku jako nazwa okna
                    }
                }
                else
                {
                    tekst.Clear();
                }
            }
        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            int nwd = 0;
            int temp = 0;
            int nww = 0;
            int wynik = 0;
            if (int.TryParse(tekst.Text, out int liczba))
                {
                    if(int.TryParse(tekst1.Text, out int liczba1))
                    {
                    int liczba2 = liczba;
                    int liczba3 = liczba1;
                    if(liczba == 0 && liczba1 == 0)
                    {
                        MessageBox.Show("Nieskończoność", "Wynik", MessageBoxButton.OK, MessageBoxImage.Information);
                    }else if(liczba == 0)
                    {

                    }
                    while (liczba != liczba1)
                    {
                        if(liczba > liczba1)
                        {
                            liczba -= liczba1;
                            nwd = liczba;
                        }
                        else
                        {
                            liczba1 -= liczba;
                            nwd = liczba1;
                        }
                      
                    }
                     nww = liczba2*liczba3/nwd;
                }

            }
            cos.Text = "NWD: " + nwd + "\nNWW: " + nww;

        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "PlainText | *.txt";
            oknoZapisu.Title = "Zapisz jako";
            if (oknoZapisu.ShowDialog() == true)
            {
                //zapisywanie do pliku
                File.WriteAllText(oknoZapisu.FileName, tekst.Text);
                //TODO nazwa pliku jako nazwa okna
            }
        }

        private void Na_Zielony(object sender, RoutedEventArgs e)
        {
            tekst.Background = Brushes.Green;
        }
        private void Na_Niebieski(object sender, RoutedEventArgs e)
        {
            tekst.Background = Brushes.Blue;
        }

        private void Na_14(object sender, RoutedEventArgs e)
        {
            tekst.FontSize = 12;
        }
        private void Na_24(object sender, RoutedEventArgs e)
        {
            tekst.FontSize = 24;
        }
        private void O_Programie(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor: costam \n Wersja: 0.6", "O programie", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Instrukcja(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NWD to Największy Wspólny Dzielnik \nNWW to Najmniejsza Wspólna Wielokrotność", "Instrukcja", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void NWD(object sender, RoutedEventArgs e)
        {
            int nwd = 0;
            if (int.TryParse(tekst.Text, out int liczba))
            {
                if (int.TryParse(tekst1.Text, out int liczba1))
                {
                    while (liczba != liczba1)
                    {
                        if (liczba > liczba1)
                        {
                            liczba -= liczba1;
                            nwd = liczba;
                        }
                        else
                        {
                            liczba1 -= liczba;
                            nwd = liczba1;
                        }
                    }
                    cos.Text = "NWD: " + nwd;
                }
            }
        }

        private void NWW(object sender, RoutedEventArgs e)
        {
            int nww = 0;
            int nwd = 0;
            if (int.TryParse(tekst.Text, out int liczba))
            {
                if (int.TryParse(tekst1.Text, out int liczba1))
                {
                    int liczba2 = liczba;
                    int liczba3 = liczba1;
                    while (liczba != liczba1)
                    {
                        if (liczba > liczba1)
                        {
                            liczba -= liczba1;
                            nwd = liczba;
                        }
                        else
                        {
                            liczba1 -= liczba;
                            nwd = liczba1;
                        }
                    }
                    nww = liczba2 * liczba3 / nwd;
                }
            }
            cos.Text = "NWW: " + nww;
        }
    }
}

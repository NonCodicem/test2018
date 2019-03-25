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
using Microsoft.Win32;
using System.IO;

namespace Test2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> data = new List<string>();
        private string initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string currentfile;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == true)
            {
                currentfile = dialog.FileName;
                using (StreamReader inputstream = File.OpenText(currentfile))
                {
                    string line;
                    while ((line = inputstream.ReadLine()) != null)
                    {
                        string[] words;
                        char[] seperator = { ',' };
                        words = line.Split(seperator);

                        string naam = words[0];
                        string bmi = Convert.ToString(berekenBMI(Convert.ToDouble(words[1]), Convert.ToDouble(words[2])));
                        string gegevens = $"{naam} heeft een BMI van {bmi}.";
                        data.Add(gegevens);

                        lstBMI.Items.Clear();
                        foreach (var item in data)
                        {
                            lstBMI.Items.Add(item);
                        }
                        
                    }
                }
            }
        }

        private void btnBewaar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private double berekenBMI(double lengte, double gewicht)
        {
            double bmi;
            bmi = gewicht / Math.Pow((lengte / 100.0),(lengte / 100.0));
            return Math.Round(bmi,2);
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            string filter = txtFilter.Text;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                lstBMI.Items.Clear();
            }
        }
    }
}

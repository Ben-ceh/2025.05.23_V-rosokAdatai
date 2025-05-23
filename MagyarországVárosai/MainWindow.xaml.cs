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
using System.IO;

namespace MagyarországVárosai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Varos> varosok = new List<Varos>();
        public MainWindow()
        {
            InitializeComponent();
            Fajlbeolvas();
        }

        private void lb_Varosok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string kivalaszt = lb_Varosok.SelectedItem.ToString();
            foreach (var item in varosok)
            {
                if (item.Varosnev == kivalaszt)
                {
                    tbl_nev.Text = $"Város: {item.Varosnev}";
                    tbl_jaras.Text = $"Járás: {item.Jaras}";
                    tbl_kisterseg.Text = $"Kistérség: {item.Kisterseg}";
                    tbl_nepesseg.Text = $"Népesség: {item.Nepesseg}";
                    tbl_terulet.Text = $"Terület: {item.Terulet}";
                    
                }
            }
        }
        private void Fajlbeolvas()
        {

           


            using(StreamReader olvas = new StreamReader("varosok.txt"))
            {
                olvas.ReadLine();
                while (!olvas.EndOfStream)
                {
                    
                    string[] sor = olvas.ReadLine().Split(',');
                    string vNev = sor[1].Substring(1,sor[1].Length-2);
                    string jaras = sor[2].Substring(1,sor[2].Length-2);
                    string kisterseg = sor[3].Substring(1,sor[3].Length-2);
                    Varos egyVaros = new Varos(sor[0],vNev,jaras,kisterseg,sor[4],sor[5]);
                    varosok.Add(egyVaros);
                    
                    lb_Varosok.Items.Add(vNev);
                }
            }
        }

        private void btn_keres_Click(object sender, RoutedEventArgs e)
        {
            List<string> keresettVarosok = new List<string>();
            string keres = tbx_kereses.Text;
            int szamlalo = 0;
            
            foreach (var item in varosok)
            {
                if (item.Varosnev.ToLower().Contains(keres.ToLower()))
                {
                    keresettVarosok.Add(item.Varosnev);

                }
                else
                {
                    szamlalo++;
                }
            }

            if(szamlalo == varosok.Count)
            {
                tbx_kereses.Clear();
                MessageBox.Show("Nincs a keresésednek megfelelő elem!","Hiba!",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            if (tbx_kereses.Text != "")
            {
                lb_Varosok.Items.Clear();
                //lb_Varosok.ItemsSource = keresettVarosok;
                foreach (var item in keresettVarosok)
                {
                    lb_Varosok.Items.Add(item);
                }
                tbx_kereses.Clear();
            }

          
            

        }

        private void btn_ujKeres_Click(object sender, RoutedEventArgs e)
        {
            lb_Varosok.SelectedItem = null;
            lb_Varosok.Items.Clear();
            
            foreach (var item in varosok)
            {
                lb_Varosok.Items.Add(item.Varosnev.ToString());
            }
        }
    }
}

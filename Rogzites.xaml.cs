using Microsoft.EntityFrameworkCore;
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
using System.Collections.ObjectModel;

namespace Tanulok
{
    /// <summary>
    /// Interaction logic for Rogzites.xaml
    /// </summary>
    public partial class Rogzites : Window 
    {
        
        public Rogzites(Tanulo tanulo) // Konstruktor, ami beállítja az ablak adatforrását a megadott tanulóra
        {
            InitializeComponent();
            Loaded += Rogzites_Loaded;
            this.DataContext = tanulo;
        }

        private void Rogzites_Loaded(object sender, RoutedEventArgs e) // Az ablak betöltésekor meghívott eseménykezelő, ami feltölti a ComboBoxokat adatokkal az adatbázisból
        {
            cboSzervEgys.ItemsSource = MainWindow.AppDBContext.SzervezetiEgysegek.Local.ToObservableCollection();
            cboTagozat.ItemsSource = MainWindow.AppDBContext.Tagozatok.Local.ToObservableCollection();
            cboTagozat.DisplayMemberPath = "TagozatNev";
        }


        private void btnOK_Click(object sender, RoutedEventArgs e) // A "Rögzítés" gomb eseménykezelője, ami ellenőrzi az adatok érvényességét és bezárja az ablakot, ha minden mező kitöltve
        {
            Tanulo tanulo = (Tanulo)this.DataContext;
            if(tanulo.NEPTUNKod.Length != 6)
            {
                txtNeptunKod.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tanulo.Nev))
            {
                txtNev.Focus();
                return;
            }
            if (tanulo.AktualFelev.Length != 1)
            {
                txtAktFelev.Focus();
                return;
            }
            if (tanulo.SzervezetiEgyseg == null)
            {
                cboSzervEgys.IsDropDownOpen = true;
                return;
            }
            if (tanulo.Tagozat == null)
            {
                cboTagozat.IsDropDownOpen= true;
                return;
            }
            this.DialogResult = true;
            this.Close();
            
        }

        private void btnMegsem_Click(object sender, RoutedEventArgs e) // A "Mégsem" gomb eseménykezelője, ami bezárja az ablakot
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

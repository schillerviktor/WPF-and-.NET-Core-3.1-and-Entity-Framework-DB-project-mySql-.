using Microsoft.EntityFrameworkCore; // az Entity Framework Core használata
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Tanulok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ApplicationDBContext AppDBContext { get; set; } // az adatbázis kapcsolat beállítása
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppDBContext = new ApplicationDBContext(); // az adatbázis kapcsolat inicializálása
            AppDBContext.SzervezetiEgysegek.Load(); // betöltjük a SzervezetiEgysegek táblát
            AppDBContext.Tagozatok.Load(); // betöltjük a Tagozatok táblát
            cboSzervezetiEgyseg.ItemsSource = AppDBContext.SzervezetiEgysegek.Local.ToObservableCollection(); /* feltöltjük az egyes vezérlőelemeket
                                                                                                               * az adatbázisból származó adatokkal*/

        }

        private void btnKeres_Click(object sender, RoutedEventArgs e)
        {
            var lista = AppDBContext.Tanulok.Where(x =>
                (x.NEPTUNKod == txtNeptun.Text || string.IsNullOrWhiteSpace(txtNeptun.Text)) // ha a keresőszöveg üres vagy azonos az adott hallgató NEPTUN-kódjával, akkor visszatérjük vele
                &&
                (x.SzervezetiEgyseg == cboSzervezetiEgyseg.SelectedItem || cboSzervezetiEgyseg.SelectedItem == null) // ha a szervezeti egység egyezik a kiválasztott elemmel vagy az nincs kiválasztva, akkor visszatérünk vele
                );
            dgLista.ItemsSource = new ObservableCollection<Tanulo>(lista); // a talált v. szűrt adatokat ObservableCollection-be helyezzük, majd az adatokat átadjuk a datagrid-nak (táblázat)
        }

        private void btnFeltTorlese_Click(object sender, RoutedEventArgs e)
        {
            txtNeptun.Text = ""; // NEPTUN-kód törlése
            cboSzervezetiEgyseg.SelectedItem = null; // a szervezeti egység kiválasztásának törlése
            btnKeres_Click(null, null); // újra feltöltjük a datagrid-et
        }

        private void btnUj_Click(object sender, RoutedEventArgs e) // Az 'Új' gombra való kattintáskor hívódik meg
        {
            Tanulo tanulo = new Tanulo(); // új hallgató létrehozása, generálja a 'Rogzites' ablakot
            Rogzites rogzites = new Rogzites(tanulo); // Létrehoz egy Rogzites ablakot, amelynek paramétere az új Tanulo objektum
            if(rogzites.ShowDialog() == true) // Ha az ablakat sikeresen megnyitotta a felhasználó,...
            {
                AppDBContext.Tanulok.Add(tanulo); // Az új tanuló adatait hozzáadja az adatbázishoz,
                AppDBContext.SaveChanges(); // Végrehajtja a módosításokat az adatbázisban,
                btnKeres_Click(null, null); // Újra betölti a listát az újonnan hozzáadott elemmel.
            }
        }

        private void btnModositas_Click(object sender, RoutedEventArgs e) // A 'Módosítás' gombra való kattintáskor hívódik meg
        {
            if (dgLista.SelectedItem != null) // Ha van kijelölt elem a listában...
            {
                Tanulo tanulo = (Tanulo)dgLista.SelectedItem; // Az aktuális Tanulo objektumot eltárolja a 'tanulo' változóban
                Rogzites rogzites = new Rogzites(tanulo); // Létrehoz egy Rogzites ablakot, amelynek paramétere az aktuális Tanulo objektum
                if(rogzites.ShowDialog() == true) // Ha az ablakat sikeresen megnyitotta a felhasználó,...
                {
                    AppDBContext.Entry(tanulo).State = EntityState.Modified; // Az aktuális Tanulo objektum állapotát 'Módosítva' állapotra állítja
                    AppDBContext.SaveChanges(); // Végrehajtja a módosításokat az adatbázisban
                }
                else // Ha a felhasználó mégsem szeretne módosítani
                {
                    AppDBContext.Entry(tanulo).State = EntityState.Unchanged; // Az aktuális Tanulo objektum állapotát 'Változatlan' állapotra állítja
                    dgLista.Items.Refresh(); // Frissíti a listát, hogy az aktuális elem a régi adataival jelenjen meg
                }
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e) // A 'Törlés' gombra való kattintáskor hívódik meg
        {
            if (dgLista.SelectedItem != null) // Ha van kijelölt elem a listában,...
            {
                if(MessageBox.Show("Törli a kijelölt adatokat?", "Hallgató adatok", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) // Felugrik egy megerősítő ablak
                {
                    Tanulo tanulo = (Tanulo)dgLista.SelectedItem; // Az aktuális Tanulo objektumot eltárolja a 'tanulo' változóban
                    AppDBContext.Tanulok.Remove(tanulo); // Az tanuló adatait eltávolítja az adatbázisból,
                    AppDBContext.SaveChanges(); // Végrehajtja a módosításokat az adatbázisban,
                    btnKeres_Click(null, null); // Újra betölti a listát az újonnan hozzáadott elemmel.
                }
            }
        }

        
    }
}

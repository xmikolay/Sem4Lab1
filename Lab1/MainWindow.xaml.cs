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

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Band> bands = new List<Band>();
        List<Band> filteredBands = new List<Band>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Band band1 = new HeavyMetalBand() 
            { 
                BandName = "Metallica",
                YearFormed = 1981,
                Members = "James Hetfield, Lars Ulrich, Kirk Hammett, Cliff Burton, Dave Mustaine, Robert Trujillo, Jason Newsted, Ron McGovney",
                Albums = new List<Album> { new Album("Master Of Puppets"), new Album("Kill em All"), new Album("Ride The Lightning"), new Album("Metallica")}
            };

            Band band2 = new AlternativeRockBand() 
            { 
                BandName = "Deftones",
                YearFormed = 1988,
                Members = "Chino Moreno, Stephen Carpenter, Abe Cunningham, Chi Cheng, Frank Delgado",
                Albums = new List<Album> { new Album("Around the Fur"), new Album("Deftones"), new Album("White Pony"), new Album("Diamond Eyes") }
            };
            Band band3 = new RockBand() 
            { 
                BandName = "Green Day", 
                YearFormed = 1987, 
                Members = "Billie Joe Armstrong, Mike Dirnt, Tre Cool",
                Albums = new List<Album> { new Album("American Idiot"), new Album("Dookie"), new Album("21st Century Breakdown"), new Album("Cigarettes and Valentines") }
            };
            Band band4 = new NuMetalBand() 
            { 
                BandName = "Limp Bizkit", 
                YearFormed = 1994, 
                Members = "Fred Durst, John Otto, Wes Borland, DJ Lethal, Sam Rivers",
                Albums = new List<Album> { new Album("Chocolate Starfish and The Hot Dog Water"), new Album("Significant Other"), new Album("Greatest Hitz"), new Album("Three dollar bill, Y'all") }
            };
            Band band5 = new RockBand() 
            { 
                BandName = "Nirvana",
                YearFormed = 1987,
                Members = "Kurt Cobain, Krist Novoselic, Dave Grohl",
                Albums = new List<Album> { new Album("Nevermind"), new Album("Bleach"), new Album("In Utero"), new Album("MTV Unplugged in New York") }
            };
            Band band6 = new RockBand() 
            { 
                BandName = "Linkin Park",
                YearFormed = 1996,
                Members = "Chester Bennington, Mike Shinoda, Brad Delson, Joe Hahn, Dave Farrell, Emily Armstrong, Colin Brittain",
                Albums = new List<Album> { new Album("Meteora"), new Album("Hybrid Theory"), new Album("Minutes to Midnight"), new Album("From Zero") }
            };

            bands.Add(band1);
            bands.Add(band2);
            bands.Add(band3);
            bands.Add(band4);
            bands.Add(band5);
            bands.Add(band6);

            bands.Sort();

            filteredBands = new List<Band>(bands);

            lbxBands.ItemsSource = filteredBands;

            cbGenre.Items.Add("All");
            cbGenre.Items.Add("Rock");
            cbGenre.Items.Add("Alternative Rock");
            cbGenre.Items.Add("Nu Metal");
            cbGenre.Items.Add("Heavy Metal");
            cbGenre.SelectedIndex = 0;
        }

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selected = lbxBands.SelectedItem as Band;

            if (selected != null)
            {
                UpdateDisplay(selected);
            }
        }

        private void UpdateDisplay(Band selected)
        {
            tblkFormed.Text = selected.YearFormed.ToString();
            tblkMembers.Text = selected.Members.ToString();
            lbxAlbums.ItemsSource = selected.Albums;
        }

        private void cbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbGenre.SelectedItem != null)
            {
                string selectedGenre = cbGenre.SelectedItem as string;

                filteredBands.Clear();

                foreach (Band band in bands)
                {
                    if (selectedGenre == "All" || band.Genre == selectedGenre)
                    {
                        filteredBands.Add(band);
                    }
                }

                lbxBands.ItemsSource = null;
                lbxBands.ItemsSource = filteredBands;
            }
        }

        private void WriteToFile()
        {
            Band selectedBand = lbxBands.SelectedItem as Band;

            if (selectedBand != null)
            {
                string filePath = $"{selectedBand.BandName}_data.txt";

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine($"Band Name: {selectedBand.BandName}");
                        sw.WriteLine($"Year Formed: {selectedBand.YearFormed}");
                        sw.WriteLine($"Members: {selectedBand.Members}");
                        sw.WriteLine($"Genre: {selectedBand.Genre}");
                        sw.WriteLine("Albums:");

                        foreach (Album album in selectedBand.Albums)
                        {
                            sw.WriteLine($"  - {album.AlbumName} ({album.YearsSinceRelease()} years since release)");
                        }
                    }
                    MessageBox.Show($"{selectedBand.BandName} info has been saved to file.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occured when saving to file: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a band first.");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile();
        }
    }
}

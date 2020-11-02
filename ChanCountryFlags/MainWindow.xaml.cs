using ChanCountryFlags.Model;
using Newtonsoft.Json;
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

namespace ChanCountryFlags
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var boardsJson = System.IO.File.ReadAllText("Resources/boards.json");
            var boards = JsonConvert.DeserializeObject<Boards>(boardsJson);

            var flagBoards = boards.GetFlagBoards();

            var catalogJson = System.IO.File.ReadAllText("Resources/catalog.json");
            var catalog = JsonConvert.DeserializeObject<CatalogPage[]>(catalogJson, CatalogConverter.Settings);
        }
    }
}

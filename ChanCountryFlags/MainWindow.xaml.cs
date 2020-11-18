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
        public IEnumerable<Board> FlagBoards { get; private set; }
        public IEnumerable<Country> Countries { get; private set; }
        public IEnumerable<Post> Posts { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            var boardsJson = System.IO.File.ReadAllText("Resources/boards.json");
            var boards = JsonConvert.DeserializeObject<Boards>(boardsJson);

            FlagBoards = boards.GetFlagBoards();
            Countries = CountryCache.GetAllCountries();

            var catalogJson = System.IO.File.ReadAllText("Resources/catalog.json");
            var catalog = JsonConvert.DeserializeObject<CatalogPage[]>(catalogJson, CatalogConverter.Settings);

            var threadJson = System.IO.File.ReadAllText("Resources/thread.json");
            var thread = JsonConvert.DeserializeObject<Thread>(threadJson, ThreadConverter.Settings);

            Posts = thread.Posts;

            DataContext = this;
        }
    }
}

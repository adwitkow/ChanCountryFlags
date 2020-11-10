using SixLabors.ImageSharp;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChanCountryFlags.Model
{
    public class Country
    {
        public ImageSource Icon { get; set; }
        public string Code { get; }
        public string Name { get; }

        public Country(ImageSource icon, string code, string name)
        {
            this.Icon = icon;
            this.Code = code;
            this.Name = name;
        }

        public Country(string code, string name) : this(null, code, name) { }

        public override string ToString()
        {
            return Name;
        }
    }
}

using SixLabors.ImageSharp;

namespace ChanCountryFlags.Model
{
    public class Country
    {
        public Image Icon { get; set; }
        public string Code { get; }
        public string Name { get; }

        public Country(Image icon, string code, string name)
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

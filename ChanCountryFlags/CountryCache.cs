using ChanCountryFlags.Helpers;
using ChanCountryFlags.Model;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace ChanCountryFlags
{
    static class CountryCache
    {
        private static readonly Dictionary<string, Country> CodeToCountryMap = SeedCountries();

        public static IEnumerable<Country> GetAllCountries()
        {
            return CodeToCountryMap.Values;
        }

        public static Country GetCountry(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                countryCode = "XX";
            }

            var success = CodeToCountryMap.TryGetValue(countryCode, out var result);

            if (!success)
            {
                result = GetCountry("XX");
            }

            return result;
        }

        private static Dictionary<string, Country> SeedCountries()
        {
            var json = System.IO.File.ReadAllText("Resources/countries.json");
            var countries = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var results = new Dictionary<string, Country>();

            var flagWidth = 16;
            var flagHeight = 11;
            int flagColumns = 16;

            using (var flagsImage = Image.Load("Resources/flags.png"))
            {
                for (int i = 0; i < countries.Count; i++)
                {
                    var countryPair = countries.ElementAt(i);
                    var code = countryPair.Key;
                    var fullName = countryPair.Value;

                    int offsetX;
                    int offsetY;

                    if (i > 0)
                    {
                        offsetX = i % flagColumns * flagWidth;
                        offsetY = i / flagColumns * flagHeight;
                    }
                    else
                    {
                        offsetX = 0;
                        offsetY = 0;
                    }

                    var image = flagsImage.Clone(action => action.Crop(new Rectangle(offsetX, offsetY, flagWidth, flagHeight)));
                    var bitmap = image.ToBitmap();

                    results.Add(code, new Country(bitmap.ToImageSource(), code, fullName));
                }
            }

            return results;
        }
    }
}

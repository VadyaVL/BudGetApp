using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Extensions
{
    /*
     * This is required to download pictures from a collaborative project that are marked as [Build Action: Embedded Resource]
     */
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        private static Dictionary<string, ImageSource> Images = new Dictionary<string, ImageSource>();

        private static ImageSource CrateImage(string source)
        {
            if (!Images.ContainsKey(source))
            {
                Images.Add(source, ImageSource.FromResource(source));
            }

            return Images[source];
        }

        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            return CrateImage(Source);
        }
    }
}

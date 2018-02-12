using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
        public SignInPage ()
		{
			InitializeComponent ();
        }

        #region Events

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.Transparent);

            var width = 2 * (sender as SKCanvasView).Width;
            var height = 2 * (sender as SKCanvasView).Height;
            
            // Dark-blue -> Light-blue
            var colors = new SKColor[] { new SKColor(0, 110, 240), new SKColor(0, 150, 250) };
            var shader = SKShader.CreateLinearGradient(new SKPoint((int)width, (int)height), new SKPoint(0, 0), colors, null, SKShaderTileMode.Clamp);
            var paint = new SKPaint() { Shader = shader };
            canvas.DrawPaint(paint);
        }

        #endregion
    }
}
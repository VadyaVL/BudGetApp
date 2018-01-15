using BudGet.Logic.Services;
using MvvmCross.Platform;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        #region Properties

        private IAccountService AccountService { get; set; }

        #endregion

        #region Constructors

        public LoginPage ()
		{
			InitializeComponent ();

            this.AccountService = Mvx.Resolve<IAccountService>();
        }

        #endregion

        #region Events

        private void OnLogin(object sender, EventArgs args)
        {
            this.AccountService.IsAuthenticated = true;

            // Switch to MainPage
            App.Current.MainPage = new MainPage();
        }

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
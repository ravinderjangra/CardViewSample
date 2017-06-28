using System;
using CardViewSample.CustomControl;
using CardViewSample.iOS.CustomControlsRenderer;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CardView), typeof(CardViewRenderer))]
namespace CardViewSample.iOS.CustomControlsRenderer
{
	public class CardViewRenderer : FrameRenderer
	{

		public override void Draw(CGRect rect)
		{
			SetupShadowLayer();
			base.Draw(rect);
		}

		void SetupShadowLayer()
		{
			Layer.CornerRadius = 2; // 5 Default
			if (Element.BackgroundColor == Xamarin.Forms.Color.Default)
			{
				Layer.BackgroundColor = UIColor.White.CGColor;
			}
			else
			{
				Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();
			}

			Layer.ShadowRadius = 2; // 5 Default
			Layer.ShadowColor = UIColor.Black.CGColor;
			Layer.ShadowOpacity = 0.4f; // 0.8f Default
			Layer.ShadowOffset = new CGSize(0f, 2.5f);

			if (Element.OutlineColor == Xamarin.Forms.Color.Default)
			{
				Layer.BorderColor = UIColor.Clear.CGColor;
			}
			else
			{
				Layer.BorderColor = Element.OutlineColor.ToCGColor();
				Layer.BorderWidth = 1;
			}

			Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			Layer.ShouldRasterize = true;
		}
	}
}
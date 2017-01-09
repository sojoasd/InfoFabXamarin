using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;
using InfoFabApp.Droid;

[assembly: ExportRenderer(typeof(Label), typeof(AwesomeLabelRenderer))]
[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(AwesomeButtonRenderer))]
namespace InfoFabApp.Droid
{
	public class AwesomeLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			AwesomeUtil.CheckAndSetTypeFace(Control);
		}
	}

	public class AwesomeButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			AwesomeUtil.CheckAndSetTypeFace(Control);
		}
	}

	internal static class AwesomeUtil
	{
		public static void CheckAndSetTypeFace(TextView view)
		{
			if (view.Text.Length == 0) return;
			var text = view.Text;
			if (text.Length > 1 || text[0] < 0xf000)
			{
				return;
			}

			var font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.Assets, "fontawesome.ttf");
			view.Typeface = font;
		}
	}

}

using CloudCherry.CustomControls;
using CloudCherry.Droid.Renderer;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;

[assembly: ExportRenderer(typeof(ElevatedStackView), typeof(ElevatedViewRenderer))]
namespace CloudCherry.Droid.Renderer
{
    public class ElevatedViewRenderer : VisualElementRenderer<Grid>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Grid> e)
        {
            base.OnElementChanged(e);
            StateListAnimator = null; // clear the state list animator
            Elevation = 9; // set the elevation
            BackgroundTintMode = PorterDuff.Mode.Add;
        }
    }
}
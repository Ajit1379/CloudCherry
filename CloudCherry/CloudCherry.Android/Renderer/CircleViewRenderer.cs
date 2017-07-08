using System.ComponentModel;
using Android.Graphics;
using CloudCherry.CustomControls;
using CloudCherry.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircleView), typeof(CircleViewRenderer))]
namespace CloudCherry.Droid.Renderer
{
    public class CircleViewRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            SetWillNotDraw(false);
            Invalidate();
        }

        public override void Draw(Canvas canvas)
        {
            var box = Element as CircleView;
            var rect = new Rect();
            var paint = new Paint
                            {
                                Color = box.BackgroundColor.ToAndroid(),
                                AntiAlias = true,
                            };
            GetDrawingRect(rect);
            var radius = (float)(rect.Width() / 14 * 7); // ... / box width * box corner radius
            canvas.DrawRoundRect(new RectF(rect), radius, radius, paint);
        }
    }
}
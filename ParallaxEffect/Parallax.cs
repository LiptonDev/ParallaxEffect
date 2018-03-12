using DevExpress.Mvvm.UI.Interactivity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ParallaxEffect
{
    public class Parallax : Behavior<Window>
    {
        #region Dependency
        public static readonly DependencyProperty UseParallaxProperty = DependencyProperty.RegisterAttached("UseParallax", typeof(bool), typeof(Parallax), new PropertyMetadata(false));

        public static bool GetUseParallax(DependencyObject obj) => (bool)obj.GetValue(UseParallaxProperty);
        public static void SetUseParallax(DependencyObject obj, bool value) => obj.SetValue(UseParallaxProperty, value);

        public static readonly DependencyProperty XOffsetProperty = DependencyProperty.RegisterAttached("XOffset", typeof(int), typeof(Parallax), new PropertyMetadata(0));

        public static readonly DependencyProperty YOffsetProperty = DependencyProperty.RegisterAttached("YOffset", typeof(int), typeof(Parallax), new PropertyMetadata(0));

        public static readonly DependencyProperty XDirectionProperty = DependencyProperty.RegisterAttached("XDirection", typeof(ParallaxDirection), typeof(Parallax), new PropertyMetadata(ParallaxDirection.From));

        public static readonly DependencyProperty YDirectionProperty = DependencyProperty.RegisterAttached("YDirection", typeof(ParallaxDirection), typeof(Parallax), new PropertyMetadata(ParallaxDirection.From));

        public static int GetXOffset(DependencyObject obj) => (int)obj.GetValue(XOffsetProperty);
        public static void SetXOffset(DependencyObject obj, int value) => obj.SetValue(XOffsetProperty, value);
        public static int GetYOffset(DependencyObject obj) => (int)obj.GetValue(YOffsetProperty);
        public static void SetYOffset(DependencyObject obj, int value) => obj.SetValue(YOffsetProperty, value);
        public static ParallaxDirection GetXDirection(DependencyObject obj) => (ParallaxDirection)obj.GetValue(XDirectionProperty);
        public static void SetXDirection(DependencyObject obj, ParallaxDirection value) => obj.SetValue(XDirectionProperty, value);
        public static ParallaxDirection GetYDirection(DependencyObject obj) => (ParallaxDirection)obj.GetValue(YDirectionProperty);
        public static void SetYDirection(DependencyObject obj, ParallaxDirection value) => obj.SetValue(YDirectionProperty, value);
        #endregion

        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (!(AssociatedObject.Content is Panel content))
                return;

            var mouse = e.GetPosition(AssociatedObject);

            foreach (FrameworkElement item in content.Children)
            {
                if (!GetUseParallax(item))
                    continue;

                int xoffset = GetXOffset(item);
                int yoffset = GetYOffset(item);
                ParallaxDirection xdirection = GetXDirection(item);
                ParallaxDirection ydirection = GetYDirection(item);

                double newX = AssociatedObject.ActualHeight - (xdirection == ParallaxDirection.From ? (mouse.X / xoffset) : -(mouse.X / xoffset)) - AssociatedObject.ActualHeight;
                double newY = AssociatedObject.ActualWidth - (xdirection == ParallaxDirection.From ? (mouse.Y / yoffset) : -(mouse.Y / yoffset)) - AssociatedObject.ActualWidth;

                if (!(item.RenderTransform is TranslateTransform))
                    item.RenderTransform = new TranslateTransform(newX, newY);
                else
                {
                    TranslateTransform transform = (TranslateTransform)item.RenderTransform;
                    if (xoffset > 0)
                        transform.X = newX;
                    if (yoffset > 0)
                        transform.Y = newY;
                }
            }
        }
    }
}

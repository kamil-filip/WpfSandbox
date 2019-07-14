using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MySimpleCanvas
{
    public class SimpleCanvas : Panel
    {



        public static double GetTop(DependencyObject obj)
        {
            return (double)obj.GetValue(TopProperty);
        }

        public static void SetTop(DependencyObject obj, double value)
        {
            obj.SetValue(TopProperty, value);
        }

        // Using a DependencyProperty as the backing store for Top.  This enables animation, styling, binding, etc...
        /*  public static readonly DependencyProperty TopProperty =
              DependencyProperty.RegisterAttached("Top", typeof(double), typeof(SimpleCanvas), 
                  new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentArrange 
                  ));
                  */

        public static readonly DependencyProperty TopProperty =
      DependencyProperty.RegisterAttached("Top", typeof(double), typeof(SimpleCanvas),
          new PropertyMetadata(0.0, MyStub));

        private static void MyStub(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d!= null)
            {
                if(d is FrameworkElement)
                {
                    var myChild = d as FrameworkElement;

                    var parent = myChild.Parent as SimpleCanvas;

                  //  parent.InvalidateArrange();
                  //  parent.UpdateLayout();
                }
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var test = base.MeasureOverride(availableSize);

            var mySize = new Size();
            foreach(UIElement el in this.InternalChildren)
            {
                el.Measure(availableSize);
                mySize.Height += el.DesiredSize.Height;
                mySize.Width += el.DesiredSize.Width;
            }

            return mySize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point();

            foreach(UIElement el in this.InternalChildren)
            {
                location.Y = GetTop(el);
                el.Arrange(new Rect(location, el.DesiredSize));                
            }

            return base.ArrangeOverride(finalSize);
        }


    }
}

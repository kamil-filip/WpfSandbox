using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyDiagonalPanel
{
    public class DiagonalPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {           
            var size = new Size();
            foreach(UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
                size.Height += child.DesiredSize.Height;
                size.Width += child.DesiredSize.Width;
            }

            return size;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {

            var location = new Point();
            foreach(UIElement child in InternalChildren)
            {
                child.Arrange(new Rect(location, child.DesiredSize));
                location.X += child.DesiredSize.Width;
                location.Y += child.DesiredSize.Height;
            }

            return finalSize;
        }
    }
}

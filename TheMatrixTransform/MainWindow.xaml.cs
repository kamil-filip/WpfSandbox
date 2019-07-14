using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheMatrixTransform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Matrix _rotateMatrix = new Matrix();
        private Matrix _scaleMatrix = new Matrix();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RotateValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
            var radians = DegreeToRadian(e.NewValue);

            _rotateMatrix = new Matrix
            {
                M11 = Math.Cos(radians),
                M12 = Math.Sin(radians),
                M21 = -Math.Sin(radians),
                M22 = Math.Cos(radians)
            };

            matrixTransform.Matrix = _rotateMatrix * _scaleMatrix;

        }

        private void ScaleValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _scaleMatrix = new Matrix
            {
                M11 = e.NewValue,
                M22 = e.NewValue
            };

            matrixTransform.Matrix = _rotateMatrix * _scaleMatrix;
        }

        private double DegreeToRadian(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

    }
}

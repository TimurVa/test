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

namespace TemporaryWPF
{
    /// <summary>
    /// Interaction logic for ImageControl.xaml
    /// </summary>
    public partial class ImageControl : UserControl
    {
        public UIElement Selected { get; set; }
        public Point PrevPos { get; set; }
        public ImageControl()
        {
            InitializeComponent();
        }

        private void iconcanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
                Selected = e.OriginalSource as UIElement;

                Selected.CaptureMouse();
                PrevPos = Mouse.GetPosition(Selected);
           
        }

        private void iconcanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Selected != null)
            {
                Selected.ReleaseMouseCapture();
            }
            Selected = null;
        }

        private void iconcanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected != null)
            {
                Canvas.SetLeft(Selected, e.GetPosition(this.iconcanvas).X - PrevPos.X);
                Canvas.SetTop(Selected, e.GetPosition(this.iconcanvas).Y - PrevPos.Y);
            }
        }
    }
}

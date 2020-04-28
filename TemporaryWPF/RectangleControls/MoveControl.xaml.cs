using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TemporaryWPF.PostgreSchema;

namespace TemporaryWPF
{
    /// <summary>
    /// Логика взаимодействия для MoveControl.xaml
    /// </summary>
    public partial class MoveControl : UserControl
    {
        public UIElement Selected;
        public Point PrevPos;
        public Shapes Smodel;
        public Shape shape;

        public ObservableCollection<LineControl> _lineControl;

        public MoveControl()
        {
            InitializeComponent();

            _lineControl = new ObservableCollection<LineControl>();
            _lineControl.CollectionChanged += _lineControl_CollectionChanged;
        }

        private void _lineControl_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        this.MyCanvas.Children.Add((LineControl)e.NewItems[0]);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        this.MyCanvas.Children.Remove(((LineControl)e.NewItems[0]));
                    }
                    break;
            }
        }

        public MoveControl(Shapes model)
        {
            Smodel = model;
            shape = new Rectangle()
            {
                Width = (double)model.Width,
                Height = (double)model.Height,
                Fill = Brushes.Red,
            };

            Canvas.SetLeft(shape, (double)model.Leftpos);
            Canvas.SetTop(shape, (double)model.Toppos);
            
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var ar = LogicalTreeHelper.GetParent(this);
            Selected = e.OriginalSource as UIElement;

            Selected.CaptureMouse();
            PrevPos = Mouse.GetPosition(MyCanvas);
        }

        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Selected.ReleaseMouseCapture();
            Selected = null;
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected != null)
            {
               // var ar = LogicalTreeHelper.GetParent(this);
                Point point = Mouse.GetPosition(MyCanvas);
                double OffsetX = point.X - PrevPos.X;
                double OffsetY = point.Y - PrevPos.Y;

                double NewX = Canvas.GetLeft(Selected);
                double NewY = Canvas.GetTop(Selected);

                NewX += OffsetX;
                NewY += OffsetY;
                Canvas.SetLeft(Selected, NewX);
                Canvas.SetTop(Selected, NewY);

                PrevPos = point;
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            _lineControl.Add(new LineControl());
        }
    }
}

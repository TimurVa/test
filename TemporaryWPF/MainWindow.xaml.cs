using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

    public partial class MainWindow : Window
    {
        public ObservableCollection<RectangleModel> RM;
        public ObservableCollection<LineControl> LC;
        public UIElement Selected { get; set; }
        public Point PrevPos { get; set; }

        public MainWindow()
        {
            InitializeComponent();

          //  DataContext = new WindowViewModel();

            RM = new ObservableCollection<RectangleModel>();
            RM.CollectionChanged += RM_CollectionChanged;

            LC = new ObservableCollection<LineControl>();
            LC.CollectionChanged += LC_CollectionChanged;
        }

        private void LC_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        area.Children.Add((LineControl)e.NewItems[0]);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        area.Children.Remove((LineControl)e.NewItems[0]);
                    }
                    break;
            }
        }

        private void RM_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        area.Children.Add(((RectangleModel)e.NewItems[0]).figure);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        area.Children.Remove(((RectangleModel)e.NewItems[0]).figure);
                    }
                    break;
            }
        }

        private void area_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.OriginalSource == typeof(Image))
            //{
            //    Selected = e.Source as UIElement;

            //    Selected.CaptureMouse();
            //    PrevPos = Mouse.GetPosition(Selected);
            //} 
            //else
            //{
            //   if (e.ClickCount == 2)
            //    {
            //        Selected == e.OriginalSource as UIElement;
            //    }
            //    else
            //    {

            //    }
            //}
            e.Handled = true;
            if (typeof(Image).FullName == e.OriginalSource.ToString())
            {
                Selected = e.OriginalSource as UIElement;
                Selected.CaptureMouse();
                PrevPos = Mouse.GetPosition(Selected);
            } 
            else if (typeof(UserControl).FullName == e.OriginalSource.ToString())
            {
                
            }
            
           
        }

        private void area_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Selected != null)
            {
                Selected.ReleaseMouseCapture();
            }
            Selected = null;
        }

        private void area_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected != null)
            {
                Canvas.SetLeft(Selected, e.GetPosition(this.area).X - PrevPos.X);
                Canvas.SetTop(Selected, e.GetPosition(this.area).Y - PrevPos.Y);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Shapes model = new Shapes()
            {
                Width = 80,
                Height = 80,
                Leftpos = 50,
                Toppos = 100
            };

            RectangleModel rectangleModel = new RectangleModel(model);
            RM.Add(rectangleModel);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            LineControl lineControl = new LineControl();
            LC.Add(lineControl);
        }
    }
}

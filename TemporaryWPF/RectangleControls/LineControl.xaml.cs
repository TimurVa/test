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
    /// Логика взаимодействия для LineControl.xaml
    /// </summary>
    public partial class LineControl : UserControl
    {

        public LineControl()
        {
            InitializeComponent();
        }

        private void Lcgrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
            //    //UIElement element = sender as UIElement;
            //    //if (element == null)
            //    //    return;
            //    //DataObject datObj = new DataObject(this);
            //    //DragDrop.DoDragDrop(element, datObj, DragDropEffects.Move);
            //}
        }

        private void Lcgrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void Lcgrid_MouseMove(object sender, MouseEventArgs e)
        {
        }

        //delete line
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           // delete logic here
        }

        //private void UserControl_Drop(object sender, DragEventArgs e)
        //{
        //    FrameworkElement elem = sender as FrameworkElement;
        //    if (null == elem)
        //        return;
        //    IDataObject data = e.Data;
        //    if (!data.GetDataPresent(typeof(Line)))
        //        return;
        //    Line node = data.GetData(typeof(Line)) as Line;
        //    if (null == node)
        //        return;

        //}
    }
}

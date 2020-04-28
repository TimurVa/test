using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TemporaryWPF.PostgreSchema;

namespace TemporaryWPF
{
    public class RectangleModel
    {
        /// <summary>
        /// from db property 
        /// </summary>
        public Shapes shape;
        /// <summary>
        /// custom property
        /// </summary>
        public Shape figure;
        public RectangleModel(Shapes model)
        {
            shape = model;

            figure = new Rectangle()
            {
                Width = (double)model.Width,
                Height = (double)model.Height,
                Fill = Brushes.Green,
            };
            Canvas.SetLeft(figure, (double)model.Leftpos);
            Canvas.SetTop(figure, (double)model.Toppos);
        }

        //public void SendInfo()
        //{
        //    shape.Leftpos = (int)Canvas.GetLeft(figure);
        //    shape.Toppos = (int)Canvas.GetTop(figure);
        //}
    }
}

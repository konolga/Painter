using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Painter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool flag = false;
        Brush _fillBrush = new SolidColorBrush(Colors.Beige);
        private int Height = 10;
        private int Width = 10;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (flag)
            {
                double x = e.GetCurrentPoint(DrawingArea).Position.X + Height / 5;// Getting the position of the pointer
                double y = e.GetCurrentPoint(DrawingArea).Position.Y + Width / 5;
                Ellipse ellipse = new Ellipse();
                ellipse.Height = Height;
                ellipse.Width = Width;
                ellipse.Fill = _fillBrush;
                Canvas.SetLeft(ellipse, x); //set the position of the ellipse on the canvas
                Canvas.SetTop(ellipse, y);
                DrawingArea.Children.Add(ellipse);// add ellipse to the canvas
            }

        }

        private void Page_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            flag = true;
        }

        private void Page_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            flag = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DrawingArea.Children.Clear(); // remove all ellipses from the canvas 
        }


        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // _fillBrush = Rec1.Fill;

            Rectangle clickedRectangle = (Rectangle)e.OriginalSource; //get specifically clicked rectangle
            _fillBrush = clickedRectangle.Fill;

        }

        private void btnEraser_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _fillBrush = DrawingArea.Background; //Eraser
        }

        private void Background_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Rectangle clickedRectangle = (Rectangle)e.OriginalSource; //get specifically clicked rectangle
            DrawingArea.Background = clickedRectangle.Fill;
        }

        private void Size_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock clickedSize = (TextBlock)e.OriginalSource; //get specifically clicked size
            Height = int.Parse(clickedSize.Text);
            Width = int.Parse(clickedSize.Text);
        }
    }
}

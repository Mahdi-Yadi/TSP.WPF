using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TSP.WPF;
public partial class MainWindow : Window
{

    private List<Point> cities = new List<Point>();

    public MainWindow()
    {
        InitializeComponent();
    }

    #region BTNs

    private void appdrag_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }

    private void close_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void mini_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    #endregion

    #region Algo

    // الگوریتم حریصانه 1
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    // الگوریتم حریصانه 2
    private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Other

    private void CityInput_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            AddCity_Click(sender,e);
        }
    }

    private void AddCity_Click(object sender, RoutedEventArgs e)
    {
        try
        {

            string[] ci = cityInput.Text.Split(',');

            if (ci.Length == 2)
            {

                double x = double.Parse(ci[0]);
                double y = double.Parse(ci[1]);

                if (x < 0 || y < 0 || x > CityCanvas.ActualWidth || y > CityCanvas.ActualHeight)
                {
                    MessageBox.Show("مختصات وارد شده خارج از حد مرزی است!");
                    return;
                }

                cities.Add(new Point(x,y));
                CityList.Items.Add($"({x},{y})");
                cityInput.Clear();

                // نمایش شهر
                DrawCity(x,y);

            }
            else
            {
                MessageBox.Show("محور x و محور y را به درستی وارد نمایید.");
            }

        }
        catch (Exception)
        {
            MessageBox.Show("فرمت وارد شده درست نمی باشد!");
            throw;
        }
    }

    private void clear_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void addCitySample_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Drawing

    private void DrawCity(double x,double y)
    {
        Ellipse cityCircle = new Ellipse();

        cityCircle.Width = 10;
        cityCircle.Height = 10;
        cityCircle.Fill = Brushes.DarkViolet;

        Canvas.SetLeft(cityCircle, x - 5);
        Canvas.SetTop(cityCircle, y - 5);
        CityCanvas.Children.Add(cityCircle);
    }

    #endregion

}
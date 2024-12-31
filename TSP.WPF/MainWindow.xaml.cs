using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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

    private void DrawPath(List<Point> cities, List<int> path)
    {
        CityCanvas.Children.Clear();

        foreach (var city in cities)
        {
            DrawCity(city.X,city.Y);   
        }

        for (int i = 0; i < path.Count - 1; i++)
        {
            Line line = new Line()
            {
                X1 = cities[path[i]].X,
                Y1 = cities[path[i]].Y,
                X2 = cities[path[i + 1]].X,
                Y2 = cities[path[i + 1]].X,
                Stroke = Brushes.DarkSlateGray,
                StrokeThickness = 2
            };
            CityCanvas.Children.Add(line);
        }

    }

    #endregion

    #region Animation

    private void AnimationPath(List<Point> cities, List<int> path)
    {
        Ellipse movingDot = new Ellipse()
        {
            Width = 10,
            Height = 10,
            Fill = Brushes.Azure
        };

        CityCanvas.Children.Add(movingDot);

        PathGeometry animationPath = new PathGeometry();

        PathFigure figure = new PathFigure{StartPoint = this.cities[path[0]] };

        for (int i = 1; i < path.Count; i++)
        {
            figure.Segments.Add(new LineSegment(cities[path[i]],true));
        }

        animationPath.Figures.Add(figure);

        DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath()
        {
            PathGeometry = animationPath,
            Source = PathAnimationSource.X,
            Duration = TimeSpan.FromSeconds(5)
        };

        DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath()
        {
            PathGeometry = animationPath,
            Source = PathAnimationSource.Y,
            Duration = TimeSpan.FromSeconds(5)
        };

        TimeSpan duration = TimeSpan.FromSeconds(path.Count * 0.5);

        animationX.Duration = duration;
        animationY.Duration = duration;

        movingDot.BeginAnimation(Canvas.LeftProperty,animationX);
        movingDot.BeginAnimation(Canvas.TopProperty,animationY);
    }

    #endregion

    #region Sample

    private void addCitySample_OnClick(object sender, RoutedEventArgs e)
    {
        List<Point> sampleCities = new List<Point>()
        {
            new Point(50,50),
            new Point(150,50),
            new Point(50,150),
            new Point(250,450),
            new Point(350,450),
            new Point(80,330),
            new Point(60,120),
        };

        foreach (var city in sampleCities)
        {
            cities.Add(city);
            CityList.Items.Add($"({city.X},{city.Y})");
            DrawCity(city.X,city.Y);
        }

        MessageBox.Show("لیست شهرهای پیشفرض اضافه گردید. 👌");
    }

    #endregion

}
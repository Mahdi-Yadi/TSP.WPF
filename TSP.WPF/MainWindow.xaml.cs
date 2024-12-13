using System.Windows;
using System.Windows.Input;
namespace TSP.WPF;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

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

    private void CityInput_OnKeyDown(object sender, KeyEventArgs e)
    {
        throw new NotImplementedException();
    }

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

    private void AddCity_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void clear_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void addCitySample_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

}
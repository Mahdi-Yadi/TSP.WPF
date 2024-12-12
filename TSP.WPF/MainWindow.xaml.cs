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
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Algorithms;

public partial class MainPage : UserControl
{
    private MainWindow _mainWindow;


    public MainPage(MainWindow mainWindow)

    {
        InitializeComponent();
        _mainWindow = mainWindow;

    }


    

}
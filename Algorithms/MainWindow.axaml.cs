using Avalonia.Controls;
using System;
using Avalonia;
using Avalonia.Markup.Xaml;


namespace Algorithms
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //OpenPage(new TopicsPage(this));
        }

        private void OnOpenLcaClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OpenPage(new AlgorithmPage("LCA", this)); // Открываем страницу LCA
        }


        private void OnOpenBinarySearchClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OpenPage(new AlgorithmPage("Бинпоиск", this)); // Открываем страницу бинарного поиска
        }

        public void OpenPage(UserControl page)
        {
            MainContent.Content = page;
        }
    }
}
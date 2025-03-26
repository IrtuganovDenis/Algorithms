using Algorithms;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Numerics;
using System;
using System.Linq;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Drawing;
using Avalonia;
using System.Runtime.Serialization;
using System.Xml;
//using System.Drawing;

namespace Algorithms
{
    public partial class AlgorithmPage : UserControl
    {
        private MainWindow _mainWindow;
        int ans;
        public AlgorithmPage(string algorithmName, MainWindow mainWindow)
        {
            InitializeComponent();
            n.Text = "n:";
            Result.Text = "";
            _mainWindow = mainWindow;
            AlgorithmName.Text = algorithmName;
            AlgorithmDescription.Text = GetAlgorithmDescription(algorithmName); 
            
        }

        private void OnShowClick(object sender, RoutedEventArgs e)
        {
            if (AlgorithmName.Text == "LCA")
            {
                int size = (int)TreeSizeSlider.Value;
                LCA l = new LCA(size);
                DrawTree1(size, l);
                QueryLca(l, size);
            }
        }

        private void DrawTree1(int size, LCA l)
        {
            DrawingCanvas.Children.Clear();
            
            List<int>[] g = l.g;
            bool[] vis = new bool[size + 1];
            DrawTree(1, vis, 1, 10, 10, 150, g);
        }

        public void DrawTree(int vertex, bool[] visited, int depth, double x, double y, double offsetX, List<int>[] g)
        {
            visited[vertex] = true;
            

            double childX = x - offsetX / 2; 
            double childY = y + 100;

            foreach (int neighbor in g[vertex])
            {
                if (!visited[neighbor])
                {
                    DrawEdge(x, y, childX + offsetX / 2, childY);
                    DrawTree(neighbor, visited, depth + 1, childX + offsetX / 2, childY, offsetX / 2, g);
                    childX += offsetX;
                }
            }
            DrawVertex(vertex, depth, x, y);
        }

        private void DrawVertex(int vertex, int depth, double x, double y)
        {
            var circle = new Ellipse
            {
                Width = 40,
                Height = 40,
                Fill = Brushes.LightBlue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            Canvas.SetLeft(circle, x);
            Canvas.SetTop(circle, y);
            DrawingCanvas.Children.Add(circle);

            var textBlock = new TextBlock
            {
                Text = vertex.ToString(),
                Foreground = Brushes.Black,
                FontSize = 16
            };

            Canvas.SetLeft(textBlock, x + 15);
            Canvas.SetTop(textBlock, y + 10);
            DrawingCanvas.Children.Add(textBlock);
        }

        private void DrawEdge(double x1, double y1, double x2, double y2)
        {
            Avalonia.Point p1 = new Avalonia.Point(x1 + 15, y1 + 15);
            Avalonia.Point p2 = new Avalonia.Point(x2 + 15, y2 + 15);
            var line = new Line
            {
                StartPoint = p1,
                EndPoint = p2,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            DrawingCanvas.Children.Add(line);
        }

        private void QueryLca(LCA l, int size)
        { 
            Random r = new Random();
            int v1 = r.Next(2, size + 1);
            int v2 = r.Next(1, size + 1);
            while (v1 == v2 && size > 1)
            {
                v2 = r.Next(1, size);
            }
            ans = l.Lca(v1, v2);
            Query.Text = "Введите lca вершин " + v1.ToString() + " и " + v2.ToString();
            
        }

        public void GiveAnswer(object sender, RoutedEventArgs e)
        {

            if (Input.Text != ans.ToString())
            {
                Result.Text = "Wrong answer";
                Result.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Result.Text = "Correct answer";
                Result.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        private string GetAlgorithmDescription(string algorithmName)
        {
            return algorithmName switch
            {
                "LCA" => "LCA (Lowest Common Ancestor) - это алгоритм, который находит наименьшего общего предка двух узлов в дереве.",
                "Бинпоиск" => "Бинарный поиск - это алгоритм поиска, который работает на отсортированных массивах, деля массив пополам на каждом шаге.",
                _ => "Описание не найдено."
            };
        }

        private void OnBackClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _mainWindow.OpenPage(new MainPage(_mainWindow)); 
        }
    }
}
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLab16._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            //DoubleAnimation da = new DoubleAnimation(-100, 100, new Duration(new TimeSpan(0, 0, 1)));//вариант записать кратко следующие 4 строки
            DoubleAnimation da = new DoubleAnimation();
            da.From = 150;
            da.To = 30;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.DecelerationRatio=1;
            da.AutoReverse=true;
            da.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Top)")); //Do not miss the '(' and ')'

            DoubleAnimation da1 = new DoubleAnimation();
            da1.From = 0;
            da1.By = (double)GetValue(Window.WidthProperty);
            da1.Duration = new Duration(TimeSpan.FromSeconds(15));
            da1.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTargetProperty(da1, new PropertyPath("(Canvas.Left)")); //Do not miss the '(' and ')'

            sb.Children.Add(da);
            sb.Children.Add(da1);

            ball.BeginStoryboard(sb);

        }
    }
}

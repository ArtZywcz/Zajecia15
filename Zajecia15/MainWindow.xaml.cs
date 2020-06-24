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
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace Zajecia15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static Timer timer;
        private static int x;
        private static bool mode;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {

            InitializeComponent();
            x = 0;
            mode = true;
            
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mode)
            {
                ScaleTransform3D myScaleTransform3D = new ScaleTransform3D();
                myScaleTransform3D.ScaleX = 1.01;
                myScaleTransform3D.ScaleY = 1.01;
                myScaleTransform3D.ScaleZ = 1.01;

                ((MainWindow)Application.Current.MainWindow).setTransform(myScaleTransform3D);

                Thread.Sleep(50);
                x++;
                if (x > 30) mode = false;
            }
            else
            {
                ScaleTransform3D myScaleTransform3D = new ScaleTransform3D();
                myScaleTransform3D.ScaleX = 0.99;
                myScaleTransform3D.ScaleY = 0.99;
                myScaleTransform3D.ScaleZ = 0.99;
                ((MainWindow)Application.Current.MainWindow).setTransform(myScaleTransform3D);

                x--;
                if (x < -30) mode = true;
            }

        }



        private void setTransform(ScaleTransform3D test)
        {
            TransformGroup.Children.Add(test);
        }
    }
}

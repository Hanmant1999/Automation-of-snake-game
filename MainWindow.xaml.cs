using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int posx = 0;
        static int posy = 1;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Thread(StartDraw).Start();
        }

        private void StartDraw()
        {
            Drawsnake(posx, posy);
            Generatefrog();
        }
        private void Drawsnake(int posx, int posy)
        {
            Text(posx, posy, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));

        }

        private void Generatefrog()
        {
            Random rd = new Random();
            int posx = rd.Next(2, 700);
            int posy = rd.Next(3, 500);
            Text(posx, posy, "o", Color.FromRgb(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)));
            snakemove(posx, posy);
            Thread.Sleep(40000);



        }
        private void snakemove(int posx, int posy)
        {
            if (posy > MainWindow.posy)
            {
                int step = MainWindow.posy;
                if (posx > MainWindow.posx)
                {
                    moveupright(step,posx,posy);


                }
                else
                {
                    moveupleft(step,posx,posy);
                }


            }
            else if(posy < MainWindow.posy)
            {
                int step = MainWindow.posy;
                if (posx > MainWindow.posx)
                {
                   
                    movedownright(step,posx,posy);
                }
                else
                {
                    movedownleft(step,posx,posy);

                }

            }
            updatestat(posx, posy);
            ClearCanvas();
            Generatefrog();

        }
        private static void updatestat(int posx, int posy)
        {
            MainWindow.posx = posx;
            MainWindow.posy = posy;
        }
        private void moveupright(int step,int posx,int posy)
        {
            for (int i = MainWindow.posx; i < posx; i++)
            {
                while (step <= posy)

                {
                    //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                    Drawsnake(i, step);
                    step++;
                }
                //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                Drawsnake(i, step);
                Thread.Sleep(50);
            }
        }


        private void moveupleft(int step,int posx,int posy)
        {
            for (int i = MainWindow.posx; i > posx; i--)
            {
                while (step <= posy)

                {
                    //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                    Drawsnake(i, step);
                    step++;
                }
                //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                Drawsnake(i, step);
                Thread.Sleep(50);

            }
        }
        private void movedownright(int step,int posx ,int posy)
        {
            for (int i = MainWindow.posx; i < posx; i++)
            {
                while (step >= posy)

                {
                    Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                    // Drawsnake(i,j);
                    step--;
                }
                //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                Drawsnake(i, step);
                Thread.Sleep(50);
            }
        }
        private void movedownleft(int step,int posx,int posy)
        {
            for (int i = MainWindow.posx; i >= posx; i--)
            {
                while (step >= posy)

                {
                    //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                    Drawsnake(i, step);
                    step--;
                }
                //Text(i, step, "o", Color.FromRgb(Convert.ToByte(31), Convert.ToByte(170), Convert.ToByte(59)));
                Drawsnake(i, step);
                Thread.Sleep(50);
            }

        }

        private void Text(double x, double y, string text, Color color)
        {
            this.Dispatcher.Invoke(() =>
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = text;
                textBlock.Foreground = new SolidColorBrush(color);
                textBlock.Background = new SolidColorBrush(color);
                Canvas.SetLeft(textBlock, x);
                Canvas.SetTop(textBlock, y);
                canvas.Children.Add(textBlock);
            });
        }

        private void ClearCanvas()
        {
            this.Dispatcher.Invoke(() =>
            {
                canvas.Children.Clear();
            });


        }
        private void removerange(int index,int count)
        {

            this.Dispatcher.Invoke(() =>
            {
                canvas.Children.RemoveRange(index,count);
            });



        }


    }
}

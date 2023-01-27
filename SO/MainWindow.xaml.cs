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
using System.Windows.Threading;

namespace SO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rectangle> rauto1 = new List<Rectangle>();
        List<double> kat1 = new List<double>();
        List<double> kat11 = new List<double>();
        List<double> xa1 = new List<double>();
        List<double> ya1 = new List<double>();
        List<double> xa11 = new List<double>();
        List<double> ya11 = new List<double>();
        List<double> v1 = new List<double>();
        List<double> v11 = new List<double>();

        List<Rectangle> rauto2 = new List<Rectangle>();
        List<double> kat2 = new List<double>();
        List<double> kat22 = new List<double>();
        List<double> xa2 = new List<double>();
        List<double> ya2 = new List<double>();
        List<double> xa22 = new List<double>();
        List<double> ya22 = new List<double>();
        List<double> v2 = new List<double>();
        List<double> v22 = new List<double>();

        List<Rectangle> trains = new List<Rectangle>();
        List<double> yac = new List<double>();
        bool stop;

        public MainWindow()
        {
            InitializeComponent();

            Thread auto1 = new Thread(Auto1);
            auto1.Start();

            Thread droga1 = new Thread(Droga1);
            droga1.Start();

            Thread auto2 = new Thread(Auto2);
            auto2.Start();

            Thread droga2 = new Thread(Droga2);
            droga2.Start();

            Thread pociag = new Thread(Pociag);
            pociag.Start();

            Thread train = new Thread(Train);
            train.Start();
        }
        public void Auto1()
        {
            while (true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Rectangle auto1 = new Rectangle();
                    auto1.Width = 40;
                    auto1.Height = 20;
                    auto1.Fill = new ImageBrush(new BitmapImage(new Uri(@"assets/car.png", UriKind.Relative)));
                    Canvas1.Children.Add(auto1);
                    Canvas.SetTop(auto1, 145);
                    rauto1.Add(auto1);
                    xa1.Add(0);
                    ya1.Add(145);
                    kat1.Add(3.6);
                    kat11.Add(3.6);
                    xa11.Add(0);
                    ya11.Add(0);
                    Random rnd = new Random();
                    double pr = rnd.NextDouble() + 1;
                    v1.Add(pr);
                    v11.Add(pr);
                });
                Thread.Sleep(1500);
            }
        }
         public void Auto2()
         {
             while (true)
             {
                 this.Dispatcher.Invoke(() =>
                 {
                     Rectangle auto2 = new Rectangle();
                     auto2.Width = 40;
                     auto2.Height = 20;
                     auto2.Fill = Brushes.AliceBlue;
                     Canvas1.Children.Add(auto2);
                     Canvas.SetTop(auto2, 145);
                     rauto2.Add(auto2);
                     xa2.Add(0);
                     ya2.Add(145);
                     kat2.Add(3.6);
                     kat22.Add(3.6);
                     xa22.Add(0);
                     ya22.Add(0);
                 });
                 Thread.Sleep(1500);
             }
         }

        public void Droga1()
        {
            double r1 = 91;
            double r2 = 62;

            while (true)
            {
                List<Rectangle> rdroga1 = new List<Rectangle>(rauto1);
                foreach (Rectangle auto1 in rdroga1)
                {
                    //Pierwsza prosta
                    if (xa1[rdroga1.IndexOf(auto1)] < 490 && ya1[rdroga1.IndexOf(auto1)] == 145)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto1, xa1[rdroga1.IndexOf(auto1)]);
                            xa1[rdroga1.IndexOf(auto1)] = xa1[rdroga1.IndexOf(auto1)] + v1[rdroga1.IndexOf(auto1)];

                            if (rdroga1.IndexOf(auto1) != 0 && (xa1[rdroga1.IndexOf(auto1)]) > (xa1[(rdroga1.IndexOf(auto1)) - 1] - 80))
                            {
                                v1[rdroga1.IndexOf(auto1)] = v1[(rdroga1.IndexOf(auto1) - 1)];
                            }

                            /* if (xa1[rdroga1.IndexOf(auto1)] == 440 && ya1[rdroga1.IndexOf(auto1)] == 145)
                             {
                                 if (stop == true)
                                 {
                                     v1[rdroga1.IndexOf(auto1)] = 0;
                                 }
                                 else
                                 {
                                     v1[rdroga1.IndexOf(auto1)] = v11[rdroga1.IndexOf(auto1)];
                                 }
                             }*/
                        });
                    }
                    //Pierwszy zakręt
                    else if (kat1[rdroga1.IndexOf(auto1)] > -0.3)
                    {
                        kat1[rdroga1.IndexOf(auto1)] = kat1[rdroga1.IndexOf(auto1)] - 0.1;
                        xa11[rdroga1.IndexOf(auto1)] = xa1[rdroga1.IndexOf(auto1)] + r1 * Math.Sin(kat1[rdroga1.IndexOf(auto1)]);
                        ya11[rdroga1.IndexOf(auto1)] = ya1[rdroga1.IndexOf(auto1)] + r1 * Math.Cos(kat1[rdroga1.IndexOf(auto1)]);

                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto1, xa11[rdroga1.IndexOf(auto1)] + 30);
                            Canvas.SetTop(auto1, ya11[rdroga1.IndexOf(auto1)] + 91);
                        });
                    }
                    //Druga prosta
                    else if (xa11[rdroga1.IndexOf(auto1)] > 462 && xa11[rdroga1.IndexOf(auto1)] < 464)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            xa1[rdroga1.IndexOf(auto1)] = xa11[rdroga1.IndexOf(auto1)] + 30;
                            ya1[rdroga1.IndexOf(auto1)] = ya11[rdroga1.IndexOf(auto1)] + 91;
                            xa11[rdroga1.IndexOf(auto1)] = 0;
                            ya11[rdroga1.IndexOf(auto1)] = 0;
                        });
                    }

                    else if (xa1[rdroga1.IndexOf(auto1)] < 464 + 30 && xa1[rdroga1.IndexOf(auto1)] > 160 && ya1[rdroga1.IndexOf(auto1)] > 322 && ya1[rdroga1.IndexOf(auto1)] < 323)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto1, xa1[rdroga1.IndexOf(auto1)]);
                            xa1[rdroga1.IndexOf(auto1)] = xa1[rdroga1.IndexOf(auto1)] - v1[rdroga1.IndexOf(auto1)];
                            if (rdroga1.IndexOf(auto1) != 0 && (xa1[rdroga1.IndexOf(auto1)]) > (xa1[(rdroga1.IndexOf(auto1)) - 1] - 80))
                            {
                                v1[rdroga1.IndexOf(auto1)] = v1[(rdroga1.IndexOf(auto1) - 1)];
                            }
                        });
                    }

                    //Drugi zakręt
                    else if (kat11[rdroga1.IndexOf(auto1)] < 6)
                    {
                        kat11[rdroga1.IndexOf(auto1)] = kat11[rdroga1.IndexOf(auto1)] + 0.1;
                        xa11[rdroga1.IndexOf(auto1)] = xa1[rdroga1.IndexOf(auto1)] + r2 * Math.Sin(kat11[rdroga1.IndexOf(auto1)]);
                        ya11[rdroga1.IndexOf(auto1)] = ya1[rdroga1.IndexOf(auto1)] + r2 * Math.Cos(kat11[rdroga1.IndexOf(auto1)]);

                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto1, xa11[rdroga1.IndexOf(auto1)] + 15);
                            Canvas.SetTop(auto1, ya11[rdroga1.IndexOf(auto1)] + 62);
                        });
                    }
                    else if (xa11[rdroga1.IndexOf(auto1)] > 147 && xa11[rdroga1.IndexOf(auto1)] < 148)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            xa1[rdroga1.IndexOf(auto1)] = xa11[rdroga1.IndexOf(auto1)] + 15;
                            ya1[rdroga1.IndexOf(auto1)] = ya11[rdroga1.IndexOf(auto1)] + 62;
                            xa11[rdroga1.IndexOf(auto1)] = 0;
                            ya11[rdroga1.IndexOf(auto1)] = 0;

                        });
                    }
                    // TRZECIA PROSTA
                    else if (xa11[rdroga1.IndexOf(auto1)] > 147 && xa11[rdroga1.IndexOf(auto1)] < 148)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            xa1[rdroga1.IndexOf(auto1)] = xa11[rdroga1.IndexOf(auto1)] + 15;
                            ya1[rdroga1.IndexOf(auto1)] = ya11[rdroga1.IndexOf(auto1)] + 62;
                            xa11[rdroga1.IndexOf(auto1)] = 0;
                            ya11[rdroga1.IndexOf(auto1)] = 0;

                        });
                    }
                    else if (xa1[rdroga1.IndexOf(auto1)] > 147 + 15 && xa1[rdroga1.IndexOf(auto1)] < 800 && ya1[rdroga1.IndexOf(auto1)] > 383 + 62 && ya1[rdroga1.IndexOf(auto1)] < 384 + 62)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto1, xa1[rdroga1.IndexOf(auto1)]);
                            xa1[rdroga1.IndexOf(auto1)] = xa1[rdroga1.IndexOf(auto1)] + v1[rdroga1.IndexOf(auto1)];

                            if (rdroga1.IndexOf(auto1) != 0 && (xa1[rdroga1.IndexOf(auto1)]) > (xa1[(rdroga1.IndexOf(auto1)) - 1] - 80))
                            {
                                v1[rdroga1.IndexOf(auto1)] = v1[(rdroga1.IndexOf(auto1) - 1)];
                            }

                            /* if (xa1[rdroga1.IndexOf(auto1)] == 440 && ya1[rdroga1.IndexOf(auto1)] > 383 + 62 && ya1[rdroga1.IndexOf(auto1)] < 384 + 62)
                             {
                                 if (stop == true)
                                 {
                                     v1[rdroga1.IndexOf(auto1)] = 0;
                                 }
                                 else
                                 {
                                     v1[rdroga1.IndexOf(auto1)] = v11[rdroga1.IndexOf(auto1)];
                                 }
                             }*/
                        });
                    }
                }
                Thread.Sleep(10);
            }
        }
        public void Droga2()
        {
            double r1 = 94;
            double r2 = 62;

            while (true)
            {
                List<Rectangle> rdroga2 = new List<Rectangle>(rauto2);
                foreach (Rectangle auto2 in rdroga2)
                {

                    //PIERWSZA PROSTA
                    if (xa2[rdroga2.IndexOf(auto2)] > 175 && ya2[rdroga2.IndexOf(auto2)] == 477)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto2, xa2[rdroga2.IndexOf(auto2)]);
                            xa2[rdroga2.IndexOf(auto2)] = xa2[rdroga2.IndexOf(auto2)] - v2[rdroga2.IndexOf(auto2)];

                            if (rdroga2.IndexOf(auto2) != 0 && (xa2[rdroga2.IndexOf(auto2)] - 80) < (xa2[(rdroga2.IndexOf(auto2)) - 1]))
                            {
                                v2[rdroga2.IndexOf(auto2)] = v2[(rdroga2.IndexOf(auto2) - 1)];
                            }

                            if (xa2[rdroga2.IndexOf(auto2)] == 540 && ya2[rdroga2.IndexOf(auto2)] == 477)
                            {
                                if (stop == true)
                                {
                                    v2[rdroga2.IndexOf(auto2)] = 0;
                                }
                                else
                                {
                                    v2[rdroga2.IndexOf(auto2)] = v22[rdroga2.IndexOf(auto2)];
                                }
                            }
                        });
                    }

                    //PIERWSZY ZAKRET
                    else if (kat2[rdroga2.IndexOf(auto2)] > -3)
                    {
                        kat2[rdroga2.IndexOf(auto2)] = kat2[rdroga2.IndexOf(auto2)] - 0.1;
                        xa22[rdroga2.IndexOf(auto2)] = xa2[rdroga2.IndexOf(auto2)] + r1 * Math.Sin(kat2[rdroga2.IndexOf(auto2)]);
                        ya22[rdroga2.IndexOf(auto2)] = ya2[rdroga2.IndexOf(auto2)] + r1 * Math.Cos(kat2[rdroga2.IndexOf(auto2)]);

                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto2, xa22[rdroga2.IndexOf(auto2)] - 25);
                            Canvas.SetTop(auto2, ya22[rdroga2.IndexOf(auto2)] - 91);

                        });
                    }

                    //else
                    //  MessageBox.Show(Convert.ToString(y2[rectanglesD2.IndexOf(autko2)]));


                    else if (xa22[rauto2.IndexOf(auto2)] > 158 && xa22[rauto2.IndexOf(auto2)] < 165)
                    {

                        this.Dispatcher.Invoke(() =>
                        {

                            xa2[rauto2.IndexOf(auto2)] = xa22[rauto2.IndexOf(auto2)] - 25;
                            ya2[rauto2.IndexOf(auto2)] = ya22[rauto2.IndexOf(auto2)] - 91;

                            xa22[rauto2.IndexOf(auto2)] = 0;
                            ya22[rauto2.IndexOf(auto2)] = 0;
                        });
                    }

                    //DRUGA PROSTA

                    else if (xa2[rauto2.IndexOf(auto2)] > 161 - 25 && xa2[rauto2.IndexOf(auto2)] < 490 && ya2[rauto2.IndexOf(auto2)] > 383 - 91 && ya2[rauto2.IndexOf(auto2)] < 384 - 91)
                    {

                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto2, xa2[rauto2.IndexOf(auto2)]);
                            xa2[rauto2.IndexOf(auto2)] = xa2[rauto2.IndexOf(auto2)] + v2[rauto2.IndexOf(auto2)];

                            if (rauto2.IndexOf(auto2) != 0 && (xa2[rauto2.IndexOf(auto2)]) > (xa2[(rauto2.IndexOf(auto2)) - 1] - 80))
                            {
                                v2[rauto2.IndexOf(auto2)] = v2[(rauto2.IndexOf(auto2) - 1)];
                            }

                            if (xa2[rauto2.IndexOf(auto2)] == 440 && ya2[rauto2.IndexOf(auto2)] > 237 - 62 && ya2[rauto2.IndexOf(auto2)] < 238 - 62)
                            {
                                if (stop == true)
                                {
                                    v2[rauto2.IndexOf(auto2)] = 0;
                                }
                                else
                                {
                                    v2[rauto2.IndexOf(auto2)] = v22[rauto2.IndexOf(auto2)];
                                }
                            }
                        });

                    }


                    //DRUGI ZAKRET
                    else if (kat22[rauto2.IndexOf(auto2)] < 3.6)
                    {
                        kat22[rauto2.IndexOf(auto2)] = kat22[rauto2.IndexOf(auto2)] + 0.1;
                        xa22[rauto2.IndexOf(auto2)] = xa2[rauto2.IndexOf(auto2)] + r2 * Math.Sin(kat22[rauto2.IndexOf(auto2)]);
                        ya22[rauto2.IndexOf(auto2)] = ya2[rauto2.IndexOf(auto2)] + r2 * Math.Cos(kat22[rauto2.IndexOf(auto2)]);

                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto2, xa2[rauto2.IndexOf(auto2)] + 15);
                            Canvas.SetTop(auto2, ya2[rauto2.IndexOf(auto2)] - 62);
                        });


                    }
                    //else
                    //    MessageBox.Show(Convert.ToString(x2[rectanglesD2.IndexOf(autko2)]));



                    else if (xa22[rauto2.IndexOf(auto2)] > 462 && xa22[rauto2.IndexOf(auto2)] < 464)
                    {

                        this.Dispatcher.Invoke(() =>
                        {

                            xa22[rauto2.IndexOf(auto2)] = xa22[rauto2.IndexOf(auto2)] + 15;
                            ya22[rauto2.IndexOf(auto2)] = ya22[rauto2.IndexOf(auto2)] - 62;

                            xa22[rauto2.IndexOf(auto2)] = 0;
                            ya22[rauto2.IndexOf(auto2)] = 0;
                        });

                    }

                    //TRZECIA PROSTA
                    else if (xa2[rauto2.IndexOf(auto2)] < 464 + 15 && xa2[rauto2.IndexOf(auto2)] > 0 && ya2[rauto2.IndexOf(auto2)] > 237 - 62 && ya22[rauto2.IndexOf(auto2)] < 238 - 62)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetLeft(auto2, xa22[rauto2.IndexOf(auto2)]);
                            xa2[rauto2.IndexOf(auto2)] = xa2[rauto2.IndexOf(auto2)] - v2[rauto2.IndexOf(auto2)];

                            if (rauto2.IndexOf(auto2) != 0 && (xa2[rauto2.IndexOf(auto2)]) > (xa2[(rauto2.IndexOf(auto2)) - 1] - 80))
                            {
                                v2[rauto2.IndexOf(auto2)] = v2[(rauto2.IndexOf(auto2) - 1)];
                            }
                        });
                    }
                }
                Thread.Sleep(10);
            }
        }
        public void Pociag()
        {
            while (true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Rectangle train = new Rectangle();
                    train.Width = 150;
                    train.Height = 200;
                    train.Fill = new ImageBrush(new BitmapImage(new Uri(@"assets/train.png", UriKind.Relative)));
                    Canvas1.Children.Add(train);
                    Canvas.SetBottom(train, -20);
                    Canvas.SetLeft(train, -40);
                    trains.Add(train);
                    yac.Add(0);
                });
                Thread.Sleep(25000);
            }
        }
        public void Train()
        {
            while (true)
            {
                List<Rectangle> trains2 = new List<Rectangle>(trains);
                foreach (Rectangle train in trains2)
                {

                    stop = true;


                    if (yac[trains2.IndexOf(train)] <= 600)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetBottom(train, yac[trains2.IndexOf(train)]);
                            yac[trains2.IndexOf(train)] = yac[trains2.IndexOf(train)] + 3;
                            if (yac[trains2.IndexOf(train)] >= 600)
                            {
                                stop = false;
                            }
                        });
                        Thread.Sleep(50);
                    }
                }
            }
        }
    }
}

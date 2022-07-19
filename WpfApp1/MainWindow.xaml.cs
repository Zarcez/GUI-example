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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int diceRoll = 0;
        private Random rd = new Random();
        private Storyboard storyboard;
        public MainWindow()
        {
            InitializeComponent();


            
            RotateTransform transform = new RotateTransform()
            {
                CenterX = 90,
                CenterY = 115,
                Angle = 0,
            };
            diceRec.RenderTransform = transform;
            
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = 720,
                Duration = TimeSpan.FromSeconds(3),
            };

            storyboard = new Storyboard();
            storyboard.Children.Add(animation); 
            Storyboard.SetTarget(animation, diceRec);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Polygon.RenderTransform).(RotateTransform.Angle)"));
            storyboard.Completed += show_number;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int dice = 0;
            diceRec.Opacity = 1.0;
            numberDisplay.Opacity = 0.0;
            if (dice4.IsChecked == true)
            {
                dice = 4;
                diceRec.Points = new PointCollection { new Point(90, 24), new Point(180, 180), new Point(0, 180) };
            }
            else if (dice6.IsChecked == true)
            {
                dice = 6;
                diceRec.Points = new PointCollection { new Point(25, 50), new Point(155, 50), new Point(155, 180), new Point(25 , 180) };
            }
            diceRolls.Text = "You have rolled "+ ++diceRoll +" times";

            int result = roll(dice);
            numberDisplay.Text = ""+result;
            storyboard.Begin(this);

        }

        private int roll (int dice)
        {
            return rd.Next(1, dice+1);
        }
        
        private void show_number(object sender, System.EventArgs e)
        {
            numberDisplay.Opacity = 1.0;
        }
        
    }
}

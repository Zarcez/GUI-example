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
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int dice = 0;
            if (dice4.IsChecked == true)
            {
                dice = 4;    
            }
            else if (dice6.IsChecked == true)
            {
                dice = 6;
            }
            diceRolls.Text = "You have rolled "+ ++diceRoll +" times";
            int result = roll(dice);
            numberDisplay.Text = ""+result;

        }

        private int roll (int dice)
        {
            return rd.Next(1, dice+1);
        }
    }
}

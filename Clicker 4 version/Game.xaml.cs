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
using System.Windows.Threading;

namespace Clicker_4_version
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
            tm.Interval = TimeSpan.FromSeconds(0.5);
            tm.Tick += tmTiker;
            ProgressLive.Maximum = maxValueProgressBar;
            maxDamage.Text = Convert.ToString(max1);
            minDamage.Text = Convert.ToString(min1);
        }

        private void tmTiker(object sender, EventArgs e)
        {
            Krit.Visibility = Visibility.Hidden;
            tm.Stop();
        }

        private void dtTicker(object sender, EventArgs e)
        {
            increment--;
            if (minute == 0 & increment == 0)
            {
                increment = 0;
                MessageBox.Show("Конец, общий счёт: " + scor + "    " + "достигший уровень: " + level);
                
            }
            if (increment <= 0)
            {
                minute--;
                increment = 15;
            }
            Second.Content = increment.ToString();
            Minute.Content = minute.ToString();
        }

        private int increment = 0;
        private int minute = 1;
        int damage;
        DispatcherTimer tm = new DispatcherTimer();
        int min1 = 2;
        int max1 = 20;
        int shans = 30;
        int maxValueProgressBar = 100;
        int level = 1;
        int scor = 0;

        private void ProgressLive_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Punch_Click(object sender, RoutedEventArgs e)
        {
            Random number = new Random();
            Random dm = new Random();
            int newShans = number.Next(0, 100);
            damage = number.Next(min1, max1);
            damageText.Text = Convert.ToString(damage);
            int dam = number.Next(10, 20);  //множитель крита
            double Kry;
            if (newShans <= shans)//крит
            {
                double d = (dam * 0.1);
                Kry = d * damage;
                Krit.Visibility = Visibility;
                tm.Start();
                ProgressLive.Value -= Convert.ToInt32(Kry);
                int scr = Convert.ToInt32(Kry * 0.8);
                scor += scr;
                Score.Text = Convert.ToString(scor);

            }
            else//прост урон
            {
                ProgressLive.Value -= damage;
            }

            ProgressLive.Value -= damage;

            if (ProgressLive.Value > 0)
            {
                ProgressLive.Value -= damage;
            }
            else
            {
                maxValueProgressBar *= 2;
                ProgressLive.Maximum = maxValueProgressBar;
                ProgressLive.Value = maxValueProgressBar;
                level += 1;
                min1 = min1 + 5;
                minDamage.Text = Convert.ToString(min1);
                max1 = max1 + 10;
                maxDamage.Text = Convert.ToString(max1);
            }
            levelText.Text = Convert.ToString(level);
            Random score = new Random();
        }
    }
}

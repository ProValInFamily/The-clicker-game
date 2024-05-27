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

namespace clicker5
{
    /// <summary>
    /// Логика взаимодействия для Custom.xaml
    /// </summary>
    public partial class Custom : Page
    {
        public Custom()
        {
            InitializeComponent();
        }

        private void Style1_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Dictionary1.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Style2_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Dictionary2.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Style3_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Dictionary3.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}

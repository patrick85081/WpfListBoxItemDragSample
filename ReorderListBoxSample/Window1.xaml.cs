using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ReorderListBoxSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ObservableCollection<SolidColorBrush> _colors = 
            new ObservableCollection<SolidColorBrush>();

        public Window1()
        {
            InitializeComponent();

            _colors.Add(new SolidColorBrush(Colors.Blue));
            _colors.Add(new SolidColorBrush(Colors.Red));
            _colors.Add(new SolidColorBrush(Colors.Green));
            _colors.Add(new SolidColorBrush(Colors.Black));

            ReorderList.DataContext = _colors;
        }

        private void ReorderList_ReorderRequested(object sender, PixelLab.Wpf.ReorderEventArgs e)
        {
            SolidColorBrush item1 = (SolidColorBrush) 
                ReorderList.ItemContainerGenerator.ItemFromContainer(e.ItemContainer);
            SolidColorBrush item2 = (SolidColorBrush)
                ReorderList.ItemContainerGenerator.ItemFromContainer(e.ToContainer);

            _colors.Move(_colors.IndexOf(item1), _colors.IndexOf(item2));
        }
    }
}

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
using System.Xaml;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkIfNum(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsNumber(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int rows = int.Parse(textBox.Text);
            int columns = int.Parse(textBox1.Text);
            int mines = int.Parse(textBox2.Text);
            Board board = new Board(rows, columns, mines);
            board.Show();
        }
    }
}

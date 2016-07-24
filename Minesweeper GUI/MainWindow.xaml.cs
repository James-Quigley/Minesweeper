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
            int rows, columns, mines;
            try
            {
                rows = int.Parse(textBox.Text);
                columns = int.Parse(textBox1.Text);
                mines = int.Parse(textBox2.Text);
                if (mines >= rows * columns)
                {
                    MessageBox.Show("More mines than spaces!");
                }
                else if (rows < 2 || columns < 2)
                {
                    MessageBox.Show("Board must be at least 2x2!");
                }
                else
                {
                    Board board = new Board(rows, columns, mines);
                    board.Show();
                }
            }
            catch (Exception excpt)
            {
                MessageBox.Show("Please enter a value!");
            }
            
        }
    }
}

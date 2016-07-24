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
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : Window
    {
        GameBoard game;
        public Board(int rows, int columns, int mines)
        {
            InitializeComponent();
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < columns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    button.Width = 30;
                    button.Height = 30;
                    button.Content = "";
                    button.Margin = new Thickness(1, 1, 1, 1);
                    button.Click += leftClick;
                    button.MouseRightButtonDown += Button_MouseRightButtonDown;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    grid.Children.Add(button);
                }
            }
            game = new GameBoard(rows, columns, mines);
        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            game.onRightClick(row, column);
            List<Point> list = new List<Point>();
            list.Add(new Point(row, column));
            update(list);
        }

        private void leftClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            List<Point> list = game.onClick(row, column);
            update(list);
        }

        private void update(List<Point> list)
        {
            if (game.gameOver)
            {
                MessageBox.Show("You Lose!");
                this.Close();
            }
            else if (game.win)
            {
                MessageBox.Show("You Win!");
                this.Close();
            }
            else
            {
                Tile[,] board = game.getGameBoard();
                foreach (Point tile in list) {
                    Button button = grid.Children.Cast<Button>().First(e => Grid.GetRow(e) == tile.X && Grid.GetColumn(e) == tile.Y);
                    if (board[(int)tile.X, (int)tile.Y].isFlagged())
                    {
                        button.Content = "\u2691";
                        button.Foreground = Brushes.Red;
                    }
                    else if (!board[(int)tile.X, (int)tile.Y].isHidden())
                    {
                        button.Content = board[(int)tile.X, (int)tile.Y].getValue();
                        switch (board[(int)tile.X, (int)tile.Y].getValue())
                        {
                            case 1:
                                button.Foreground = Brushes.Blue;
                                break;
                            case 2:
                                button.Foreground = Brushes.Green;
                                break;
                            case 3:
                                button.Foreground = Brushes.OrangeRed;
                                break;
                            case 4:
                                button.Foreground = Brushes.BlueViolet;
                                break;
                            case 5:
                                button.Foreground = Brushes.DarkRed;
                                break;
                            case 6:
                                button.Foreground = Brushes.LightGreen;
                                break;
                            case 7:
                                button.Foreground = Brushes.Purple;
                                break;
                            case 8:
                                button.Foreground = Brushes.Gray;
                                break;
                        }
                        button.Background = Brushes.DarkGray;
                    }
                    else
                    {
                        button.Content = "";
                    }
                }
            }
        }
    }
}

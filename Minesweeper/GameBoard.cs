using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameBoard
    {
        private int MINE = 9;
        public bool gameOver, win;
        private int boardHeight, boardWidth, totalMines, tilesFlagged, tilesRevealed;
        private Tile[,] boardTiles;

        public GameBoard(int height, int width, int mines)
        {
            gameOver = false;
            win = false;
            boardHeight = height;
            boardWidth = width;
            totalMines = mines;
            tilesFlagged = 0;
            tilesRevealed = 0;
            boardTiles = new Tile[height,width];
            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    boardTiles[i, j] = new Tile(i,j);
                }
            }

            init();
        }

        private void init()
        {
            Random rnd = new Random();
            int x = 0;
            while (x < totalMines)
            {
                int height = rnd.Next(0, boardHeight);
                int width = rnd.Next(0, boardWidth);
                if (boardTiles[height, width].getValue() != MINE)
                {
                    boardTiles[height, width].setValue(MINE);
                    x++;
                }
            }
            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    setAdjacentTiles(i, j);
                    if (boardTiles[i, j].getValue() != MINE)
                    {
                        boardTiles[i, j].setValue(boardTiles[i, j].getNumAdjacentMines());
                    }
                }
            }
        }

        public Tile[,] getGameBoard()
        {
            return boardTiles;
        }

        private void setAdjacentTiles(int i, int j)
        {
            if (i == 0)
            {
                if (j == 0)
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[0, 1]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[1, 0]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[1, 1]);
                }
                else if (j == boardWidth - 1)
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[0, j]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[1, j]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[1, j - 1]);
                }
                else
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[0, j - 1]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[0, j + 1]);
                    for (int x = j - 1; x <= j + 1; x++)
                    {
                        boardTiles[i, j].addAdjacentTile(boardTiles[1, x]);
                    }
                }
            }
            else if (i == boardHeight - 1)
            {
                if (j == 0)
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, 0]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, 1]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i, 1]);
                }
                else if (j == boardWidth - 1)
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, j]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, j - 1]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i, j - 1]);
                }
                else
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[i, j - 1]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i, j + 1]);
                    for (int x = j - 1; x <= j + 1; x++)
                    {
                        boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, x]);
                    }
                }
            }
            else
            {
                if (j == 0)
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, 0]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i + 1, 0]);
                    for (int x = i - 1; x <= i + 1; x++)
                    {
                        boardTiles[i, j].addAdjacentTile(boardTiles[x, 1]);
                    }
                }
                else if (j == boardWidth - 1)
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, j]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i + 1, j]);
                    for (int x = i - 1; x <= i + 1; x++)
                    {
                        boardTiles[i, j].addAdjacentTile(boardTiles[x, j - 1]);
                    }
                }
                else
                {
                    boardTiles[i, j].addAdjacentTile(boardTiles[i, j - 1]);
                    boardTiles[i, j].addAdjacentTile(boardTiles[i, j + 1]);
                    for (int x = j - 1; x <= j + 1; x++)
                    {
                        boardTiles[i, j].addAdjacentTile(boardTiles[i - 1, x]);
                    }
                    for (int x = j - 1; x <= j + 1; x++)
                    {
                        boardTiles[i, j].addAdjacentTile(boardTiles[i + 1, x]);
                    }
                }
            }
        }

        public void printBoard(bool hideValues)
        {
            Console.WriteLine();
            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    if (hideValues)
                    {
                        if (boardTiles[i, j].isFlagged())
                        {
                            Console.Write("FLAG\t");
                        }
                        else if (boardTiles[i, j].isHidden())
                        {
                            Console.Write("[" + i + "," + j + "]\t");
                        }
                        else if (boardTiles[i,j].getValue() == MINE)
                        {
                            Console.Write("MINE\t");
                        }
                        else
                        {
                            Console.Write(boardTiles[i, j].getValue() + "\t");
                        }
                    }
                    else if (boardTiles[i, j].getValue() == MINE)
                    {
                        Console.Write("MINE\t");
                    }
                    else
                    {
                        Console.Write(boardTiles[i, j].getValue() + "\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public List<System.Windows.Point> onClick(int x, int y)
        {
            List<System.Windows.Point> list = new List<System.Windows.Point>();
            Queue<Tile> queue = new Queue<Tile>();
            Tile t = boardTiles[x, y];
            if (!t.isFlagged())
            {
                if (t.getValue() == MINE)
                {
                    gameOver = true;
                }
                else
                {
                    queue.Enqueue(t);
                    list.Add(new System.Windows.Point(t.getX(), t.getY()));
                }
            }
            while(queue.Count != 0)
            {
                Tile current = queue.Dequeue();
                current.setHidden(false);
                tilesRevealed++;
                if(totalMines == (boardHeight * boardWidth) - tilesRevealed)
                {
                    win = true;
                    break;
                }
                if (current.getValue() == 0)
                {
                    List<Tile> tiles = current.getAdjacentTiles();
                    foreach (Tile tile in tiles)
                    {
                        if (tile.isHidden() && !queue.Contains(tile))
                        {
                            queue.Enqueue(tile);
                            list.Add(new System.Windows.Point(tile.getX(), tile.getY()));
                        }
                    }
                }
            }
            return list;
        }

        public void onRightClick(int x, int y)
        {
            Tile t = boardTiles[x, y];
            if (t.isFlagged())
            {
                tilesFlagged--;
                t.setFlagged(false);
            }
            else
            {
                tilesFlagged++;
                t.setFlagged(true);
            }
        }
    }
}

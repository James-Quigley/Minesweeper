using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Tile
    {
        private int MINE = 9;
        private bool hidden;
        private int value;
        private bool flagged;
        private List<Tile> adjacentTiles;
        private int x, y;

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
            hidden = true;
            value = 0;
            flagged = false;
            adjacentTiles = new List<Tile>();
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setHidden(bool var)
        {
            hidden = var;
        }

        public bool isHidden()
        {
            return hidden;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int var)
        {
            value = var;
        }

        public void setFlagged(bool var)
        {
            flagged = var;
        }

        public bool isFlagged()
        {
            return flagged;
        }

        public List<Tile> getAdjacentTiles()
        {
            return adjacentTiles;
        }

        public void addAdjacentTile(Tile t)
        {
            adjacentTiles.Add(t);
        }

        internal int getNumAdjacentMines()
        {
            int mines = 0;
            foreach (Tile t in adjacentTiles)
            {
                if (t.getValue() == MINE)
                {
                    mines++;
                }
            }
            return mines;
        }
    }
}

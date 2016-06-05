using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Tile
    {
        private bool hidden;
        private int value;
        private bool flagged;
        private List<Tile> adjacentTiles;

        public Tile()
        {
            hidden = true;
            value = 0;
            flagged = false;
            adjacentTiles = new List<Tile>();
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
    }
}

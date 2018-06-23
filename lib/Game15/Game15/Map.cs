using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game15
{
    struct Map
    {
        private int _size;
        private int[,] map;

        public Map(int size)
        {
            this._size = size;
            map = new int[size, size];
        }

        public void Set(Coord coord, int value)
        {
            if (coord.OnBoard(_size))
                map[coord.x, coord.y] = value;
        }

        public int Get(Coord coord)
        {
            if (coord.OnBoard(_size))
                return map[coord.x, coord.y];
            return 0;
        }

        public void Copy(Coord from, Coord to)
        {
            Set(to, Get(from));
        }
    }
}

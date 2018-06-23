using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game15
{
    public class Game : IGame
    {
        private int _size;
        private Map _map;
        private Coord _space;

        public int Moves { get; set; }

        public Game(int size)
        {
            this._size = size;
            _map = new Map(_size);
        }

        public void Start(int seed = 0)
        {
            int _digit = 0;
            foreach (Coord coord in new Coord().YieldCoord(_size))
                _map.Set(coord, ++_digit);
            _space = new Coord(_size);
            if (seed > 0)
                Shuffle(seed);
            Moves = 0;
        }

        /// <summary>
        /// Shuffle elements on game doard;
        /// </summary>
        /// <param name="seed">Level of dif.</param>
        private void Shuffle(int seed)
        {
            Random random = new Random(seed);
            for (int i = 0; i < seed; i++)
                PressAt(random.Next(_size), random.Next(_size));
        }

        /// <summary>
        /// Press at element ob board
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Steps</returns>
        public int PressAt(int x, int y)
        {
            return PressAt(new Coord(x, y));
        }

        private int PressAt(Coord coord)
        {
            if (_space.Equals(coord)) return 0;
            if (coord.x != _space.x && coord.y != _space.y) return 0;

            int _steps = Math.Abs(coord.x - _space.x) +
                Math.Abs(coord.y - _space.y);

            while (coord.x != _space.x)
                Shift(Math.Sign(coord.x - _space.x), 0);

            while (coord.y != _space.y)
                Shift(0, Math.Sign(coord.y - _space.y));

            Moves += _steps;
            return _steps;
        }

        private void Shift(int shiftX, int ShiftY)
        {
            Coord _next = _space.Add(shiftX, ShiftY);
            _map.Copy(_next, _space);
            _space = _next;
        }

        public int GetDigitAt(int x, int y)
        {
            return GetDigitAt(new Coord(x, y));
        }

        private int GetDigitAt(Coord coord)
        {
            if (_space.Equals(coord))
                return 0;
            return _map.Get(coord);
        }

        public bool Solved()
        {
            if (!_space.Equals(new Coord(_size)))
                return false;
            int _digit = 0;
            foreach (Coord coord in new Coord().YieldCoord(_size))
                if (_map.Get(coord) != ++_digit)
                    return _space.Equals(coord);
            return true;
        }
    }
}


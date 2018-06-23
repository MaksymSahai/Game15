using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game15
{
    interface IGame
    {
        void Start(int seed = 0);
        int PressAt(int x, int y);
        int GetDigitAt(int x, int y);
        bool Solved();
    }
}

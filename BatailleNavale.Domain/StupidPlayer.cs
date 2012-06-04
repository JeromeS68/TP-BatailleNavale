using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavale.Domain
{
    public class StupidPlayer : IPlayer
    {
        int x;
        int y;

        /* Stupide, mais peut parfois gagner... */
        public StupidPlayer()
        {
            x = 0;
            y = 0;
        }

        void IPlayer.Play(BattleGrid grid)
        {
            if (x < 10 && y < 10)
            {
                grid.Shoot(x, y);
                if (x < 9)
                    x++;
                else if (y < 9)
                {
                    x = 0;
                    y++;
                }
            }

        }
    }
}

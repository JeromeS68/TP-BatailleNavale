using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavale.Domain
{
    public interface IPlayer
    {
        void Play(BattleGrid grid);
    }
}

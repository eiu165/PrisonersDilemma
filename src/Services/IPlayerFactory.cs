﻿using Arena;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPlayerFactory
    {
        IPlayable GetPlayer(PlayerType type);
    }
}

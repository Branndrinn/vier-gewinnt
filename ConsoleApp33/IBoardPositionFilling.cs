﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    interface IBoardPositionFilling : IEquatable<IBoardPositionFilling>
    {
        ConsoleColor Color { get; set; }
        string Name { get; set; }
        string TextualRepresentation { get; set; }
    }
}

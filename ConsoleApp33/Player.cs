using System;
using System.Collections.Generic;

namespace ConnectFour
{
#pragma warning disable CS0659 // Typ überschreibt Object.Equals(object o), überschreibt jedoch nicht Object.GetHashCode()
    class Player : IBoardPositionFilling
#pragma warning restore CS0659 // Typ überschreibt Object.Equals(object o), überschreibt jedoch nicht Object.GetHashCode()
    {
        public ConsoleColor Color { get; set; }
        public string Name { get; set; }
        public string TextualRepresentation
        {
            get
            {
                string Gamestone = "    ";
                return Gamestone;
            }
            set
            {

            }
        }
        public Player(string name, ConsoleColor color)
        {
            Color = color;
            Name = name;
        }
        public ConsoleColor SetColor(int colorNum, ConsoleColor[] colors)
        {
            ConsoleColor color;
            color = colors[colorNum];
            return color;
        }

        public bool Equals(IBoardPositionFilling other)
        {
            return Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            if (obj is IBoardPositionFilling)
                return Equals((IBoardPositionFilling)obj);
            return base.Equals(obj);
        }
    }
}
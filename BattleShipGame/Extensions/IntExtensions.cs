using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Extensions
{
    public static class IntExtensions
    {
        public static bool IsInvalidLimit(this int point) {

            if (point < 1 || point > Constants.BoardLength)
            {
                Console.Write($"Invalid value, must between 1 and { Constants.BoardLength }.");
                Console.WriteLine(Environment.NewLine);
                return true;
            }
            return false;            
        }
    }
}

using Battleship.Models;
using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Battle battle = new Battle();
            battle.PlayBattle();
        }
    }
}

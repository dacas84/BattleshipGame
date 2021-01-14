using Battleship.Extensions;
using System;

namespace Battleship.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Board MyBoard { get; set; }

        public Board MyShotsBoard { get; set; }

        public bool LastShotSucceeded { get; set; }


        public Player(int id)
        {
            Id = id;
            MyBoard = new Board();
            MyShotsBoard = new Board();
        }
        public void SetName()
        {
            Console.Write($"Please enter Player {Id} name: ");
            string name = Console.ReadLine();
            Name = !string.IsNullOrEmpty(name) ? name : $"Player {Id}";
        }
        public void ShowBoards()
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("My Board:                          My Shots:");
            for (int i = 0; i <= Constants.BoardLength; i++)
            {
                PrintBoard(MyBoard, i);
                Console.Write("                 ");
                PrintBoard(MyShotsBoard, i);
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }
        public void PrintBoard(Board board, int i)
        {
            for (int j = 0; j <= Constants.BoardLength; j++)
            {
                if (i == 0)
                    Console.Write(j > 0 ? ($"{ j } ") : "  ");
                else if (j == 0)
                    Console.Write($"{ i } ");
                else
                {
                    if (board.Positions[i - 1, j - 1] == "0")
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    else if (board.Positions[i - 1, j - 1] == "X")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(board.Positions[i - 1, j - 1] + " ");
                }
            }
        }
        public void PlaceShip()
        {
            int orientation = GetOrientation();
            Console.Write($"{Name} please enter the coordinates where the ship will start: {Environment.NewLine}");
            int startRow = GetCoordinate("row");
            int startColumn = GetCoordinate("column");

            if (orientation == 0)
                PlaceHorizontally(startRow - 1, startColumn - 1);
            else
                PlaceVertically(startRow - 1, startColumn - 1);

        }

        public void PlaceHorizontally(int row, int column)
        {
            if (column + Constants.ShipLength < Constants.BoardLength)
                for (int i = 0; i < Constants.ShipLength; i++)
                    MyBoard.Positions[row, column + i] = "0";

            else if (column - Constants.ShipLength >= 0)
                for (int i = 0; i < Constants.ShipLength; i++)
                    MyBoard.Positions[row, column - i] = "0";
        }

        public void PlaceVertically(int row, int column)
        {
            if (row + Constants.ShipLength < Constants.BoardLength)
                for (int i = 0; i < Constants.ShipLength; i++)
                    MyBoard.Positions[row + i, column] = "0";

            else if (row - Constants.ShipLength >= 0)
                for (int i = 0; i < Constants.ShipLength; i++)
                    MyBoard.Positions[row - i, column] = "0";
        }

        public ShotPosition Shot()
        {
            Console.Write($"{Name} please enter the row and column number to shot: {Environment.NewLine}");
            return new ShotPosition(GetCoordinate("row"), GetCoordinate("column"));
        }
        public int GetOrientation()
        {
            Console.Write($"Let's place your ship! { Environment.NewLine }");
            Console.Write($"{Name} please enter ship orientation, 0/horizontal or 1/vertical: ");
            Int32.TryParse(Console.ReadLine(), out int val);
            return (val == 1 || val == 0) ? val : 0;
        }

        public int GetCoordinate(string type)
        {
            int coordinate;
            do
            {
                Console.Write($"{type} number: ");
                Int32.TryParse(Console.ReadLine(), out coordinate);
            }
            while (coordinate.IsInvalidLimit());
            return coordinate;
        }

        public void UpdateBoards(ShotPosition myShot, Player opponent)
        {
            if (opponent.MyBoard.Positions[myShot.Row - 1, myShot.Column - 1] == "0")
            {
                MyShotsBoard.Positions[myShot.Row - 1, myShot.Column - 1] = "X";
                opponent.MyBoard.Positions[myShot.Row - 1, myShot.Column - 1] = "X";
                opponent.MyBoard.Hits++;
                LastShotSucceeded = true;
            }
            else
            {
                MyShotsBoard.Positions[myShot.Row - 1, myShot.Column - 1] = "M";
                opponent.MyBoard.Positions[myShot.Row - 1, myShot.Column - 1] = "M";
                LastShotSucceeded = false;
            }
        }

        public void NextPlayerMsg()
        {
            Console.Write($"{Environment.NewLine} Press any key to continue with the next player.");
            Console.ReadLine();
        }

        public void ResultMsg()
        {
            Console.Write($"You {(LastShotSucceeded ? "hit" : "miss")} it!! ");
        }
    }
}

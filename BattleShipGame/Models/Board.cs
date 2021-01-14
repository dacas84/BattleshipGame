namespace Battleship.Models
{
    public class Board
    {
        public int Hits { get; set; }
        public string[,] Positions { get; set; } = new string[Constants.BoardLength, Constants.BoardLength];

        public Board()
        {
            for (int i = 0; i < Constants.BoardLength; i++)
            {
                for (int j = 0; j < Constants.BoardLength; j++)
                {
                    Positions[i, j] = "~";
                }
            }
        }
    }
}

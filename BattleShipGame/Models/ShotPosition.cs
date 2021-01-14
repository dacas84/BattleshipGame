namespace Battleship.Models
{
    public class ShotPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public ShotPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}

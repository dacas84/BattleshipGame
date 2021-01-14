using System;

namespace Battleship.Models
{
    public class Battle
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Battle()
        {
            Player1 = new Player(1);
            Player2 = new Player(2);           
            BattleSetUp(Player1);
            BattleSetUp(Player2);
        }

        public void BattleSetUp(Player player)
        {
            player.SetName();
            player.ShowBoards();
            player.PlaceShip();
            player.ShowBoards();
            player.NextPlayerMsg();
            Console.Clear();
        }

        public void PlayBattle()
        {

            while (Player1.MyBoard.Hits != Constants.ShipLength && Player2.MyBoard.Hits != Constants.ShipLength)
            {
                PlayTurn();
            }

            if (Player1.MyBoard.Hits == Constants.ShipLength)
            {
                Console.WriteLine($"{ Environment.NewLine } { Player1.Name } says: { Player2.Name }, you sunk my battleship!");
            }
            else if (Player2.MyBoard.Hits == Constants.ShipLength)
            {
                Console.WriteLine($"{ Environment.NewLine } { Player2.Name } says: { Player1.Name}, you sunk my battleship!");
            }
        }

        public void PlayTurn()
        {
            PlayRoutine(Player1, Player2);
            if (Player2.MyBoard.Hits < Constants.ShipLength)
                PlayRoutine(Player2, Player1);
        }

        public void PlayRoutine(Player player, Player opponent)
        {
            player.ShowBoards();
            player.UpdateBoards(player.Shot(), opponent);
            player.ShowBoards();
            player.ResultMsg();
            if (opponent.MyBoard.Hits != Constants.ShipLength)
                player.NextPlayerMsg();
        }

    }
}

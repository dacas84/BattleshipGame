using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        public Player player1;
        public Player player2;

        [TestInitialize]
        public void setup()
        {
            player1 = new Player(1);
            player2 = new Player(2);
            player2.MyBoard.Positions[0, 0] = "0";
            player2.MyBoard.Positions[0, 1] = "0";
            player2.MyBoard.Positions[0, 2] = "0";
        }

        [TestMethod]
        public void SetName_NullEntry_DefaultValue()
        {
            var input = new StringReader("");
            Console.SetIn(input);

            player1.SetName();

            Assert.AreEqual("Player 1", player1.Name);
        }

        [TestMethod]
        public void SetName_TypeName_RteurnsName()
        {
            string name = "Somebody";
            var input = new StringReader(name);
            Console.SetIn(input);

            player1.SetName();

            Assert.AreEqual(name, player1.Name);
        }

        [TestMethod]
        public void GetCoordinate_InvalidValue_RepeatUntilValid()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var inputFirst = new StringReader(@"10
            5");
            Console.SetIn(inputFirst);

            int result = player1.GetCoordinate("row");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void UpdateBoards_PlayerHitsOpponet_OpponentHit()
        {
            ShotPosition shot = new ShotPosition(1, 1);

            player1.UpdateBoards(shot, player2);

            Assert.AreEqual(1, player2.MyBoard.Hits);
            Assert.AreEqual("X", player2.MyBoard.Positions[0, 0]);
            Assert.IsTrue(player1.LastShotSucceeded);
        }

        [TestMethod]
        public void UpdateBoards_PlayerMissOpponet_OpponentMissed()
        {
            ShotPosition shot = new ShotPosition(1, 4);

            player1.UpdateBoards(shot, player2);

            Assert.AreEqual(0, player2.MyBoard.Hits);
            Assert.AreEqual("M", player2.MyBoard.Positions[0, 3]);
            Assert.IsFalse(player1.LastShotSucceeded);
        }

        [TestMethod]
        public void ResultMsg_LastShotSucceededIsTrue_HitMessage()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("");
            Console.SetIn(input);

            player1.LastShotSucceeded = true;

            player1.ResultMsg();
            var expectedOutput = @"You hit it!! ";
            Assert.AreEqual(expectedOutput, output.ToString());

        }

        [TestMethod]
        public void ResultMsg_LastShotSucceededIsFalse_MissMessage()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("");
            Console.SetIn(input);

            player1.LastShotSucceeded = false;

            player1.ResultMsg();
            var expectedOutput = @"You miss it!! ";
            Assert.AreEqual(expectedOutput, output.ToString());

        }

        [TestMethod]
        public void PlaceShip_HorizontalLocation_HorizontalToRigthShip()
        {
            var input = new StringReader(@"0
            1
            1");
            Console.SetIn(input);

            player1.PlaceShip();

            Assert.AreEqual("0", player1.MyBoard.Positions[0, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 1]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 2]);

        }

        [TestMethod]
        public void PlaceShip_InvalidHorizontalLocation_HorizontalToLeftShip()
        {
            var input = new StringReader(@"0
            1
            7");
            Console.SetIn(input);

            player1.PlaceShip();

            Assert.AreEqual("0", player1.MyBoard.Positions[0, 6]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 5]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 4]);

        }

        [TestMethod]
        public void PlaceHorizontally_HorizontalLocation_HorizontalToRigthShip()
        {
            player1.PlaceHorizontally(0, 0);

            Assert.AreEqual("0", player1.MyBoard.Positions[0, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 1]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 2]);

        }

        [TestMethod]
        public void PlaceHorizontally_InvalidHorizontalLocation_HorizontalToLeftShip()
        {
            player1.PlaceHorizontally(0, 6);

            Assert.AreEqual("0", player1.MyBoard.Positions[0, 6]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 5]);
            Assert.AreEqual("0", player1.MyBoard.Positions[0, 4]);

        }

        [TestMethod]
        public void PlaceShip_VerticalLocation_VerticalDownShip()
        {
            var input = new StringReader(@"1
            1
            1");
            Console.SetIn(input);

            player1.PlaceShip();

            Assert.AreEqual("0", player1.MyBoard.Positions[0, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[1, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[2, 0]);

        }
        [TestMethod]
        public void PlaceShip_VerticalLocation_VerticalUpShip()
        {
            var input = new StringReader(@"1
            7
            1");
            Console.SetIn(input);

            player1.PlaceShip();

            Assert.AreEqual("0", player1.MyBoard.Positions[6, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[5, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[4, 0]);

        }

        [TestMethod]
        public void PlaceVertically_VerticalLocation_VerticalDownShip()
        {
            player1.PlaceVertically(0, 0);

            Assert.AreEqual("0", player1.MyBoard.Positions[0, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[1, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[2, 0]);

        }
        [TestMethod]
        public void PlaceVertically_VerticalLocation_VerticalUpShip()
        {
            player1.PlaceVertically(6, 0);

            Assert.AreEqual("0", player1.MyBoard.Positions[6, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[5, 0]);
            Assert.AreEqual("0", player1.MyBoard.Positions[4, 0]);

        }
    }
}

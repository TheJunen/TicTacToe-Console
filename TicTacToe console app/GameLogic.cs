using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_console_app
{
    internal class GameLogic
    {
        internal int counter { get; private set; } = 0; //ingen userinput, trenger ikke validasjon
        internal Gameboard gameboard { get; set; } = new Gameboard();
        internal GameMessages gamemessages { get; set; } = new GameMessages();

        public GameLogic()
        {
            gameboard.initializeVariable(); //fyller opp string variabler i board.
        }

        internal void PlayGame()
        {
            gamemessages.introduction(); //introduksjonsmelding
            while (gamemessages.PlayAgain == "Y") //denne kjøres på nytt hvis du spiller spillet på nytt
            {
                gameboard.initializeVariable(); //nullstiller brettet
                while (hasWon() == false && counter < 9) //så lenge ingen har vunnet og counter er under 9 så kjører loopen
                {
                    askData("X"); //sender string X, og askData sørger for at X blir puttet i boardet.
                    Console.WriteLine($"Counter: {counter}"); //ved å ha writeline etter askData kjører har bruker kontroll på hvor mange boardslots har blitt brukt
                    System.Threading.Thread.Sleep(1000); //venter 1 sek
                    Console.Clear(); //konsoll clear
                    if (hasWon() == true)
                        break;
                    if (counter < 9) // sjekker om counter er under 9, dette sørger for at det alle 9 slots blir fyllt
                        askData("0"); //sender string O, og askData sørger for at O blir puttet i boardet.
                    Console.WriteLine($"Counter: {counter}");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
                if (hasWon() == true)//Kjører spillet på nytt hvis du skriver Y
                    gamemessages.playAgainMsg("Congratulations! You won!", counter);
                else
                    gamemessages.playAgainMsg("Sorry, but this was a tie game", counter);
            }
            gamemessages.goodBye(); //avslutningsmelding av program
        }

        private void askData(string player)
        {
            Console.WriteLine("Player : " + player);
            int selection;
            while (true) //loop kjører til break aktiveres
            {
                Console.WriteLine("Please enter your selection");
                gameboard.drawBoard();  //skriver ut board
                selection = Convert.ToInt32(Console.ReadLine());
                if (gameboard.InvalidMove(selection)) // sørger for at bruker får feilmelding når en av disse utløses
                    Console.WriteLine("Invalid selection!");
                else
                    break;
            }

            gameboard.MakePlayerMove(selection, player);//putter spillernavn inn valgt boardslots, for eks skrives 1 i selection og da byttes innhold i board[1] med spillernavn.
            counter++;
        }

        private bool hasWon() //sørger for at alle mulige winner pattern returnerer true, ellers false.
        {
            string[] currentBoard = gameboard.GetBoard();
            if (currentBoard[0].Equals(currentBoard[1]) && currentBoard[1].Equals(currentBoard[2]))
                return true;
            if (currentBoard[0].Equals(currentBoard[3]) && currentBoard[3].Equals(currentBoard[6]))
                return true;
            if (currentBoard[1].Equals(currentBoard[4]) && currentBoard[4].Equals(currentBoard[8]))
                return true;
            if (currentBoard[2].Equals(currentBoard[5]) && currentBoard[3].Equals(currentBoard[8]))
                return true;
            if (currentBoard[2].Equals(currentBoard[4]) && currentBoard[4].Equals(currentBoard[6]))
                return true;
            if (currentBoard[0].Equals(currentBoard[4]) && currentBoard[4].Equals(currentBoard[8]))
                return true;
            return false;
        }

    }
}

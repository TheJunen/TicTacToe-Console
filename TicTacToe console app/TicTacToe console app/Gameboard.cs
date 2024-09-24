using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_console_app
{
    internal class Gameboard
    {
        private string[] board { get; set; } = new string[9];

        internal void initializeVariable() //fyller opp 9 indexer, gjør om til string og putter den i board variabel.
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = i.ToString();
            }
        }

        internal void drawBoard() //tegner brettet
        {
            for (int i = 0; i < 7; i += 3) //draw the board. kjøres 3 ganger
                Console.WriteLine(board[i] + "|" + board[i + 1] + "|" + board[i + 2]);
        }

        internal string[] GetBoard() //returner brettet
        {
            return board;
        }

        internal bool InvalidMove(int selection)
        {
            return selection < 0 || selection > 8 || board[selection] == "X" || board[selection] == "O"; // sørger for at bruker får feilmelding når en av disse utløses
        }

        internal void MakePlayerMove(int selection, string player)
        {
            board[selection] = player;
        }
    }
}

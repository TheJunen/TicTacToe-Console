using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace TicTacToe_console_app
{
    class Program
    {
        //1|2|3
        //4|5|6
        //7|8|9

        //X|2|3
        //4|5|6
        //7|8|9

        static void Main(string[] args)
        {
            GameLogic gamelogic = new GameLogic();
            gamelogic.PlayGame();
        }
    }
}
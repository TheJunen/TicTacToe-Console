using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_console_app
{
    internal class GameMessages
    {
        private string playAgain_ = "Y";
        public string PlayAgain
        { 
            get { return playAgain_; }
            set
            {
                if (value == "Y")
                    playAgain_ = "Y";
                else if (value == "N")
                    playAgain_ = "N";
                else
                    Console.WriteLine("Invalid value. Please use 'Y' for yes or 'N' for no.");
            }
        }

        internal void playAgainMsg(string message, int counter)
        {
            Console.WriteLine(message + "Do you want to play again? Write 'Y' for yes, 'N' for no.");
            string input = Console.ReadLine();
            PlayAgain = input;
            if (input.Equals("Y"))
            {
                counter = 0;
            }
        }
        internal void goodBye()
        {
            Console.WriteLine("Thank you for playing! Thanks Youtube for watching");
        }


        internal void introduction()
        {
            Console.Title = ("Tic Tac Toe Version 2");
            Console.WriteLine("Welcome to Tic Tac Toe. \n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

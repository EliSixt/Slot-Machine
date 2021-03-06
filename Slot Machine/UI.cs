using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class UI
    {
        /// <summary>
        /// WriteLine a message of the total money after the player decides to not continue and cashout instead.
        /// </summary>
        /// <param name="totalMoney">The total amount of money.</param>
        public static void CashOut(int totalMoney)
        {
            Console.Clear();
            Console.WriteLine($"Your cashout is ${totalMoney}!");
        }
        /// <summary>
        /// Asks the user if they want to continue.
        /// </summary>
        /// <returns>Boolean, based on their answer.</returns>
        public static bool AskToContinue()
        {
            Console.WriteLine("Do you wanna make a bet? yes/no");
            string yesOrNoAnswer = Console.ReadLine();
            if (yesOrNoAnswer == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Displays a Game Over.
        /// </summary>
        public static void GameOver()
        {
            Console.WriteLine("You ran out of money. Game Over. =(");
        }
        /// <summary>
        /// Displays updated total amount of money after the win.
        /// Displays the line position that the player won at. 
        /// </summary>
        /// <param name="linePosition">The line/slot position of which the player won at.</param>
        /// <param name="totalMoney">The total amount of money.</param>
        public static void WonBet(string linePosition, int totalMoney)
        {
            Console.WriteLine($"You Won on {linePosition}! =) You now have ${totalMoney}!");
        }
        /// <summary>
        /// Displays the line position that the player lost it's bet on.
        /// </summary>
        /// <param name="linePosition">The line/slot position of which the player lost at.</param>
        public static void LostBet(string linePosition)
        {
            Console.WriteLine($"You Lost your bet on {linePosition}. =(");
        }
        /// <summary>
        /// Asks for user how much to bet, reads input, and returns amount.
        /// </summary>
        /// <param name="totalMoney">The total amount of money.</param>
        /// <returns>Amount of money entered towards the bet.</returns>
        public static int GetPlacedBet(int totalMoney)
        {
            Console.Clear();
            Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on each of those lines?");
            Console.WriteLine("Please stay within your limit.");
            int amountOfPlacedBet = Convert.ToInt32(Console.ReadLine());
            return amountOfPlacedBet;
        }
        /// <summary>
        /// Tells the player to choose a line and all the options. Creates a string variable 
        /// with the input and returns it.
        /// </summary>
        /// <returns>Player's line choice(s) as a string.</returns>
        public static string ChooseALine()
        {
            Console.WriteLine("Choose a Line!");
            Console.WriteLine("For rows choose: 1, 2, or 3");
            Console.WriteLine("For columns choose: a, b, or c");
            Console.WriteLine("For diagonals choose: 1a or 1c");
            Console.WriteLine("Please separate inputs by a space.");
            string chosenLine = Console.ReadLine();
            return chosenLine;
        }
        /// <summary>
        /// Displays slot grid array with numbers/letters to use as reference for 
        /// choosing a line.
        /// </summary>
        /// <param name="array">A [3,3] array to be displayed.</param>
        public static void DisplaySlots(int[,] array)
        {
            Console.Clear();
            //   array = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
            Console.WriteLine("   a b c");
            int listing = 1;
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{listing++}. ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

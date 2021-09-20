using System;

namespace Slot_Machine
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] slotArrayValues = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
            int totalMoney = 30;
            int placedBet = 0;

            bool motivationAndMoney = true;
            while (motivationAndMoney && totalMoney > 0)
            {
                //Asks if they want to continue betting or cashout.
                if (UI.AskToContinue() == false)
                {
                    UI.CashOut(totalMoney);
                    break;
                }
                Console.Clear();

                //Making some visual referencing for userInput to place bets on.
                slotArrayValues = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
                UI.DisplaySlots(slotArrayValues);

                
                Console.WriteLine("Choose a Line!");
                string inputPosition = Console.ReadLine();
                Console.Clear();

                //Checks to see if theres enough money to make that bet
                //and that the user doesnt enter a huge amount that they dont have, making the program crash later.

                bool enoughMoney = false;
                while (!enoughMoney)
                {
                    Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on that line?");//TODO add a limiter 
                    placedBet = Convert.ToInt32(Console.ReadLine());
                    if ((totalMoney - placedBet) >= 0)
                    {
                        enoughMoney = true;
                        totalMoney -= placedBet;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Please stay within your limit.");
                    }

                }

                //looping through and adding random numbers to each position in array then displaying it. 
                RandomNumsIntoArray(slotArrayValues);
                UI.DisplaySlots(slotArrayValues);

                bool matchingValues = IsWinningSlot(inputPosition, slotArrayValues);

                if (matchingValues)
                {
                    totalMoney += placedBet * 2;
                    Console.WriteLine("You Win! =)");
                    Console.WriteLine($"You have ${totalMoney}!");
                }
                if (!matchingValues)
                {
                    Console.WriteLine($"You Lose, you have ${totalMoney}.");
                }

            }
            if (totalMoney <= 0)
            {
                Console.WriteLine("You ran out of money =(");
            }

            //****TODO: later on embed these next statements in a while loop, while they have money left to bet and
            //while they wanna keep on playing. Try to figure out if you can automatically make
            //new varibles/names with those bets and lines to reference and check them later.
            //Or if somehow you can add a loop and reuse some premade variables for InputPosition/PlacedBet, or add a limit.****

            //user starts with $3. Gets asked what they want to bet on and how much on each.
            //TODO: make functions as flexible as posible so placing jagged bets wont be an issue.
        }
        /// <summary>
        /// Takes in a 2D array and loops through it replacing/adding 0-2 numbers randomly.
        /// </summary>
        /// <param name="slotArrayValues">2D array to be filled up with random numbers.</param>
        /// <returns>Same array with randomly chosen numbers</returns>
        static int[,] RandomNumsIntoArray(int[,] slotArrayValues)
        {
            Random rng = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int randomthreeNums = rng.Next(0, 3);
                    slotArrayValues[i, j] = randomthreeNums;
                }
            }
            return slotArrayValues;
        }

        /// <summary>
        /// Checks for matching diagonal values (diagonally ascending)
        /// </summary>
        /// <param name="twoDArray">The 2D array being looped through and compared</param>
        /// <returns>Boolean</returns>
        static bool AscendingDiagonalTracker(int[,] twoDArray)
        {
            for (int i = 0; i < twoDArray.GetLength(0); i++)
            {
                if (twoDArray[0, 2] != twoDArray[i, (2-i)])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks for matching diagonal values (diagonally descending)
        /// </summary>
        /// <param name="twoDArray">The 2D array being looped through and compared</param>
        /// <returns>Boolean</returns>
        static bool DescendingDiagonalTracker(int[,] twoDArray)
        {
            for (int i = 0; i < twoDArray.GetLength(0); i++)
            {
                if (twoDArray[0, 0] != twoDArray[i, i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks to see if an array within a 2D array contains matching values (Horizontally) 
        /// </summary>
        /// <param name="linePosition">The rank position to be looped through and compared</param>
        /// <param name="twoDArray">The 2D array being looped through</param>
        /// <returns>Boolean</returns>
        static bool HorizontalTracker(int linePosition, int[,] twoDArray)
        {
            for (int i = 0; i < twoDArray.GetLength(1); i++)
            {
                if (twoDArray[linePosition, 0] != twoDArray[linePosition, i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks to see if an array within a 2D array contains matching values (vertically)
        /// </summary>
        /// <param name="linePosition">The rank position to be looped through and compared</param>
        /// <param name="twoDArray">The 2D array being looped through</param>
        /// <returns>Boolean</returns>
        static bool VerticalTracker(int linePosition, int[,] twoDArray)
        {
            for (int i = 0; i < twoDArray.GetLength(0); i++)
            {
                if (twoDArray[0, linePosition] != twoDArray[i, linePosition])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks to see if the player's choice has  matching values.
        /// </summary>
        /// <param name="inputPosition">player's input position from the graph</param>
        /// <param name="twoDArray">The 2D array being looped through</param>
        /// <returns>Boolean</returns>
        static bool IsWinningSlot(string inputPosition, int[,] twoDArray)
        {
            switch(inputPosition)
            {
                case "1":
                    return HorizontalTracker(0, twoDArray);
                case "2":
                    return HorizontalTracker(1, twoDArray);
                case "3":
                    return HorizontalTracker(2, twoDArray);
                case "a":
                    return VerticalTracker(0, twoDArray);
                case "b":
                    return VerticalTracker(1, twoDArray);
                case "c":
                    return VerticalTracker(2, twoDArray);
                case "1a":
                case "a1": 
                    return AscendingDiagonalTracker(twoDArray);
                case "1c":
                case "c1":
                    return DescendingDiagonalTracker(twoDArray);
                default:
                    return false;
            }
        }

    }
}

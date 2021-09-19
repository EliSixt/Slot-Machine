using System;

namespace Slot_Machine
{
    class Program
    {
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
                    return HorizontalTracker(0, twoDArray);
                case "1a":
                case "a1": 
                    return AscendingDiagonalTracker(twoDArray);

                default:
                    return false;
            }

            //Checking values of horizontal slot, returning bool
            if (inputPosition == "1")
            {
                return HorizontalTracker(0, twoDArray);
            }
            if (inputPosition == "2")
            {
                return HorizontalTracker(1, twoDArray);
            }
            if (inputPosition == "3")
            {
                return HorizontalTracker(2, twoDArray);
            }
            //Checking values of vertical slot, returning bool
            if (inputPosition == "a")
            {
                return VerticalTracker(0, twoDArray);
            }
            if (inputPosition == "b")
            {
                return VerticalTracker(1, twoDArray);
            }
            if (inputPosition == "c")
            {
                return VerticalTracker(2, twoDArray);
            }
            //Checking values of ascending diagonal, returning bool 
            if (inputPosition == "a1" || inputPosition == "1a" || inputPosition == "3c" || inputPosition == "c3")
            {
                return AscendingDiagonalTracker(twoDArray);
            }
            //Checking values of descending diagonal, returning bool 
            if (inputPosition == "1c" || inputPosition == "c1" || inputPosition == "3a" || inputPosition == "a3")
            {
                return DescendingDiagonalTracker(twoDArray);
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int[,] slotArrayValues = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
            int totalMoney = 30;
            int placedBet = 0;

            bool motivationAndMoney = true;
            while (motivationAndMoney && totalMoney > 0)
            {
                Console.WriteLine("Do you wanna make a bet? yes/no");
                string yesOrNoAnswer = Convert.ToString(Console.ReadLine());
                if (yesOrNoAnswer == "no")
                {
                    Console.Clear();
                    Console.WriteLine($"Your cashout is ${totalMoney}!");
                    break;
                }
                Console.Clear();

                //Making some visual referencing for userInput to place bets on.
                slotArrayValues = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
                UI.DisplaySlots(slotArrayValues);

                
                Console.WriteLine("Choose a Line!");//Fixed on center horizontal line while making changes all around first.
                string inputPosition = Convert.ToString(Console.ReadLine());
                //int slotPosition = InputConverter(inputPosition);
                Console.Clear();

                //Checks to see if theres enough money to make that bet
                //and that the user doesnt enter a huge amount that they dont have, making the program crash later.

                bool creditChecking = true;
                while (creditChecking)
                {
                    Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on that line?");//TODO add a limiter 
                    placedBet = Convert.ToInt32(Console.ReadLine());
                    if ((totalMoney - placedBet) >= 0)
                    {
                        creditChecking = false;
                        totalMoney -= placedBet;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Please stay within your limit.");
                    }

                }


                //looping through and adding random numbers to each position in array then displaying it. 

                Random rng = new Random();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int randomthreeNums = rng.Next(1, 4);
                        slotArrayValues[i, j] = randomthreeNums;
                    }
                }

                Console.WriteLine("   a b c");
                int listing = 1;
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{listing++}. ");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(slotArrayValues[i, j] + " ");
                    }
                    Console.WriteLine();
                }

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


    }
}

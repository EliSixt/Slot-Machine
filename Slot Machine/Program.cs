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

            while (totalMoney > 0)
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

                string inputPosition = UI.ChooseALine();

                //TODO:Need the option of all horzontal lines, all diagonal lines, or all vertical lines.
                //run a loop through the string inputPosition and add each position coordinate (condition separated by a space) to a List<string>
                //Then run each item in the list through the existing program and return a winning display if TotalMoney changed.

                string[] betPlacedSlotPostions = inputPosition.Split(' ');
                foreach (var betPlaced in betPlacedSlotPostions)
                {

                    //run the existing methods here so that they will return true/false foreach betPlaced and change totalMoney.
                }
                //display result based on totalMoney going up or down 



                //Checks to see if theres enough money to make that bet
                //and that the user doesnt enter a huge amount that they dont have, making the program crash later.
                placedBet = confirmingPlacedBet(totalMoney, placedBet);
                totalMoney -= placedBet;

                //looping through and adding random numbers to each position in array then displaying it. 
                RandomNumsIntoArray(slotArrayValues);

                UI.DisplaySlots(slotArrayValues);

                //Checking if player's choice has all matching values
                bool matchingValues = IsWinningSlot(inputPosition, slotArrayValues);

                //checks to see if the matchingValues is true/false and returns the winning results or losing consequences 
                totalMoney = WinningResult(matchingValues, placedBet, totalMoney);
            }
            if (totalMoney <= 0)
            {
                Console.WriteLine("You ran out of money =(");
            }
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
                if (twoDArray[0, 2] != twoDArray[i, (2 - i)])
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
        /// Confirms if theres enough money to make that bet and that the user doesnt enter a huge amount that they dont have.
        /// </summary>
        /// <param name="totalMoney">The total amount of money.</param>
        /// <param name="placedBet">Player's money bet.</param>
        /// <returns>placedBet</returns>
        static int confirmingPlacedBet(int totalMoney, int placedBet)
        {
            bool enoughMoney = false;
            while (!enoughMoney)
            {
                Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on that line?");//TODO add a limiter 
                placedBet = Convert.ToInt32(Console.ReadLine());
                if ((totalMoney - placedBet) >= 0)
                {
                    enoughMoney = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please stay within your limit.");
                }
            }
            return placedBet;
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
            switch (inputPosition)
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
                case "1c":
                case "c1":
                    return AscendingDiagonalTracker(twoDArray);
                case "1a":
                case "a1":
                    return DescendingDiagonalTracker(twoDArray);
                default:
                    return false;
            }
        }
        /// <summary>
        /// Checks to see if the matchingValues is true/false and returns the winning display and totalMoney plus the placedBet multiplier.
        /// Else it returns the losing display, totalMoney is unchanged.
        /// </summary>
        /// <param name="matchingValues">A variable result that checks to see if the player's choice has matching values.</param>
        /// <param name="placedBet">Player's money bet.</param>
        /// <param name="totalMoney">The total amount of money.</param>
        /// <returns></returns>
        static int WinningResult(bool matchingValues, int placedBet, int totalMoney)
        {

            if (matchingValues)
            {
                totalMoney += placedBet * 2;
                Console.WriteLine("You Win! =)");
                Console.WriteLine($"You have ${totalMoney}!");
            }
            else
            {
                Console.WriteLine($"You Lose, you have ${totalMoney}.");
            }
            return totalMoney;
        }
    }
}

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
                UI.ClearConsole();

                //Making some visual referencing for userInput to place bets on.
                slotArrayValues = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
                UI.DisplaySlots(slotArrayValues);


                //TODO:Need the option of all horzontal lines, all diagonal lines, or all vertical lines.
                //display result based on totalMoney going up or down 

                //Takes the input from the player's choices and places it into a string array based on a space separator.
                string inputPosition = UI.ChooseALine();
                string[] betPlaceSlotPostions = inputPosition.Split(' ');

                //Assigns bet from player's input.
                //Checks to see if theres enough money to make that bet, else it asks until a valid entry is accepted.
                //Subtracts confirmed bet from total money.
                placedBet = UI.GetPlacedBet(totalMoney);
                placedBet = ConfirmingPlacedBet(totalMoney, placedBet, betPlaceSlotPostions);
                totalMoney -= placedBet * betPlaceSlotPostions.Length;

                //Creates a random grid array for the slots then displays it. 
                slotArrayValues = GetRandomGrid();
                UI.DisplaySlots(slotArrayValues);

                //run the existing methods here so that they will return true/false foreach betPlaced and change totalMoney.
                foreach (var betPlace in betPlaceSlotPostions)
                {
                    //Checking if player's choices has all matching values
                    bool matchingValues = IsWinningSlot(betPlace, slotArrayValues);

                    //checks to see if the matchingValues is true/false and returns the winning results to totalMoney or losing consequences 
                    totalMoney = WinningResult(matchingValues, placedBet, totalMoney, betPlace);
                }
            }
            if (totalMoney <= 0)
            {
                UI.GameOver();
            }
        }
        /// <summary>
        /// Creates a random grid [3,3], with numbers 0-2, then returns it.
        /// </summary>
        /// <returns>Array with randomly chosen numbers</returns>
        static int[,] GetRandomGrid()
        {
            Random rng = new Random();
            int[,] randomGrid = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int randomthreeNums = rng.Next(0, 3);
                    randomGrid[i, j] = randomthreeNums;
                }
            }
            return randomGrid;
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
        /// Confirms if theres enough money to make that bet (by multiplying number of bets by the placedBet and subtracting it from the total) 
        /// so that the user doesnt enter a huge amount that they dont have.
        /// </summary>
        /// <param name="totalMoney">The total amount of money.</param>
        /// <param name="bet">Player's money bet.</param>
        /// <param name="betPlacedSlotPositions">A string array of all the slot-positions bets.</param>
        /// <returns>Confirmed bet within the total money limits.</returns>
        static int ConfirmingPlacedBet(int totalMoney, int bet, string[] betPlacedSlotPositions)
        {
            //int amountOfPlacedBet = placedBet;
            bool enoughMoney = false;
            while (!enoughMoney)
            {
                //placedBet;
                //amountOfPlacedBet = UI.GetPlacedBet(totalMoney);
                if ((totalMoney >= (betPlacedSlotPositions.Length * bet)))
                {
                    //Console.Clear();
                    enoughMoney = true;
                    //return true;
                }
                else
                {
                    //Console.WriteLine("Please stay within your limit.");
                    bet = UI.GetPlacedBet(totalMoney);
                }
            }
            return bet;
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
        /// <param name="matchingValues">A boolean result that checks to see if the player's choice has matching values.</param>
        /// <param name="placedBet">Player's money bet.</param>
        /// <param name="totalMoney">The total amount of money.</param>
        /// <param name="theLinePosition">The line/slot position being referenced.</param>
        /// <returns>The losing display || The winning display and totalMoney plus the winning multiplier.</returns>
        static int WinningResult(bool matchingValues, int placedBet, int totalMoney, string theLinePosition)
        {

            if (matchingValues)
            {
                totalMoney += placedBet * 2;
                UI.WonBet(theLinePosition, totalMoney);
            }
            else
            {
                UI.LostBet(theLinePosition);
            }
            return totalMoney;
        }
    }
}

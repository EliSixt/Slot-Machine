using System;

namespace Slot_Machine
{
    class Program
    {
        /// <summary>
        /// Checks to see if an array within a 2D array contains matching value (Horizontally) 
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
        static void Main(string[] args)
        {
            int[,] slotArrayValues = new int[3, 3] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
            int totalMoney = 3;
            int firstPlacedBet = 0;
            //int secondPlacedBet = 0;

            //Making some sort of referencing for userInput to place bets on.

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

            Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on the center line?");
            firstPlacedBet = Convert.ToInt32(Console.ReadLine());
            totalMoney -= firstPlacedBet;
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
            listing = 1;
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{listing++}. ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(slotArrayValues[i, j] + " ");
                }
                Console.WriteLine();
            }

            if(HorizontalTracker(1, slotArrayValues))
            {
                totalMoney += firstPlacedBet * 2;
                Console.WriteLine("You Win! =)");
            }
            else
            {
                Console.WriteLine($"You Lose, your total is ${totalMoney}.");
            }


            //****TODO: later on embed these next statements in a while loop, while they have money left to bet and
            //while they wanna keep on playing. Try to figure out if you can automatically make
            //new varibles/names with those bets and lines to reference and check them later.
            //Or if somehow you can add a loop and reuse some premade variables for InputPosition/PlacedBet, or add a limit.****

            //user starts with $3. Gets asked what they want to bet on and how much on each.
            //TODO: make functions as flexible as posible so placing jagged bets wont be an issue.

            //Console.WriteLine("Choose a Line!");
            //Console.WriteLine("Ex: 1 is a row, a is a column, 1a is diagonal line");
            //string firstLinePosition = Convert.ToString(Console.ReadLine());
            //Console.Clear();


            //bool creditChecking = true;
            //while (creditChecking)
            //{
            //    Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on that line?");//TODO add a limiter 
            //    firstPlacedBet = Convert.ToInt32(Console.ReadLine());
            //    if ((totalMoney - firstPlacedBet) >= 0)
            //    {
            //        creditChecking = false;
            //        totalMoney -= firstPlacedBet;
            //        Console.Clear();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please stay within your limit.");
            //    }

            //}

            ////Console.WriteLine("You have $3 in total. How many dollars do you wanna bet on that line?");
            ////firstPlacedBet += Convert.ToInt32(Console.ReadLine());
            ////totalMoney -= firstPlacedBet;
            ////Console.Clear();


            ////Add the option of a third bet?

            //if (totalMoney > 0)
            //{
            //    Console.WriteLine("Do you wanna make another bet? yes/no");
            //    string yesNoAnswerOnBet = Convert.ToString(Console.ReadLine());
            //    Console.Clear();

            //    if (yesNoAnswerOnBet == "yes")
            //    {
            //        //displaying the grid
            //        Console.WriteLine("   a b c");
            //        listing = 1;
            //        for (int i = 0; i < 3; i++)
            //        {
            //            Console.Write($"{listing++}. ");
            //            for (int j = 0; j < 3; j++)
            //            {
            //                Console.Write(slotArrayValues[i, j] + " ");
            //            }
            //            Console.WriteLine();
            //        }

            //        Console.WriteLine("Choose a Line!");//TODO: make sure they arent choosing the same line, temprary fix is to just add it on the PlacedBet
            //        string secondInputPosition = Convert.ToString(Console.ReadLine());
            //        Console.Clear();

            //        //checking to see that the user doesnt enter a huge amount that they dont have, making the program crash later.
            //        creditChecking = true;
            //        while (creditChecking)
            //        {
            //            Console.WriteLine($"You have ${totalMoney} in total. How many dollars do you wanna bet on that line?");//TODO add a limiter 
            //            secondPlacedBet = Convert.ToInt32(Console.ReadLine());
            //            if ((totalMoney - secondPlacedBet) >= 0)
            //            {
            //                creditChecking = false;
            //                totalMoney -= secondPlacedBet;
            //                Console.Clear();
            //            }
            //            else
            //            {
            //                Console.WriteLine("Please stay within your limit.");
            //            }

            //        }
            //    }
            //}



            ////looping through and adding random numbers to each position in array then displaying it. 

            //Random rng = new Random();
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        int randomthreeNums = rng.Next(1, 4);
            //        slotArrayValues[i, j] = randomthreeNums;
            //    }
            //}

            //Console.WriteLine("   a b c");
            //listing = 1;
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.Write($"{listing++}. ");
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write(slotArrayValues[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}


            //int x = 0;
            //bool matchingTracker = true;
            ////checking in a row
            //if (firstLinePosition == "2")
            //{
            //    x = 1;

            //    //broken but potential idea for a reusable function
            //    for (int i = 0; i < 3; i++)
            //    {
            //        if (slotArrayValues[x, 0] != slotArrayValues[x, i])
            //        {
            //            matchingTracker = false;
            //        }

            //    }
            //    if (matchingTracker)
            //    {
            //        totalMoney += firstPlacedBet * 2;
            //    }
            //}
        }

        
    }
}

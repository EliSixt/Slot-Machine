using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class UI
    {
        public static void CashOut(int totalMoney)
        {
            Console.Clear();
            Console.WriteLine($"Your cashout is ${totalMoney}!");
        }
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
        public static int WinningResult(bool matchingValues, int placedBet, int totalMoney)
        {

            if (matchingValues)
            {
                Console.WriteLine("You Win! =)");
                Console.WriteLine($"You have ${totalMoney}!");
                return totalMoney += placedBet * 2;
            }
            else
            {
                Console.WriteLine($"You Lose, you have ${totalMoney}.");
                return totalMoney;
            }
        }
        public static string ChooseALine()
        {
            Console.WriteLine("Choose a Line!");
            Console.WriteLine("Ex: 1, 2, 3 or a, b, c or 1a, 1c");
            string chosenLine = Console.ReadLine();
            return chosenLine;
        }
        public static void DisplaySlots(int[,] array)
        {
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

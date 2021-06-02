using System;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RpsChoice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }
        static void Main(string[] args)
        {
            string replayAnswer = "";
            //do while loop for replaying game
            do
            {
                //variables
                bool successfulConversion;
                int playerChoiceInt = -1;
                int wins = 0;
                int loses = 0;
                int round = 1;

                //get user name
                Console.WriteLine("Welcome to Rock-Paper-Scissors!\nPlease enter your name");
                string userName = Console.ReadLine();
                //loop for 3 rounds or until winner decided
                do
                {
                    //loop to get valid input
                    do
                    {
                        Console.WriteLine("1. Rock\n2. Paper\n3. Scissors\nPlease enter a number:");
                        string playerChoice = Console.ReadLine();
                        successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                        if (!successfulConversion)
                        {
                            //not an integer
                            Console.WriteLine($"Error: {playerChoice} is not a valid option.");
                        }
                        else if (playerChoiceInt > 3 || playerChoiceInt < 1)
                        {
                            //if  integer not in range
                            Console.WriteLine($"Error: {playerChoiceInt} is not within range.");
                        }

                    } while (playerChoiceInt < 1 || playerChoiceInt > 3);

                    //get computer choice
                    Random rand = new Random();
                    int computerChoice = rand.Next(1, 4);
                    Console.WriteLine($"The computer's choice is {computerChoice}");
                    Console.WriteLine($"The Player's choice is {playerChoiceInt}");

                    //determine winner
                    if (playerChoiceInt == computerChoice)
                    {
                        //tie
                        Console.WriteLine("Tie game!");
                    }
                    else if ((playerChoiceInt == 3 && computerChoice == 1) || (playerChoiceInt == 2 && computerChoice == 3) || (playerChoiceInt == 1 && computerChoice == 2))
                    {
                        //comp wins
                        Console.WriteLine($"Computer wins! {(RpsChoice)computerChoice} beats {(RpsChoice)playerChoiceInt}!");
                        loses++;
                    }
                    else
                    {
                        //player wins
                        Console.WriteLine($"{userName} wins! {(RpsChoice)playerChoiceInt} beats {(RpsChoice)computerChoice}!");
                        wins++;
                    }
                    round++;
                } while ((wins < 2 && loses < 2) && round <= 3); //continue loop until winner decided or 3 rounds passed
                //display winner
                if (wins == 2 || wins > loses)
                {
                    Console.WriteLine($"{userName} wins the game!");
                }
                else if (loses == 2 || loses > wins)
                {
                    Console.WriteLine("Computer wins the game!");
                }
                else if (wins == loses)
                {
                    Console.WriteLine("Tie game!");
                }
                Console.WriteLine($"Score: {userName} {wins}, Computer {loses}");
                //prompt to replay
                Console.WriteLine("Play again? Y/N:");
                //convert answer to lower case to compare
                replayAnswer = Console.ReadLine().ToLower();
            } while (replayAnswer == "y");
        }
    }
}
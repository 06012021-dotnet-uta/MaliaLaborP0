using System;

namespace RockPaperScissors1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Examples
            //PersonBaseClass personBaseClass1 = new PersonBaseClass();
            //PersonBaseClass personBaseClass2 = new PersonBaseClass("Malia","Labor");
            //PlayerDerivedClass player1 = new PlayerDerivedClass();
            //PlayerDerivedClass player2 = new PlayerDerivedClass("", "");
            // player1.MyCountry = "'Merica";
            // player1.MyAge = 28;
            // player1.City = "Tucson";
            // player1.State = "Arizona";
            // player1.Street = "123 w. Broadway";
            // player1.fName = "Malia";
            // player1.lName = "Labor";
            // string fullAddress = player1.GetFullAddress();
            // Console.WriteLine(fullAddress);

            //variables
            string replayAnswer = "";
            RpsGame rpsGame = new RpsGame();
            PlayerDerivedClass player1 = new PlayerDerivedClass();
            PlayerDerivedClass computer = new PlayerDerivedClass("Hal", "9000");
            //get user name
            Console.WriteLine(rpsGame.NamePrompt("first"));
            player1.FName = rpsGame.GetPlayerName(Console.ReadLine());
            Console.WriteLine(rpsGame.NamePrompt("last"));
            player1.LName = rpsGame.GetPlayerName(Console.ReadLine());
            //do while loop for replaying game
            do
            {
                //reset wins if game is replayed
                player1.Wins = 0;
                computer.Wins = 0;
                //variables
                int round = 1;
                bool validInput = false;
                Console.WriteLine(rpsGame.WelcomeMessage());
                //loop for 3 rounds or until winner decided
                do
                {
                    do
                    {
                        Console.WriteLine(rpsGame.RulesMessage());
                        validInput = rpsGame.GetPlayerChoice(Console.ReadLine(), player1);
                    } while (validInput == false);
                    //get computer choice
                    rpsGame.GetCompChoice(computer);
                    //determine round winner
                    Console.WriteLine(rpsGame.DetermineRoundWinner(player1, computer));
                    //increment round
                    round++;
                } while ((player1.Wins < 2 && computer.Wins < 2) && round <= 3); //continue loop until winner decided or 3 rounds passed
                //display game winner
                Console.WriteLine(rpsGame.DetermineGameWinner(player1, computer));
                //loop to get valid input for replay
                do
                {
                    //prompt to replay
                    Console.WriteLine(rpsGame.ReplayPrompt());
                    //format answer from console read
                    replayAnswer = rpsGame.ReplayAnswer(Console.ReadLine());
                } while (replayAnswer == "");
            } while (replayAnswer == "y");
        }
    }
}
using System;

namespace RockPaperScissors1
{
    public class RpsGame
    {
        public string NamePrompt(string nameType)
        {
            string message = $"Please enter your {nameType} name:";
            return message;
        }
        //returns welcome message string
        public string WelcomeMessage()
        {
            string welcome = "Welcome to Rock Paper Scissors!";
            return welcome;
        }
        //returns string with rules
        public string RulesMessage()
        {
            string rules = "1. Rock\n2. Paper\n3. Scissors\nPlease enter a number:";
            return rules;
        }
        //process user input for choice, returns true if input was valid, false if not valid
        public bool GetPlayerChoice(string playerInput, PlayerDerivedClass player) //returns bool, true if valid, false if not valid
        {
            bool successfulConversion;
            int playerChoiceInt;
            successfulConversion = Int32.TryParse(playerInput, out playerChoiceInt);
            if (!successfulConversion)
            {
                return false;
            }
            else if (playerChoiceInt > 3 || playerChoiceInt < 1)
            {
                return false;
            }
            else
            {
                player.Choice = playerChoiceInt;
                return true;
            }
        }
        //get computer choice, returns int
        public int GetCompChoice(PlayerDerivedClass computer)
        {
            Random rand = new Random();
            int computerChoice = rand.Next(1, 4);
            computer.Choice = computerChoice;
            return computerChoice;
        }
        //determine round winner, returns string that displays winner of round
        public string DetermineRoundWinner(PlayerDerivedClass player1, PlayerDerivedClass computer)
        {
            if (player1.Choice == computer.Choice)
            {
                //tie
                return "Tie round!";
            }
            else if ((player1.Choice == 3 && computer.Choice == 1) || (player1.Choice == 2 && computer.Choice == 3) || (player1.Choice == 1 && computer.Choice == 2))
            {
                //comp wins
                computer.Wins++;
                return $"{computer.FName} wins! {computer.Choice} beats {player1.Choice}";
            }
            else
            {
                //player wins
                player1.Wins++;
                return $"{player1.FName} wins! {player1.Choice} beats {computer.Choice}";
            }
        }
        //determine game winner, returns formatted string that displays winner
        public string DetermineGameWinner(PlayerDerivedClass player1, PlayerDerivedClass computer)
        {
            string returnString = "";
            if (player1.Wins == 2 || player1.Wins > computer.Wins)
            {
                returnString += $"{player1.FName} wins the game!";
            }
            else if (computer.Wins == 2 || computer.Wins > player1.Wins)
            {
                returnString += $"{computer.FName} wins the game!";
            }
            else if (player1.Wins == computer.Wins)
            {
                returnString += "Tie game!";
            }
            returnString += $"\nScore: {player1.FName}: {player1.Wins}, {computer.FName}: {computer.Wins}";
            return returnString;
        }
        //replay prompt
        public string ReplayPrompt()
        {
            string prompt = "Play again? Y/N";
            return prompt;
        }
        //process replay answer, returns formatted answer if y or n
        public string ReplayAnswer(string answer)
        {
            string formattedAnswer = answer.Trim().ToLower();
            if (formattedAnswer == "y" || formattedAnswer == "n")
                return formattedAnswer;
            else 
                return "";
        }
        //returns string if name is valid length
        public string GetPlayerName(string playerInput)
        {
            string name = playerInput.Trim();
            if (name.Length > 20 || name.Length < 1) //if name too long or too short
                return null;
            return name; //return name if valid
        }
    }
}
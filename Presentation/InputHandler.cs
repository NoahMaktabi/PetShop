using System;

/*
 * This class is designed to contain helper methods to be used by other classes.
 * The class is static and cannot be instantiated, all methods are also static. 
 * GetAge() asks the user for age and then parse it into int.
 * GetId() asks the user to provide the Id of the animal that is being sold. 
 * GetString() asks the user for a string input provided a predicate. 
 * GetBoolValue() gets a bool value from user via a Y or N question. The user should provide a message to be presented to the user. 
 * GetCapitalInfoFromUser() gets capital info from the user that is then saved into Capital in AnimalShop. The capital is parsed into decimal. 
 * GetDecimalFromUserInput() gets price info from user. The price is parsed into decimal.
 *
 */



namespace Presentation
{
    public static class InputHandler 
    {
        public static int GetAge()
        {
            Console.Clear();
            const string msgToUser = "Please enter the age of the pet.";
            const string invalidMsg = "Incorrect input. Please enter a number between 1 and 100";
            return InputHandler.GetIntFromUserInput(msgToUser, invalidMsg, 1, 100);
        }


        public static int GetId(int minId, int maxId)
        {
            const string msgToUser = "Type the id of the pet you want to sell";
            var invalidMsg = $"Incorrect input. Please enter a number between {minId} and {maxId}. Choose from the list above!";
            return InputHandler.GetIntFromUserInput(msgToUser, invalidMsg, minId, maxId);
        }

        /// <summary>
        /// Print out Please enter the {predicate} of the pet to console and asks for a string
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>string from console ReadLine</returns>
        public static string GetString(string predicate)
        {
            Console.Clear();
            Console.WriteLine($"Please enter the {predicate} of the pet");
            Console.CursorVisible = true;
            var str = Console.ReadLine();
            Console.CursorVisible = false;
            return str;
        }


        /// <summary>
        /// Get boolean value from user by asking for Y or N input.
        /// You have to provide a msg to show the user, ex. Is your pet insured?
        /// </summary>
        /// <param name="message"></param>
        /// <param name="clearConsole"></param>
        /// <returns>Boolean value</returns>
        public static bool GetBoolValue(string message, bool clearConsole = true)
        {
            if (clearConsole)
                Console.Clear();

            Console.WriteLine(message);
            Console.WriteLine("Please press Y or N for yes or no.");
            var keyPressed = Console.ReadKey(true);

            while ((keyPressed.Key != ConsoleKey.Y) && (keyPressed.Key != ConsoleKey.N))
            {
                Console.WriteLine(message);
                Console.WriteLine("Please press Y or N for yes or no.");
                keyPressed = Console.ReadKey(true);
            }

            return keyPressed.Key == ConsoleKey.Y;
        }

        public static decimal GetCapitalInfoFromUser()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Console.WindowHeight = 50;
#pragma warning restore CA1416 // Validate platform compatibility
            const string msgToUser = "PetShop program har started...\nEnter your start capital to proceed to shop.\nMinimum is 10000 kr";
            var invalidMsg = "You did not enter a number or the number is less than 10000";
            var capital = InputHandler.GetDecimalFromUserInput(msgToUser, invalidMsg, 10000, decimal.MaxValue);
            return capital;
        }

        public static decimal GetPriceInfoFromUser(string predicate, decimal min = 1)
        {
            Console.Clear();
            var msgToUser =
                $"What is the {predicate} price?";
            var invalidMsg = "You did not enter a number or the number is less than 0";
            invalidMsg = (min > 1)
                ? $"You did not enter a number or the number is less than the purchase price {min}."
                : invalidMsg;

            var price = InputHandler.GetDecimalFromUserInput(msgToUser, invalidMsg, min, decimal.MaxValue);
            return price;
        }


        /// <summary>
        /// Writes msgToUser, then request input from user,
        /// then converts input into decimal,
        /// checks that decimal is between or equals min and max before returning.
        /// invalidMsg must be provided in case the user types wrong input
        /// </summary>
        /// <param name="msgToUser">Msg to write to user before asking for input. Ex: Type your age,</param>
        /// <param name="invalidMsg">Msg to provide in case the input is not a number or not inside the min/max param</param>
        /// <param name="min">Minimum number allowed</param>
        /// <param name="max">Maximum number allowed</param>
        /// <returns>Valid decimal from the criteria defined in the parameters</returns>
        public static decimal GetDecimalFromUserInput(string msgToUser, string invalidMsg, decimal min, decimal max)
        {
            Console.WriteLine(msgToUser);
            Console.CursorVisible = true;
            var input = Console.ReadLine();
            var success = decimal.TryParse(input, out var number);
            while (!success || !ValidDecimal(number, min, max))
            {
                Console.WriteLine(invalidMsg);
                input = Console.ReadLine();
                success = decimal.TryParse(input, out number);
            }
            Console.CursorVisible = false;
            return number;
        }

        private static bool ValidDecimal(decimal number, decimal min, decimal max)
        {
            return number >= min && number <= max;
        }


        /// <summary>
        /// Writes msgToUser, then request input from user,
        /// then converts input into int,
        /// checks that int is between or equals min and max before returning.
        /// invalidMsg must be provided in case the user types wrong input
        /// </summary>
        /// <param name="msgToUser">Msg to write to user before asking for input. Ex: Type your age,</param>
        /// <param name="invalidMsg">Msg to provide in case the input is not a number or not inside the min/max param</param>
        /// <param name="min">Minimum number allowed</param>
        /// <param name="max">Maximum number allowed</param>
        /// <returns>Valid int from the criteria defined in the parameters</returns>
        public static int GetIntFromUserInput(string msgToUser, string invalidMsg, int min, int max)
        {
            Console.WriteLine(msgToUser);
            Console.CursorVisible = true;
            var input = Console.ReadLine();
            var success = int.TryParse(input, out var number);
            while (!success || !ValidInt(number, min, max))
            {
                Console.WriteLine(invalidMsg);
                input = Console.ReadLine();
                success = int.TryParse(input, out number);
            }
            Console.CursorVisible = false;
            return number;
        }

        private static bool ValidInt(int number, int min, int max)
        {
            return number >= min && number <= max;
        }


    }
}

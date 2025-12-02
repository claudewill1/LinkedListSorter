using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace LinkedListSorter.App.Utilities
{
    /// <summary>
    /// Provides helper methods for reading, validating, and converting input
    /// values used by the console application. All methods are unimplemented
    /// and contain pseudocode to guide test-driven development.
    /// </summary>
    public static class InputUtility
    {
        /// <summary>
        /// Reads an integer from console input and validates the result.
        /// </summary>
        /// <returns>An integer value entered by the user.</returns>
        public static int ReadInt()
        {
            
            while (true)
            {
               string? input = Console.ReadLine();
            
                if (input == null)
                    throw new InvalidOperationException("No input received.");

                if (int.TryParse(input, out int result))
                {
                    return result;
                }

                // If parsing fails: print "Invalid input. Please enter a valid integer."
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            
        }

        /// <summary>
        /// Reads a list of integer values separated by spaces or commas.
        /// Used to populate linked lists in bulk.
        /// </summary>
        /// <returns>A list of integer values.</returns>
        public static List<int> ReadIntList()
        {
            // Pseudocode:
            // read a line of input
            string input = Console.ReadLine(); 
            // Handle null input
            if (string.IsNullOrEmpty(input))
                return new List<int>();
            // split input by spaces and commas
            string[] tokens = input.Split(new char[] { ' ', ',' })
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .ToArray();
            // create empty list of ints
            List<int> resultList = new List<int>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int value))
                {
                    resultList.Add(value);
                }
                else
                {
                    // Optionally print warning about invalid token
                    Console.WriteLine($"Warning: '{token}' is not a valid integer and will be ignored.");

                }
            }
            return resultList;
            
        }

        /// <summary>
        /// Reads a single menu choice and validates against a set of allowed options.
        /// </summary>
        /// <param name="validOptions">Characters that are accepted as valid.</param>
        /// <returns>The user-selected menu character.</returns>
        public static char ReadMenuChoice(HashSet<char> validOptions)
        {
            // Pseudocode:
            while (true)
            {
                // Read a single key from Console.ReadKey() intercept: true prevents key from being printed to console while still returning key pressed
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                // Convert to lowercase
                char key = char.ToLower(keyInfo.KeyChar);

                // If key is in validOptions:
                if (validOptions.Contains(key))
                {
                    return key;
                }
                // Otherwise: display invalid choice message
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            
        }

        /// <summary>
        /// Reads a boolean choice, typically Y/N.
        /// </summary>
        /// <returns>True for yes, false for no.</returns>
        public static bool ReadYesNo()
        {
            // Pseudocode:
            // loop:
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                char key = char.ToLower(keyInfo.KeyChar);
                if (key == 'y')
                {
                    return true;
                }
                else if (key == 'n')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter Y or N.");
                }
            }
        }

        /// <summary>
        /// Clears the console and prints a title banner for visual separation.
        /// </summary>
        /// <param name="title">Title text to display.</param>
        public static void PrintBanner(string title)
        {
            // Pseudocode:
            // Console.Clear()
            // print a row of dashes or stars
            // print the title centered or left aligned
            // print another row of dashes
        }

        /// <summary>
        /// Prompts the user with text and reads an integer with validation.
        /// Wrapper around ReadInt with a printed label.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int PromptInt(string prompt)
        {
            // Pseudocode:
            // print the prompt
            // call ReadInt()
            // return the resulting integer
            return 0;
        }

        /// <summary>
        /// Prompts the user and reads a validated menu choice.
        /// </summary>
        public static char PromptMenuChoice(string prompt, HashSet<char> validOptions)
        {
            // Pseudocode:
            // print prompt
            // call ReadMenuChoice(validOptions)
            // return chosen character
            return '\0';
        }

        /// <summary>
        /// Prompts the user and reads a list of integers.
        /// </summary>
        public static List<int> PromptIntList(string prompt)
        {
            // Pseudocode:
            // print prompt
            // call ReadIntList()
            // return the list of integers
            return new List<int>();
        }
    }
}

using System;
using System.Linq;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {

            //Introduce the game to the user.
            Console.WriteLine("Welcome to Yahtzee!\nLet's play.");

            //First, you need to put the dice into an array
            //declare the array 
            //generate a random number between 1 and 6 for each die
            //I don't think you need this random int??
            //The RollTheDice method is called which takes the empty array with 5 ints in it
            //The diceRoll(the spread of 5 randomly numbered dice) generated from the RollTheDice method
            // is assigned the variable of diceRoll (the empty array with 5 positions in it we declared earlier

            //declared this variable to be able to pass in remainingDice needed for subsequent rolls
            //assigned a value of 5 because, initially, 5 dice are needed for the first roll
            int remainingDice = 5;
            int[] diceRolls = RollTheDice(remainingDice);

            //Write the user's first roll
            Console.WriteLine("Your first dice roll is: ");

            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.Write(i + 1 + ": ");
                Console.WriteLine(diceRolls[i]);
            }

            Console.WriteLine("Which dice would you like to keep? Separate the dice numbers with a space, please.");
            //saves the number of the dice the user would like to keep in a string
            string userKeptDice = Console.ReadLine();
            //enters the number of the userKeptDice into a string array and splits them by a space
            string[] userKeptDiceArray = userKeptDice.Split(" ");
            //declares an array of ints that will later contain 
            //array of strings that has been split into an array of integers
            int[] userKeptDiceNumbers = new int[userKeptDiceArray.Length];
            //you have to assign the NUMBER of the dice to the corresponding actual value of each die
            //which would mean the number-1 is the position of that die within the diceRolls array

            //loop through the numbers of the dice (change to position) the user kept
            //and assign them the value of the corresponding int in the diceRolls array (the actual
            //value of the kept dice numbers)
            for (int i = 0; i < userKeptDiceNumbers.Length; i++)
            {
                //take the items (numbers of the dice the user kept (1-5)-which are now strings) 
                //and assign them a position (0-4) - represented by the -1
                int keptDiePosition = int.Parse(userKeptDiceArray[i]) - 1;
                //then assign the item from this position to the item in the position of the diceRolls array
                //and assign these VALUES to the userKeptDiceNUmbers int array that was created earlier
                userKeptDiceNumbers[i] = diceRolls[keptDiePosition];



            }
            //In preparation for the second roll, subtract the number of dice the user kept from the first roll
            //from the 5 total dice that could potentially be rolled on roll # 2
            remainingDice = 5 - userKeptDiceNumbers.Length;

            //an array of random numbers (length of remainingDice) with a value between 1 and 6 (diceRolls - returned from the 
            //RollTheDice method), is assigned to a new int array, secondDiceRolls
             diceRolls = RollTheDice(remainingDice);

            //What does this do?
            //secondDiceRolls.CopyTo(diceRolls, 0);
            //userKeptDiceNumbers.CopyTo(diceRolls, secondDiceRolls.Length);


            Console.WriteLine("Your second dice roll is: ");

            for (int i = 0; i < remainingDice; i++)
            {
                Console.Write(i + 1 + ": ");
                Console.WriteLine(diceRolls[i]);
            }

            Console.WriteLine("Which dice would you like to keep? Separate the dice numbers with a space, please.");
            //saves the number of the dice the user would like to keep in a string
            string userKeptDice2 = Console.ReadLine();
            //enters the number of the userKeptDice2 into a string array and splits them by a space
            string[] userKeptDiceArray2 = userKeptDice2.Split(" ");
            //declares an array of ints that will later contain 
            //array of strings that has been split into an array of integers
            int[] userKeptDiceNumbers2 = new int[userKeptDiceArray2.Length];
            //you have to assign the NUMBER of the dice to the corresponding actual value of each die
            //which would mean the number-1 is the position of that die within the diceRolls array 
            //(from the RollTheDice method)

            //loop through the numbers of the dice (change to position) the user kept from the second roll
            //and assign them the value of the corresponding int in the diceRolls2 array (the actual
            //value of the kept dice numbers)
            for (int i = 0; i < userKeptDiceNumbers2.Length; i++)
            {
                //take the items (numbers of the dice the user kept (1-5)-which are now strings) 
                //and assign them a position (0-4) - represented by the -1
                int keptDiePosition2 = int.Parse(userKeptDiceArray2[i]) - 1;
                //then assign the item from this position to the item in the position of the diceRolls array
                //and assign these VALUES to the userKeptDiceNUmbers int array that was created earlier
                userKeptDiceNumbers2[i] = diceRolls[keptDiePosition2];
            }
            //then, combine userKeptDiceNumbers array from first roll and userKeptDiceNumbers2 array

            int[] combinedUserKeptDiceNumbersArray = userKeptDiceNumbers.Concat(userKeptDiceNumbers2).ToArray();

            //find the number of values/items within these 2 arrays
            //take 5 - this number(new remainingDice?)

            int remainingDice2 = 5 - combinedUserKeptDiceNumbersArray.Length;

            //RollTheDice for the third roll (with the remaining dice that were 
            //heldfrom the first and second roll)
            //an array of random numbers (length of remainingDice) with a value between 1 and 6 (diceRolls - returned from the 
            //RollTheDice method), is assigned to a new int array, secondDiceRolls
            diceRolls = RollTheDice(remainingDice2);
            //thirdDiceRolls.CopyTo(diceRolls, 0);
            //userKeptDiceNumbers2.CopyTo(diceRolls, thirdDiceRolls.Length);

            Console.WriteLine("Your third and final dice roll is: ");

            for (int i = 0; i < remainingDice2; i++)
            {
                Console.Write(i + 1 + ": ");
                Console.WriteLine(diceRolls[i]);
            }
            //concat third dice roll and the combined user kept numbers array
            
            int[]finalCombinedUserKeptDiceNumbersArray = diceRolls.Concat(combinedUserKeptDiceNumbersArray).ToArray();

            
            int playerScore = DuplicateCount(finalCombinedUserKeptDiceNumbersArray);
            Console.WriteLine("Your score is " + playerScore);
           

            int computerHighestScore = 0;
            for (int i = 0; i < 3; i++)
            {
                int[] computerRoll = RollTheDice(5);
                int score = DuplicateCount(computerRoll);
                
                
                if (score > computerHighestScore)
                {
                    computerHighestScore = score;

                }
                
                    
            }
            Console.WriteLine("The computer's score is " + computerHighestScore);

            if (playerScore >= computerHighestScore)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.Write("Computer Wins!");
            }

            Console.ReadLine();
        }


        public static int DuplicateCount(int[] finalCombinedUserKeptDiceNumbersArray)
        {
            //sort the array in order of value so they can be compared
            Array.Sort(finalCombinedUserKeptDiceNumbersArray);
            //assign the current position within final array 
            int currentValue = finalCombinedUserKeptDiceNumbersArray[0];
            int i = 0;
            int currentFrequency = 0;
            int maxScore = 0;

            while (i < finalCombinedUserKeptDiceNumbersArray.Length)
            {
                int currentComparisonValue = currentValue;
                //currentFrequency= the frequency of the current number
                //currentValue is the number within the current position of the final array
                 
                while (currentComparisonValue == currentValue)
                {
                    currentFrequency++;
                    i++;
                    if (i == finalCombinedUserKeptDiceNumbersArray.Length)
                        break;
                    currentValue = finalCombinedUserKeptDiceNumbersArray[i];
                }
                if (currentFrequency > maxScore)
                {
                    //the greatest frequency becomes the maxScore
                    maxScore = currentFrequency;
                }
                //currentFrequency = 0;
                i++;
            }
            return (maxScore);



        }

        //To roll the dice, you need a dice roll method that passes in the dice roll array
        public static int[] RollTheDice(int remainingDice)
        {

            //for each die that is to be rolled(or rerolled) a new random number between 1 and 6 is 
            //put into the diceRoll array
            //this dice Roll is then returned
            int[] diceRolls = new int[remainingDice];
            for (int i = 0; i < remainingDice; i++)
            {
                
                diceRolls[i] = new Random().Next(1, 7);

            }
            return diceRolls;

        }

        //(First Roll)You need to roll 5 dice (int 1-6?) somehow
        //The dice roll generates 5 random numbers (with a value of 1-6)
        //Write the numbers generated by the 5 dice on the first roll
        //Ask the user which dice they want to keep
        //Hold the dice and their values that the user wants to keep.
        //Roll the remaining dice one more time (minus the dice the user kept)
        //Ask the user which dice they want to keep again
        //Roll the dice one last time (minus the dice the user kept)
        //Add up the number on the die that was rolled the most (ex. 5,4,4,3,3 the score would be 2.
        // 2,2,2,3,1 the score would be 3.)
        //so, of the total kept dice, print the total number of dice that had the value that occurred the most


        //next, the computer rolls three times
        //of the three rolls, print the total number of dice that occurred the most

        //print the winner, whoo had the most total number of dice with the same value, 
        //with a tie going to the user/player


    }
}

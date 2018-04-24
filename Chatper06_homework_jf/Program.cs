using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// Jeremy Farmer
/// 02-27-18
/// 
/// Programs takes user input for sets of grades then calculates out the final grade letter of the average
/// of all sets combined
/// 
/// *I apologize for this coding*
/// </summary>
namespace Chatper06_homework_jf
{
    class Program
    {
        static void Main(string[] args)
        {

            string newScore = "";

            ArrayList scoreDB = new ArrayList();
            ArrayList averageScoreSet = new ArrayList();

            Console.WriteLine("Enter done to complete a grade set or enter stop to get the average of all sets.");



            do  // do while loop to get the scores
            {

                newScore = null;
                
                //Get a new stop from the user
                Console.WriteLine("Enter a score: ");
                newScore = Console.ReadLine();

                if (!newScore.ToLower().Equals("stop"))
                {

                    //Try to convert the input to an int to add to our scores
                    try
                    {
                        //Adds the grade to the specified arraylist
                        Grade newGrade = new Grade(Convert.ToInt32(newScore), scoreDB);
                        newGrade.addToScores();
                        Console.WriteLine("Added score to db " + newScore);

                    }
                    catch (FormatException ex)   // catches if the input was not an int 
                    {
                        
                        //Check if the input was 'done' to complete the set
                        if (newScore.ToLower().Equals("done"))
                        {
                            Console.WriteLine("Executing done block");
                            double gradeSet = 0.0;
                            double averageForSet = 0.0;
                            int i = 0;

                            foreach (object item in scoreDB)
                            {
                                gradeSet += Convert.ToDouble(item);
                                i++;
                            }
                            averageForSet = gradeSet / i;
                            averageScoreSet.Add(averageForSet);
                            scoreDB.Clear(); //Clear out the scoreDB for the next set
                        }
                        else //Input wasn't done or stop so let the user know
                        {
                            Console.WriteLine("Input wasn't - done, stop or a valid number");
                        }
                       
                    }

                }
               

            } while (newScore.ToLower() != "stop");  // End of while loop


            //Check if the user had entered values and then entered stop
            if(scoreDB.Count != 0)
            {
                //Calculate their values and get the average
                Console.WriteLine("Executing done block");
                double gradeSet = 0.0;
                double averageForSet = 0.0;
                int i = 0;

                foreach (object item in scoreDB)
                {
                    gradeSet += Convert.ToDouble(item);
                    i++;
                }
                try
                {
                    averageForSet = gradeSet / i;
                }catch(DivideByZeroException ex)
                {
                    Console.WriteLine("Division by zero");
                }
                averageScoreSet.Add(averageForSet);
                Console.WriteLine("Stop found");
            }



            int numberOfSets = 0;
            double averageOfSets = 0.0;

            //If there wasn't more than one set
            if (averageScoreSet.Count == 0)
            {
                //Get the average of items input
                foreach (object item in scoreDB)
                {
                    averageOfSets += Convert.ToDouble(item);
                    numberOfSets++;
                }
                //Display to the user the average
                Console.WriteLine("Average of the grades was : " + averageOfSets / numberOfSets);
                Console.ReadLine();
            }
            //If there is more than one set
            else
            {
                //Display the set and the average of the set and calculate the average of all sets
                foreach (double average in averageScoreSet)
                {
                    Console.WriteLine("Set number " + (numberOfSets + 1) + "'s average is " + average);
                    averageOfSets += average;
                    numberOfSets++;
                }

                //Display the total average of all sets
                Console.WriteLine("Total average score is " + averageOfSets / numberOfSets);
                Console.WriteLine("Your grade is an " + Grade.calculateLetterGrade(averageOfSets / numberOfSets));

                Console.WriteLine("Exit program");
                Console.ReadLine();
            }
        }
    }
}

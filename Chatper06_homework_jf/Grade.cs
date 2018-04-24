using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chatper06_homework_jf
{
    class Grade
    {

        public int score { get; set; }
        public ArrayList GradeDB { get; set; }

        public Grade(int number, ArrayList gradeDB)
        {
            this.score = number;
            this.GradeDB = gradeDB;
        }

        /// <summary>
        /// Method to add scores to the arraylist associated with the grades
        /// checks if the number input is valid before adding it in
        /// </summary>
        public void addToScores()
        {
            if (this.score < 0)
            {
                Console.WriteLine("Value is under 0. 0 is being recorded as this grade");
                this.GradeDB.Add(0);
            }
            else if (this.score > 100)
            {
                Console.WriteLine("Value is over 100. 100 is being recorded as this grade");
                this.GradeDB.Add(100);
            }
            else
            {
                this.GradeDB.Add(this.score);
            }
        }

        /// <summary>
        /// Method to calculate the letter grade of an average and return the letter
        /// associated out
        /// </summary>
        /// <param name="average"></param>
        /// <returns></returns>
        public static char calculateLetterGrade(double average)
        {
            if(average <= 100 && average >= 90)
            {
                return 'A';
            }
            else if(average <= 89 && average >= 80)
            {
                return 'B';
            } 
            else if(average <= 79 && average >= 70)
            {
                return 'C';
            }
            else if(average <= 69 && average >= 60)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

    }
}

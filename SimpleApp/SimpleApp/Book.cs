using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    public class Book
    {
        //ordinea e irelevanta, daca grades era declarat sub functie, functia tot avea acces la colectie
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public double getAverage()
        {
            var average = 0.0;
            foreach(double value in grades)
            {
                average += value;
            }

            return (average / grades.Count);
        }

        public double getLowerGrade()
        {
            return grades.Min();
        }

        public double getHighestGrade()
        {
            return grades.Max();
        }

        public int gradesCount()
        {
            return grades.Count;
        }


    }
}

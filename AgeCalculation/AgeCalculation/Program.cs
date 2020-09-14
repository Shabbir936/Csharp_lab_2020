using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgeCalculation
{
    class Program
    {
        public class DayException : Exception
        {
            public DayException(String message) : base(message)
            { }
        }
        public class MonthException : Exception
        {
            public MonthException(String message) : base(message)
            { }
        }
        static void dateValidation(int dob,int mob)
        {
            if (dob <= 0)
            {
                throw new DayException("You have entered and invalid day.");
            }
            else
            {
                switch(mob)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (dob > 31)
                        {
                            throw new DayException("You have entered and invalid day.");
                        }
                    break;
                    case 2:
                        if (dob > 29)
                        {
                            throw new DayException("You have entered and invalid day.");
                        }
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (dob > 30)
                        {
                            throw new DayException("You have entered an invalid day.");
                        }
                        break;
                    default:
                        throw new MonthException("You have entered an invalid month.");
                }
            }

        }
        static void Main(string[] args)
        {
            //taking birthdate as input separately
            //as year , month , date 
            
            int yob;
            int mob;
            int dob;
            int verifyResult;

            Console.WriteLine("Enter year of birth");
            yob=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter month of birth");
            mob = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter day of birth");
            dob = Convert.ToInt32(Console.ReadLine());
             try
            {
                dateValidation(dob, mob);
            }
            catch (Exception e) when (e is MonthException || e is DayException)
            {
                Console.WriteLine(e);
            }
            

                verifyResult = AgeVerifier(yob, mob, dob);


                if (verifyResult == -1000)
                {
                    Console.WriteLine("Invalid Inputs");
                }
                else if (verifyResult < 0)
                {
                    Console.WriteLine("You dont seem to have been born yet...... hmmm , are you a time traveller?");
                }
                else if (verifyResult >= 135)
                {
                    Console.WriteLine("You're too old , dont lie here!");
                }
                else if (verifyResult == 0)
                {
                    Console.WriteLine("A new born! Welcome to the world!");
                }
                else
                {
                    Console.WriteLine("Your Age is = {0}", AgeCalculator(yob,mob,dob));
                    if (birthdayCheck(mob, dob))
                    {
                        Console.WriteLine(String.Format("Happy Birthday! You are now {0} years old. Feel old yet?", verifyResult));
                    }
                }
                Console.WriteLine("Your astrological sign is - " + astrologicalSign(mob, dob));
                Console.ReadLine();
        

        }

        private static String AgeCalculator(int yob,int mob,int dob)
        {
            try
            {
                DateTime dateOfBirth = new DateTime(yob, mob, dob);
                DateTime tdate = DateTime.Today;
                DateTime bdate = dateOfBirth.Date;
                TimeSpan totalHours = tdate.Subtract(bdate.Date);
                int years = (int)(totalHours.Days/365.25) ;
                int months = (int)((totalHours.Days%365.25)/30);
                int days = (int)((totalHours.Days % 365.25) % 30) ;

                return String.Format("You are {0} years {1} months {2} days old 3}", years, months, days,);
               
                
                


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            return "invalid";
        }

        private static string astrologicalSign(int mob, int dob)
        {
            
            switch (mob)
            {
                case 1:
                    if (dob <= 20)
                        return "Capricorn";
                    else
                        return "Aquarius";
                case 2:
                    if (dob <= 19)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (dob <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (dob <= 20)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (dob <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (dob <= 21)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (dob <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (dob <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (dob <= 21)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (dob <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (dob <= 22)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (dob <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
                default:
                    return "invalid";

                    
            }

        }

        private static bool birthdayCheck(int mob, int dob)
        {
            DateTime tdate = DateTime.Today;
            DateTime birthday = new DateTime(tdate.Year, mob, dob);
            return DateTime.Equals(tdate, birthday);
        }

        private static int AgeVerifier(int yob, int mob, int dob)
        {

            try
            {
                DateTime dateOfBirth = new DateTime(yob, mob, dob);
            DateTime tdate = DateTime.Today;
            DateTime bdate = dateOfBirth.Date;
                return tdate.Year - bdate.Year;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            return -1000;

        }
    }
}

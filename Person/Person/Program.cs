 using System;


namespace Person
{
    
    class Person
    {
        private string firstName;
        private string lastName;
        private DateTime dOB;
        private string emailAddress;

        public Person(string firstName,string lastName,string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }

        public Person(string firstName, string lastName, DateTime dOB)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DOB = dOB;
        }

        public Person(string firstName, string lastName, string emailAddress, DateTime dOB)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.DOB = dOB;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DOB { get => dOB; set => dOB = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }

        public bool Adult 
        {
            get
            { 
                if ((DateTime.Today.Year-dOB.Year) >= 18)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public string Sunsign
        {
            get
            {
                switch (dOB.Month)
                {
                    case 1:
                        if (dOB.Day <= 20)
                            return "Capricorn";
                        else
                            return "Aquarius";
                    case 2:
                        if (dOB.Day <= 19)
                            return "Aquarius";
                        else
                            return "Pisces";
                    case 3:
                        if (dOB.Day <= 20)
                            return "Pisces";
                        else
                            return "Aries";
                    case 4:
                        if (dOB.Day <= 20)
                            return "Aries";
                        else
                            return "Taurus";
                    case 5:
                        if (dOB.Day <= 20)
                            return "Taurus";
                        else
                            return "Gemini";
                    case 6:
                        if (dOB.Day <= 21)
                            return "Gemini";
                        else
                            return "Cancer";
                    case 7:
                        if (dOB.Day <= 22)
                            return "Cancer";
                        else
                            return "Leo";
                    case 8:
                        if (dOB.Day <= 22)
                            return "Leo";
                        else
                            return "Virgo";
                    case 9:
                        if (dOB.Day <= 21)
                            return "Virgo";
                        else
                            return "Libra";
                    case 10:
                        if (dOB.Day <= 22)
                            return "Libra";
                        else
                            return "Scorpio";
                    case 11:
                        if (dOB.Day <= 22)
                            return "Scorpio";
                        else
                            return "Sagittarius";
                    case 12:
                        if (dOB.Day <= 21)
                            return "Sagittarius";
                        else
                            return "Capricorn";
                    default:
                        return "invalid";


                }
            }
        }

        public bool Birthday
        {
            get
            {
                if (DateTime.Today.Day == dOB.Day && DateTime.Today.Month == dOB.Month)
                    return true;
                else
                    return false;
            }
        }

        public string ScreenName
        {
            get
            {
                return String.Format("{0}.{1}",firstName.Substring(0,4),dOB.Year.ToString());
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string firstName,lastName,emailAddress,dOB;
            Console.WriteLine("Enter the the first name of the person:");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter the email address:");
            emailAddress=Console.ReadLine();
            Console.WriteLine("Enter the date of birth in the following format - YYYY/MM/DD :");
            dOB = Console.ReadLine();


            Person P1 = new Person(firstName, lastName, emailAddress, new DateTime(Convert.ToInt32(dOB.Substring(0,4)), Convert.ToInt32(dOB.Substring(5, 2)), Convert.ToInt32(dOB.Substring(8, 2))));

            Console.WriteLine("Adult? " + P1.Adult);
            Console.WriteLine("Sun Sign - " + P1.Sunsign);
            Console.WriteLine("Birthday? " + P1.Birthday);
            Console.WriteLine("Screen Name - " + P1.ScreenName);
            Console.ReadLine();
        }
    }
}

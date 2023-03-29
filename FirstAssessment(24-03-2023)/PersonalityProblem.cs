using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssessment
{
    internal class PersonalityProblem
    {

        enum ZodiacSigns
        {
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        };

        //private string[] friends = new string[10];
        private int birth_month_integer= 1;

        private Dictionary<string, string[]> zodiaccollection = new Dictionary<string, string[]>();

        public string Name { get; set; }  

        public string Birth_month { get; set; }

        public int Birth_year { get; set; }

        public int Birth_date { get; set; }

        //private string[] Friends {
        //    get
        //    {
        //        return friends;
        //    }
        //   }



        private Dictionary<string, string[]> ZodiacCollection
        {
            get
            {
                return zodiaccollection;
            }
        }



        public void MainFunction()
        {


            Console.Write("Enter your name : ");
            Name = Console.ReadLine();

            //Friends.Append(Name);


            // FOR Testing
            string[] demo = { "test1", "test2" };
            ZodiacCollection["Leo"] = demo;
            string[] demo1 = { "rolex", "lcu" };
            ZodiacCollection["Scorpio"] = demo1;


            FindPersonality();
            FindZodiac();
            FindAge();

            
        }



        public void FindPersonality()
        {
            string question1 = "1. Who are you?\na) Introvet\nb) Extrovet\nc)Adoptable";
            string question2 = "2. How do you spend your free time?\na) Alone \nb) With Someone\nc)Dependence";
            string question3 = "3. What you do to relaxed your self?\na) For a Walk\nb) Trip\nc)Based On Time";

            Console.WriteLine("Welcome!! To Find your Personality");
            Console.WriteLine("Answer the MCQ based question to identity your self.");

            string userChoice1, userChoice2, userChoice3;

            userChoice1 = CallQuestion(question1);
            if (userChoice1.Equals(""))
            {
                Console.WriteLine("No option choosen!!");
                userChoice1 = CallQuestion(question1);
            }
            userChoice2 = CallQuestion(question2);
            if (userChoice2.Equals(""))
            {
                Console.WriteLine("No option choosen!!");
                userChoice2 = CallQuestion(question2);
            }
            userChoice3 = CallQuestion(question3);
            if (userChoice3.Equals(""))
            {
                Console.WriteLine("No option choosen!!");
                userChoice3 = CallQuestion(question3);
            }

            if (userChoice1.Equals("a") && userChoice2.Equals("a") && userChoice3.Equals("a"))
                Console.WriteLine("Your Introvet person who likes to alone");
            else if (userChoice1.Equals("b") && userChoice2.Equals("b") && userChoice3 == "b")
                Console.WriteLine("Your Extrovet person who likes to explore");
            else
                Console.WriteLine("Your adoptive person");
        }


        public string CallQuestion(string question)
        {
            string userInput;
            Console.WriteLine(question);
            Console.Write("Enter only the option letter : ");
            userInput = Console.ReadLine();
            return userInput;
        }


        public void FindZodiac()
        {

            GetDOB();

            string[] month_list = { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };

            string Zodiac = "";


            for(int idx=0; idx < month_list.Length; idx++)
            {
                if (month_list[idx].Equals(Birth_month))
                {
                    var zodiac_value = ((ZodiacSigns)idx).ToString();
                    Zodiac = zodiac_value;
                    
                    if (ZodiacCollection.ContainsKey(Zodiac))
                    {
                        ZodiacCollection[zodiac_value].Append(Name);
                    }
                    else
                    {
                        string[] partner = { Name };
                        ZodiacCollection[Zodiac] = partner;
                    }

                    birth_month_integer = idx + 1; 
                    break;

                }
            }

            string[] friend_partners = ZodiacCollection[Zodiac];

            Console.WriteLine("The Zodiac Sign : {0}", Zodiac);
            Console.Write("Your Partners are : ");
            foreach (string partner in friend_partners)
            {
                    if(!partner.Equals(Name))
                    {
                        Console.Write(partner + " ");
                    }
            }
            Console.WriteLine();
        }

        public void FindAge()
        {

            if (Birth_date.Equals(0))
                GetDOB();

            DateTime dob = new DateTime(Birth_year, birth_month_integer, Birth_date);
            TimeSpan age = DateTime.Now.Subtract(dob);
            int years = (int)(age.TotalDays / 365.25);

            Console.WriteLine("Hi! {0}. Your {1} years old.",Name,years);
        }

        public void GetDOB()
        {
            Console.Write("Enter your Birth Month: (First letter of Month) ");
            Birth_month = Console.ReadLine().ToLower();

            Console.Write("Enter your Birth Date: ");
            Birth_date = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Birth year: ");
            Birth_year = Convert.ToInt32(Console.ReadLine());

        }


    }
}

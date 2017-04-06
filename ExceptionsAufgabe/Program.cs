using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAufgabe
{
    class Program
    {

        List<Person> persons = new List<Person>();

        static void Main(string[] args)
        {

            Program program = new Program();
            program.Mainmenu();
            Console.WriteLine("Programmende");
            Console.ReadLine();
        }

        void Mainmenu()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("1. Personen anzeigen \n2. Person hinzufuegen \n3. Beenden");

                try
                {
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            ShowAllPersons();
                            run = false;
                            break;
                        case 2:
                            AddPerson();
                            run = false;
                            break;
                        case 3:
                            run = false;
                            break;
                        default:
                            Console.WriteLine("1 oder 2 oder 3?");
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Bitte nur Zahlen eingeben");
                }
            }
        }

        void ShowAllPersons()
        {
            foreach (Person person in persons)
            {
                Console.WriteLine("{0} ({1}) : {2}", person.Name, person.Nickname, person.Age);
            }
            Mainmenu();
        }

        void AddPerson()
        {
            
            try
            {
                Console.WriteLine("Namen eingeben (Camelcase) > ");
                string name = ReadName();
                Console.WriteLine("Nickname eingeben (max. 6 Zeichen) > ");
                string nickname = ReadNickname();
                //int age = ReadAge();

                persons.Add(new Person() { Name = name, Nickname = nickname /*, Age = age*/ });

                Mainmenu();
            }
            catch (NameFormatException)
            {
                Console.WriteLine("GROSSBUCHSTABE!");
                AddPerson();
            }
            catch (NicknameFormatException)
            {
                Console.WriteLine("MAX 6 ZEICHEN!");
                AddPerson();
            }

        }

        string ReadName()
        {

            string name;
            name = Console.ReadLine();
            if (Char.IsUpper(name, 0))
            {
                return name;
            }
            else
            {
                throw new NameFormatException();
            }
        }

        string ReadNickname()
        {
            string nickname;
            nickname = Console.ReadLine();
            
            if (isNicknameAssigned(nickname))
            {
                throw new AssignedNicknameException();
            }
            else if(nickname.Length > 6){
                throw new NicknameFormatException();
            }
            else
            {
                return nickname;
            }
        }

        int Readage()
        {
            int age = 0;
            try
            {
                age = Convert.ToInt32(Console.ReadLine());

                if(age <= 0)
                {
                    throw new BadArgumentException();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Ungueltige Zahl");
            }

            return age;
        }

        bool isNicknameAssigned(string nickname)
        {
            foreach (Person person in persons)
            {
                if(person.Nickname == nickname)
                {
                    return true;
                }                
            }
            return false;
        }

    }
}

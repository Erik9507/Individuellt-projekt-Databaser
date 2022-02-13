using Individuellt_projekt_Databaser.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Individuellt_projekt_Databaser
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool main = true;
            while (main)
            {
                PrintMenu();
                var keyInfo = Console.ReadKey(intercept: true);
                ConsoleKey menu = keyInfo.Key;
                switch (menu)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        getStudents();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        getStudentsInClass();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        addStaff();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        staffInfo();
                        break;

                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        courseInfo();
                        break;

                    default:
                        Console.WriteLine("Ogiltigt alternativ");
                        break;
                }
            }
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Välj nedan i menyn");
            Console.WriteLine();
            Console.WriteLine("[1] Visa information om alla Elever"); //klar
            Console.WriteLine("[2] Visa information om alla Elever i en viss klass"); //klar
            Console.WriteLine("[3] Lägg till ny personal"); //klar
            Console.WriteLine("[4] Visa information om personal och avdelningar");//klar
            Console.WriteLine("[5] Visa en lista på alla aktiva kurser");//klar
        }
        public static void getStudents()
        {
            SchoolDbContext Context = new SchoolDbContext();
            Console.Clear();
            Console.WriteLine("Hämta alla Elever");
            Console.WriteLine("Vill du se elever sorterade på för eller efternamn?");
            Console.WriteLine("1: Förnamn");
            Console.WriteLine("2: Efternamn");
            int order = Convert.ToInt32(Console.ReadLine());
            if (order == 1)
            {
                var stud = from elev in Context.Elev
                           orderby elev.FNamn
                           select elev;
                foreach (var item in stud)
                {
                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                    Console.WriteLine("------------------------------");
                }
            }
            else if (order == 2)
            {
                var stud = from elev in Context.Elev
                           orderby elev.ENamn
                           select elev;
                foreach (var item in stud)
                {
                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt alternativ");
            }
            Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
            Console.ReadKey();
            Console.Clear();
        }
        public static void getStudentsInClass()
        {
            SchoolDbContext Context = new SchoolDbContext();
            Console.Clear();
            Console.WriteLine("Hämta alla Elever i en klass");
            var classes = from Klass in Context.Klass
                          orderby Klass.Id
                          select Klass;

            foreach (var item in classes)
            {
                Console.WriteLine(item.Id + ": " + item.Namn);
            }
            Console.WriteLine("Välj vilken klass du vill se:");
            int case2 = Convert.ToInt32(Console.ReadLine());
            if (case2 == 1)
            {
                var sut21 = from elev in Context.Elev
                            where elev.KlassId == 1
                            select elev;
                Console.Clear();
                Console.WriteLine("Alla elever i sut21");
                foreach (var item in sut21)
                {
                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                    Console.WriteLine("------------------------------");
                }
                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                Console.ReadKey();
                Console.Clear();
            }
            if (case2 == 2)
            {
                var sut20 = from elev in Context.Elev
                            where elev.KlassId == 2
                            select elev;
                Console.Clear();
                Console.WriteLine("Alla elever i sut20");
                foreach (var item in sut20)

                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                Console.WriteLine("------------------------------");

                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void addStaff()
        {
            SchoolDbContext Context = new SchoolDbContext();

            Console.Clear();
            Console.WriteLine("Lägg till ny personal");
            Console.WriteLine("Vill du lägga till:");
            Console.WriteLine("[1} Lärare");
            Console.WriteLine("[2} Adminitratör");
            Console.WriteLine("[3} Rektor ");

            int roll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv in förnamn:");
            string newFname = Console.ReadLine();
            Console.WriteLine("Skriv in efternamn");
            string newLname = Console.ReadLine();
            Console.WriteLine("Skriv in månadslön för den nya anställda");
            int newSalary = Convert.ToInt32(Console.ReadLine());

            Personal p1 = new Personal()
            {
                BefattningsId = roll,
                SkolId = 1,
                FNamn = newFname,
                ENamn = newLname,
                Månadslön = newSalary,
            };
            Console.WriteLine(p1.ENamn + " Lades till i databasen");
            Context.Add(p1);
            Context.SaveChanges();
            Console.Clear();
        }
        public static void staffInfo()
        {
            SchoolDbContext Context = new SchoolDbContext();
            Console.Clear();
            var allstaff = from personal in Context.Personal
                           join befattning in Context.Befattning on personal.BefattningsId equals befattning.Id
                           orderby befattning
                           select new { Fullname = personal.FNamn + " " + personal.ENamn, Bef = befattning.Befattning1 };
            foreach (var item in allstaff)
            {
                Console.WriteLine($"Namn: {item.Fullname}");
                Console.WriteLine($"Befattning: { item.Bef}\n");
            }

            var count1 = Context.Personal
                .Where(id1 => id1.BefattningsId == 1)
                .Count();

            var count2 = Context.Personal
             .Where(id2 => id2.BefattningsId == 2)
             .Count();

            var count3 = Context.Personal
             .Where(id3 => id3.BefattningsId == 3)
             .Count();

            Console.WriteLine($"Antal anställda i läraravdelningen: {count1}");
            Console.WriteLine($"Antal anställda i rektorsavdelningen: {count2}");
            Console.WriteLine($"Antal anställda i administratörsavdelningen: {count3}\n");

            Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
            Console.ReadKey();
            Console.Clear();
        }
        public static void courseInfo()
        {
            DateTime today = DateTime.Now.Date;
            SchoolDbContext Context = new SchoolDbContext();
            Console.Clear();
            Console.WriteLine("Nedan ser du en lisa på alla aktiva kurser");
            var course = from kurs in Context.Kurs
                         orderby kurs.Id
                         where kurs.Startdatum < today && kurs.SlutDatum > today
                         select kurs;
            foreach (var item in course)
            {
                Console.WriteLine($"Kursnamn:{item.KursNamn}");
                Console.WriteLine($"Kursen Startar: {item.Startdatum} och kurs slutar: {item.SlutDatum}");
                Console.WriteLine();
            }
            Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
            Console.ReadKey();
            Console.Clear();

        }
    }
}

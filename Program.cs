using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Members
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            List<Members> members = new List<Members>();
            Input(members);
            Display(members);
            int n = int.Parse(Console.ReadLine());
            int choose;

            do
            {
                ShowMenu();
                choose = Int32.Parse(Console.ReadLine());
                switch(choose)
                {
                    case 1:
                        FindMale(members);
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        InputFullname(members);
                        break;
                    case 4:
                        int choose2;
                        choose2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("1. List of members who has birth year is 1998");
                        Console.WriteLine("2. List of members who has birth year greater than 1998");
                        Console.WriteLine("3. List of members who has birth year less than 1998");
                        Console.WriteLine("4. Come back");
                    do
                    {
                        switch (choose2)
                        {
                            case 1:
                                BirthYearin1998(members);
                                break;
                            case 2:
                                BirthYearthan1998(members);
                                break;
                            case 3:
                                BirthYearless1998(members);
                                break;
                        }
                    } while (choose2 != 4);
                        break;
                    case 5:
                        FistPersonHaNoi(members);
                        break;
                    case 6:
                        JoinClassBefore(members);
                        break;
                    case 7:
                        Console.WriteLine("Bye Bye!!!!");
                        break;
                    default:
                        Console.WriteLine("Retype");
                        break;                  
                }
            } while (choose != 7);
        }

        static void Input(List<Members> members)
        {
            Console.WriteLine("Input the number of members: ");
            int n = Int32.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Members member = new Members();
                member.Input();
                members.Add(member);
            }
        }

        static void Display(List<Members> members)
        {
            for(int i = 0; i < members.Count; i++)
            {
                members[i].Display();
            }
        }

        static void FindMale(List<Members> members)
        {
            var maleMembers = from maleMember in members
                where maleMember.gender == "Nam"
                select maleMember;
            foreach (var maleMember in maleMembers)
                Console.WriteLine(maleMember.ToString());
        }

        static void InputFullname(List<Members> members)
        {
            string fullName;
            for(int i = 0; i < members.Count; i++)
            {
                fullName = members[i].firstName + " " + members[i].lastName;
                Console.WriteLine(fullName);
            }
            
        }

        static void BirthYearin1998(List<Members> members)
        {

        }

        static void BirthYearthan1998(List<Members> members)
        {

        }

        static void BirthYearless1998(List<Members> members)
        {

        }

        static void FistPersonHaNoi(List<Members> members)
        {

        }

        static void JoinClassBefore(List<Members> members)
        {

        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Return a list of members who is Male");
            Console.WriteLine("2. Return the oldest one");
            Console.WriteLine("3. Return a new list that contains Full Name only");
            Console.WriteLine("4. Return a list of members who is Male");
            Console.WriteLine("4. Return 3 list");
            Console.WriteLine("5. Return the first person who was born in Ha Noi");
            Console.WriteLine("6. Return List of member who join class before 22/03/2021");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Choose: ");
        }
    }
}

namespace NashTechDayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var members = new List<Member>()
            {
                new Member("nguyen","van anh","Male", new DateTime(2002,09,22),"0987654","Ha Nam",true),
                new Member("Tran","Van Nga","Female", new DateTime(2001,05,22),"0987654","Ha Noi",false),
                new Member("Do","Thai Tuan","Male", new DateTime(1998,05,22),"0987654","Ha Noi",true),
                new Member("Vu","Hoang Nam","Male", new DateTime(2002,09,22),"0987654","Vinh Phuc",true),
                new Member("Hoang","van anh","Male", new DateTime(2000,09,12),"0987654","Ha Noi",false),
                new Member("Kim","Lan","Female", new DateTime(1989,05,22),"0987654","HCM",true),
                new Member("Dang","The Mau","Male", new DateTime(2002,09,22),"0987654","Hai Phong",false),
                new Member("Tran","Anh","Female", new DateTime(1989,09,22),"0987654","Cao Bang",false),
            };
            while (true)
            {
                Console.Write("\n");
                Console.Write("Program C#\n");
                Console.Write("------------------------------------------------");
                Console.Write("\n\n");
                Console.Write("\nThis is the choice:\n");
                Console.Write("1 - Return a list of members who is Male " +
                              "\n2 - Return the oldest one based on “Age”." +
                              "\n3 - Return a new list that contains Full Name only." +
                              "\n4 - Return 3 lists:" +
                              "\n5 - Return the first person who was born in Ha Noi" +
                              "\n6 - Exit.\n");
                Console.Write("\nEnter your choice: ");

                int opt;
                opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.Write("Return a list of members who is Male\n");
                        Console.Write("------------------------------------\n");
                        var membersMale = from member in members
                                          where member.Gender == "Male"
                                          select member;

                        foreach (var member in membersMale)
                        {
                            Console.WriteLine(member.Information);
                        }
                        break;
                    case 2:
                        Console.Write("Return the oldest one based on “Age”\n");
                        Console.Write("------------------------------------\n");

                        var oldMember = members.OrderByDescending(x => x.Age).FirstOrDefault();

                        if (oldMember != null)
                        {
                            Console.WriteLine(oldMember.Information);
                        }
                        break;
                    case 3:
                        Console.Write("Return a new list that contains Full Name only\n");
                        Console.Write("----------------------------------------------\n");

                        var fullName = from member in members
                                       select member;

                        foreach (var member in fullName)
                        {
                            Console.WriteLine($" {member.FirstName,10} {member.LastName,20}");
                        }
                        break;
                    case 4:
                        Console.Write("Return 3 list\n");
                        Console.Write("1 - List of members who has birth year is 2000 " +
                                "\n2 - List of members who has birth year greater than 2000." +
                                "\n3 - List of members who has birth year less than 2000" +
                                "\n4 - Exit.\n");
                        Console.Write("--------------------------------------------------------\n");
                        Console.Write("\nEnter your choice: ");

                        int opt1;
                        opt1 = Convert.ToInt32(Console.ReadLine());

                        switch (opt1)
                        {
                            case 1:
                                Console.Write("\n List of members who has birth year is 2000\n");

                                var member2000 = from member in members
                                                 where member.DateOfBirth.Year == 2000
                                                 select member;

                                foreach (var member in member2000)
                                {
                                    Console.WriteLine(member.Information);
                                }
                                break;
                            case 2:
                                Console.Write("\n List of members who has birth year greater than 2000\n");

                                var memberGreater2000 = from member in members
                                                        where member.DateOfBirth.Year > 2000
                                                        select member;

                                foreach (var member in memberGreater2000)
                                {
                                    Console.WriteLine(member.Information);
                                }
                                break;
                            case 3:
                                Console.Write("\nList of members who has birth year less than 2000\n");

                                var memberLess2000 = from member in members
                                                     where member.DateOfBirth.Year < 2000
                                                     select member;

                                foreach (var member in memberLess2000)
                                {
                                    Console.WriteLine(member.Information);
                                }
                                break;

                            default:
                                Console.Write("Enter a valid option\n");
                                break;
                        }
                        break;
                    case 5:
                        Console.Write("Return the first person who was born in Ha Noi\n");
                        Console.Write("----------------------------------------------\n");

                        var firstMember = members.Where(m => m.BirthPlace == "Ha Noi").FirstOrDefault();

                        if (firstMember != null)
                        {
                            Console.WriteLine(firstMember.Information);
                        }
                        break;

                    default:
                        Console.Write("Enter a valid option\n");
                        break;
                }
            }
        }
    }
}

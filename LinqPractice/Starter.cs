namespace LinqPractice
{
    internal class Starter
    {
        public static void Run()
        {
            ColoredGreenConsoleWrite("\t\t\t\t\t\tLINQ Practice\n\n");

            // Contact.cs
            var contacts = GetInitialContacts();
            var secondContacts = GetSecondContacts();
            var contactsEmpty = new List<Contact>();

            // Employee.cs -> needed only to be used in Join()
            var employees = GetEmployees();

            // number of a current operation
            int n = 0;

            // 1. select
            var names = from contact in contacts
                        select contact.Name;
            Print($"{++n}. select names only:", names);

            // 2. Where()
            var femalesFromUkraine = contacts.Where(c => c.Country == "Ukraine" && c.Gender == Gender.Female);
            Print($"{++n}. Where() -> female contacts from Ukraine:", femalesFromUkraine);

            // 3. OrderBy()
            var orderedAscending = contacts.OrderBy(c => c.Age).ThenBy(c => c.Name);
            Print($"{++n}. OrderBy().ThenBy() -> ordered contact list in ascending order:", orderedAscending);

            // 4. orderby descending
            var orderedDescending = from contact in contacts
                                    orderby contact.Gender descending, contact.Name descending
                                    select contact;
            Print($"{++n}. orderby descending (+ implicit ThenBy()) -> ordered contact list in descending order:", orderedDescending);

            // 5. Join()
            var workers = contacts.Join(employees, c => c.Name, e => e.Name, (c, e) => new { c.Name, e.Company, c.Age });
            Print($"{++n}. Join() -> create a new collection of workers out of 'contacts' and 'employees'", workers);

            // 6. GroupBy()
            var contactsByCountry = contacts.GroupBy(c => c.Country)
                .Select(group => new { Country = group.Key, Count = group.Count() });
            Print($"{++n}. GroupBy() -> get number of contacts from each country:", contactsByCountry);

            // 7. All()
            bool isEveryoneAdult = contacts.All(c => c.Age >= 18);
            ColoredGreenConsoleWrite($"{++n}. All():\n");
            Console.WriteLine($"  Everyone is over 18 y.o.: {isEveryoneAdult}\n");

            // 8. Any()
            bool isAnyoneFromJapan = contacts.Any(c => c.Country == "Japan");
            ColoredGreenConsoleWrite($"{++n}. Any():\n");
            Console.WriteLine($"  Someone is from Japan: {isAnyoneFromJapan}\n");

            // 9. Count()
            int ukrainiansNumber = contacts.Count(c => c.Country == "Ukraine");
            ColoredGreenConsoleWrite($"{++n}. Count():\n");
            Console.WriteLine($"  Number of contacts from Ukraine: {ukrainiansNumber}\n");

            // 10. Take()
            var takeFirstThreeContacts = contacts.Take(3);
            Print($"{++n}. Take() -> take first 3 contacts:", takeFirstThreeContacts);

            // 11. TakeLast()
            var takeLastFiveContacts = contacts.TakeLast(5);
            Print($"{++n}. TakeLast() -> take last 5 contacts:", takeLastFiveContacts);

            // 12. Skip()
            var skippedFirstTwoContacts = contacts.Skip(2);
            Print($"{++n}. Skip() -> skip first 2 contacts:", skippedFirstTwoContacts);

            // 13. SkipWhile()
            var skipWhileUsaNotFound = contacts.SkipWhile(c => c.Country != "USA");
            Print($"{++n}. SkipWhile() -> skip contacts while contacts from USA not found", skipWhileUsaNotFound);

            // 14. Contains()
            bool isNamePresent = contacts.Select(c => c.Name).Contains("тітка Клава");
            ColoredGreenConsoleWrite($"{++n}. Contains():\n");
            Console.WriteLine($"  тітка Клава is present in contacts: {isNamePresent}\n");

            // 15. Distinct()
            var distinctContacts = contacts.Distinct(new ContactEqualityComparer()).ToList();
            Print($"{++n}. Distinct().ToList() -> remove duplicates", distinctContacts);

            // 16. Except()
            var exceptContacts = contacts.Except(secondContacts, new ContactEqualityComparer()).ToArray();
            Print($"{++n}. Except().ToArray() -> remove contacts from 'contacts' that are present in 'secondContacts'", exceptContacts);

            // 17. Union()
            var unionContacts = contacts.Union(secondContacts, new ContactEqualityComparer());
            Print($"{++n}. Union() -> combine contacts from 'contacts' and 'secondContacts', excluding duplicates", unionContacts);

            // 18. Intersect()
            var intersectContacts = contacts.Intersect(secondContacts, new ContactEqualityComparer());
            Print($"{++n}. Intersect() -> common contacts from 'contacts' and 'secondContacts' will appear", intersectContacts);

            // 19. Concat()
            var concatContacts = contacts.Concat(secondContacts);
            Print($"{++n}. Concat() -> combine contacts from 'contacts' and 'secondContacts', including duplicates", concatContacts);

            // 20. First()
            Contact firstContact = contacts.First();
            ColoredGreenConsoleWrite($"{++n}. First():\n");
            Console.WriteLine($"  first contact: {firstContact}\n");

            // 21. FirstOrDefault()
            Contact defaultContact = new Contact("default", -1, "+123456789012", "Arctic", Gender.PreferNotToSay);
            Contact firstOrDefault = contactsEmpty.FirstOrDefault(defaultContact);
            ColoredGreenConsoleWrite($"{++n}. FirstOrDefault():\n");
            Console.WriteLine($"  first or default contact of an empty contact list: {firstOrDefault}\n");

            // 22. ElementAt()
            Contact sixthContact = contacts.ElementAt(5);
            ColoredGreenConsoleWrite($"{++n}. ElementAt():\n");
            Console.WriteLine($"  6th element: {sixthContact}\n");

            // 23. ElementAtOrDefault()
            Contact? hundredthContact = contacts.ElementAtOrDefault(100);
            ColoredGreenConsoleWrite($"{++n}. ElementAtOrDefault():\n");
            Console.WriteLine($"  100th element: " + (hundredthContact is null ? "-" : hundredthContact) + "\n");

            // 24. Last()
            Contact lastContact = contacts.Last();
            ColoredGreenConsoleWrite($"{++n}. Last():\n");
            Console.WriteLine($"  last contact: {lastContact}\n");

            // 25. LastOrDefault()
            Contact? lastOrDefault = contactsEmpty.LastOrDefault();
            ColoredGreenConsoleWrite($"{++n}. LastOrDefault():\n");
            Console.WriteLine($"  last or default contact of an empty contact list: " + (lastOrDefault is null ? "null" : lastOrDefault) + "\n");

            // 26. Reverse()
            contacts.Reverse();
            Print($"{++n}. Reverse() -> invert the order of the contacts", contacts);
        }

        // Get initial contacts for our main object - 'contacts'
        private static List<Contact> GetInitialContacts()
        {
            var contacts = new List<Contact>()
            {
                new Contact("Ганна", 19,        "+380954605153", "Ukraine", Gender.Female),
                new Contact("Вікторія", 25,     "+380664605155", "Ukraine", Gender.Female),
                new Contact("Богдан", 27,       "+380508118912", "Belarus", Gender.Male),
                new Contact("Назар", 22,        "+380632278621", "Ukraine", Gender.Male),
                new Contact("тітка Клава", 68,  "+380735889412", "Ukraine", Gender.Female),

                new Contact("Yukino", 19,       "+030720123456", "Japan", Gender.Female),
                new Contact("Uncle Sam", 65,    "+109225348922", "USA", Gender.Male),
                new Contact("Nicole", 29,       "+330921551211", "France", Gender.Female),
                new Contact("Jisoo", 28,        "+826350828231", "South Korea", Gender.Female),
                new Contact("Jorge", 24,        "+340652256551", "Spain", Gender.Male),

                new Contact("Jorge", 24,        "+340652256551", "Spain", Gender.Male)
            };

            return contacts;
        }

        // needed for Except(), Union(), Intersect(), Concat()
        private static List<Contact> GetSecondContacts()
        {
            var contacts = new List<Contact>()
            {
                new Contact("Ганна", 19,        "+380954605153", "Ukraine", Gender.Female),
                new Contact("Карина", 26,       "+380964205151", "Ukraine", Gender.Female),
                new Contact("Богдан", 27,       "+380508118912", "Belarus", Gender.Male),
                new Contact("Назар", 22,        "+380632278621", "Ukraine", Gender.Male),
                new Contact("Максим", 38,       "+380995789432", "Ukraine", Gender.Male),

                new Contact("Yukino", 19,       "+030720123456", "Japan", Gender.Female),
                new Contact("Uncle Sam", 65,    "+109225348922", "USA", Gender.Male),
                new Contact("Jiwoo", 28,        "+826350828231", "South Korea", Gender.Female),
                new Contact("Olivier", 33,      "+3306500489051", "France", Gender.Male),
            };

            return contacts;
        }

        // needed only to be used in Join()
        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee("Максим", "Укрпошта"),
                new Employee("Яна", "ПриватБанк"),
                new Employee("Yukino", "Google Japan"),
                new Employee("Uncle Sam", "Lockheed Martin"),
                new Employee("Андрій", "McDonalds"),

                new Employee("Jisoo", "Microsoft Korea"),
                new Employee("Olivier", "AMD"),
                new Employee("Богдан", "Uklon"),
            };

            return employees;
        }

        // Print only IEnumerable<T> collections, i.e. complex objects
        private static void Print<T>(string info, IEnumerable<T> collection)
        {
            ColoredGreenConsoleWrite(info + "\n");

            int count = 0;

            foreach (var c in collection)
            {
                // print 'new line' every 5 contacts for better/easier reading
                if (count++ % 5 == 0)
                {
                    Console.WriteLine();
                }

                Console.WriteLine("  " + c);
            }

            Console.WriteLine("\n");
        }

        // without "\n" is needed to use ColoredGreenConsoleWrite() in Run() correctly
        private static void ColoredGreenConsoleWrite(string info)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(info);
            Console.ResetColor();
        }
    }
}

namespace LinqPractice
{
    // needed only to be used in LINQ: Join()
    internal class Employee
    {
        public Employee(string name, string company)
        {
            Name = name;
            Company = company;
        }

        public string Name { get; set; }
        public string Company { get; set; }
    }
}

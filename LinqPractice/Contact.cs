namespace LinqPractice
{
    internal class Contact : IComparable<Contact>
    {
        public Contact(string name, int age, string number, string country, Gender gender)
        {
            Name = name;
            Age = age;
            Number = number;
            Country = country;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }

        // Compare with each property except for 'Country'
        // because a person can move to another country
        public int CompareTo(Contact? secondContact)
        {
            if (secondContact == null)
            {
                return -1;
            }

            int res = Name.CompareTo(secondContact.Name);

            if (res == 0)
            {
                res = Age.CompareTo(secondContact.Age);

                if (res == 0)
                {
                    res = Number.CompareTo(secondContact.Number);

                    if (res == 0)
                    {
                        res = Gender.CompareTo(secondContact.Gender);
                    }
                }
            }

            return res;
        }

        public override string ToString()
        {
            return $"Contact {{ Name = {Name}, Age = {Age}, Number = {Number}, Country = {Country}, Gender = {Gender}}}";
        }
    }
}

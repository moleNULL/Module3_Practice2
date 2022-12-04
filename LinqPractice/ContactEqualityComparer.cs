namespace LinqPractice
{
    // is used in LINQ: Distinct(), Except(), Union(), Intersect()
    internal class ContactEqualityComparer : IEqualityComparer<Contact>
    {
        // Compare with each property except for 'Country'
        // because a person can move to another country
        public bool Equals(Contact? x, Contact? y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            bool res = x.Name == y.Name;

            if (res)
            {
                res = x.Age == y.Age;

                if (res)
                {
                    res = x.Number == y.Number;

                    if (res)
                    {
                        res = x.Gender == y.Gender;
                    }
                }
            }

            return res;
        }

        public int GetHashCode(Contact c)
        {
            return c.Number.GetHashCode();
        }
    }
}

namespace FacetedBuilderDemo
{

    public class Person
    {
        public string StreetAddress, PostCode, City;

        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }


    public class PersonBuilder
    {
        protected Person person = new Person();

        public PersonJobBuilder works => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyname)
        {
            person.CompanyName = companyname;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int Amount)
        {
            person.AnnualIncome = Amount;
            return this;
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {

            var pb = new PersonBuilder();
                
             Person person =   pb.works.At("apple").AsA("softwareengineer").Earning(5000);
            Console.WriteLine(person.ToString());
        }
    }
}
namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        protected Category() { }

        public Category(string name)
        {
            ValidateNameAndSetName(name);
        }

        public void Update(string name)
        {
            ValidateNameAndSetName(name);
        }

        private void ValidateNameAndSetName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is Required");
            DomainException.When(name.Length < 3, "Name is invalid");

            Name = name;
        }
    }
}

using CleanShop.Domain.Validation;

namespace CleanShop.Domain.Entities;
public sealed class Category
{
    public Category(string name)
    {
        ValidateDomain(name);
    }
    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid ID value");
        ValidateDomain(name);
    }

    public int Id { get; private set; }
    public string Name { get; private set; }

    public ICollection<Product> Products { get; set; }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, to short, minmum 3 characters");

        Name = name;
    }
}

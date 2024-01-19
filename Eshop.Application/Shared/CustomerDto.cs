namespace Eshop.Application.Shared
{
    public class CustomerDto 
    {
        public Guid Id { get; }

        public string Name{ get; }

        public CustomerDto(Guid id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}

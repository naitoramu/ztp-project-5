public class CustomerNotExistsException : Exception 
{ 
    public Guid Id { get; }

    public CustomerNotExistsException(Guid id)
    {
        Id = id;
    }
}
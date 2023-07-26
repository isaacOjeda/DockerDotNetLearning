namespace DockerDotNetLearning.Api.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string Company { get; set; }
    public string JobTitle { get; set; }
}
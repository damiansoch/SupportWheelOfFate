namespace SupportWheelOfFate.Models
{
    public class Engineer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public bool Selected { get; set; }

    }
}

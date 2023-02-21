namespace SupportWheelOfFate.Models
{
    public class Engineer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public bool FristShift { get; set; }
        public bool SecondShift { get; set; }

        public DateTime? FirstShiftDate { get; set; }
        public string? FirstShiftTime { get; set; } 
        public DateTime? SecondShiftDate { get;set; }
        public string? SecondShiftTime { get; set;} 
    }
}

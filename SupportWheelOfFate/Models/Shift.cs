using System.ComponentModel.DataAnnotations.Schema;

namespace SupportWheelOfFate.Models
{
    public class Shift
    {
        public Guid Id { get; set; }
        public int Day { get; set; } = default!;
        public string TimeOfDay { get; set; } = default!;

        
        
        public Engineer Engineer { get; set; } = default!;
       

        

    }
}

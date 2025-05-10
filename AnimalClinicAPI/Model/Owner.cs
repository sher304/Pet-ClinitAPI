using System.ComponentModel.DataAnnotations;

namespace AnimalClinicAPI.Model;

public class Owner
{
    public int  id { get; set; }
    [MaxLength(100)]
    public String firstName { get; set; }
    [MaxLength(100)]
    public String lastName { get; set; }
}
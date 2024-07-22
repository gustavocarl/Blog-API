using System.ComponentModel.DataAnnotations;

namespace PostCentral.Models;

public abstract class Base
{
    [Key]
    public Guid Id { get; set; }
}
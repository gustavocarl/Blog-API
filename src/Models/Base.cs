using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Blog_API.Models;

public abstract class Base
{
    [Key]
    public Guid Id { get; set; }
}

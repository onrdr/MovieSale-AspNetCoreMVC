using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }

    public int MovieId { get; set; }
    [ForeignKey(nameof(MovieId))]
    public Movie Movie { get; set; }

    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order Order{ get; set; }
}


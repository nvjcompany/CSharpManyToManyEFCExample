using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp14.Models
{
  public class User
  {
    public User()
    {
      this.Orders = new List<Order>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
  }
}

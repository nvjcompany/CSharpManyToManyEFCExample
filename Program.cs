using ConsoleApp14.Database;
using ConsoleApp14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp14
{
  class Program
  {
    static void Main(string[] args)
    {
      var context = new ApplicationDbContext();
      var users = context.Users
        .Include(x => x.Orders)
        .ThenInclude(x => x.Product)
        .ToList();

      Console.ReadLine();
    }
  }
}

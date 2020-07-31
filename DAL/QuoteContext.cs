using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiPractice.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPractice.DAL
{
    public class QuoteContext : DbContext
    {
        public QuoteContext() : base("DefaultConnection")//name of conn string,dafult is class name
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DbSet<Quote> Quotes { get; set; }
    }
    
}
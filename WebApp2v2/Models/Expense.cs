using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2v2.Models
{

    public enum Type
    {
        food,
        utilities,
        transportation,
        outing,
        groceries,
        clothes,
        electronics,
        other
    }
    public class Expense
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public long Sum { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Currency { get; set; }

        public Type Type { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
        

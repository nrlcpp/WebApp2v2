﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2v2.Models;

namespace WebApp2v2.Dto
{
    public class ExpenseDtoDetail
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long Sum { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public Models.Type Type { get; set; }
        public IEnumerable<CommentDtoDetail> Comments { get; set; }


        public static ExpenseDtoDetail GetDtoFromExpense(Expense expense)
        {
            return new ExpenseDtoDetail
            {
                Id = expense.Id,
                Description = expense.Description,
                Sum = expense.Sum,
                Location = expense.Location,
                Date = expense.Date,
                Currency = expense.Currency,
                Type = expense.Type,
                Comments = expense.Comments.Select(c => new CommentDtoDetail()
                {
                    Text = c.Text,
                })

            };
        }
    }
}

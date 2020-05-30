using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2v2.Models;

namespace WebApp2v2.Dto
{
    public class CommentDtoGet
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public long ExpenseId { get; set; }


        public static CommentDtoGet GetDtoFromComment(Comment comment)
        {
            return new CommentDtoGet
            {
                Id = comment.Id,
                Text = comment.Text,
                Important = comment.Important,
                ExpenseId = comment.ExpenseId
            };
        }
    }
}

using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class Program
    {
        static void Main(string[] args)
        {
            BookModel[] newBookList = {
                new BookModel { BookName = "Economy 1", BookPrice = 62, AuthorID = 1 },
                new BookModel { BookName = "Economy 2", BookPrice = 63, AuthorID = 1 }
            };

            BookManager.InsertBookByDbSet(newBookList[0]);
            BookManager.InsertBookBySP(newBookList[1]);
        }
    }
}

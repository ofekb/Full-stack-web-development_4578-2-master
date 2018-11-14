using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookManager
    {

        //the UIL will call this function and send a BOL object
        //the BLL will add the object t the EF
        //and save the changes to the DAL
        public static void InsertBookByDbSet(BookModel newBook)
        {
            using(BookStoreEntities ef=new BookStoreEntities())
            {

                ef.Books.Add(new Book
                {
                    BookName = newBook.BookName,
                    BookPrice = newBook.BookPrice,
                    AuthorID = newBook.AuthorID
                });
               
                ef.SaveChanges();
            }
        }



        public static void InsertBookBySP(BookModel newBook)
        {
            using (BookStoreEntities ef = new BookStoreEntities())
            {
              
                //here we use the SP that we created in the DB
                ef.InsertBook(newBook.BookName, newBook.BookPrice, newBook.AuthorID);
                ef.SaveChanges();
            }
        }
    }
}

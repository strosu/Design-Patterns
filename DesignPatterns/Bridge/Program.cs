using System;
using System.Collections;
using System.Collections.Generic;
using Bridge.After;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Manuscript> documents = new List<Manuscript>();

            var faq = new FAQ()
            {
                Title = "faqTitle"
            };

            faq.Questions.Add("q1");
            faq.Questions.Add("q2");

            documents.Add(faq);

            var book = new Book
            {
                Text = "bookText",
                Title = "bookTitle",
                Author = "bookAuthor"
            };

            documents.Add(book);

            var paper = new TermPaper
            {
                Text = "paperText",
                References = "paperReferences",
                Student = "pStudent",
                Class = "pClass"
            };

            documents.Add(paper);

            foreach (var doc in documents)
            {
                doc.Print();
            }

            Console.ReadLine();
        }

        //static void Initial(string[] args)
        //{
        //    var faq = new FAQ()
        //    {
        //        Title = "faqTitle"
        //    };

        //    faq.Questions.Add("q1");
        //    faq.Questions.Add("q2");

        //    var book = new Book
        //    {
        //        Text = "bookText",
        //        Title = "bookTitle",
        //        Author = "bookAuthor"
        //    };

        //    var paper = new TermPaper
        //    {
        //        Text = "paperText",
        //        References = "paperReferences",
        //        Student = "pStudent",
        //        Class = "pClass"
        //    };

        //    faq.Print();
        //    book.Print();
        //    paper.Print();

        //    Console.ReadLine();
        //}
    }
}

using System;

namespace Bridge.After
{
    public class Book : Manuscript
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Text{ get; set; }

        public override void Print()
        {
            Console.WriteLine(Title);

            Console.WriteLine(_formatter.Format("Title", Title));
            Console.WriteLine(_formatter.Format("Author", Author));
            Console.WriteLine(_formatter.Format("Text", Text));
        }

        public Book(IFormatter formatter) : base(formatter)
        {
        }
    }
}
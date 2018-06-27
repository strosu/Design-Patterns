using System;

namespace Bridge.After
{
    public class TermPaper : Manuscript
    {
        public string Class { get; set; }

        public string Student{ get; set; }

        public string Text { get; set; }

        public string References { get; set; }

        public override void Print()
        {
            Console.WriteLine(_formatter.Format("Class", Class));
            Console.WriteLine(_formatter.Format("Student", Student));
            Console.WriteLine(_formatter.Format("Text", Text));
            Console.WriteLine(_formatter.Format("References", References));
        }

        public TermPaper(IFormatter formatter) : base(formatter)
        {
        }
    }
}
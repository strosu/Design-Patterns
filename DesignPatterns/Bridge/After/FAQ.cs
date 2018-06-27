using System;
using System.Collections.Generic;

namespace Bridge.After
{
    public class FAQ : Manuscript
    {
        public string Title { get; set; }

        public IList<string> Questions { get; set; } = new List<string>();

        public override void Print()
        {
            Console.WriteLine(_formatter.Format("Title", Title));
            foreach (var question in Questions)
            {
                Console.WriteLine(_formatter.Format("question", question));
            }
        }

        public FAQ(IFormatter formatter) : base(formatter)
        {
        }
    }
}
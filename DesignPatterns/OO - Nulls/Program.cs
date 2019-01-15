using System;
using System.Linq;
using OO___Nulls.Common;

namespace OO___Nulls
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            var now = DateTime.Now;

            article.MoneyBackGuarantee.Claim(now, () => Console.WriteLine("money back"));
            article.ExpressTimeLimitedWarranty.Claim(now, () => Console.WriteLine("repair"));
        }

        static void Main(string[] args)
        {
            Warranty moneyBack = new TimeLimitedWarranty(DateTime.Today, TimeSpan.FromDays(1));
            Warranty express = new TimeLimitedWarranty(DateTime.Today, TimeSpan.FromDays(10));
            Warranty circuit = new TimeLimitedWarranty(DateTime.Today, TimeSpan.FromDays(100));

            SoldArticle3 article = new SoldArticle3(moneyBack, express, new DefaultRules());
            article.InstallCircuitry(new Part(DateTime.Now), circuit);
            article.NotOperational();
            article.Claim(() => Console.WriteLine("blabla"));
            Console.ReadLine();

            //var sellingDate = DateTime.Now.AddDays(-10);
            //var moneyBack = TimeSpan.FromDays(11);
            //var warranty = TimeSpan.FromDays(365);
            
            //var moneyBackWarranty = new TimeLimitedWarranty(sellingDate, moneyBack);
            //var extendedWarranty = new TimeLimitedWarranty(sellingDate, warranty);

            //var article = new SoldArticle(moneyBackWarranty, extendedWarranty);
            //ClaimWarranty(article);

            //var article2 = new SoldArticle(moneyBackWarranty, VoidWarranty.Instance);
            //ClaimWarranty(article2);

            //var longWarranty = new LifeTimeWarranty(sellingDate);
            //var article3 = new SoldArticle(longWarranty, VoidWarranty.Instance);
            //ClaimWarranty(article3);

            //var some = Option<string>.Some("somevalue");
            //var some2 = Option<string>.Some("so");
            //some
            //    .When(x => x.Length > 3).Do(s => Console.WriteLine($"{s} long"))
            //    .WhenSome().Do(s => Console.WriteLine($"{s} short"))
            //    .WhenNone(() => Console.WriteLine("missing"))
            //    .Execute();

            //string label =
            //    some.When(s => s.Length > 3).MapTo(s => s.Substring(0, 3) + ".")
            //        .WhenSome().MapTo(s => s)
            //        .WhenNone().MapTo("<empty>")
            //        .Map();

            //some.Where(x => x.Length > 3).Do(_ => Console.WriteLine("more than 3 characters"));
            //some2.Where(x => x.Length > 3).Do(_ => Console.WriteLine("more than 3 characters"));

            Console.ReadLine();
        }
    }
}

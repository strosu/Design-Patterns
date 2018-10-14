﻿using System;
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

            var sellingDate = DateTime.Now.AddDays(-10);
            var moneyBack = TimeSpan.FromDays(11);
            var warranty = TimeSpan.FromDays(365);
            
            var moneyBackWarranty = new TimeLimitedWarranty(sellingDate, moneyBack);
            var extendedWarranty = new TimeLimitedWarranty(sellingDate, warranty);

            var article = new SoldArticle(moneyBackWarranty, extendedWarranty);
            ClaimWarranty(article);

            var article2 = new SoldArticle(moneyBackWarranty, VoidWarranty.Instance);
            ClaimWarranty(article2);

            var longWarranty = new LifeTimeWarranty(sellingDate);
            var article3 = new SoldArticle(longWarranty, VoidWarranty.Instance);
            ClaimWarranty(article3);

            var some = Option<string>.Some("somevalue");
            some
                .When(x => x.Length > 3).Do(s => Console.WriteLine($"{s} long"))
                .WhenSome().Do(s => Console.WriteLine($"{s} short"))
                .WhenNone(() => Console.WriteLine("missing"))
                .Execute();

            string label =
                some.When(s => s.Length > 3).MapTo(s => s.Substring(0, 3) + ".")
                    .WhenSome().MapTo(s => s)
                    .WhenNone().MapTo("<empty>")
                    .Map();

            Console.ReadLine();
        }
    }
}

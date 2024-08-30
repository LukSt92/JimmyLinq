﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    public static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
        {
            if (prices[comic.Issue] > 100)
                return PriceRange.Expensive;
            else
                return PriceRange.Cheap;
        }
        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(
                              IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            var grouped = comics.OrderBy(comic => prices[comic.Issue]).GroupBy(comic => CalculatePriceRange(comic, prices));
            //IEnumerable<IGrouping<PriceRange, Comic>> grouped =
            //    from comic in comics
            //    orderby prices[comic.Issue]
            //    group comic by CalculatePriceRange(comic, prices) into priceGroup
            //    select priceGroup;
            return grouped;
        }
        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            //var joined =
            //    from comic in comics
            //    orderby comic.Issue
            //    join review in reviews
            //    on comic.Issue equals review.Issue
            //    select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";

            var joined = comics.OrderBy(comic => comic.Issue).Join(reviews, comic => comic.Issue, review => review.Issue,
                (comic, review) => $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}");

            return joined;
        }

    }
}

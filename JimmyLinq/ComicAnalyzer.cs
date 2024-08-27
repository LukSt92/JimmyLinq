using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic)
        {
            if (Comic.Prices[comic.Issue] > 100)
                return PriceRange.Expensive;
            else
                return PriceRange.Cheap;
        }
        public static IEnumerable<object> GroupComicsByPrice(IEnumerable<Comic> catalog, IReadOnlyDictionary<int, decimal> prices)
        {
            var group =
                from comic in catalog
                orderby prices[comic.Issue]
                group comic by CalculatePriceRange(comic) into grouped
                select grouped;
            return (IEnumerable<IGrouping<PriceRange, Comic>>)group;
        }
        public static IEnumerable<object> GetReviews(IEnumerable<Comic> catalog, IEnumerable<Review> reviews)
        {
            var first =
                from comic in catalog
                orderby comic.Issue
                join review in reviews
                on comic.Issue equals review.Issue
                select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
            return first;
        }

    }
}

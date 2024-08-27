using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    class Comic
    {
        public static readonly IEnumerable<Review> Reviews = new[] {
            new Review() { Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
            new Review() { Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
            new Review() { Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
            new Review() { Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
            new Review() { Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 },
};
    }
}

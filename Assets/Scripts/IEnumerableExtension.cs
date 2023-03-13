using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class IEnumerableExtension
    {
        public static void Shuffle<T>(this Stack<T> stack)
        {
            Random rng = new Random();
            stack = new Stack<T>(stack.OrderBy(t => rng.Next()));
        }
    }
}

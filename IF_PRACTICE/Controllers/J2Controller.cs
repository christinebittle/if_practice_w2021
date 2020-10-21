using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IF_PRACTICE.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// Standard Dice Game Solution. Uses nested loops.
        /// </summary>
        /// <param name="n">A die with 'n' sides</param>
        /// <param name="m">A die with 'm' sides</param>
        /// <param name="goal">A goal number to reach.</param>
        /// <returns>list of {counter, iterations}. {counter} describes how many ways an n and m sided die can be rolled to a {goal}. {iterations} describes how many steps the program needed to take to find a solution.</returns>
        [Route("api/J2/DiceGameStandard/{n}/{m}")]
        [HttpGet]
        public List<int> DiceGameStandard(int n, int m, int goal)
        {
            int counter = 0;
            int iterations = 0;

            //validation happens before logic
            bool isGameValid = n > 0 && m > 0 && ((m + n) >= goal);
            if (!isGameValid) return new List<int> { 0, 0 };

            for(int i=1; i<=n; i++)
            {
                for(int j=1; j<=m; j++)
                {
                    if (i + j == goal) counter++;
                    iterations++;
                }
            }
            return new List<int>{counter,iterations};
        }

        /// <summary>
        /// Standard Dice Game Solution. Uses nested loops.
        /// </summary>
        /// <param name="n">A die with 'n' sides</param>
        /// <param name="m">A die with 'm' sides</param>
        /// <param name="goal">A goal number to reach.</param>
        /// <returns>list of {counter, iterations}. {counter} describes how many ways an n and m sided die can be rolled to a {goal}. {iterations} describes how many steps the program needed to take to find a solution.</returns>
        //optimized dice game solution
        [Route("api/J2/DiceGameOptimized/{n}/{m}")]
        [HttpGet]
        public List<int> DiceGameOptimized(int n, int m, int goal)
        {
            int counter = 0;
            int iterations = 0;

            //validation happens before logic
            bool isGameValid = n > 0 && m > 0 && ((m + n) >= goal);
            if (!isGameValid) return new List<int> { 0, 0 };

           
            //Start at the highest possible lower bound
            int lowerBound = Math.Max(1, (goal-m));
            //Continue until the lowest possible upper bound
            int upperBound = Math.Min(n, (goal-1));

            for (int i = lowerBound; i <= upperBound; i++)
            {
                //only proceed if the combination is possible
                if(i+m >= goal)
                {
                    //if it is possible, there is only one combination which works (m between 1 and m)
                    counter++;
                    
                }
                iterations++;
            }
            return new List<int>{ counter, iterations };
        }

        /// <summary>
        /// Standard Dice Game Solution. Uses nested loops.
        /// </summary>
        /// <param name="n">A die with 'n' sides</param>
        /// <param name="m">A die with 'm' sides</param>
        /// <param name="goal">A goal number to reach.</param>
        /// <returns>list of {counter, iterations}. {counter} describes how many ways an n and m sided die can be rolled to a {goal}. {iterations} describes how many steps the program needed to take to find a solution.</returns>
        //Dice game solution in fewest possible steps.
        [Route("api/J2/DiceGameOptimal/{n}/{m}")]
        [HttpGet]
        public List<int> DiceGameOptimal(int n, int m, int goal)
        {

            bool isGameValid = n > 0 && m > 0 && (m + n) >= goal;
            if (!isGameValid) return new List<int> { 0, 0 };

            //checks if the combination is even possible
            if (n + m < goal) return new List<int> { 0, 0 };
            //Start at the highest possible lower bound
            int lowerBound = Math.Max(1, (goal - m));
            //Continue until the lowest possible upper bound
            int upperBound = Math.Min(n, (goal - 1));

            //The number of solutions is the number of integers between {upperbound} and {lowerbound}
            int solutions = upperBound - lowerBound + 1;
            return new List<int> { solutions, 1 };

        }
    }
}

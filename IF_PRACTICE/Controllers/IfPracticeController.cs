using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace IF_PRACTICE.Controllers
{
    public class IfPracticeController : ApiController
    {
        


        /// <summary>
        /// Adds three numbers together 
        /// </summary>
        /// <param name="num1">The first number to add</param>
        /// <param name="num2">The second number to add</param>
        /// <param name="num3">The third number to add</param>
        /// <returns>The three numbers added together</returns>
        /// <example>
        ///     GET : /api/IfPractice/Sum/10/100/10      ->      120
        /// </example>
        [HttpGet]
        [Route("api/IfPractice/Sum/{num1}/{num2}/{num3}")]
        public int Sum(int num1, int num2, int num3)
        {
            int sum = num1 + num2 + num3;
            return sum;
        }



        /// <summary>
        /// Calculates the product of 3 numbers
        /// </summary>
        /// <param name="product1">The first product</param>
        /// <param name="product2">The second product</param>
        /// <param name="product3">The third product</param>
        /// <returns>The three numbers multiplied together</returns>
        /// <example>
        /// GET : /api/IfPractice/Product/10/10/10       ->      1000
        /// </example>
        /// <example>
        /// GET : /api/IfPractice/Product/0/10/20        ->      0
        /// </example>
        [HttpGet]
        [Route("api/IfPractice/Product/{product1}/{product2}/{product3}")]
        public int Product(int product1, int product2, int product3)
        {
            int product = product1 * product2 * product3;
            return product;
        }


        
        /// <summary>
        /// Determines if 3 angles can make a triangle.
        /// </summary>
        /// <param name="angle1">The first angle of the triangle.</param>
        /// <param name="angle2">The second angle of the triangle.</param>
        /// <param name="angle3">The third angle of the triangle.</param>
        /// <returns>TRUE if the angles can make a triangle. FALSE otherwise.</returns>
        /// <example>
        ///     GET : /api/IfPractice/ValidTriangle/60/60/60 -> TRUE
        /// </example>
        /// <example>
        ///     GET : /api/IfPractice/ValidTriangle/100/50/50 -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/IfPractice/ValidTriangle/{angle1}/{angle2}/{angle3}")]
        public bool ValidTriangle(decimal angle1, decimal angle2, decimal angle3)
        {
            bool isValidTriangle;
            if (angle1 <= 0 || angle2 <= 0 || angle3 <= 0)
            {
                isValidTriangle = false;
                return isValidTriangle;
            }
            decimal sum = angle1 + angle2 + angle3;

            if (sum == 180) isValidTriangle = true;
            else isValidTriangle = false;

            return isValidTriangle;
        }


        
        /// <summary>
        /// Determines if a number is divisible by another number
        /// </summary>
        /// <param name="dividend">The number to divide</param>
        /// <param name="divisor">The number to divide by</param>
        /// <returns>Returns TRUE if the dividend is divisible by the divisor, FALSE if not.</returns>
        /// <example>
        ///     GET : /api/IfPractice/Divisible/10/2        ->       TRUE
        /// </example>
        /// <example>
        ///     GET : /api/IfPractice/Divisible/15/5        ->       TRUE
        /// </example>
        /// <example>
        ///     GET : /api/IfPractice/Divisible/23/3        ->       FALSE
        /// </example>
        [HttpGet]
        [Route("api/IfPracticeB/Divisor/{dividend}/{divisor}")]
        public bool Divisible(int dividend, int divisor)
        {
            int remainder = dividend % divisor;
            if (remainder == 0) return true;
            else return false;
        }

        /// <summary>
        /// Determines the length of the hypotenuse of a right-angled triangle.
        /// </summary>
        /// <param name="sideA">The length of side A</param>
        /// <param name="sideB">The length of side B</param>
        /// <returns>The length of the hypotenuse</returns>
        /// <example>
        ///     eg. GET api/example/pythagorean/9/12	-> 15
        /// </example>
        /// <example>
        ///     GET api/example/pythagorean/9/10	-> 13.453
        /// </example>
        [HttpGet]
        [Route("api/IfPracticeB/Pythagorean/{sideA}/{sideB}")]
        public double Pythagorean(double sideA, double sideB)
        {
            //We must have positive numbers for our actual triangle sides
            if (sideA > 0 && sideB > 0)
            {
                double hypotenuse = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
                return hypotenuse;
            }
            else
            {
                //Not a valid triangle
                return 0;
            }
        }

        /// <summary>
        /// This is a function which calculates the power of two integers
        /// </summary>
        /// <param name="numberBase">Base Number</param>
        /// <param name="numberExponent">Exponent Number</param>
        // <returns>numberBase ^ numberExponent</returns>
        /// <example>
        ///     GET : api/IfPractice/Power/2/3     ->      8
        /// </example>
        /// <example>
        //      GET : api/IfPractice/Power/2/4     ->      16
        //  </example>
        [HttpGet]
        [Route("api/IfPracticeB/Power/{numberBase}/{numberExponent}")]
        public double Power(double numberBase, double numberExponent)
        {
            double power = Math.Pow(numberBase, numberExponent);
            return power;
        }

        /// <summary>
        /// Calculates the number of coins. Returns TRUE if we have enough to buy a toy for $10.50CAD. Returns FALSE otherwise.
        /// </summary>
        /// <param name="Nickels">The number of Nickels</param>
        /// <param name="Dimes">The number of Dimes</param>
        /// <param name="Quarters">The number of Quarters</param>
        /// <param name="Loonies">The number of Loonies</param>
        /// <param name="Toonies">The number of Toonies</param>
        /// <returns>If the total amount of money is enough to purchase a toy worth $10.50CAD</returns>
        /// <example>
        ///     GET api/IfPractice/CoinComputer/0/0/0/15/0		-> TRUE
        /// </example>
        /// <example>
        ///     GET api/IfPractice/CoinComputer/20/0/0/1/1		-> FALSE
        /// </example>
        /// <example>
        ///     GET api/IfPractice/CoinComputer/100/20/2/4/0	-> TRUE
        /// </example>
        [HttpGet]
        [Route("api/IfPractice/CoinComputer/{Nickels}/{Dimes}/{Quarters}/{Loonies}/{Toonies}")]
        public bool CoinComputer(int Nickels, int Dimes, int Quarters, int Loonies, int Toonies)
        {
            //Declare value of Toy as well as value of coins
            decimal ToyCost = 10.50M;
            decimal NickelValue = 0.05M;
            decimal DimeValue = 0.10M;
            decimal QuarterValue = 0.25M;
            decimal LoonieValue = 1.00M;
            decimal ToonieValue = 2.00M;

            //value is the sum of (#coins * coinsvalue)
            decimal TotalAmount = Nickels * NickelValue
                + Dimes * DimeValue
                + Quarters * QuarterValue
                + Loonies * LoonieValue
                + Toonies * ToonieValue;

            //Compare amount with the Toy Cost
            if (TotalAmount >= ToyCost) return true;
            else return false;
        }

        /// <summary>
        /// Determines the quadrant of an (x,y) coordinate. Returns 0 if the point is not on any quadrant.
        /// </summary>
        /// <param name="x">The x value of the coordinate</param>
        /// <param name="y">The y value of the coordinate</param>
        /// <returns>The quadrant the coordinate belongs to.</returns>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/1/1	-> 	1
        /// </example>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/-1/-1	->	3
        /// </example>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/1/-1	->	4
        /// </example>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/0/10	->	0
        /// </example>
        [HttpGet]
        [Route("api/IfPractice/PointQuadrant/{x}/{y}")]
        public int PointQuadrant(int x, int y)
        {
            //Value which we will return indicating the quadrant #
            int quadrant;

            //top right quadrant
            if (x > 0 && y > 0) quadrant = 1;
            //top left quadrant
            else if (x < 0 && y > 0) quadrant = 2;
            //bottom left quadrant
            else if (x < 0 && y < 0) quadrant = 3;
            //bottom right quadrant
            else if (x > 0 && y < 0) quadrant = 4;
            //point lies on either x-axis (x=0,y), y-axis (x,y=0), or both (x=0,y=0)
            else quadrant = 0;

            return quadrant;
        }

        /// <summary>
        /// Determines the number of quadrants that a line segment passes through
        /// NOTE: a line can only pass through up to 3 quadrants.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point</param>
        /// <param name="y1">The y-coordinate of the first point</param>
        /// <param name="x2">The x-coordinate of the second point</param>
        /// <param name="y2">The y-coordinate of the second point</param>
        /// <returns>The number of quadrants the line passes through.</returns>
        /// <example>
        ///     GET api/IfPractice/LineQuadrant/1/1/-1/-1		->	2
        ///     Explanation: https://www.wolframalpha.com/input/?i=line+%281%2C1%29%2C+%28-1%2C-1%29
        /// </example>
        /// <example>
        ///     api/IfPractice/LineQuadrant/-10/5/10/5 		->	2
        ///     Explanation: https://www.wolframalpha.com/input/?i=line+%28-10%2C5%29%2C+%2810%2C5%29
        /// </example>
        /// <example>
        ///     GET api/IfPractice/LineQuadrant/1/2/3/4		->	1
        ///     Explanation: https://www.wolframalpha.com/input/?i=line+%281%2C2%29%2C+%283%2C4%29
        /// </example>
        /// <example>
        ///     GET api/IfPractice/LineQuadrant/-6/-10/2/20		->	3
        ///     Explanation: https://www.wolframalpha.com/input/?i=line+%28-6%2C-10%29%2C+%282%2C20%29
        /// </example>
        [HttpGet]
        [Route("api/IfPractice/LineQuadrant/{x1}/{y1}/{x2}/{y2}")]
        public int LineQuadrant(int x1, int x2, int y1, int y2)
        {
            int totalQuadrants;

            //If both points are the same, this is not a valid line
            if (x1 == x2 && y1 == y2)
            {
                totalQuadrants = 0;
                //return totalQuadrants;
            }
            else
            {
                //Determines if the line is horizontal
                bool isLineHorizontal = y1 == y2;
                //Determines if the line is vertical
                bool isLineVertical = x1 == x2;
                //line must be diagonal if it is (NOT(vertical) AND NOT(horizontal))
                bool isLineDiagonal = !isLineVertical && !isLineHorizontal;

                //i.e. is the sign in front of x1 and x2 different? (x1>0 and x2<0) or (x1<0 and x2>0)
                bool isXOpposite = (x1 > 0 && x2 < 0) || (x1 < 0 && x2 > 0);
                //i.e. is the sign in front of y1 and y2 different? (y1>0 and y2<0) or (y1<0 and y2>0)
                bool isYOpposite = (y1 > 0 && y2 < 0) || (y1 < 0 && y2 > 0);


                // Note that the line cannot both be horizontal and vertical (no longer a line)
                // 3 possibilities: Horizontal, Vertical, Diagonal.

                // Line is horizontal
                if (isLineHorizontal)
                {
                    Debug.WriteLine("Line is Horizontal");
                    //Does the line travel on exactly the x-axis?
                    if (y1 == 0 && y2 == 0)
                    {
                        //If so, the line does not pass through any quadrants.
                        totalQuadrants = 0;
                        //return totalQuadrants;
                    }
                    //Are x1 and x2 on opposite sides of the y axis?
                    else if (isXOpposite)
                    {
                        // If so, the line passes through two quadrants. 
                        // either (3 and 4) or (1 and 2)
                        totalQuadrants = 2;
                        //return totalQuadrants;
                    }
                    else
                    {
                        // In all other situations, the line only passes through one quadrant.
                        // either 1 or 2 or 3, or 4
                        totalQuadrants = 1;
                        //return totalQuadrants;
                    }
                }
                //Line is vertical
                if (isLineVertical)
                {
                    Debug.WriteLine("Line is Vertical.");
                    //Does the line travel on exactly the x-axis?
                    if (x1 == 0 && x2 == 0)
                    {
                        //If so, the line does not pass through any quadrants.
                        totalQuadrants = 0;
                        //return totalQuadrants;
                    }
                    //Are y1 and y2 on opposite sides of the x axis?
                    else if (isYOpposite)
                    {
                        // If so, the line passes through two quadrants.
                        // either (1 and 4) or (2 and 3)
                        totalQuadrants = 2;
                        //return totalQuadrants;
                    }
                    else
                    {
                        //In all other situations, the line only passes through one quadrant.
                        // either 1 or 2 or 3 or 4
                        totalQuadrants = 1;
                        //return totalQuadrants;
                    }
                }
                //Line must be diagonal.
                else
                {
                    Debug.WriteLine("Line is Diagonal");
                    // only compute slope if you know the line is diagonal!
                    // we know y2!=y1 and x2!=x1 so this will always produce a positive or negative number.
                    decimal slope = (y2 - y1) / (x2 - x1);

                    // Solve for "B", the y-intercept.
                    // y = m * x + b
                    // y1 = slope*x1 + b
                    // y1 - slope*x1 = b

                    //This could be solved by providing the points of x2 and y2 as well.
                    decimal yIntercept = y1 - slope * x1;

                    //Does the line intercept with the origin (0,0)?
                    //Does y=0 when x=0?
                    if (slope*0 + yIntercept == 0)
                    {
                        // If so, the line passes through the origin
                        // Because the line is also diagonal, it can only pass through 2 quadrants
                        // Either (1 and 3) or (2 and 4)
                        totalQuadrants = 2;
                        //return totalQuadrants;
                    }
                    // Do the two points exist in the same quadrant?
                    // i.e. is x not opposite and is y not opposite?
                    // note: you could also use the "PointQuadrant" method here and compare the quadrants of each point.
                    else if (!isXOpposite && !isYOpposite)
                    {
                        Debug.WriteLine("both points are 'same' quadrant");
                        totalQuadrants = 1;
                        //return totalQuadrants;
                    }
                    //Meaning
                    // - Line is Diagonal
                    // - Line does NOT pass through origin
                    // - Both points exist in DIFFERENT quadrants
                    // - Does it elapse 2 quadrants or 3?
                    else
                    {
                        int point1Quadrant = PointQuadrant(x1, y1);
                        int point2Quadrant = PointQuadrant(x2, y2);

                        
                        //if the difference is 1 or -1, the quadrants are adjacent (neighbors)
                        //if the difference is 2 or -2, the quadrants are opposites (non-adjacent)
                        int quadrantDifference = Math.Abs(point1Quadrant - point2Quadrant);

                        //Are the quadrants neighbors?
                        if (quadrantDifference != 2)
                        {
                            // if so, the line passes through 2 quadrants
                            // either (1 and 2) or (2 and 3) or (3 and 4) or (1 and 4) 
                            totalQuadrants = 2;
                            //return totalQuadrants;
                        }
                        //Are the quadrants opposite?
                        else
                        {
                            // if so, the line passes through 3 quadrants
                            // either (4 and 1 and 2) or (1 and 2 and 3) or (2 and 3 and 4) or (3 and 4 and 1)
                            totalQuadrants = 3;
                            //return totalQuadrants;
                        }
                    }
                }
            }

            // link to wolfram alpha searching "line segment (x1,y1),  (x2,y2)"
            string evidence = "https://www.wolframalpha.com/input/?i=line+segment+%28" + x1 + "%2C" + y1 + "%29%2C+%28" + x2 + "%2C" + y2 + "%29";

            return totalQuadrants;
        }

    }
}

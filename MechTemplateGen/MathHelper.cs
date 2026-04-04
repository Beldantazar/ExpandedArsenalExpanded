using System;
using System.Collections.Generic;
using System.Text;

namespace MechTemplateGen
{
    internal class MathHelper
    {
        /// <summary>
        /// Rounds the value to the nearest increment. 
        /// Assumes mid-point rounding, value >= 0.5 rounds up, value < 0.5 rounds down.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="increment">Enter the increment value to round toward.</param>
        /// <returns>Returns the value rounded to the nearest increment value.</returns>
        public static decimal RoundToNearest(decimal Value, decimal increment)
        {
            // Returning the value rounded to the nearest increment value.
            return Math.Round(Value * DecimalMath.DecimalEx.Pow(increment, -1), 0) * increment;
        }

        /// <summary>
        /// Rounds down the value to the nearest increment. 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="increment">Enter the increment value to round down toward.</param>
        /// <returns>Returns the value rounded down to the nearest increment value.</returns>
        public static decimal FloorToNearest(decimal Value, decimal increment)
        {
            // Returning the value rounded down to the nearest increment value.
            return Math.Floor(Value * DecimalMath.DecimalEx.Pow(increment, -1)) * increment;
        }

        /// <summary>
        /// Rounds up the value to the nearest increment. 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="increment">Enter the increment value to round up toward.</param>
        /// <returns>Returns the value rounded up to the nearest increment value.</returns>
        public static decimal CeilingToNearest(decimal Value, decimal increment)
        {
            // Returning the value rounded up to the nearest increment value.
            return Math.Ceiling(Value * DecimalMath.DecimalEx.Pow(increment, -1)) * increment;
        }
    }
}

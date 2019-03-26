using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    /// <summary>
    /// usage
    /// ex.
    /// 
    /// value range: 1 ~ 100.
    /// trials: 5 times.
    /// RandomNumberGenerator generator = new RandomNumberGenerator(1, 100, 5)
    /// 
    /// try {
    ///     int number = generator.Generate()
    /// }
    /// catch (InvalidOperationException e)
    /// {
    /// }
    /// 
    /// </summary>
    class RandomNumberGenerator
    {
        private HashSet<int> numberSets = new HashSet<int>();
        private readonly int minValue;
        private readonly int maxValue;
        public readonly int maxTrials;
        private int trials = 0;

        public RandomNumberGenerator(int minValue, int maxValue, int maxTrials)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.maxTrials = maxTrials;
        }

        public int GetMaxTrial()
        {
            return maxTrials;
        }

        public int GetCurrentTrials()
        {
            return trials;
        }

        public void Clear()
        {
            numberSets.Clear();
            trials = 0;
        }

        /// <summary>
        /// Generate random number between minValue and maxValue.
        /// Every time it produce random number it will increase trial count.
        /// </summary>
        /// <param name="minValue">minimum value</param>
        /// <param name="maxValue">maximum value</param>
        /// <returns>unique random number which is not appeared in previouse trials, otherwise it will throw an exception</returns>
        public int Generate()
        {
            int value = -1;

            if (trials++ == maxTrials)
            {
                throw new InvalidOperationException("Cannot try more than max trials.");
            }

            do
            {
                value = new Random().Next(minValue, maxValue);

            } while (numberSets.Contains(value));

            numberSets.Add(value);

            return value;
        }
    }
}

// review by Mohamed

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
        // Global variables should start with _
        private HashSet<int> numberSets = new HashSet<int>();
        // we don't neet these variables, you can pass them instead to generate method.
        // i.e. Generate(int minValue, int maxValue)
        private readonly int minValue;
        private readonly int maxValue;

        // These are not needed since they are handled in the main class (Form1.cs)
        public readonly int maxTrials;
        private int trials = 0;
        // Not needed if we're gonna use just Generate method
        public RandomNumberGenerator(int minValue, int maxValue, int maxTrials)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.maxTrials = maxTrials;
        }
        // not needed
        public int GetMaxTrial()
        {
            return maxTrials;
        }
        // not needed
        public int GetCurrentTrials()
        {
            return trials;
        }
        // nover used, should be used inside Generate
        public void Clear()
        {
            numberSets.Clear();
            trials = 0;
        }


        //the summery specifies min and max parameters but they are not there 

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
            // no need for this check since it will performed in the main class
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

﻿/**
 * 
 * class GameOfNumbers
 * description: askdjfaksdfj
 * 
 * history: 
 *  - created: 29, Mar 2019
 *  - reviewed: 29, Mar 2019
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class CompareInputs
    {

        /// <summary>
        /// This method is comparing the actual number with the inputed number to check whether user has guess the correct number or how close his guess to the actual number
        /// </summary>
        /// <param name="inputedNumber"></param>
        /// <param name="actualNumber"></param>
        /// <returns></returns>
        public string IsTheSame(int inputedNumber, int actualNumber)
        {
            if (inputedNumber == actualNumber)
            {
                return "Success!!!";
            }
            else
            {
                // review no.1: bla bla
                if (inputedNumber==(actualNumber+1) || inputedNumber == (actualNumber - 1))
                {
                    return "Warmer!!!";
                }
                else if (inputedNumber < (actualNumber + 5) && inputedNumber > (actualNumber - 5))
                {
                    return "Warm!!!";
                }
                else if (inputedNumber < (actualNumber + 10) && inputedNumber > (actualNumber - 10))
                {
                    return "Cold!!!";
                }
                else
                {
                    return "Coldest!!!";
                }
            }
        }
    }
}

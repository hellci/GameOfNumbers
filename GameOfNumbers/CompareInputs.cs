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
        /// This method is comparing the actual number with the inputed number to check whether user has guess the correct number or how close his guess to correct number
        /// </summary>
        /// <param name="inputedNumber"></param>
        /// <param name="actualNumber"></param>
        /// <returns></returns>
        public string IsTheSame(int inputedNumber, int actualNumber)
        {
            string result=null;
            if (inputedNumber == actualNumber)
            {
                result = "Success!!!";
            }
            else
            {
               if(inputedNumber==(actualNumber+1) || inputedNumber == (actualNumber - 1))
                {
                    result = "Warmer!!!";
                }
                else if (inputedNumber < (actualNumber + 5) && inputedNumber > (actualNumber - 5))
                {
                    result = "Warm!!!";
                }
                else if (inputedNumber < (actualNumber + 10) && inputedNumber > (actualNumber - 10))
                {
                    result = "Cold!!!";
                }
                else
                {
                    result = "Coldest!!!";
                }
            }
            return result;
        }
    }
}

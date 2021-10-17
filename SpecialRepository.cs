using System;
namespace Assigment1
{
    public class SpecialRepository
    {
        public int registerFlagCheck(int output)
        {
            if(output ==0)
            {
                return 1;
            }
            else if(output < 0)
            {
                return 2;
            }
            else if(output > Int16.MaxValue || output < Int16.MinValue)
            {
                return 3;
            }
            
            return 4;
        }
        

        public int carryFlagCheck(int output)
        {
            if(output > Int16.MaxValue){
                return 0;
            }
            return 4;
        }
    }
}
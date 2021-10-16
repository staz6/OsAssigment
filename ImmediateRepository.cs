using System;
namespace Assigment1
{
    public  class ImmediateRepository 
    {
        public int[] movei(int[] gpr, int r1, int r2, int r3)
        { 
            gpr[r1]=r2+r3;
            return gpr;
        }
    }
}
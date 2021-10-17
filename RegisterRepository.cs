using System;

namespace Assigment1
{
    /// <summary>
    /// This whole code is pretty self explanatory i think
    /// each function takes the gpr , r1 index , r2 index
    /// and then return the update gpr back to main body.
    /// </summary>
    /// flagCheck != 4 ? flagCheck : gpr[9];
    public class RegisterRepository
    {
        private readonly SpecialRepository specialReo = new SpecialRepository();
        public int[] mov(int[] gpr,int r1,int r2)
        {
            gpr[r1]=gpr[r2];
            return gpr;
        }
        public int[] add(int[] gpr, int r1, int r2)
        { 
            int[] tmp = gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1]+gpr[r2]);
            int flagCheck=specialReo.registerFlagCheck(gpr[r1],tmp[r1],tmp[r2]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] sub(int[] gpr, int r1, int r2)
        { 
            int[] tmp =gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1]-gpr[r2]);
            int flagCheck=specialReo.registerFlagCheck(gpr[r1],tmp[r1],tmp[r2]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] mull(int[] gpr, int r1, int r2)
        { 
            int[] tmp = gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1]*gpr[r2]);
            int flagCheck=specialReo.registerFlagCheck(gpr[r1],tmp[r1],tmp[r2]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] div(int[] gpr, int r1, int r2)
        { 
            int[] tmp = gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1]/gpr[r2]);
            int flagCheck=specialReo.registerFlagCheck(gpr[r1],tmp[r1],tmp[r2]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] and(int[] gpr, int r1, int r2)
        { 
            int[] tmp =gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1] & gpr[r2]);
            int flagCheck=specialReo.registerFlagCheck(gpr[r1],tmp[r1],tmp[r2]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] or(int[] gpr, int r1, int r2)
        { 
            int[] tmp = gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1]|gpr[r2]);
            int flagCheck=specialReo.registerFlagCheck(gpr[r1],tmp[r1],tmp[r2]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
    }
}
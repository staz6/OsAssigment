using System;

namespace Assigment1
{
    /// <summary>
    /// Class for Register-register instruction
    /// This whole code is pretty self explanatory i think
    /// each function takes the gpr , r1 index , r2 index
    /// perform the operation define 
    /// and then return the update gpr back to main body.
    /// </summary>
    public class RegisterRepository
    {
        /// <summary>
        /// Special Repository contain the flagcheck function
        /// parameters => gpr[index] update gpr value
        /// gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];  => turnary operation, should have just make a global function for it forgot
        /// if flagCheck = 4, means nothing happend then do not change the flag register value
        /// other wise set flag register which gpr[9] = flagCheck return value
        /// </summary>
        /// <returns></returns>
        private readonly SpecialRepository specialRepo = new SpecialRepository();
        public int[] mov(int[] gpr,int r1,int r2)
        {
            gpr[r1]=gpr[r2];
            return gpr;
        }
        public int[] add(int[] gpr, int r1, int r2)
        { 
            
            gpr[r1]=Convert.ToInt16(gpr[r1]+gpr[r2]);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] sub(int[] gpr, int r1, int r2)
        { 
            
            gpr[r1]=Convert.ToInt16(gpr[r1]-gpr[r2]);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] mull(int[] gpr, int r1, int r2)
        { 
            
            gpr[r1]=Convert.ToInt16(gpr[r1]*gpr[r2]);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] div(int[] gpr, int r1, int r2)
        { 
            
            gpr[r1]=Convert.ToInt16(gpr[r1]/gpr[r2]);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] and(int[] gpr, int r1, int r2)
        { 
            int[] tmp =gpr;
            gpr[r1]=Convert.ToInt16(gpr[r1] & gpr[r2]);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] or(int[] gpr, int r1, int r2)
        { 
            
            gpr[r1]=Convert.ToInt16(gpr[r1]|gpr[r2]);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
    }
}
using System;
namespace Assigment1
{
    /// <summary>
    /// Class for imediate register instruction
    /// All the arthimetic imediate function do almost the same thing
    /// each function takes the gpr , r1 index ,  value 1 and value 2
    /// convert the value 1 and value 2 into their hex representaion
    /// perform the operation define 
    /// and then return the update gpr back to main body.
    /// </summar>
    public class ImmediateRepository
    {
        /// <summary>
        /// Explanation for special repository is written in RegisterRepository
        /// </summary>
        /// <returns></returns>
        private readonly SpecialRepository specialRepo = new SpecialRepository();

        public int[] movei(int[] gpr, int r1, int r2, int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1] = Convert.ToInt16(hexValue, 16);
            return gpr;
        }
        
        public int[] addi(int[] gpr,int r1,int r2,int r3)
        {
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] + Convert.ToInt16(hexValue,16);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] subi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] - Convert.ToInt16(hexValue,16);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] muli(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] * Convert.ToInt16(hexValue,16);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] divi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] / Convert.ToInt16(hexValue,16);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] andi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] & Convert.ToInt16(hexValue,16);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        public int[] ori(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            #pragma warning disable CS0675
            gpr[r1]=gpr[r1] | Convert.ToInt16(hexValue,16);
            int flagCheck=specialRepo.registerFlagCheck(gpr[r1]);
            gpr[9]= flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        /// <summary>
        /// Branc if equal to zero
        /// do the if check on flag 
        /// if true => add num to index
        /// else => return index + 2;
        /// </summary>
        /// <param name="index"> current program counter index</param>
        /// <param name="flag"> current flag value of gpr</param>
        /// <param name="num"> offset number</param>
        /// <returns>update program counter index</returns>

        public int bz(int index,int flag,int num)
        {
            if(flag==0) return index+num;
            return index+2;
        }
        /// <summary>
        /// Branc if not equal to zero
        /// do the if check on flag 
        /// if true => add num to index
        /// else => return index + 2;
        /// </summary>
        /// <param name="index"> current program counter index</param>
        /// <param name="flag"> current flag value of gpr</param>
        /// <param name="num"> offset number</param>
        /// <returns>update program counter index</returns>
        public int bnz(int index,int flag,int num)
        {
            if(flag!=0) return index+num;
            return index+2;
        }
        /// <summary>
        /// Branc if carray 
        /// do the if check on flag 
        /// if true => add num to index
        /// else => return index + 2;
        /// </summary>
        /// <param name="index"> current program counter index</param>
        /// <param name="flag"> current flag value of gpr</param>
        /// <param name="num"> offset number</param>
        /// <returns>update program counter index</returns>
        public int bc(int index,int flag,int num)
        {
            if(flag==0) return index+num;
            return index+2;
        }
        /// <summary>
        /// Branc if sign 
        /// do the if check on flag 
        /// if true => add num to index
        /// else => return index + 2;
        /// </summary>
        /// <param name="index"> current program counter index</param>
        /// <param name="flag"> current flag value of gpr</param>
        /// <param name="num"> offset number</param>
        /// <returns>update program counter index</returns>
        public int bs(int index,int flag,int num)
        {
            if(flag==2) return index+num;
            return index+2;
        }
        /// <summary>
        /// Jump
        /// just add the offset value to index
        /// </summary>
        /// <param name="index"> current program counter index</param>
        /// <param name="num"> offset number</param>
        /// <returns>update program counter index</returns>
        public int jump(int index,int num)
        {
            return index+num;
        }



    }
}
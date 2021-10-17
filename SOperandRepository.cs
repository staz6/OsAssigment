using System;
using System.Numerics;

namespace Assigment1
{
    /// <summary>
    /// Single operand class
    /// </summary>
    public class SOperandRepository
    {
        /// <summary>
        /// calling carryFlahCheck function of SpecialRepository in every function
        /// to update the value of flag register
        /// </summary>
        /// <returns></returns>
        private readonly SpecialRepository specialRepo = new SpecialRepository();
        /// <summary>
        /// Shift left
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">register to offset</param>
        /// <returns>updated gpr</returns>
        public int[] shl(int[] gpr,int r1)
        {
            gpr[r1] = gpr[r1] << 1;
            int flagCheck = specialRepo.carryFlagCheck(gpr[r1]);
            gpr[9] = flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        /// <summary>
        /// Shift right
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">register to offset</param>
        /// <returns>updated gpr</returns>
        public int[] shr(int[] gpr,int r1)
        {
            gpr[r1] = gpr[r1] >> 1;
            int flagCheck = specialRepo.carryFlagCheck(gpr[r1]);
            gpr[9] = flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        /// <summary>
        /// Rotate left
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">register to rotate</param>
        /// <param name="offset">rotate offset value</param>
        /// <returns>updated gpr</returns>
        public int[] rtl(int[] gpr,int r1,int offset)
        {
            gpr[r1] = Convert.ToInt16(BitOperations.RotateLeft(Convert.ToUInt16(gpr[r1]),offset));
            int flagCheck = specialRepo.carryFlagCheck(gpr[r1]);
            gpr[9] = flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        /// <summary>
        /// Rotate right
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">register to rotate</param>
        /// <param name="offset">rotate offset value</param>
        /// <returns>updated gpr</returns>
         public int[] rtr(int[] gpr,int r1,int offset)
        {
            gpr[r1] = Convert.ToInt16(BitOperations.RotateRight(Convert.ToUInt16(gpr[r1]),offset));
            int flagCheck = specialRepo.carryFlagCheck(gpr[r1]);
            gpr[9] = flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        /// <summary>
        /// Increment
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">register to increment</param>
        /// <returns>gpr</returns>
        public int[] inc(int[] gpr,int r1)
        {
            gpr[r1] = gpr[r1] + 1;
            int flagCheck = specialRepo.carryFlagCheck(gpr[r1]);
            gpr[9] = flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }
        /// <summary>
        /// decreament
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">register to decrease</param>
        /// <returns>gpr</returns>
        public int[] dec(int[] gpr,int r1)
        {
            gpr[r1] = gpr[r1] - 1;
            int flagCheck = specialRepo.carryFlagCheck(gpr[r1]);
            gpr[9] = flagCheck != 4 ? flagCheck : gpr[9];
            return gpr;
        }

    }
}
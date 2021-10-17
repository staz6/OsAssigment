using System;

namespace Assigment1
{
    /// <summary>
    /// Class for memory register instruction
    /// </summar>
    public class MemoryRepository
    {
        /// <summary>
        /// Movl
        /// load the memory value in the gpr[index]
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">r1 index</param>
        /// <param name="memoryValue">contain the value to be load, passing it while calling the function</param>
        /// <returns>updated gpr</returns>
        public int[] movl(int[] gpr,int r1,int memoryValue)
        {
            gpr[r1]=memoryValue;
            return gpr;
        }
        /// <summary>
        /// Movs
        /// store the gpr[index] value in the memory[index]
        /// </summary>
        /// <param name="gpr">gpr</param>
        /// <param name="r1">r1 index to access the value in gpr</param>
        /// <param name="memory"> memory array</param>
        /// <param name="index">memory index of where to placed the value</param>
        /// <returns>updated memory array</returns>
        public byte[] movs(int[] gpr,int r1, byte[] memory,int index)
        {
            memory[index]=Convert.ToByte(gpr[r1]);
            return memory;
        }
    }
}
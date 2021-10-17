namespace Assigment1
{
    public class MemoryRepository
    {
        public int[] movl(int[] gpr,int r1,int memoryValue)
        {
            gpr[r1]=memoryValue;
            return gpr;
        }
        public int[] movs(int[] gpr,int r1, int[] memory,int index)
        {
            memory[index]=gpr[r1];
            return memory;
        }
    }
}
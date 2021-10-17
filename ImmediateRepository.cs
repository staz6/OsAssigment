using System;
namespace Assigment1
{
    public class ImmediateRepository
    {
        private readonly SpecialRepository _repo = new SpecialRepository();

        public int[] movei(int[] gpr, int r1, int r2, int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1] = Convert.ToInt16(hexValue, 16);
            return gpr;
        }
        
        public int[] addi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] + Convert.ToInt16(hexValue,16);
            return gpr;
        }
        public int[] subi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] - Convert.ToInt16(hexValue,16);
            return gpr;
        }
        public int[] muli(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] * Convert.ToInt16(hexValue,16);
            return gpr;
        }
        public int[] divi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] / Convert.ToInt16(hexValue,16);
            return gpr;
        }
        public int[] andi(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            gpr[r1]=gpr[r1] & Convert.ToInt16(hexValue,16);
            return gpr;
        }
        public int[] ori(int[] gpr,int r1,int r2,int r3)
        {
            int[] tmp = gpr;
            string hexValue = r2.ToString("X") + r3.ToString("X");
            #pragma warning disable CS0675
            gpr[r1]=gpr[r1] | Convert.ToInt16(hexValue,16);
            return gpr;
        }

        public int bz(int index,int flag,int num)
        {
            if(flag==0) return index+num;
            return index+2;
        }
        public int bnz(int index,int flag,int num)
        {
            if(flag!=0) return index+num;
            return index+2;
        }
        public int bc(int index,int flag,int num)
        {
            if(flag==0) return index+num;
            return index+2;
        }
        public int bs(int index,int flag,int num)
        {
            if(flag==2) return index+num;
            return index+2;
        }
        public int jump(int index,int num)
        {
            return index+num;
        }



    }
}
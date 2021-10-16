using System;

namespace Assigment1
{   
    // 
    class Program
    {
        private readonly IRepository _repo;

        Program(IRepository repo)
        {
            _repo = repo;
        }
        static void Main(string[] args)
        {
            //memory array
            byte[] arr = {48, 1, 0, 1, 48, 2, 127, 255, 25, 1 ,2 ,243};
            //initialize program counter and set it to zero
            byte programCounter = 0;

            //grp array with default value 0
            byte[] gpr = new byte[15];
            for(int i=0;i<15;i++) gpr[i]=0;

            

           



        }
    }
}

using System;

namespace Assigment1
{

    /// <summary>
    /// git : https://github.com/staz6/OsAssigment.git
    /// OS : Linux, might have to run to dotnet restore if u want to run this on microsoft windows, since sometime csproj file get buggy
    /// Classes:
    /// RegisterRepository is for the register-register functions.
    /// ImmediateRepository is for imediate-register functions.
    /// Helper class is just for my sanity.
    /// </summary>
    public class Program
    {
        //memory array
        public static byte[] arr = { 48, 1, 0, 1, 48, 2, 127, 255, 25, 1, 2, 243 };

        //initialize program counter and set it to zero
        private static int programCounter = 0;
        public static int r1(){
            return programCounter+1;
        }
        public static int r2(){
            return programCounter+2;
        }
        public static int r3(){
            return programCounter+3;
        }
        public static string returnHex(int programCounter){
            return arr[programCounter].ToString("X");
        }
        
        public static void Main(string[] args)
        {

            //grp array with default value 0
            int[] gpr = new int[16];
            for (int i = 0; i < 16; i++) gpr[i] = 0;

            var immediateRepo = new ImmediateRepository();
            var registerRepo = new RegisterRepository();
            while (true)
            {
                if  (returnHex(programCounter) == Helper.MOVI)
                {
                    gpr = immediateRepo.movei(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    Console.WriteLine(OpCodeResponse.GetDefaultMessageForStatusCode(Helper.MOVI));
                    foreach(var value in gpr) Console.WriteLine(value);
                    Console.WriteLine();
                    
                }
                else if(returnHex(programCounter)==Helper.MUL){
                    gpr = registerRepo.mull(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    Console.WriteLine(OpCodeResponse.GetDefaultMessageForStatusCode(Helper.MUL));
                    foreach(var value in gpr) Console.WriteLine(value);
                    Console.WriteLine();
                }
                if(returnHex(programCounter)==Helper.END){
                    Console.WriteLine(OpCodeResponse.GetDefaultMessageForStatusCode(Helper.END));
                    break;
                }
            }






        }
    }
}

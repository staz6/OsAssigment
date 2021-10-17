using System;

namespace Assigment1
{

    /// <summary>
    /// git : https://github.com/staz6/OsAssigment.git
    /// OS : Linux, might have to run to dotnet restore if u want to run this on microsoft windows, since sometime csproj file get buggy
    /// Classes:
    /// RegisterRepository is for the register-register functions.
    /// ImmediateRepository is for imediate-register functions.
    /// Helper classes is just for my sanity.
    /// OpCodeResponse is just to handle console output 
    /// </summary>
    public class Program
    {
        //memory array
        public static byte[] arr = { 48, 1, 0, 1, 48, 2, 127, 255, 25, 1, 2, 243 };

        //gpr array, using int as datatype otherwise overflow will crash the program and I will have to use try catch block everywhere.
        public static int[] gpr = new int[16];

        //initialize program counter and set it to zero
        private static int programCounter = 0;

        /// <summary>
        /// Below 3 function return r1,r2,r3 
        /// The returnHex is to get the hex value of memory
        /// The log function is just to print output
        /// </summary>
        /// <returns>int r1, int r2, int r3, string hex(memory address), console output</returns>
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
        public static void log(string opCode)
        {
                    Console.WriteLine(OpCodeResponse.GetDefaultMessageForStatusCode(opCode));
                    foreach(var value in gpr) Console.WriteLine(value);
                    Console.WriteLine();
        }
        
        public static void Main(string[] args)
        {

            //initializing gpr with 0 values
            
            for (int i = 0; i < 16; i++) gpr[i] = 0;

            /// <summary>
            /// Object For Register repository and immediate repository
            /// </summary>
            var immediateRepo = new ImmediateRepository();
            var registerRepo = new RegisterRepository();
            while (true)
            {

                /// <summary>
                /// Start Register-register instruction 
                /// All the code does the same thing run the if state if returnHex(programCounter) === RHelper.value
                /// All register-register function take the same value gpr array, and register index
                /// Set gpr to the corresponding functio value in RegisterRepository 
                /// Increase program counter by 3
                /// then log the result using log function
                /// </summary>
                /// <param name="gpr,index r1,index r2"></param>
                /// <returns>gpr</returns>
                if(returnHex(programCounter)==RHelper.MOV){
                    gpr = registerRepo.mov(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.MOV);
                }
                else if(returnHex(programCounter) == RHelper.ADD){
                    gpr = registerRepo.add(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.ADD);
                }
                else if(returnHex(programCounter) == RHelper.SUB){
                    gpr = registerRepo.sub(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.SUB);
                }
                else if(returnHex(programCounter)==RHelper.MUL){
                    gpr = registerRepo.mull(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.MUL);
                }
                else if(returnHex(programCounter) == RHelper.DIV){
                    gpr = registerRepo.div(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.DIV);
                }
                else if(returnHex(programCounter) == RHelper.AND){
                    gpr = registerRepo.and(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.AND);
                }
                else if(returnHex(programCounter) == RHelper.OR){
                    gpr = registerRepo.or(gpr, arr[r1()], arr[r2()]);
                    programCounter=programCounter+3;
                    log(RHelper.OR);
                }
                /// <summary>
                /// End of Register-register function
                /// </summary>


                /// <summary>
                /// Start Register Immediate instructions
                /// All the code does the same thing run the if state if returnHex(programCounter) === IHelper.value
                /// All register-immediate function take the same value gpr array, and value
                /// Set gpr to the corresponding functio value in RegisterRepository
                /// Increase program counter by 3
                /// The log the result using log function
                /// </summary>
                /// <param name="gpr,r1,num 1 , num2"></param>
                /// <returns>int[] gpr</returns>
                else if  (returnHex(programCounter) == IHelper.MOVI)
                {
                    gpr = immediateRepo.movei(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.MOVI);
                    
                }
                else if  (returnHex(programCounter) == IHelper.ADDI)
                {
                    gpr = immediateRepo.addi(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.ADDI);
                    
                }
                else if  (returnHex(programCounter) == IHelper.SUBI)
                {
                    gpr = immediateRepo.subi(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.SUBI);
                    
                }
                 else if  (returnHex(programCounter) == IHelper.MULI)
                {
                    gpr = immediateRepo.muli(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.MULI);
                    
                }
                 else if  (returnHex(programCounter) == IHelper.DIVI)
                {
                    gpr = immediateRepo.divi(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.DIVI);
                    
                }
                 else if  (returnHex(programCounter) == IHelper.ANDI)
                {
                    gpr = immediateRepo.andi(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.ANDI);
                    
                }
                 else if  (returnHex(programCounter) == IHelper.ORI)
                {
                    gpr = immediateRepo.ori(gpr, arr[r1()], arr[r2()], arr[r3()]);
                    programCounter=programCounter+4;
                    log(IHelper.ORI);
                    
                }
                /// <summary>
                /// Start of branch immediate instructions
                /// All functions below take the same value current programCounter value (memory address array index), flag value from gpr (if required), and offset number
                /// </summary>
                /// <returns>update program counter</returns>
                else if  (returnHex(programCounter) == IHelper.BZ)
                {
                    programCounter = immediateRepo.bz(programCounter, gpr[9], arr[r1()]);
                    log(IHelper.BZ);
                    
                }
                else if  (returnHex(programCounter) == IHelper.BNZ)
                {
                    programCounter = immediateRepo.bnz(programCounter, gpr[9], arr[r1()]);
                    log(IHelper.BZ);
                    
                }
                else if  (returnHex(programCounter) == IHelper.BC)
                {
                    programCounter = immediateRepo.bc(programCounter, gpr[9], arr[r1()]);
                    log(IHelper.BZ);
                    
                }
                else if  (returnHex(programCounter) == IHelper.BS)
                {
                    programCounter = immediateRepo.bs(programCounter, gpr[9], arr[r1()]);
                    log(IHelper.BZ);
                    
                }
                else if  (returnHex(programCounter) == IHelper.JMP)
                {
                    programCounter = immediateRepo.jump(programCounter,  arr[r1()]);
                    log(IHelper.BZ);
                    
                }
                /// <summary>
                /// End of intermediate instructions, still need to implement CALL AND ACT
                /// </summary>
                
                
                
                
                else if(returnHex(programCounter)==NHelper.END){
                    log(NHelper.END);
                    break;
                }
            }
            Console.WriteLine("End of Loop");
            Console.WriteLine("Program counter is point to {0}  hex conversion = {1}", arr[programCounter],arr[programCounter].ToString("X"));
            foreach(var value in gpr) Console.WriteLine(value);






        }
    }
}

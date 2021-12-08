using System;
using System.Collections.Generic;
using System.IO;
using Assigment1.Helpers;
using OsAssigment.Helpers;

namespace Assigment1
{

    /// <summary>
    /// git : https://github.com/staz6/OsAssigment.git
    /// OS : Linux, might have to run to dotnet restore if u want to run this on microsoft windows, since sometime csproj file get buggy
    /// Classes:
    /// RegisterRepository is for the register-register instruction functions.
    /// ImmediateRepository is for imediate-register instruction functions.
    /// Memory Repository is for memory register instruction functions.
    /// SOperandRepository is for single operand instruction functions.
    /// SpecialRepository is to deal with special cases like update flag, check carry etc.
    /// Helper classes are just for my sanity.
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

            /// <summary>
            /// Load Files in to Memory.
            /// </summary>
            string[] fileName = {"p5","flags","sfull","power","noop","large0"};
            var memory = new Memory();
            memory.Data ??= new List<Data>();
 
            foreach(var value in fileName)
            {
                byte[] file = File.ReadAllBytes("./osphase2demofiles/"+value+".txt");
                Data tmpObj = new Data();
                tmpObj.Name=value;
                tmpObj.Value ??= new List<byte>();
                foreach(var x in file) tmpObj.Value.Add(x); 
                memory.Data.Add(tmpObj);
            }

             /// <summary>
            /// Load Files in to Memory. 
            /// loop through memory.Data is an object that is a list of our files data in format {name:fileName, List:filebyes}
            /// then assisng them to Page Class 
            /// Page class is an object in format
                // {
                //     pages:[
                //         name,
                //         piority,
                //         processId,
                //         dataSize,
                //         pageTables:[list1,list2]
                //     ]
                // }
            /// This is what the class would look like once converted to json. Pretty self
            /// explanatory i think.
            /// </summary>

            VMemory vm = new VMemory();
            vm.Pages ??= new List<Page>();
            foreach(var value in memory.Data)
            {
                Page pageObj = new Page();
                pageObj.Name=value.Name;
                pageObj.Piority = value.Value[0];
                pageObj.ProcessId=Convert.ToByte(value.Value[1] + value.Value[2]);
                pageObj.DataSize=Convert.ToByte(value.Value[3]+value.Value[4]);
                pageObj.PageTables ??= new List<PageTable>();
                
                List<byte> tmpList = new List<byte>();
                for(int i=0;i<value.Value.Count;i++){
                    tmpList.Add(value.Value[i]);
                    if(tmpList.Count==128){
                        PageTable pageTable = new PageTable();
                        pageTable.Value=tmpList;
                        pageObj.PageTables.Add(pageTable);
                        tmpList = new List<byte>();
                    }
                }
            } 
                
            
            
            




            //initializing gpr with 0 values
            
            // for (int i = 0; i < 16; i++) gpr[i] = 0;

            // /// <summary>
            // /// Object For Register repository, immediate reposiry, memory repositry , single operand repository
            // /// no operand repository
            // /// </summary>
            // var immediateRepo = new ImmediateRepository();
            // var registerRepo = new RegisterRepository();
            // var memoryRepo = new MemoryRepository();
            // var sOperandRepo = new SOperandRepository();
            // while (true)
            // {
            //     //this is just so i can point to previoud program counter to call the log function, 
            //     var tmpLog= returnHex(programCounter);

            //     /// <summary>
            //     /// Start Register-register instruction 
            //     /// All the code does the same thing run the if state if returnHex(programCounter) === RHelper.value
            //     /// All register-register function take the same value gpr array, and register index
            //     /// Set gpr to the corresponding functio value in RegisterRepository 
            //     /// Increase program counter by 3
            //     /// then log the result using log function
            //     /// </summary>
            //     /// <param name="gpr,index r1,index r2"></param>
            //     /// <returns>gpr</returns>
            //     if(returnHex(programCounter)==RHelper.MOV){
            //         gpr = registerRepo.mov(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     else if(returnHex(programCounter) == RHelper.ADD){
            //         gpr = registerRepo.add(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     else if(returnHex(programCounter) == RHelper.SUB){
            //         gpr = registerRepo.sub(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     else if(returnHex(programCounter)==RHelper.MUL){
            //         gpr = registerRepo.mull(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     else if(returnHex(programCounter) == RHelper.DIV){
            //         gpr = registerRepo.div(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     else if(returnHex(programCounter) == RHelper.AND){
            //         gpr = registerRepo.and(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     else if(returnHex(programCounter) == RHelper.OR){
            //         gpr = registerRepo.or(gpr, arr[r1()], arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
            //     /// <summary>
            //     /// End of Register-register function
            //     /// </summary>


            //     /// <summary>
            //     /// Start Register Immediate instructions
            //     /// All the code does the same thing run the if state if returnHex(programCounter) === IHelper.value
            //     /// All register-immediate function take the same value gpr array, and value
            //     /// Set gpr to the corresponding functio value in RegisterRepository
            //     /// Increase program counter by 3
            //     /// The log the result using log function
            //     /// </summary>
            //     /// <param name="gpr,r1,num 1 , num2"></param>
            //     /// <returns>int[] gpr</returns>
            //     else if  (returnHex(programCounter) == IHelper.MOVI)
            //     {
            //         gpr = immediateRepo.movei(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //     else if  (returnHex(programCounter) == IHelper.ADDI)
            //     {
            //         gpr = immediateRepo.addi(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //     else if  (returnHex(programCounter) == IHelper.SUBI)
            //     {
            //         gpr = immediateRepo.subi(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //      else if  (returnHex(programCounter) == IHelper.MULI)
            //     {
            //         gpr = immediateRepo.muli(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //      else if  (returnHex(programCounter) == IHelper.DIVI)
            //     {
            //         gpr = immediateRepo.divi(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //      else if  (returnHex(programCounter) == IHelper.ANDI)
            //     {
            //         gpr = immediateRepo.andi(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //      else if  (returnHex(programCounter) == IHelper.ORI)
            //     {
            //         gpr = immediateRepo.ori(gpr, arr[r1()], arr[r2()], arr[r3()]);
            //         programCounter=programCounter+4;
                    
            //     }
            //     /// <summary>
            //     /// Start of branch immediate instructions
            //     /// All functions below take the same value current programCounter value (memory address array index), flag value from gpr (if required), and offset number
            //     /// </summary>
            //     /// <returns>update program counter</returns>
            //     else if  (returnHex(programCounter) == IHelper.BZ)
            //     {
            //         programCounter = immediateRepo.bz(programCounter, gpr[9], arr[r1()]);
                    
            //     }
            //     else if  (returnHex(programCounter) == IHelper.BNZ)
            //     {
            //         programCounter = immediateRepo.bnz(programCounter, gpr[9], arr[r1()]);
                    
            //     }
            //     else if  (returnHex(programCounter) == IHelper.BC)
            //     {
            //         programCounter = immediateRepo.bc(programCounter, gpr[9], arr[r1()]);
                    
            //     }
            //     else if  (returnHex(programCounter) == IHelper.BS)
            //     {
            //         programCounter = immediateRepo.bs(programCounter, gpr[9], arr[r1()]);
                    
            //     }
            //     else if  (returnHex(programCounter) == IHelper.JMP)
            //     {
            //         programCounter = immediateRepo.jump(programCounter,  arr[r1()]);
                    
            //     }
            //     /// <summary>
            //     /// End of intermediate instructions, still need to implement CALL AND ACT
            //     /// </summary>
                
            //     /// <summary>
            //     /// Start Memory register instruction
            //     /// </summary>
                
            //     /// <summary>
            //     /// movl 
            //     /// </summary>
            //     /// <param name="gpr, r1 index, memory value"></param>
            //     /// <returns>gpr</returns>
            //     else if(returnHex(programCounter) == MHelper.MOVL)
            //     {
            //         gpr=memoryRepo.movl(gpr,arr[r1()],arr[r2()]);
            //         programCounter=programCounter+3;
            //     }

            //     /// <summary>
            //     /// movs 
            //     /// </summary>
            //     /// <param name="gpr, r1 index, memory array,memory index"></param>
            //     /// <returns>memory array arr</returns>
            //     else if(returnHex(programCounter) == MHelper.MOVS)
            //     {
            //         arr=memoryRepo.movs(gpr,arr[r1()],arr,arr[r2()]);
            //         programCounter=programCounter+3;
            //     }
                
            //     /// <summary>
            //     /// Start Single operand register instructions 
            //     /// Just calling the function here if the memoryaddres[programCOunter] matches
            //     /// for actual comment goto SOperandRepository
            //     /// </summary>
            //     /// <returns>gpr</returns>
                
            //     else if(returnHex(programCounter)==SOHelper.SHL)
            //     {
            //         gpr = sOperandRepo.shl(gpr,arr[r1()]);
            //         programCounter = programCounter +2;
            //     }
            //     else if(returnHex(programCounter)==SOHelper.SHR)
            //     {
            //         gpr = sOperandRepo.shr(gpr,arr[r1()]);
            //         programCounter = programCounter +2;
            //     }
            //     else if(returnHex(programCounter)==SOHelper.RTL)
            //     {
            //         gpr = sOperandRepo.rtl(gpr,arr[r1()],arr[r2()]);
            //         programCounter = programCounter +3;
            //     }
            //     else if(returnHex(programCounter)==SOHelper.RTR)
            //     {
            //         gpr = sOperandRepo.rtr(gpr,arr[r1()],arr[r2()]);
            //         programCounter = programCounter +3;
            //     }
            //     else if(returnHex(programCounter)==SOHelper.INC)
            //     {
            //         gpr = sOperandRepo.inc(gpr,arr[r1()]);
            //         programCounter = programCounter +2;
            //     }
            //      else if(returnHex(programCounter)==SOHelper.DEC)
            //     {
            //         gpr = sOperandRepo.dec(gpr,arr[r1()]);
            //         programCounter = programCounter +2;
            //     }
                
        
            //     /// <summary>
            //     /// Start no operand instruction 
            //     /// ingnore f1 for new
            //     /// if f2 do nothing, 
            //     /// if f3 END
            //     /// </summary>
            //     else if(returnHex(programCounter)==NHelper.NOOP)
            //     {
            //         programCounter=programCounter+1;
            //     }
            //     else if(returnHex(programCounter)==NHelper.END){
            //         log(NHelper.END);
            //         break;
            //     }
            //     // print output on console.
            //     log(tmpLog);
            // }
            // Console.WriteLine("End of Loop");
            // Console.WriteLine("Program counter is point to {0}  hex conversion = {1}", arr[programCounter],arr[programCounter].ToString("X"));
            // foreach(var value in gpr) Console.WriteLine(value);






        }
    }
}

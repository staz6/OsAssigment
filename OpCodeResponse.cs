using System.ComponentModel.Design;
using System;
using Assigment1.Helpers;

namespace Assigment1
{
    public static  class OpCodeResponse 
    {
        
        public static string GetDefaultMessageForStatusCode(string statusCode)
        {
            return statusCode switch{
                RHelper.MOV => "MOV R1 R2",
                RHelper.ADD => "ADD ADD R1 R2",
                RHelper.SUB => "SUB R1 R2",
                RHelper.MUL => "MUL R1 R2",
                RHelper.DIV => "DIV R1 R2",
                RHelper.AND => "AND R1 & R2",
                RHelper.OR => "OR R1 | R2",

                IHelper.MOVI=>"MOVI R1 R2",
                IHelper.ADDI=>"ADDI R1 R2",
                IHelper.SUBI=>"SUBI R1 R2",
                IHelper.MULI=>"MULI R1 R2",
                IHelper.DIVI => "DIVI R1 R2",
                IHelper.ANDI => "ANDI R1 R2",
                IHelper.ORI => "ORI R1 R2",
                IHelper.BZ=>"BZ NUM",
                IHelper.BNZ=>"BNZ NUM",
                IHelper.BC=>"BC NUM",
                IHelper.BS=>"BS NUM",
                IHelper.JMP=>"JMP NUM",

                MHelper.MOVL => "MOVL",
                MHelper.MOVS => "MOVS",

                 
                NHelper.END => "F3 End Successfully",
                _ => "Welcome to the dark side"
                
            };
        }
    }
}
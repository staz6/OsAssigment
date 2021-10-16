using System.ComponentModel.Design;
using System;
namespace Assigment1
{
    public static  class OpCodeResponse 
    {
        
        public static string GetDefaultMessageForStatusCode(string statusCode)
        {
            return statusCode switch{
                Helper.MOVI => "MOVI",
                Helper.MUL => "MUL",
                Helper.END => "F3 End Successfully",
                _ => "Welcome to the dark side"
                
            };
        }
    }
}
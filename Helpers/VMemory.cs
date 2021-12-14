using System.Collections.Generic;
using System.Linq;

namespace OsAssigment.Helpers
{
    public class VMemory
    {
        public List<Page> Pages { get; set; }
    }
    public class Page
    {
        public string Name {get;set;}
        public byte Piority { get; set; }
        public byte ProcessId{get;set;}
        public byte DataSize{get;set;}
        public byte programCounter{get;set;} =0;
        public byte[] GPR {get;set;} = Enumerable.Repeat<byte>(0, 16).ToArray();
         public List<byte> DataPage { get; set; }
        public List<CodePage> CodePages{get;set;}
    }
    public class CodePage{
        public List<byte> Values{get;set;}
    }
}
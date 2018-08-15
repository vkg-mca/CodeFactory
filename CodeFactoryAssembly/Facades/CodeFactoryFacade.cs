using CodeFactoryDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactoryAssembly
{
    public class CodeFactoryFacade
    {

        public Int32 ReadCodeSet()
        {
            Int32 Result = 0;
            CodeSetManager CodeSetManager = new CodeSetManager();
            Result = CodeSetManager.ReadCodeSet();
            return Result;
        }
         public Int32 AddCodeSet(string Code, string ShortValue, string LongValue, DateTime EffectiveFromDate, DateTime EffectiveToDate, string CategoryCode)
        {
            Int32 Result = 0;
            CodeSetManager CodeSetManager = new CodeSetManager();
            Result = CodeSetManager.AddCodeSet(Code, ShortValue, LongValue, EffectiveFromDate, EffectiveToDate, CategoryCode);
            return Result;

         }

         public Int32 ReadEmployer()
         {
             Int32 Result = 0;
             EmployerManager EmployerManager = new EmployerManager();
             Result = EmployerManager.ReadEmployer();
             return Result;
         }
    }
}

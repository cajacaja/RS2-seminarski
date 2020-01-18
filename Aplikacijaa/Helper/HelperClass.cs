using Aplikacijaa.ContextFolder;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Helper
{
    public class HelperClass
    {
        private  MyContext db;

        private static HelperClass obj;
        public HelperClass(MyContext context)
        {
            db = context;
        }

        public static HelperClass GetInstance(MyContext context)
        {
            if (obj == null)
                obj = new HelperClass(context);
            return obj;
        }

       

        
    }
}

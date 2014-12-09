using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbageCollectionExp01
{
    class FinalizeTest
    {
        public string Name { get; set; }

        public FinalizeTest(string name)
        {
            this.Name = name;
        }

         ~FinalizeTest()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linker
{
    public class Symbol
    {
        string name;
        public string Name { set { name = value; } get { return name; } }

        int implementationModule;
        public int ImplementationModule { set { implementationModule = value; } get { return implementationModule; } }

        int relativeAddress;
        public int RelativeAdress { set { relativeAddress = value; } get { return relativeAddress; } }

        
        public Symbol(string name, int implementationModule, int relativeAddress)
        {
            this.name = name;
            this.implementationModule = implementationModule;
            this.relativeAddress = relativeAddress;
        }
    }
}

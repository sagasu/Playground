using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    internal class Printer
    {
        public void Install()
        {
            Console.WriteLine("Printer Installed");
        }

        public virtual void InstallVirtual()
        {
            Console.WriteLine("Printer virtual Installed");
        }
        
        public virtual void InstallVirtualWithOverride()
        {
            Console.WriteLine("Printer override Installed");
        }
        
        public virtual void InstallVirtualNew()
        {
            Console.WriteLine("Printer virtual new Installed");
        }
        
        public void InstallNew()
        {
            Console.WriteLine("Printer new Installed");
        }
    }

    class LaserPrinter : Printer
    {
        public void Install()
        {
            Console.WriteLine("Laser Printer Installed");
        }

        public void InstallVirtual()
        {
            Console.WriteLine("Laser Printer virtual Installed");
        }

        public override void InstallVirtualWithOverride()
        {
            Console.WriteLine("Laser Printer override Installed");
        }
        
        public new void InstallVirtualNew()
        {
            Console.WriteLine("Laser Printer virtual new Installed");
        }
        
        public new void InstallNew()
        {
            Console.WriteLine("Laser Printer new Installed");
        }

    }
}

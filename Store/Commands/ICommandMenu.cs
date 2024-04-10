using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Commands
{
    internal interface ICommandMenu
    {
        public int IdCommand { get; set; }
        public void Execute();
        
    }
}

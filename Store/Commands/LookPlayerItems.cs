using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Commands
{
    internal class LookPlayerItems : CommandMenu
    {
        public override int IdCommand { get; set; } = 2;

        public override void Execute(Store store)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan_Solution.GUIException
{
    class CheckBoxException: ArgumentNullException
    {
       public CheckBoxException(string message) : base(message) { }
}
}

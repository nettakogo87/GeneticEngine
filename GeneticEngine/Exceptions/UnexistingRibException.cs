using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.Exceptions
{
    public class UnexistingRibException : Exception
    {
        public override string ToString()
        {
            return "Искомое ребро не существует";
        }
    }
}

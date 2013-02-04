using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine
{
    /**
     * Особь должна реализовывать интрефейс IPerson, и хранить массив генов(генотип).
     */
    public class Person : IPerson
    {
        public int[] Genotype { get; set; }
        public int TypeOfSelection { get; set; }
        public int TypeOfMutation { get; set; }
        public int TypeOfCrossingover { get; set; }
    }
}

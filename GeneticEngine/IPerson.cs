using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine
{
    /**
     * Для контроля за тем как получаетются особи, каждая особь хранит в себе данные об этом:
     * "Тип селекции, тип мутации, тип скрещивания".
     */
    public interface IPerson
    {
        int TypeOfSelection { get; set; }
        int TypeOfMutation { get; set; }
        int TypeOfCrossingover { get; set; }
    }
}

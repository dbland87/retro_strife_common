using System;
using System.Collections.Generic;
using System.Text;

namespace RSCommonLib.Models
{
    class RSEncounterModel
    {
        public Queue<RSUnitTurnModel> turns = new Queue<RSUnitTurnModel>();

        public void SaveTurn(RSUnitTurnModel turnModel)
        {
            turns.Enqueue(turnModel);
        }
    }
}

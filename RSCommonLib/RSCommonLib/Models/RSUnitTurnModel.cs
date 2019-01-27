using System;
using System.Collections.Generic;
using System.Text;

namespace RSCommonLib.Models
{
    public class RSUnitTurnModel
    {
        public List<RSUnitModel> targets { get; set; }
        public Queue<RSUnitAction> actions { get; set; }

        public RSUnitTurnModel()
        {
            targets = new List<RSUnitModel>();
            actions = new Queue<RSUnitAction>();
        }

        public void addTarget(RSUnitModel target)
        {
            targets.Add(target);
        }

        public void setTarget(RSUnitModel target)
        {
            targets.Clear();
            targets.Add(target);
        }

        public void addAction(RSUnitAction action)
        {
            actions.Enqueue(action);
        }

        public void setAction(RSUnitAction action)
        {
            actions.Clear();
            actions.Enqueue(action);
        }

        public bool isComplete()
        {
            return targets.Count > 0 && actions.Count > 0;
        }
    }
}

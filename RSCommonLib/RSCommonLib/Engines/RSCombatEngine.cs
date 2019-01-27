using System;
using System.Collections.Generic;

namespace RSCommonLib
{
    public static class SpeedResolver
    {
        public static RSUnitModel GetNextReadyUnit(List<RSUnitModel> units, int threshold)
        {
            RSUnitModel readyUnit;

            while (units.FindAll(it => it.state.initiative >= threshold).Count < 1)
            {
                incrementInitiative(units);
            }
            units.Sort((x, y) => y.state.initiative.CompareTo(x.state.initiative));
            int max = units[0].state.initiative;
            if (units.FindAll(it => it.state.initiative == max).Count == 1)
            {
                readyUnit = units[0];
                readyUnit.state.initiative = readyUnit.state.initiative - threshold;

            }
            else
            {
                System.Random rnd = new System.Random();
                int tiebreaker = rnd.Next(
                    units.FindAll(it => it.state.initiative == max).Count);
                readyUnit = units[tiebreaker];
                readyUnit.state.initiative = readyUnit.state.initiative - threshold;
            }
            return readyUnit;
        }

        private static void incrementInitiative(List<RSUnitModel> units)
        {
            foreach (var unit in units)
            {
                unit.state.initiative += unit.resolvedSpeed();
            }
        }
    }
}

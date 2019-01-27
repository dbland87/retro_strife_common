using RSCommonLib.Interfaces;
using RSCommonLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSCommonLib.Resolvers
{
    class RSActionResolver
    {
        private RSUnitController controller;

        public RSActionResolver(RSUnitController unitController)
        {
            controller = unitController;
        }

        public void ResolveEncounter(RSEncounterModel encounter)
        {
            while(encounter.turns.Count > 0)
            {
                ResolveTurn(encounter.turns.Dequeue());
            }
        }

        public void ResolveTurn(RSUnitTurnModel turn)
        {
            while (turn.actions.Count > 0)
            {
                ResolveAction(turn.actions.Dequeue());
            }
        }

        private void ResolveAction(RSUnitAction action)
        {
            RSUnitModel target = controller.FindUnitById(action.targetId);
            switch (action.type)
            {
                case RSUnitAction.ActionType.PHYSICAL_ATTACK:
                    onPhysicalAttack(action, target);
                    break;
                case RSUnitAction.ActionType.MAGIC_ATTACK:
                    onMagicAttack(action, target);
                    break;
                case RSUnitAction.ActionType.STAT_MODIFIER:
                    onStatModifier(action, target);
                    break;
                default:
                    break;
            }
        }

        private void onPhysicalAttack(RSUnitAction action, RSUnitModel target)
        {
            //TODO need to figure out how we want def to actually affect damage.
            int damageAmount = action.amount - target.def;
            target.applyDamage(damageAmount);
        }

        private void onMagicAttack(RSUnitAction action, RSUnitModel target)
        {
            int damageAmount = action.amount - target.def;
            target.applyDamage(damageAmount);
        }

        private void onStatModifier(RSUnitAction action, RSUnitModel target)
        {
            //TODO
        }

        private List<RSUnitModel> allUnits()
        {
            return controller.GetAllUnits();
        }
    }
}

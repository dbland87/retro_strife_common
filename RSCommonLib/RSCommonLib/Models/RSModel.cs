using System;
using System.Collections.Generic;

namespace RSCommonLib
{
    public class RSUnitModel
    {
        public int id { get; set; }
        public int prefabId { get; set; }
        public string instanceId { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int hp { get; set; }
        public int speed { get; set; }
        public int def { get; set; }
        public int magicDef { get; set; }
        public int attack { get; set; }
        public RSUnitState state { get; set; }
        public RSStatModifiers modifiers { get; set; }
        public List<RSUnitAction> actions { get; set; }

        // Unit Events
        public event Action<string> UnitDeath;
        public event Action<int> LostHp;
        public event Action<int> GainedHp;

        //public event Action<RSUnitState, string> UnitStateChange;

        public RSUnitModel()
        {
            this.state = new RSUnitState();
            this.actions = new List<RSUnitAction>();
            this.modifiers = new RSStatModifiers();
        }

        public void initState()
        {
            state.hp = hp;
        }

        public int resolvedHp()
        {
            return hp + modifiers.hp;
        }
        public int resolvedSpeed()
        {
            return speed + modifiers.speed;
        }
        public int resolvedDef()
        {
            return def + modifiers.def;
        }
        public int resolvedMagicDef()
        {
            return magicDef + modifiers.magicDef;
        }
        public int resolvedAttack()
        {
            return attack + modifiers.attack;
        }
        public void applyDamage(int amount)
        {
            state.hp = state.hp - amount;
            LostHp(amount);

            if (state.hp <= 0)
            {
                UnitDeath(instanceId);
            }
        }
    }

    //    private void onNewUnitState(RSUnitState state)
    //    {
    //        if (state.hp <= 0)
    //        {
    //            UnitDeath(instanceId);
    //        }
    //        else
    //        {
    //            UnitStateChange(state, instanceId);
    //        }
    //    }
    //}

    public class RSUnitState
    {
        public int hp { get; set; }
        public int speed { get; set; }
        public int def { get; set; }
        public int magicDef { get; set; }
        public int attack { get; set; }
        public int initiative { get; set; }
        public int shield { get; set; }
    }

    public class RSStatModifiers
    {
        public int hp { get; set; }
        public int speed { get; set; }
        public int def { get; set; }
        public int magicDef { get; set; }
        public int attack { get; set; }
        public int initiative { get; set; }
        public int shield { get; set; }
    }

    public class RSUnitAction
    {
        public RSUnitAction(int _id, int _targetId, string _name, int _amount, ActionType _type)
        {
            id = _id;
            targetId = _targetId;
            name = _name;
            amount = _amount;
            type = _type;
        }
        public int id { get; set; }
        public int targetId { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public ActionType type { get; set; }
        public enum ActionType
        {
            PHYSICAL_ATTACK,
            MAGIC_ATTACK,
            STAT_MODIFIER
        }
    }
}

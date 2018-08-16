﻿using System.Collections.Generic;
using Nashet.Conditions;
using Nashet.ValueSpace;

namespace Nashet.EconomicSimulation
{
    public class Separatism : AbstractReform
    {
        protected static readonly Procent willing = new Procent(3f);
        protected readonly Condition separatismAllowed;
        protected Goal typedValue { get; }
        public Country goal { get { return typedValue.separatismTarget; } }

        protected Separatism(Country country) : base(country.ShortName + " independence", "", country,
            null)//new ConditionsList(Condition.AlwaysYes))
        {
            //separatismAllowed = new Condition(x => isAvailable(x as Country), "Separatism target is valid", true);
            //allowed.add(separatismAllowed);
            //separatismTarget = country;

        }

        //public static Separatism find(Country country)
        //{
        //    var found = allSeparatists.Find(x => x.separatismTarget == country);
        //    if (found == null)
        //        return new Separatism(country);
        //    else
        //        return found;
        //}

        public Procent howIsItGoodForPop(PopUnit pop)
        {
            //return Procent.HundredProcent;
            return willing;
        }

        //public override bool isAvailable(Country country)
        //{
        //    return !separatismTarget.IsAlive;
        //}
        protected static List<Goal> allSeparatists = new List<Goal>();
        public static Goal Get(Country country)
        {
            //possibleValues
            var found = allSeparatists.Find(x => x.separatismTarget == country);
            if (found == null)
            {
                var res = new Goal(country);
                allSeparatists.Add(res);
                return res;
            }
            else
                return found;
        }
        public class Goal : IReformValue
        {
            public Country separatismTarget { get; protected set; }

            public Goal(Country separatismTarget)
            {
                this.separatismTarget = separatismTarget;
            }
            /// <summary>
            /// Doesn't have sense for that reform
            /// </summary>            
            public bool IsMoreConservative(IReformValue anotherReform)
            {
                return false;
            }           

            Procent IReformValue.LifeQualityImpact
            {
                get
                {
                    throw new System.NotImplementedException();
                }
            }

            public Procent LifeQualityImpact()
            {
                return Procent.ZeroProcent.Copy();
            }

            public float getVotingPower(PopUnit forWhom)
            {
                return 0f;
            }

            public Procent howIsItGoodForPop(PopUnit pop)
            {
                return Procent.ZeroProcent.Copy();
            }

            public bool IsAllowed(object firstObject, object secondObject, out string description)
            {
                description = null;
                return true;
            }

            public bool IsAllowed(object firstObject, object secondObject)
            {
                return true;
            }
        }
    }
    //public class OldSeparatism : AbstractReformValue, IHasCountry
    //{
    //    private static readonly List<Separatism> allSeparatists = new List<Separatism>();
    //    private static readonly Procent willing = new Procent(3f);
    //    private readonly Condition separatismAllowed;

    //    private readonly Country separatismTarget;

    //    private OldSeparatism(Country country) : base(country.ShortName + " independence", "", 0,
    //        new DoubleConditionsList())//new ConditionsList(Condition.AlwaysYes))
    //    {
    //        separatismAllowed = new Condition(x => isAvailable(x as Country), "Separatism target is valid", true);
    //        allowed.add(separatismAllowed);
    //        separatismTarget = country;
    //        allSeparatists.Add(this);
    //    }

    //    public static Separatism find(Country country)
    //    {
    //        var found = allSeparatists.Find(x => x.separatismTarget == country);
    //        if (found == null)
    //            return new Separatism(country);
    //        else
    //            return found;
    //    }

    //    protected override Procent howIsItGoodForPop(PopUnit pop)
    //    {
    //        //return Procent.HundredProcent;
    //        return willing;
    //    }

    //    public override bool isAvailable(Country country)
    //    {
    //        return !separatismTarget.IsAlive;
    //    }

    //    public Country Country
    //    {
    //        get { return separatismTarget; }
    //    }
    //}
}
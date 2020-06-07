﻿using RimWorld;
using Verse;
using System.Collections.Generic;

namespace VanillaCookingExpanded
{
    public class CompStackByIngredients: ThingComp
    {

        public override bool AllowStackWith(Thing other)
        {

            if (other.TryGetComp<CompIngredients>() != null)
            {
                List<ThingDef> listingredients1 = other.TryGetComp<CompIngredients>().ingredients;
                List<ThingDef> listingredients2 = this.parent.TryGetComp<CompIngredients>().ingredients;

                bool ingredientsEqual = SetsContainSameElements<ThingDef>(listingredients1, listingredients2);
               
                if (!ingredientsEqual)
                {
                    return false;
                }

            }


           
            return base.AllowStackWith(other);
        }

        static bool SetsContainSameElements<T>(IEnumerable<T> set1, IEnumerable<T> set2)
        {
            var setXOR = new HashSet<T>(set1);
            setXOR.SymmetricExceptWith(set2);
            return (setXOR.Count == 0);
        }


    }
}

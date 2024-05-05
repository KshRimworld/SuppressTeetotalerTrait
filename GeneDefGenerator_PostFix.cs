using RimWorld;
using System.Collections.Generic;
using Verse;

namespace STT
{
    [StaticConstructorOnStartup]
    public static class GeneDefGenerator_PostFix
    {
        static GeneDefGenerator_PostFix()
        {
            IEnumerable<string> geneDefNames = new List<string>() { "ChemicalDependency_Alcohol", "ChemicalDependency_GoJuice", "ChemicalDependency_Psychite", "ChemicalDependency_Smokeleaf", "ChemicalDependency_WakeUp" };

            GeneticTraitData drugDesire = new GeneticTraitData();
            drugDesire.def = TraitDefOf.DrugDesire;
            drugDesire.degree = -1;

            foreach (string geneDefName in geneDefNames)
                injectionTrait(geneDefName, drugDesire);
        }

        private static void injectionTrait(string geneDefName, GeneticTraitData geneticTraitData)
        {
            GeneDef geneDef = DefDatabase<GeneDef>.GetNamed(geneDefName);

            if (geneDef == null)
            {
                Log.Error("[STT] GeneDef Not found : " + geneDefName);
            }

            if (geneDef.suppressedTraits == null)
            {
                geneDef.suppressedTraits = new List<GeneticTraitData>();
            }

            geneDef.suppressedTraits.Add(geneticTraitData);
        }
    }
}

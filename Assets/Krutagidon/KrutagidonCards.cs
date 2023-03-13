using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class KrutagidonCards
{
    public static Dictionary<int, CardDefinition> CardDefinitions { get; set; } = new Dictionary<int, CardDefinition>();

    public static void InitCards()
    {
        InitDefinitions();
    }

    private static void InitDefinitions()
    {
        KrutagidonCardDefinition fizzleCard = new KrutagidonCardDefinition("Fizzle", 0, 0, 0, 0);
        CardDefinitions.Add(0, fizzleCard);

        KrutagidonCardDefinition glyphCard = new KrutagidonCardDefinition("Glyph", 0, 0, 1, 0);
        CardDefinitions.Add(1, glyphCard);

        KrutagidonCardDefinition wandCard = new KrutagidonCardDefinition("Wand", 0, 0, 1, 1);
        CardDefinitions.Add(2, wandCard);
        wandCard.AddDamageAction(1);
    }

    public static CardDefinition GetCardDefinition(int id)
    {
        return CardDefinitions[id];
    }

    public static CardDefinition FizzleCardDefinition => GetCardDefinition(0);
    public static CardDefinition GlyphCardDefinition => GetCardDefinition(1);
    public static CardDefinition WandCardDefinition => GetCardDefinition(2);
}


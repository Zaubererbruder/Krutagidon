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
        CardDefinition fizzleCard = new CardDefinition("Fizzle", 0, 0);
        CardDefinitions.Add(0, fizzleCard);

        CardDefinition glyphCard = new CardDefinition("Glyph", 0, 0);
        glyphCard.AddActionOnPlay(new PowerAction(1));
        CardDefinitions.Add(1, glyphCard);

        CardDefinition wandCard = new CardDefinition("Wand", 0, 0);
        wandCard.AddActionOnPlay(new PowerAction(1));
        //wandCard.Actions.Add(new DamageAction(1));
        //wandCard.NeedTarget = true;
        CardDefinitions.Add(2, wandCard);
    }

    public static CardDefinition GetCardDefinition(int id)
    {
        return CardDefinitions[id];
    }

    public static CardDefinition FizzleCardDefinition => GetCardDefinition(0);
    public static CardDefinition GlyphCardDefinition => GetCardDefinition(1);
    public static CardDefinition WandCardDefinition => GetCardDefinition(2);
}


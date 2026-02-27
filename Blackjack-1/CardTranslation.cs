using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

static class CardTranslation
{
    private static char[] shapes = new char[] { '♠', '♦', '♥', '♣' };
  
    public static string TranslationCard(int card)
    {
        char shape;
        int Count;
        if(card % 13 == 0)
        {
            Count = 13;
            shape = shapes[card / 13]; 
        }
        else
        {
            shape = shapes[card / 13];
            Count = card % 13;
        }
        return ($"{shape}{Count}");
    }
    
}
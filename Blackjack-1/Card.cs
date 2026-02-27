using System;
using System.Collections.Generic;
using System.Text;

class Card
{
    public readonly static char[] shapes = new char[] { '♠', '♦', '♥', '♣' };
    private readonly char _shapes;
    private readonly int _value;

    public char Shape => _shapes;
    public int Value => _value;
    public Card(char shape, int value)
    {
        _shapes = shape;
        _value = value;
    }
    public override string ToString()
    {
        string cardNumber;
        if(Value==11)
        {
            cardNumber = "J";
        }
        else if(Value==12)
        {
            cardNumber = "Q";
        }
        else if (Value==13)
        {
            cardNumber = "K";
        }
        else if(Value ==1)
        {
            cardNumber = "A";
        }
        else
        {
            cardNumber = $"{Value}";
        }
            return $"[{_shapes}{cardNumber}]";
    }
}
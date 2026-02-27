using System;
using System.Collections.Generic;
using System.Text;

class DrawCard
{
    private int[][] _orderArr;
    private int _count;
    private Card[] _cards;
    

    public DrawCard()
    {
        char shape;
        int Count;
        _orderArr = new int[52][];
        _cards = new Card[52];
        for (int i = 0; i < 52; i++)
        {
           
            if (i % 13 == 0)
            {
                Count = 13;
                shape = Card.shapes[i / 13];
            }
            else
            {
                shape = Card.shapes[i / 13];
                Count = i % 13;
            }
            _cards[i] = new Card(shape, Count);

        }
    }

    public void suffle()
    {
        Random random = new Random(); 
        for (int i = 0; i < 52; i++)
        {
            _orderArr[i] = new int[2];
            _orderArr[i][0] = i;
            _orderArr[i][1] = random.Next(1, 100000);
        }
        Array.Sort(_orderArr, (a, b) => a[1].CompareTo(b[1]));
    }
    public Card Draw()
    {
        return _cards[_orderArr[_count++][0]];
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;

class Player
{
    private Card[] _cardList;
    private int _count;
    public Player()
    {
        _cardList=new Card[22];
        _count = 0;
    }
    public void AddCard(Card card)
    {
        _cardList[_count] = card;
        _count++;
    }
    public int Score { get; private set; }
    public void CheckScore()
    {
        int acount = 0;
        int score = 0;
        for (int i = 0; i < _count; i++)
        {
            if (_cardList[i].Value > 10)
            {
                score += 10;
            }
            else if (_cardList[i].Value == 1)
            {
                acount++;
                score += 11;
            }
            else if (_cardList[i].Value <= 10)
            {
                score += _cardList[i].Value;
            }
        }
        while (score > 21)
        {
            if(acount>0)
            {
                acount--;
                score -= 10;
            }
            else
            {
                break;
            }
        }
        Score = score;
    }
    public string ShowCardList()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < _count; i++)
        {
            sb.Append($"{_cardList[i]} ");
        }

        return sb.ToString();
    }
    public string ShowHiddenCardList()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[??] ");

        for (int i = 1; i < _count; i++)
        {
            sb.Append($"{_cardList[i]} ");
        }

        return sb.ToString();
    }


}
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
        _cardList = new Card[22];
        _count = 0;
    }
    
    /// <summary>
    /// 카드 값을 Player의 내부 cardList에 저장
    /// </summary>
    /// <param name="card">  </param>
    public void AddCard(Card card)
    {
        _cardList[_count] = card;
        _count++;
    }
    public int Score { get; private set; }

    /// <summary>
    ///  점수 계산 후 Score변수에 저장
    /// </summary>
    public void CheckScore()
    {
        int aCount = 0;
        int score = 0;
        for (int i = 0; i < _count; i++) {
            if (_cardList[i].Value > 10) {
                score += 10;
            } else if (_cardList[i].Value == 1) {
                aCount++;
                score += 11;
            } else if (_cardList[i].Value <= 10) {
                score += _cardList[i].Value;
            }
        }
        while (score > 21)
        {
            if(aCount>0)
            {
                aCount--;
                score -= 10;
            }
            else
            {
                break;
            }
        }
        Score = score;
    }

    /// <summary>
    /// 플레이어가 현재 가지고 있는 카드 리스트를 반환.
    /// </summary>
    /// <param name="isHidden">첫 카드를 히든으로 반환할지 여부</param>
    /// <returns>카드 리스트</returns>
    public string GetCardList(bool isHidden = false)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < _count; i++) {
            if (isHidden && i == 0) {
                sb.Append($"[??] ");
            }
            sb.Append($"{_cardList[i]} ");
        }

        return sb.ToString();
    }
}
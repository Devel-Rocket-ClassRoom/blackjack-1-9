using System;

class DrawCard
{
    private int[][] _orderArr;
    private int _count;
    private Card[] _cards;
    private bool isShuffled;

    public DrawCard()
    {
        _orderArr = new int[52][];
        _cards = new Card[52];
        isShuffled = false;

        // 카드 52장 저장
        char shape;
        int count;
        for (int i = 0; i < 52; i++)
        {
            if (i % 13 == 0) {
                count = 13;
                shape = Card.shapes[i / 13];
            } else {
                shape = Card.shapes[i / 13];
                count = i % 13;
            }
            _cards[i] = new Card(shape, count);
        }
    }
    private void Shuffle()
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
    /// <summary>
    /// 카드를 한 장 뽑아서 반환. 카드 모두 소진 시 다시 섞기 등은 내부에서 수행
    /// </summary>
    /// <returns>뽑힌 카드 반환</returns>
    public Card Draw()
    {
        // 첫 섞기
        if (!isShuffled) {
            Shuffle();
            _count = 0;
            isShuffled = true;
        } 
        // 모두 사용 후 섞기
        else if (_count == 52) {
            Shuffle();
            _count = 0;
        }

        return _cards[_orderArr[_count++][0]];
    }

}
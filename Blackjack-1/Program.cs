using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

bool restartFlag = false;

while (true)
{
    Console.Clear();
    if (restartFlag)
    {
        Console.WriteLine("=== 새 게임 시작 ===");
    } else
    {
        Console.WriteLine("=== 블랙잭 게임 ===");
    }
    Console.WriteLine();

    DrawCard drawcard = new DrawCard();
    drawcard.suffle();

    Console.WriteLine("카드를 섞는 중 ...");
    Console.WriteLine();

    Player player = new Player();
    Player dealer = new Player();
    Card hidden = drawcard.Draw();
    dealer.AddCard(hidden);
    dealer.AddCard(drawcard.Draw());
    dealer.CheckScore();
    player.AddCard(drawcard.Draw());
    player.AddCard(drawcard.Draw());
    player.CheckScore();
    Console.WriteLine("=== 초기 패 ===");
    Console.WriteLine($"딜러의 패: {dealer.ShowHiddenCardList()}");
    Console.WriteLine("딜러 점수: ?");
    Console.WriteLine();

    Console.WriteLine($"플레이어의 카드 리스트 : {player.ShowCardList()}");
    Console.WriteLine($"플레이어의 점수: {player.Score}");
    Console.WriteLine();
    bool burstFlag = false;
    do
    {
        Console.Write($"H(Hit) 또는 S(Stand)를 선택하세요:");
        string str = Console.ReadLine();
    
        if (str.ToLower() == "h")
        {
            Card temp = drawcard.Draw();
            player.AddCard(temp);
            player.CheckScore();
            Console.WriteLine();
            Console.WriteLine($"플레이어가 카드를 받았습니다: {temp}");
            Console.WriteLine($"플레이어의 패: {player.ShowCardList()}");
            Console.WriteLine($"플레이어의 점수: {player.Score}");
            Console.WriteLine();

            if (player.Score > 21)
            {
                Console.WriteLine("버스트! 21을 초과했습니다.");
                Console.WriteLine();
                burstFlag = true;
                break;
            }
        }
        else if (str.ToLower() == "s")
        {
            Console.WriteLine();
            Console.WriteLine("플레이어가 Stand를 선택했습니다.");
            Console.WriteLine();
            break;
        }
        else
        {
            Console.WriteLine("H 또는 S 를 입력하세요.");
            Console.WriteLine();
        }
    } while (true);

    if (burstFlag)
    {
        Console.WriteLine("=== 게임 결과 ===");
        Console.WriteLine($"플레이어: {player.Score}점");
        Console.WriteLine($"딜러: {dealer.Score}점");
        Console.WriteLine();
        Console.WriteLine("플레이어 패배!");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"딜러의 숨겨진 카드: {hidden}");
        Console.WriteLine($"딜러의 패: {dealer.ShowCardList()}");
        Console.WriteLine($"딜러 점수: {dealer.Score}");
        Console.WriteLine();

        bool dealerLoseFlag = false;
        while (dealer.Score < 17)
        {
            Card temp = drawcard.Draw();
            dealer.AddCard(temp);
            dealer.CheckScore();
            Console.WriteLine($"딜러가 카드를 받습니다. {temp}");
            Console.WriteLine($"딜러의 패: {dealer.ShowCardList()}");
            Console.WriteLine($"딜러 점수: {dealer.Score}");
            Console.WriteLine();
            if(dealer.Score>21)
            {
                Console.WriteLine("딜러 버스트!");
                Console.WriteLine();
                dealerLoseFlag = true;
            }
        }

        if (dealerLoseFlag || dealer.Score < player.Score)
        {
            Console.WriteLine("=== 게임 결과 ===");
            Console.WriteLine($"플레이어: {player.Score}점");
            Console.WriteLine($"딜러: {dealer.Score}점");
            Console.WriteLine();
            Console.WriteLine("플레이어 승리!");
        }
        else if(player.Score==dealer.Score)
        {
            Console.WriteLine("=== 게임 결과 ===");
            Console.WriteLine($"플레이어: {player.Score}점");
            Console.WriteLine($"딜러: {dealer.Score}점");
            Console.WriteLine();
            Console.WriteLine("무승부 (Push)!");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("=== 게임 결과 ===");
            Console.WriteLine($"플레이어: {player.Score}점");
            Console.WriteLine($"딜러: {dealer.Score}점");
            Console.WriteLine();
            Console.WriteLine("플레이어 패배!");
            Console.WriteLine();
        }
    }
    Console.Write("새 게임을 하시겠습니까? (Y/N): ");
    string input = Console.ReadLine();
    Console.WriteLine();
    if (input.ToLower() == "y") {
        restartFlag = true;
    }
    else if(input.ToLower()=="n")
    {
        break;
    }
    
}

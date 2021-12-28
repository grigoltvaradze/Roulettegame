using ConsoleApp3;

double UserMoney = 1000;
double Maxbet = 60;

UserBet();

void UserBet()
{
    while (true)
    {
        Console.Write("Please enter Bet Amount: ");
        string Bet = Console.ReadLine();
        if (double.TryParse(Bet, out double BetAmount))
        {
            if (BetAmount > 0 && BetAmount <= Maxbet)
            {
                if (UserMoney >= BetAmount)
                {
                    Userchoice(BetAmount);
                    break;
                }
                else
                {
                    Console.WriteLine("You don't have enaught Money!");
                }
            }
            else
            {
                Console.WriteLine("Please enter Bet Between 1$ - 60$: ");
            }
        }
        else
        {
            Console.WriteLine("Please enter Numbers");
        }
    }
}

void Userchoice(double betAmount)
{
    while (true)
    {
        Console.WriteLine(" Choose Type of Bet: \n Enter : \n (1) for Red/Black bet \n (2) for Number bet");
        string userBetChoice = Console.ReadLine();
        if (userBetChoice == "1" || userBetChoice == "2")
        {
            if (userBetChoice == "1")
            {
                BetColor color = ColorChoice();
                if (ColorIsWinner(color))
                {
                    double colorWinMoney = betAmount + betAmount * 0.2;
                    double balance = UserMoney + colorWinMoney;
                    Console.WriteLine("you win" + colorWinMoney + "your balance is : " + balance);
                }
                else
                {
                    UserMoney = UserMoney - betAmount;
                    Console.WriteLine("You loose , Your balance is: " + UserMoney);
                }
                break;
            }
            else
            {
                int number = NumberChoice();
                if (NumberIsWinner(number))
                {
                    double winnedMoney = betAmount * 2;
                    double balance = UserMoney + winnedMoney;
                    Console.WriteLine("you win" + winnedMoney + "your balance is : " + balance);
                }
                else
                {
                    UserMoney = UserMoney - betAmount;
                    Console.WriteLine("You loose , Your balance is: " + UserMoney);
                }
                break;
            }
        }
        else
        {
            Console.WriteLine("Please enter :  1 or 2");
        }
    }

}
BetColor ColorChoice()
{
    while (true)
    {
        Console.WriteLine("Choice Color: \ntype (0) for zero\n type (1) for red, \n type(2) for black");
        string UserColorChoice = Console.ReadLine();
        if (int.TryParse(UserColorChoice, out int betColor))
        {
            if (UserColorChoice == "1" || UserColorChoice == "2" || UserColorChoice == "0")
            {
                if (UserColorChoice == "1")
                {
                    return BetColor.Red;
                }
                else if (UserColorChoice == "2")
                {
                    return BetColor.Black;
                }
                else
                {
                    return BetColor.Green;
                }
            }
            else
            {
                Console.WriteLine("Please enter 0, 1 or 2 ");
            }
        }
        else
        {
            Console.WriteLine("Please enter Numbers:");
        }
    }
}

int NumberChoice()
{
    while (true)
    {
        Console.WriteLine("Choice Number between 0-36:");
        string PlayerChoice = Console.ReadLine();
        if (int.TryParse(PlayerChoice, out int betNumber))
        {
            if (betNumber >= 0 && betNumber <= 36)
            {
                return betNumber;
            }
            else
            {
                Console.WriteLine("Enter number between 0-36 : ");
            }
        }
        else
        {
            Console.WriteLine("Please enter Numbers:");
        }

    }

}
bool NumberIsWinner(int number)
{
    Random random = new Random();
    int casinoChoice = random.Next(0, 36);
    return casinoChoice == number;
}
bool ColorIsWinner(BetColor color)
{
    Random random = new Random();
    int casinoChoice = random.Next(0, 36);
    BetColor casinoChoiceColor = BetColor.Empty;
    var red = new int[] { 1, 3, 5, 7, 9, 19, 21, 23, 25, 27, 12, 14, 16, 18, 30, 32, 34, 36 };
    var black = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 19, 20, 22, 24, 26, 28, 31, 33, 35 };
    var green = 0;
    if (casinoChoice == 0)
    {
        casinoChoiceColor = BetColor.Green;
    }
    else foreach (int redNumber in red)
        {
            if (redNumber == casinoChoice)
            {
                casinoChoiceColor = BetColor.Red;
                break;
            }
        }
    foreach (int blackNumber in black)
    {
        if (blackNumber == casinoChoice)
        {
            casinoChoiceColor = BetColor.Black;
            break;
        }
    }
    return casinoChoiceColor == color;
}


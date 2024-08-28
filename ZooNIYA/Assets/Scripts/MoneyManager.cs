using System;

public static class MoneyManager
{
    private static int _moneyAmount = 1000;

    public static Action<int> moneyUpdate;

    public static int GetMoneyAmount()
    {
        return _moneyAmount;
    }

    public static void AddMoney(int money)
    {
        _moneyAmount += money;
        moneyUpdate?.Invoke(_moneyAmount);
    }

    public static bool RemoveMoney(int money) 
    {  
        if (_moneyAmount >= money)
        {
            _moneyAmount -= money;
            moneyUpdate?.Invoke(_moneyAmount);
            return true;
        } else
        {
            return false;
        }
        
    }

    
}

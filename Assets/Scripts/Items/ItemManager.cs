using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;

    public GameObject coinsHolder;

    private int _totalCoins;

    protected override void Awake()
    {
        base.Awake();

        Reset();

        _totalCoins = coinsHolder.transform.childCount;
    }

    private void Reset()
    {
        coins.SetValue(0);

    }

    public void AddCoins(int amount = 1)
    {
        coins.AddValue(amount);
    }

    public int GetCollectedCoins()
    {
        return coins.GetValue();
    }

    public int GetTotalCoins()
    {
        return _totalCoins;
    }

    public int LevelCompletionPercentage()
    {
        float total = ((float)(coins.GetValue()) / (float)(_totalCoins)) * 100f;
        return (int)total;
    }
}

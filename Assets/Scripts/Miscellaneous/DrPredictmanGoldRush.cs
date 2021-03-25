using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrPredictmanGoldRush : MonoBehaviour
{
    #region Variables
    [SerializeField] int initCash;
    [SerializeField] int daysOfTrade;
    [SerializeField] List<int> pricePerDay;
    float cash = 0;
    float gold = 0;
    #endregion
    #region NaughtyAttributes
    [NaughtyAttributes.Button]
    public void Run()
    {
        cash = initCash;
        gold = 0;
        for (int i = 0; i < pricePerDay.Count - 1; i++)
        {
            if (cash == 0)
            {
                cash = gold * pricePerDay[i];
            }
            if (pricePerDay[i] <= pricePerDay[i + 1])
            {
                ChangeCashToGold(pricePerDay[i]);
            }
            else
            {
                ChangeGoldToCash(pricePerDay[i]);

            }
            print($"GOLD:{gold},Cash:{cash}");
        }
        if (cash == 0)
        {
            ChangeGoldToCash(pricePerDay[pricePerDay.Count - 1]);
        }
        print(cash);
    }
    #endregion
    #region Functions
    public void ChangeCashToGold(int exchangeRate)
    {
        gold = cash / exchangeRate;
        cash = 0;
    }
    public void ChangeGoldToCash(int exchangeRate)
    {
        cash = gold * exchangeRate;
        gold = 0;
        
    }
    #endregion
}

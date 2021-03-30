using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahyaPetrolProblem : MonoBehaviour
{
    #region Variables
    [SerializeField]int nextMonthCosumption;
    [SerializeField]int quotaFromThisMonth;
    #endregion
    #region NaughtyAttributes
    [NaughtyAttributes.Button]
    public void Run()
    {
        calcPrice();
    }
    #endregion
    #region Functions
    public void calcPrice()
    {
        int price = 0;
        int quatePricedPetrol = quotaFromThisMonth + 60;
        price += quatePricedPetrol * 1500;
        if (nextMonthCosumption > quatePricedPetrol)
        {
            price = (nextMonthCosumption - quatePricedPetrol) * 3000 + quatePricedPetrol * 1500;
        }
        else
        {
            price = nextMonthCosumption * 1500;
        }
        print(price);
    }
    #endregion
}

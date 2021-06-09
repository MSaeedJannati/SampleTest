using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class RaceTrack : MonoBehaviour
{
    #region Variables
    [SerializeField] Transform centerTransform;
    static Transform center;
    static List<CarPositionHandler> cars;
    string ranks;
    [SerializeField] TMP_Text leaderBoardText;
    #endregion
    #region Propeties
    public static Transform Center => center;
    #endregion
    #region Monobehaviour callBacks
    private void OnEnable()
    {
        cars = new List<CarPositionHandler>();
        center = centerTransform;
    }
    private void Update()
    {
        ranks = string.Empty;
        cars.Sort((y, x) => 
        {
           return x.Angle.CompareTo ( y.Angle);
        }); 
        for (int i= 0;i < cars.Count;i++)
        {
            ranks += $"#{i+1}-Car: {cars[i].Number}\n";
        }

        leaderBoardText.text = ranks;

    }
    #endregion
    #region Functions
    public static void AddCar(CarPositionHandler car)
    {
        cars.Add(car);
        car.setCarNumber(cars.Count );
    }
    #endregion
}

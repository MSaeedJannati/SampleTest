using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class WaterCondition : MonoBehaviour
{
    #region Variabeles
    [SerializeField] int Temperature;
    Stopwatch watch;

    #endregion
    #region Funcitions
    [NaughtyAttributes.Button]
    public void Run()
    {
        watch = new Stopwatch();
        watch.Restart();
       
        string phase = "Water";
        if (Temperature <= 0)
            phase = "Ice";
        else if (Temperature >= 100)
            phase = "Steam";
        watch.Stop();
        print(watch.Elapsed);
        print(phase);
    }
    #endregion
}

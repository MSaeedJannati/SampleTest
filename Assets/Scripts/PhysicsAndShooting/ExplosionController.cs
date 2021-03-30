using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    WaitForSeconds oneSec = new WaitForSeconds(1.0f);
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(disablingCoroutine());
    }
    public IEnumerator disablingCoroutine()
    {
        //GetComponentInChildren<DG.Tweening.DOTweenAnimation>().DORestart();
        //GetComponentInChildren<DG.Tweening.DOTweenAnimation>().DOPlay();
        yield return oneSec;
       
        yield return oneSec;
       
        gameObject.SetActive(false);
    }
}

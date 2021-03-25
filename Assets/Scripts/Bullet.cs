using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region MonoBehaviouCallBacks
    WaitForSeconds delay = new WaitForSeconds(2.0f);
    private void OnEnable()
    {
        GetComponent<Rigidbody>().WakeUp();
        StartCoroutine(DisableCoroutine());
    }
    #endregion
    #region Coroutins
    public IEnumerator  DisableCoroutine()
    {
        yield return delay;
        GetComponent<Rigidbody>().Sleep();
        gameObject.SetActive(false);
    }
    #endregion
}

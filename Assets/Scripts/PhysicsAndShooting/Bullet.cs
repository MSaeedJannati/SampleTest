using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region MonoBehaviouCallBacks
    WaitForSeconds delay = new WaitForSeconds(5.0f);
    private void OnEnable()
    {
        GetComponent<Rigidbody>().WakeUp();
        StartCoroutine(DisableCoroutine());
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        ImpactEffect(collision.contacts[0].point);

    }
    #endregion
    #region Functions
    public void disableBullet()
    {
        GetComponent<Rigidbody>().Sleep();
        gameObject.SetActive(false);
    }

    public virtual void ImpactEffect(Vector3 contactPos)
    {
        disableBullet();
    }
    #endregion
    #region Coroutins
    public IEnumerator  DisableCoroutine()
    {
        yield return delay;
        disableBullet();
    }
    #endregion
}

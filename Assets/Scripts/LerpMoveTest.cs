using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveTest : MonoBehaviour
{
    #region Variables
    float rootOfTwo = Mathf.Sqrt(2);
    float amount = 6.033978f;
    float Pi = Mathf.PI;
    [SerializeField] float period;
    [SerializeField] Transform[] Transforms;
    [SerializeField] Transform  myTransform;

    #endregion
    #region Functions
    public void Move()
    {
        //StartCoroutine(moveCoroutine());
        //StartCoroutine(moveCoroutineLerp());
        StartCoroutine(moveCoroutineSin());
    }
    public float TimePrime(float t)
    {
        return 2 * rootOfTwo / period * t - rootOfTwo;
    }
    public float lerPAmount(float t)
    {
        float tPrime = TimePrime(t);
        return (Mathf.Pow(tPrime, 5) / 5 - Mathf.Pow(tPrime, 3) * 4 / 3 + 4 * tPrime) / amount;
    }
    public float timePrimeSinEdition(float t)
    {
        return 2 * Pi*t / period;
    }
    public float lerpSinAmount(float t)
    {
        return (-Mathf.Sin(timePrimeSinEdition(t)) + timePrimeSinEdition(t))/(2*Pi);
    }
    #endregion
    #region Coroutines
    public IEnumerator moveCoroutine()
    {
        float t = 0;
        Vector3 initPos = Transforms[0].position;
        Vector3 destPos = Transforms[1].position;
        myTransform.position = initPos;
        Vector3 initAmount = initPos - (destPos - initPos) * lerPAmount(0);
        while (t < period)
        {
            myTransform.position = initAmount + (destPos - initPos) * lerPAmount(t);
            t += Time.deltaTime;
            yield return null;
        }
        myTransform.position = destPos;
    }
    public IEnumerator moveCoroutineLerp()
    {
        float t = 0;
        Vector3 initPos = Transforms[0].position;
        Vector3 destPos = Transforms[1].position;
        myTransform.position = initPos;
        //Vector3 initAmount = initPos - (destPos - initPos) * lerPAmount(0);
        while (t < period)
        {
            myTransform.position +=  (destPos - initPos) * Mathf.Lerp(0, period, Time.deltaTime)/period;
            t += Time.deltaTime;
            yield return null;
        }
        myTransform.position = destPos;
    }

    public IEnumerator moveCoroutineSin()
    {
        float t = 0;
        Vector3 initPos = Transforms[0].position;
        Vector3 destPos = Transforms[1].position;
        myTransform.position = initPos;
        //Vector3 initAmount = initPos - (destPos - initPos) * lerPAmount(0);
        while (t < period)
        {
            myTransform.position = initPos + (destPos - initPos) * lerpSinAmount(t);
            t += Time.deltaTime;
            yield return null;
        }
        myTransform.position = destPos;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform MuzzlePoint;

    #endregion
    #region MonoBehaviouCallBacks
    private void Start()
    {
        ObjectPool.preWarmPool(bulletPrefab, 5);
    }
    private void OnEnable()
    {
        MoveCharacter.onShoot += Shoot;
    }
    private void OnDisable()
    {
        MoveCharacter.onShoot -= Shoot;
    }
    #endregion
    #region Functions
    public void Shoot()
    {
        Rigidbody bulletRB = ObjectPool.Instantiate(bulletPrefab, MuzzlePoint.position, MuzzlePoint.rotation).GetComponent<Rigidbody>();
        bulletRB.AddForce(10.0f * MuzzlePoint.forward, ForceMode.VelocityChange);
        //bulletRB.velocity = 10.0f * MuzzlePoint.forward;
    }
    #endregion
}

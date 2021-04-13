﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject staticPlatformPrefab;
    [SerializeField] Movement movementReference;
    float rightX;
    float leftX;
    float toppestY;
    public static ObstacleGenerator instance;

    [SerializeField] Transform toppestBlock;
    float topY = 0.0f;
    #endregion
    #region MonobehaviourCallBacks
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        topY = toppestBlock.position.y;
        ObjectPool.preWarmPool(staticPlatformPrefab, 7);

    }
    private void Start()
    {
        rightX = movementReference.GetRightX();
        leftX = movementReference.GetLeftX();
    }

    #endregion
    #region Functions
    public void CreateNewObstacle()
    {
        Vector3 pos = calcRandPos();
        topY = pos.y;
        ObjectPool.Instantiate(staticPlatformPrefab, pos, Quaternion.identity);
    }
    public Vector3 calcRandPos()
    {
        Vector3 outPut = new Vector3();
        outPut.x = Random.Range(leftX, rightX);
        outPut.y = topY + 1.2f;
        outPut.z = 0;
        return outPut;
    }
    #endregion

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;

    public GameObject FactoryMethod(int tag)
    {
        GameObject enemy = enemyPrefab[tag];
        return enemy;
    }

    public int GetNPrefab()
    {
        return this.enemyPrefab.Length;
    }
}
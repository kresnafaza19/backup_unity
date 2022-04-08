using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] pillPrefab;

    public GameObject FactoryMethod(int tag)
    {
        GameObject enemy = pillPrefab[tag];
        return enemy;
    }

    public int GetNPrefab()
    {
        return this.pillPrefab.Length;
    }
}
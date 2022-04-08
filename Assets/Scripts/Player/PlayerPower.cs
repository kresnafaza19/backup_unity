using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    // Start is called before the first frame update
    int currPower = 0;
    public int initPower = 20;
    public int maxPower = 100;
    public Slider powerSlider;
    void Start()
    {
        this.currPower = this.initPower;
    }

    // Update is called once per frame
    void Update()
    {
        this.powerSlider.value = this.currPower;
        //Debug.Log("player power: " + this.currPower);
    }

    public int GetPower()
    {
        return this.currPower;
    }

    public void AddPower(int p)
    {
        this.currPower += p;
        if(this.currPower > this.maxPower)
        {
            this.currPower = this.maxPower;
        }
    }
}

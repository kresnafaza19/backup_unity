using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int gameMode;
    public float timeBetweenUpgrades = 5f;
    public PlayerShooting playerShooting;
    public GameObject[] upgrades;

    float timer = 0f;
    int[] upgradeCounts = new int[] {2, 2};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ShowUpgrade()
    {
        for (int i=0; i < upgrades.Length; i++)
        {
            if (upgradeCounts[i] > 0)
            {
                upgrades[i].SetActive(true);
            }
        }
    }

    void HideUpgrade()
    {
        for (int i=0; i < upgrades.Length; i++)
        {
            upgrades[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMode == 1)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenUpgrades && Time.timeScale != 0)
            {
                ShowUpgrade();
                if (Input.GetKeyDown(KeyCode.Alpha1) && upgradeCounts[0] > 0)
                {
                    playerShooting.AddBullet();
                    timer = 0f;
                    upgradeCounts[0] -= 1;
                    HideUpgrade();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && upgradeCounts[1] > 0)
                {
                    playerShooting.FireSpeedUp();
                    timer = 0f;
                    upgradeCounts[1] -= 1;
                    HideUpgrade();
                }
            }
        }

        else
        {
            // if boss killed
                // ShowUpgrade();
                if (Input.GetKeyDown(KeyCode.Alpha1) && upgradeCounts[0] > 0)
                {
                    playerShooting.AddBullet();
                    upgradeCounts[0] -= 1;
                    HideUpgrade();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && upgradeCounts[1] > 0)
                {
                    playerShooting.FireSpeedUp();
                    upgradeCounts[1] -= 1;
                    HideUpgrade();
                }
        }
    }
}

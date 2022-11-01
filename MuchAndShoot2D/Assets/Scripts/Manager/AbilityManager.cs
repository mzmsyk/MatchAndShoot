using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject freezengPanel;
    public GameObject freezengButton;
    public GameObject bombPanel;
    public GameObject bombButton;
    public static AbilityManager instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        //Time.timeScale = 0;
    }


    public void Freezing()
    {
        freezengButton.SetActive(true);
        freezengPanel.SetActive(false);
        Ads.instance.ShowRewardedFreezing();
    }
    public void Bomb()
    {
        bombButton.SetActive(true);
        bombPanel.SetActive(false);
        Ads.instance.ShowRewardedBomb();
    }
}

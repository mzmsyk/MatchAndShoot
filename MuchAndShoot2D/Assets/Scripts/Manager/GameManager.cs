using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public LevelManager levelManager;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void LevelFailed()
    {
        LevelManager.instance.LevelFailed();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryColliderController : MonoBehaviour
{
    //public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag=="fullcircle"|| col.gameObject.tag == "intertwinedcircle" || col.gameObject.tag == "hollowcircle" || col.gameObject.tag == "hollowlittlecircle")
        //{
        //    Time.timeScale = 0;
        //    gameManager.LevelFailed();
        //}
        if (col.gameObject.tag=="boundary")
        {
            GameManager.instance.LevelFailed();
        }
    }
}

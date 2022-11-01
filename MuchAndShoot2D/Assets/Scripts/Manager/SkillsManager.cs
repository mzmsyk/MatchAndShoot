using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    public static SkillsManager instance;
    public Rigidbody2D fallingRigidbody;
    public GameObject freezing;
    public GameObject bomb;
    public List<GameObject> falling;
    public GameObject _fallingg;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    public void FreezingAbility()
    {

        fallingRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        freezing.SetActive(false);
        StartCoroutine(FreezingDelay());
    }
    public void BombAbility()
    {
        for (int i = 0; i < 3; i++)
        {
            //Destroy(_fallingg.transform.GetChild(i).gameObject);
            
            Destroy(falling[i]);
            //falling.RemoveAt(0);
            //falling.TrimExcess();
            //falling[i].SetActive(false);
        }
        bomb.SetActive(false);
        LevelManager.instance.LevelNext(3);
        if (DOFadeListController.instance.isActiveAndEnabled==true)
        {
            DOFadeListController.instance.counter = 2;
            DOFadeListController.instance.ListFade();
        }
        
        //StartCoroutine(BombDelay());
    }
    IEnumerator FreezingDelay()
    {
        yield return new WaitForSeconds(3);
        //fallingMoveController.MovePlay();
        fallingRigidbody.constraints = RigidbodyConstraints2D.None;
        
    }
    IEnumerator BombDelay()
    {
        yield return new WaitForSeconds(3);

    }
}

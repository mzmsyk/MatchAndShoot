using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOFadeListController : MonoBehaviour
{
    public List<Transform> falling = new List<Transform>();
    public int counter = 0;
    public static DOFadeListController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ListFade()
    {
        falling[counter+1].gameObject.SetActive(true);
        falling[counter+1].GetComponent<SpriteRenderer>().DOFade(1, 0.2f);
        //falling.RemoveAt(counter);
        counter++;

    }
}

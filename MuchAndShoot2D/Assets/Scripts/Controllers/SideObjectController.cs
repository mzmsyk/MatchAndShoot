using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideObjectController : MonoBehaviour
{
    public float x = 0.6f;
    public bool isLeftSide = false;
    public bool isRightSide = false;
    public GameObject[] obj;
    bool control = true;
    bool control2 = false;
    private void Awake()
    {
       
    }
    private void Update()
    {
        if (this.transform.childCount==0)
        {
            Destroy(this.gameObject);
        }
        if (obj[0]==null&&control)
        {
            SideObjectMove();
            control = false;
            control2 = true;
        }
        if (obj[1] == null && control2)
        {
            //x += 1.2f;
            SideObjectMove();
            control2 = false;
        }
    }
    public void SideObjectMove()
    {
        if (isRightSide)
        {
            transform.DOMoveX(-x, 0.2f).SetEase(Ease.OutBounce);
            x += 0.6f;
            control = false;
            control2 = false;
        }
        
        if (isLeftSide)
        {
            transform.DOMoveX(x, 0.2f).SetEase(Ease.OutBounce);
            x += 0.6f;
            control = false;
            control2 = false;
        }
        
    }

}

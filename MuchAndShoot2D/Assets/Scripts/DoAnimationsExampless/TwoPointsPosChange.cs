using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TwoPointsPosChange : MonoBehaviour
{
    public GameObject obj;
    public GameObject activeObj;
    public float objectPosition;
    bool isMove = false;
    public float duration = 1;
    public float startTime = 7;
    void Start()
    {
        Invoke("AnimDoTwenen", startTime);
    }

    
    void Update()
    {
        if (isMove&&activeObj.activeInHierarchy)
        {
            transform.DOLocalMoveY(objectPosition, duration).SetEase(Ease.InOutQuad).SetLoops(1);
        }
    }
    public void AnimDoTwenen()
    {
        isMove = true;
    }

}

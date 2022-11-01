using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootObjectMoveControllers : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D _rigidbody2D;
    public bool isMoving = true;
    void Start()
    {

    }

    void Update()
    {
        if (isMoving)
        {
            _rigidbody2D.velocity = Vector2.up * speed;
            //transform.DOMoveY(Vector2.up.y * 10, 1f).SetEase(Ease.Linear);
            //transform.Translate(Vector2.up * speed);
        }
    }
    public void DoKill()
    {
        transform.DOKill();
    }
}

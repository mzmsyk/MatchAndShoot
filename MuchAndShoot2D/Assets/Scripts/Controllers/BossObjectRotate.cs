using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossObjectRotate : MonoBehaviour
{
    public static BossObjectRotate instance;
    float euler;
    float eulerCounter;
    public int edgeCount = 4;

    public Rigidbody2D rigidbody2D;
    bool isMove = true;
    public float speed = 0.5f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
        eulerCounter = 360 / edgeCount;
        euler = eulerCounter;
    }
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (isMove)
        {
            rigidbody2D.velocity = new Vector3(0, speed, 0);
        }
    }
    public void BossRotate()
    {
        transform.DORotate(new Vector3(0,0,euler), 0.2f);
        euler += eulerCounter;

        
    }
}

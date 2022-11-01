using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMoveController : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D _rigidbody2D;
    public bool isMove = true;
    public static FallingMoveController instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isMove)
        {
            _rigidbody2D.velocity = Vector2.down * speed;
        }
        
    }
    public void MoveStop()
    {
        isMove = false;
    }
    public void MovePlay()
    {
        isMove = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public Transform point;
    string temp;
    bool isHit=true;
    [HideInInspector] public bool isRay = false;
    public ShootManager shootManager;
    private void Update()
    {
        //RayMove();
    }

    public void RayMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, Vector2.up,6.5f);
        if (hit&&isRay)
        {
            Debug.DrawRay(point.position, Vector2.up, Color.red);
            isRay = false;
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == temp && isHit)
            {
                isHit = false;
                
                shootManager.Shoot(temp, true);
            }
        }
    }
    public void ControllerColliderHit(string tag)
    {
        temp = tag;
        isHit = true;
    }
}

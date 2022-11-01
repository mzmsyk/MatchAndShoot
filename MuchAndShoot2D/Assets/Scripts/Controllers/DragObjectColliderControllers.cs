using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragObjectColliderControllers : MonoBehaviour
{
    public string[] tagObject;
    public ShootManager shootManager;
    public float duration;
    public float strenght;
    public int vibrato;
    public float randomness;
    int counter = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        for (int i = 0; i < tagObject.Length; i++)
        {
            if (col.gameObject.tag == tagObject[i])
            {
                shootManager.Shoot(tagObject[i],true);
                transform.DOLocalRotate(new Vector3(0, 0, 60+counter), 0.2f);
                counter += 60;
                //transform.DOShakePosition(duration, strenght, vibrato, randomness);
                //transform.DOJump(new Vector3(0,0.2f,0), 0.2f, 1,1);
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    bool isShoot = false;
    bool isMove = false;
    public Transform shootPoint;
    public Transform fallingObjects;
    public GameObject[] shootObjects=new GameObject[4];
    public static ShootManager instance;
    //public int score;
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
        float dis = Vector3.Distance(shootPoint.position, fallingObjects.localPosition);
        if (dis<=6.5)
        {
            isMove = true;
        }
    }
    public void Shoot(string tag,bool _isShoot)
    {
       
        isShoot = _isShoot;
        if (isMove&&isShoot&&tag=="fullcircle")
        {
            Instantiate(shootObjects[0], shootPoint.position, shootPoint.rotation);
            shootObjects[0].SetActive(true);
            isShoot = false;
            //score++;
            //LevelManager.instance.LevelNext(score);
            
        }
        if (isMove && isShoot && tag == "intertwinedcircle")
        {
            Instantiate(shootObjects[1], shootPoint.position, shootPoint.rotation);
            shootObjects[1].SetActive(true);
            isShoot = false;
            //score++;
            //LevelManager.instance.LevelNext(score);
            
        }
        if (isMove && isShoot && tag == "hollowcircle")
        {
            Instantiate(shootObjects[2], shootPoint.position, shootPoint.rotation);
            shootObjects[2].SetActive(true);
            isShoot = false;
            //score++;
            //LevelManager.instance.LevelNext(score);
            
        }
        if (isMove && isShoot && tag == "hollowlittlecircle")
        {
            Instantiate(shootObjects[3], shootPoint.position, shootPoint.rotation);
            shootObjects[2].SetActive(true);
            isShoot = false;
            //score++;
            //LevelManager.instance.LevelNext(score);
            
        }
    }
}

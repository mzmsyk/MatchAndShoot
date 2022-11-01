using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingObjectsColliderControllers : MonoBehaviour
{

    public Transform falling;
    public SideObjectController sideObjectController;
    private void Awake()
    {
        //sideObjectController = null;
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != gameObject.tag)
        {
            ObjectOperations(col);
            Stack(col.transform);
            LevelManager.instance.LevelNext(-1);
            SkillsManager.instance.falling.Insert(0,col.gameObject);

            SkillsManager.instance.falling.TrimExcess();
        }
        else
        {
            SkillsManager.instance.falling.RemoveAt(0);
            sideObjectController.SideObjectMove();
            LevelManager.instance.LevelNext(1);
            Destroy(col.gameObject);
        }

    }
    public void Stack(Transform col)
    {
        Destroy(col.GetComponent<TrailRenderer>());
        col.transform.localPosition = new Vector3(0, this.transform.localPosition.y-0.6f, 0);
    }
    public void ObjectOperations(Collider2D col)
    {
        //col.GetComponent<ShootObjectMoveControllers>().DoKill();
        Destroy(col.GetComponent<ShootObjectMoveControllers>());
        Destroy(col.GetComponent<Rigidbody2D>());
        Destroy(col.GetComponent<ShootColliderControllers>());
        col.transform.parent = falling.transform;
        col.gameObject.AddComponent(typeof(FallingObjectsColliderControllers));
        col.gameObject.GetComponent<FallingObjectsColliderControllers>().falling = falling;
        col.gameObject.AddComponent<BoundaryColliderController>();
        col.gameObject.GetComponent<FallingObjectsColliderControllers>().sideObjectController = falling.GetChild(transform.childCount).GetComponent<SideObjectController>();
    }
}

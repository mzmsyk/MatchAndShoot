using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosManager : MonoBehaviour
{
    public Transform falling;
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != gameObject.tag)
        {
            ObjectOperations(col);
            Stack(col.transform);
            BossObjectRotate.instance.BossRotate();
            SkillsManager.instance.falling.Insert(0, col.gameObject);
            LevelManager.instance.LevelNext(-1);
        }
        else
        {
            BossObjectRotate.instance.BossRotate();
            Destroy(col.gameObject);
            LevelManager.instance.LevelNext(1);
            SkillsManager.instance.falling.RemoveAt(0);
        }

    }
    public void Stack(Transform col)
    {
        Destroy(col.GetComponent<TrailRenderer>());
        col.transform.localPosition = new Vector3(0, this.transform.localPosition.y - 0.6f, 0);
    }
    public void ObjectOperations(Collider2D col)
    {
        col.GetComponent<ShootObjectMoveControllers>().DoKill();
        Destroy(col.GetComponent<ShootObjectMoveControllers>());
        Destroy(col.GetComponent<Rigidbody2D>());
        Destroy(col.GetComponent<ShootColliderControllers>());
        col.transform.parent = falling.transform;
        col.gameObject.AddComponent(typeof(BoosManager));
        col.gameObject.GetComponent<BoosManager>().falling = falling;
        col.gameObject.AddComponent<BoundaryColliderController>();
    }
}

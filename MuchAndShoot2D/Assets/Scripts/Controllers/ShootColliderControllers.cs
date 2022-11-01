using DG.Tweening;
using UnityEngine;

public class ShootColliderControllers : MonoBehaviour
{
    public GameObject effect;
    Color color;
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag==gameObject.tag)
        {
            Instantiate(effect, col.gameObject.transform.position, col.gameObject.transform.rotation);
            //color.a = 0.5f;
            //col.GetComponent<SpriteRenderer>().DOColor(color, 0.5f);
            //col.GetComponent<SpriteRenderer>().DOFade(0, 0.3f);
            Destroy(col.gameObject,0f);
            
        }
        
    }
}

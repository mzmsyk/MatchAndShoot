using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragAndDropControllers : MonoBehaviour
{
    
    [HideInInspector] public Vector2 firstPos;
    [HideInInspector] public bool isDragging;
    Vector2 offset;
    private void Awake()
    {
        firstPos = transform.position;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!isDragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition-offset;
    }
    private void OnMouseDown()
    {
        isDragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        transform.DOScale(new Vector3(0.9f, 0.9f, 1), 0.2f);
    }
    private void OnMouseUp()
    {
        transform.position = firstPos;
        isDragging = false;
        transform.DOScale(new Vector3(0.5576962f, 0.5576962f, 1), 0.2f);
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="base")
        {
            transform.position = firstPos;
            isDragging = false;
            transform.DOScale(new Vector3(0.5576962f, 0.5576962f, 1), 0.2f);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        this.gameObject.SetActive(false);
        transform.DOScale(new Vector3(0, 0, 1), 0.2f);
        Invoke("Scalee", 0.2f);
    }
    
    public void Scalee()
    {
        this.gameObject.SetActive(true);
        transform.DOScale(new Vector3(0.5576962f, 0.5576962f, 1), 0.2f);
    }
}

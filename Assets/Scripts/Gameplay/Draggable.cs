using System;
using UnityEngine;
public class Draggable : MonoBehaviour
{
    public Action onRelease;
    //private Vector3 _dragOffset;
    private Camera _cam;

    [SerializeField] private float _speed = 10;

    void Awake()
    {
        _cam = Camera.main;
    }

    private void OnMouseUpAsButton()
    {
        onRelease?.Invoke();
    }

    void OnMouseDown()
    {
        //_dragOffset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        //transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        transform.position = GetMousePos();
    }
    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
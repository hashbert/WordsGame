using System;
using UnityEngine;

public class CardHover : MonoBehaviour
{
    public Action onHover;

    private Vector3 _originalScale;
    [SerializeField] private float _scaleAmount = 1.1f;
    private float _tweenTime = 0.2f;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        ApplyScaling();
        onHover?.Invoke();
    }
    private void OnMouseExit()
    {
        ApplyOriginalScale();
    }
    private void OnMouseUp()
    {
        ApplyOriginalScale();
    }
    private void ApplyScaling()
    {
        if (!enabled) return;
        LeanTween.scale(gameObject, _originalScale * _scaleAmount, _tweenTime).setEaseOutBounce().setIgnoreTimeScale(true);
    }
    private void ApplyOriginalScale()
    {
        LeanTween.scale(gameObject, _originalScale, _tweenTime).setEaseOutBounce().setIgnoreTimeScale(true);
    }
    public void Disable()
    {
        ApplyOriginalScale();
        enabled = false;
    }
}

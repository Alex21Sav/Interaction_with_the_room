using System;
using UnityEngine;
using DG.Tweening;

public class RemoteController : MonoBehaviour, ITarget
{
    [SerializeField] private Transform _targetPosition;
    private bool _getRemoteController = false;
    
    public static event Action GetController;
    public static event Action ThrowController;

    private void OnEnable()
    {
        Furniture.DownController += ThrowRemoteController;
        RaycastHitTarget.NotTarget += ThrowRemoteController;
    }
    private void OnDisable()
    {
        RaycastHitTarget.NotTarget -= ThrowRemoteController;
        Furniture.DownController -= ThrowRemoteController;
    }
    private void LateUpdate()
    {
        if (_getRemoteController)
        {
            transform.position = _targetPosition.position;
            transform.rotation = _targetPosition.rotation;
        }
    }
    public void PlayActionTarget()
    {
        transform.DOMove(_targetPosition.position, 0.2f).OnComplete((() =>
        {
            _getRemoteController = true;
            GetController?.Invoke();
        })); ;
    }
    private void ThrowRemoteController()
    {
        ThrowController?.Invoke();
        _getRemoteController = false;
    }
}

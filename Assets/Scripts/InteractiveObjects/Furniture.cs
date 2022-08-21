using System;
using UnityEngine;
using DG.Tweening;

public class Furniture : MonoBehaviour, ITarget
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private GameObject _remoteController;
    
    private bool _getRemoteController;
    
    public static event Action DownController;
    private void OnEnable()
    {
        RemoteController.GetController += ControllerHand;
        RemoteController.ThrowController += NotControllerHand;
    }
    private void OnDisable()
    {
        RemoteController.GetController -= ControllerHand;
        RemoteController.ThrowController -= NotControllerHand;
    }
    
    private void NotControllerHand()
    {
        _getRemoteController = false;
    }

    private void ControllerHand()
    {
        _getRemoteController = true;
    }

    public void PlayActionTarget()
    {
        if (_getRemoteController)
        {
            DownController?.Invoke();
            _remoteController.transform.DOMove(_targetPosition.position, 0.2f).OnComplete((() =>
            {
                _getRemoteController = true;
            })); ;
        }
    }
}

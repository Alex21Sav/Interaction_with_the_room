using UnityEngine;

public class TV : MonoBehaviour, ITarget
{
    [SerializeField] private GameObject _TV;
    private bool _getRemoteController = false;
    private bool _isTVActive= false;

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
    public void PlayActionTarget()
    {
        if (_getRemoteController)
        {
            if (!_isTVActive)
            {
                _TV.SetActive(true);
                _isTVActive = true;
            }
            else
            {
                _TV.SetActive(false);
                _isTVActive = false;
            }    
        }
    }
    private void ControllerHand()
    {
        _getRemoteController = true;
    }
    
    private void NotControllerHand()
    {
        _getRemoteController = false;
    }
}

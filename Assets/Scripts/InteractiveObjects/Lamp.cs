using UnityEngine;

public class Lamp : MonoBehaviour, ITarget
{
    [SerializeField] private GameObject _light;
    [SerializeField] private Renderer[] _emission;
    private bool _isActive = true;
    public void PlayActionTarget()
    {
        if (_isActive)
        {
            _light.SetActive(false);
            _isActive = false;
            foreach (var item in _emission)
            {
                item.material.DisableKeyword("_EMISSION");
            }
        }
        else
        {
            _light.SetActive(true);
            _isActive = true;
            foreach (var item in _emission)
            {
                item.material.EnableKeyword("_EMISSION");
            }

        }
    }
}

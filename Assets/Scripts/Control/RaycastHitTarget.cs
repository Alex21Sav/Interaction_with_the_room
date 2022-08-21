using System;
using UnityEngine;
using DG.Tweening;

public class RaycastHitTarget : MonoBehaviour 
{
    [SerializeField] private RectTransform _targetImage;
    private Tweener _tweener;
    
    public static event Action NotTarget;
    private void Update()
    {
        GetTarget();
    }
    private void GetTarget()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);

        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            ITarget target = raycastHit.collider.gameObject.GetComponent<ITarget>();
            if (target != null)
            {
                _tweener = _targetImage.DOScale(2f, 0.5f);
                if (Input.GetMouseButtonDown(0))
                {
                        target.PlayActionTarget();
                }
            }
            if(Input.GetMouseButtonDown(0) && target == null)
            {
                    NotTarget?.Invoke();
            }
            _targetImage.DOScale(1, 0.5f);
        }
    }
}

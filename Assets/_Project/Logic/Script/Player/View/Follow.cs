using UnityEngine;
using UnityEngine.UI;

public class Follow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;

    private void Update()
    {
        if(_target != null)
        {
            transform.position = _target.position + _offset;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetTarget(Transform target)
    {
        this._target = target;
    }
}

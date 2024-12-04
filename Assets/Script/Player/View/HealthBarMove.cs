using UnityEngine;
using UnityEngine.UI;

public class HealthBarMove : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

    private void Update()
    {
        if(target != null)
        {
            transform.position = target.position + offset;
        }
    }
}

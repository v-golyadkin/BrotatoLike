using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            Vector2 desiredPosition = (Vector2)_target.position;
            Vector2 smoothedPosition = Vector2.Lerp((Vector2)transform.position, desiredPosition, _smoothSpeed);

            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
        }

    }

    public void Init(Transform player)
    {
        _target = player;
    }
}

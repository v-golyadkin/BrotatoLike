using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestory = 3f;

    private void Update()
    {
        timeToDestory -= Time.deltaTime;

        if(timeToDestory < 0)
        {
            Destroy(gameObject);
        }
    }
}

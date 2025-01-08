using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gun", fileName = "New Gun")]
public class ScriptableGun : ScriptableObject
{
    [SerializeField] public float fireDistance = 10f;
    [SerializeField] public float fireRate = 0.5f;
    [SerializeField] public int damagePerShoot = 1;

    [SerializeField] public GameObject Prefab;
}

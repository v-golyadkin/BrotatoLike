using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Units/Enemy", fileName ="New Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField] public int Health;
    [SerializeField] public int AttackValue;
    [SerializeField] public int MoveSpeed;

    [SerializeField] public GameObject Prefab;
}

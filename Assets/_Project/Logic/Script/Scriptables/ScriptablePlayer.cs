using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Units/Player", fileName = "New Player")]
public class ScriptablePlayer : ScriptableObject
{
    [SerializeField] public int Health;
    [SerializeField] public int MoveSpeed;

    [SerializeField] public GameObject Prefab;
}

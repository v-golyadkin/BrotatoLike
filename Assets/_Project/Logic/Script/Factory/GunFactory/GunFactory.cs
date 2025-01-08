using System.Reflection;
using UnityEngine;

public class GunFactory
{
    public Gun Create(Transform player, Vector2 spawnPosition, Transform gunParent)
    {  
        var gunConfig = Resources.Load<ScriptableGun>("Configs/GunConfig/revolver");
        var go = GameObject.Instantiate(gunConfig.Prefab);
        var gun = go.GetComponent<Gun>();
        gun.Init(player, gunConfig);
        gun.SetOffset(spawnPosition);

        gun.transform.SetParent(gunParent);

        return gun;
    }
}

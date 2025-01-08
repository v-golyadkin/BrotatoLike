using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : UnitsFactory
{
    private List<ScriptableEnemy> _enemyList = new List<ScriptableEnemy>();



    public override UnitBase Create()
    {
        //var enemyConfig = Resources.Load<ScriptableEnemy>("Configs/EnemiesConfig/snake");
        //var enemyConfig = Resources.Load<ScriptableEnemy>("Configs/EnemiesConfig/snake_fast");
        //var enemyConfig = Resources.Load<ScriptableEnemy>("Configs/EnemiesConfig/snake_heavy");

        _enemyList.Add(Resources.Load<ScriptableEnemy>("Configs/EnemiesConfig/snake_fast"));
        _enemyList.Add(Resources.Load<ScriptableEnemy>("Configs/EnemiesConfig/snake_heavy"));
        _enemyList.Add(Resources.Load<ScriptableEnemy>("Configs/EnemiesConfig/snake"));

        //var enemyConfig = _enemyList[Random.Range(0, _enemyList.Count)];

        var enemyConfig = _enemyList[2];

        var go = GameObject.Instantiate(enemyConfig.Prefab);
        var enemy = go.GetComponent<EnemyBase>();

        enemy.Init(enemyConfig.Health, enemyConfig.AttackValue, enemyConfig.MoveSpeed);

        return enemy;
    }

    public UnitBase Create(Vector2 spawnPosition)
    {
        var enemy = Create();
        enemy.transform.position = new Vector3(spawnPosition.x, spawnPosition.y);

        return enemy;
    }

    public UnitBase Create(Vector2 spawnPosition, Transform parent)
    {
        var enemy = Create(spawnPosition);
        enemy.transform.SetParent(parent);

        return enemy;
    }
}

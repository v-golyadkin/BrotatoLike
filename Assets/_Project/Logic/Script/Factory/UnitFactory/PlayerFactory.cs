using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : UnitsFactory
{
    public override UnitBase Create()
    {
        var playerConfig = Resources.Load<ScriptablePlayer>("Configs/PlayersConfig/player_base");
        //var playerConfig = Resources.Load<ScriptablePlayer>("Configs/PlayersConfig/player_fast");
        //var playerConfig = Resources.Load<ScriptablePlayer>("Configs/PlayersConfig/player_heavy");
        var go = GameObject.Instantiate(playerConfig.Prefab);
        var player = go.GetComponent<Player>();

        player.Init(playerConfig.Health, playerConfig.MoveSpeed);

        return player;
    }

    public UnitBase Create(Vector2 spawnPoint)
    {
        var player = Create();

        player.transform.position = new Vector2(spawnPoint.x, spawnPoint.y);

        return player;
    }
}

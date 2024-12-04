using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;

    private Transform _player;
    private List<Vector2> gunPositions = new List<Vector2>();

    private int _spawnedGun = 0;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        gunPositions.Add(new Vector2(1.2f, 1f));
        gunPositions.Add(new Vector2(-1.2f, 1f));

        gunPositions.Add(new Vector2(1.4f, 0.2f));
        gunPositions.Add(new Vector2(-1.4f, 0.2f));

        gunPositions.Add(new Vector2(1f, -0.5f));
        gunPositions.Add(new Vector2(-1f, -0.5f));

        AddGun();
        AddGun();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            AddGun();
    }

    private void AddGun()
    {
        var position = gunPositions[_spawnedGun];

        var newGun = Instantiate(gunPrefab, position, Quaternion.identity);

        newGun.GetComponent<Gun>().SetOffset(position);
        _spawnedGun++;
    }
}

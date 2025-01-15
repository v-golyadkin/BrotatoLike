using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] Transform gunsParent;


    private Transform _player;
    private List<Vector2> gunPositions = new List<Vector2>();

    private GunFactory _gunFactory;
    
    private int _spawnedGun = 0;

    public static GunSpawner Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _gunFactory = new GunFactory();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //    AddGun();
    }

    public void Init(Transform player)
    {
        _player = player;

        gunPositions.Add(new Vector2(1.4f, 0.2f));
        gunPositions.Add(new Vector2(-1.4f, 0.2f));

        gunPositions.Add(new Vector2(1.2f, 1f));
        gunPositions.Add(new Vector2(-1.2f, 1f));

        gunPositions.Add(new Vector2(1f, -0.5f));
        gunPositions.Add(new Vector2(-1f, -0.5f));

        AddGun();
    }

    public void DestroyAllGun()
    {
        foreach (Transform gun in gunsParent)
            Destroy(gun.gameObject);
    }

    private void AddGun()
    {
        var position = gunPositions[_spawnedGun];
       
        var newGun = _gunFactory.Create(_player, position, gunsParent);

        _spawnedGun++;
    }

    public void TryAddGun()
    {
        AddGun();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string CurrentCityName;
    public string DestinationCityName;
    public List<CargoItem> Cargo;

    public static PlayerStats Instance;

    public float Speed;
    public int JumpCount;
    public float JumpHeight;
    public float CargoSecurity;
    public float Health;

    public float EnemySpawnRatio;
    public float InvulnTime = 2;

    public LevelGenOptions UpcomingArea;

    private Dictionary<string, float> _costDictionary;
    public int CannonCount;
    public float CannonFiringDistance;
    public int ZipLineCount;
    public float ZipLineLength;

    private void Awake()
    {
        if(Instance ==null)
        {
            Instance = this;
            _costDictionary = new Dictionary<string, float>();
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    internal float GetUpgradeCost(string name)
    {
        if(_costDictionary.ContainsKey(name))
            return _costDictionary[name];
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetUpgradeCost(string name, float cost)
    {
        _costDictionary[name] = cost;
    }
}

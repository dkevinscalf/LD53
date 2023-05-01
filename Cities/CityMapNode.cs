using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class CityMapNode : MonoBehaviour
{
    public string Name;
    public List<Route> Routes;
    public GameObject RouteSelectionHUD;
    public TMPro.TextMeshProUGUI CityName;
    public TMPro.TextMeshProUGUI DestinationName;
    public GameObject PositionMarker;
    public GameObject CargoMenuItemPrefab;
    public GameObject AvailableCargoMenuItemPrefab;
    public Transform AvailableCargoWindow;
    public Transform CarriedCargoWindow;
    public CityMapNode[] CitiesForDelivery;
    public CargoItem[] CargoItems;
    public int MininumJobs=1;
    public int MaximumJobs = 3;
    public LevelGenOptions CityArea;
    private int _selectedRouteIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.Instance.CurrentCityName == Name)
            SelectThisCity();
    }

    internal void AcceptCargo(CargoItem cargo)
    {
        AddCargo(cargo, CargoMenuItemPrefab, CarriedCargoWindow);
    }

    private void SelectThisCity()
    {
        Instantiate(PositionMarker, transform.position, Quaternion.identity);
        RouteSelectionHUD.SetActive(true);
        SelectRoute(0);
        DisplayCargoMenu();
    }

    private void DisplayCargoMenu()
    {
        foreach(var cargo in PlayerStats.Instance.Cargo.OrderBy(o=>o.Destination==Name?0:1))
        {
            AddCargo(cargo, CargoMenuItemPrefab, CarriedCargoWindow);
        }

        for(var i = 0; i<UnityEngine.Random.Range(MininumJobs, MaximumJobs+1); i++)
        {
            var cargo = CargoItems.Random();
            cargo.Destination = CitiesForDelivery.Random().Name;
            AddCargo(cargo, AvailableCargoMenuItemPrefab, AvailableCargoWindow);
        }
    }

    private void AddCargo(CargoItem cargo, GameObject prefab, Transform carriedCargoWindow)
    {
        Instantiate(prefab, carriedCargoWindow).GetComponent<CargoMenuItem>().Setup(cargo, this);
    }

    public void SelectionChange(int v)
    {
        _selectedRouteIndex += v;
        if (_selectedRouteIndex < 0)
            _selectedRouteIndex = Routes.Count - 1;
        if (_selectedRouteIndex >= Routes.Count)
            _selectedRouteIndex = 0;
        SelectRoute(_selectedRouteIndex);
    }

    public void BeginRoute()
    {
        PlayerStats.Instance.UpcomingArea = CityArea;
        SceneManager.LoadScene("Game");
    }

    private void SelectRoute(int i)
    {
        var route = Routes[i];
        CityName.text = route.Cities[0].Name;
        DestinationName.text = route.Cities[1].Name;
        PlayerStats.Instance.DestinationCityName = route.Cities[1].Name;
        DisableAllRoutes();
        route.RouteIndicator.SetActive(true);
        FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().Follow = route.RouteIndicator.transform;
    }

    private void DisableAllRoutes()
    {
        foreach(var route in Routes)
        {
            route.RouteIndicator.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class Route
{
    public CityMapNode[] Cities;
    public GameObject RouteIndicator;
    public string Name { get
        {
            if (Cities.Length != 2)
                return "Unknown Route";
            else
                return $"{Cities[0].Name} to {Cities[1].Name}";
        } 
    }
}

[Serializable]
public class LevelGenOptions
{
    public int IslandCount = 20;
    public int MinimumGap = 2;
    public int MaximumGap = 5;
    [Range(0, 100)]
    public int EvenRatio = 50;
    [Range(0, 100)]
    public int UpRatio = 50;
    public int MaximumUp = 2;
    public int MaximumDown = -5;
    public int MinimumIslandSize = 2;
    public int MaximumIslandSize = 20;
    public int MinimumIslandHeight = 2;
    public int MaximumIslandHeight = 5;
    public Color FGColor = Color.white;
    public RuleTile FloorTile;
    public Color BGColor = Color.gray;
    public RuleTile BackgroundTile;
    public int BackgroundOffset = -1;
    public Vector3 GroundClutterOffset = Vector3.up;
    public GameObject[] GroundClutter;
    [Range(0, 100)]
    public int GroundClutterFill = 50;
    public GameObject[] Enemies;
}
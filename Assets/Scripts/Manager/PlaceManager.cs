using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Place
{
    PokeCenter = 0,
    Mart = 1,
    TownHouse1 = 2,
    TownHouse2 = 3,
    TownHouse3 = 4,
    TownHouse4 = 5
}

public class PlaceManager : MonoBehaviour
{
    public static PlaceManager instance = null;
    #region Singletone
    public static PlaceManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@PlaceManager");
            instance = go.AddComponent<PlaceManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public List<Places> places;

    public GameObject LoadMap(string scene)
    {
        Object map = Resources.Load($"Maps/{scene}/TileMaps");
        GameObject maps = (GameObject)Instantiate(map);

        return maps;
    }

    public GameObject LoadWall(string scene)
    {
        {
            Object wall = Resources.Load($"Maps/{scene}/NoPassLayers");
            GameObject walls = (GameObject)Instantiate(wall);

            return walls;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

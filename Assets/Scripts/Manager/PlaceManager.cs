using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

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

    Dictionary<int,Places> places = new Dictionary<int,Places>();


    void Start()
    {

    }

    public void RegisterPlacePortalData(int index,Places placedata)
    {
        places.Add(index,placedata);
    }

    public GameObject LoadPlaces(Place place)
    {

        Object plc = Resources.Load($"Maps/Places/{place}");
        GameObject places = (GameObject)Instantiate(plc);

        return places;
    }

    void Update()
    {

    }
}

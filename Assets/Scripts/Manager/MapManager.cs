using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance = null;
    #region Singletone
    public static MapManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@MapManager");
            instance = go.AddComponent<MapManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public GameObject LoadMap(string scene)
    {
        Object map = Resources.Load($"Maps/{scene}/TileMaps");
        GameObject maps = (GameObject)Instantiate(map);

        return maps;
    }
    
    public GameObject LoadWall(string scene)
    {
        {
            Object wall = Resources.Load($"Maps/{scene}/Barricades");
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

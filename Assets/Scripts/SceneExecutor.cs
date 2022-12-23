using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneExecutor : MonoBehaviour
{
    public enum Scene
    {
        MapScene = 0,
        PokemonCenter = 1,
        MartScene = 2,
        Houses = 3,
        House2 = 4,
        House3 = 5,
        House4 = 6
        
    }

    public static SceneExecutor instance;
    public MapChange mapchange;
    public string beforemapname;
    public string nowmapname;

    public static SceneExecutor GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@SceneExecutor");
            instance = go.AddComponent<SceneExecutor>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    //public Scene beforeScene;
    //public Scene nowScene;


    // Start is called before the first frame update
    void Start()
    {
        

        
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChange(MapChange mapchange)
    {
        
        SceneExecutor.instance.mapchange = mapchange;
        SceneExecutor.instance.beforemapname = mapchange.nowmapname;
        SceneExecutor.instance.nowmapname = mapchange.targetmapname;
        SceneManager.LoadScene(SceneExecutor.instance.nowmapname);

        
        foreach (Scene scene in Enum.GetValues(typeof(Scene)))
        {
            
            if(scene.ToString() == SceneExecutor.instance.nowmapname)
                AudioManager.instance.BgmPlay((int)scene);
        }
        foreach (Scene scene in Enum.GetValues(typeof(Scene)))
        {
            if (scene.ToString() == SceneExecutor.instance.beforemapname)
                AudioManager.instance.BgmStop((int)scene);
        }
    }




}

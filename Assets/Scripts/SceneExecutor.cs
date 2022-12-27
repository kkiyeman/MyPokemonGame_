using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    MapScene = 0,
    Battle = 1

}

public class SceneExecutor : MonoBehaviour
{
  

    public static SceneExecutor instance;
    
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

    public void SceneChange()
    {
        
        
       
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

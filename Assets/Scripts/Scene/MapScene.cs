using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Awake()
    {

        string scenename = Scene.MapScene.ToString();

        ObjectManager objectmanager = ObjectManager.GetInstance();
        objectmanager.CreateCharacter();
        PlayerMove.instance = FindObjectOfType<PlayerMove>();
        PlayerMove.instance.walkingSound.volume = 0.3f;

        objectmanager.CreateAudioManager();
        AudioManager.instance = FindObjectOfType<AudioManager>();
        AudioManager.instance.SetSound();
        AudioManager.instance.BgmPlay(0);



        UIManager uimanager = UIManager.GetInstance();
        uimanager.SetEventSystem();
        uimanager.OpenUI($"UI{scenename}");

        PlaceManager placemanager = PlaceManager.GetInstance();
        

        Object map = Resources.Load($"Maps/MapScene/TileMaps");
        GameObject maps = (GameObject)Instantiate(map);
        Object wall = Resources.Load($"Maps/MapScene/NoPassLayers");
        GameObject walls = (GameObject)Instantiate(wall);

        PortalManager portalmanager = PortalManager.GetInstance();
        portalmanager.LoadEnters(scenename);
        portalmanager.LoadSumms(scenename);

        SceneExecutor sceneexcutor = SceneExecutor.GetInstance();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene : MonoBehaviour
{
    public string a = "MapScene";
    
    // Start is called before the first frame update
    void Awake()
    {


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
        uimanager.OpenUI($"UI{a}");

        MapManager mapmanager = MapManager.GetInstance();
        mapmanager.LoadMap(a);
        mapmanager.LoadWall(a);

        PortalManager portalmanager = PortalManager.GetInstance();
        portalmanager.LoadEnters(a);
        portalmanager.LoadSumms(a);

        SceneExecutor sceneexcutor = SceneExecutor.GetInstance();

       
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

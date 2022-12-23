using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    #region Singletone
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@UIManager");
            instance = go.AddComponent<UIManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }
    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)
        {
            Object uiObj = Resources.Load($"UI/{uiName}");
            GameObject go = (GameObject)Instantiate(uiObj);
            uiList.Add(uiName, go);
        }
        else
        {
            uiList[uiName].SetActive(true);
        }

    }

    public Image bagui;
    public Image fader;
    public Image textbox;
    public Image baglog;

    public bool isuiOn = true;

    public bool isfaded = false;

    public PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }

        player = FindObjectOfType<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bagUIControll();
        
        
        
    }
    public void bagUIControll()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isuiOn)
            {
                bagui.gameObject.SetActive(isuiOn);
                isuiOn = false;
                player.StopMove();
                
            }
            else
            {
                bagui.gameObject.SetActive(isuiOn);                
                isuiOn = true;
                //PlayerMove.instance.ResumeMove();
            }
            
        }
    }



    public IEnumerator FadeIn(PlayerMove player)
    {
        player.stop = false;
        fader.gameObject.SetActive(true);
        isfaded = true;
        for (float i = 0.0f; i<=1.2f; i+=0.1f)
        {
            fader.color = new Color(0, 0, 0,i);
            yield return new WaitForSeconds(0.1f);
        }
        fader.gameObject.SetActive(false);
        isfaded = false;
        player.stop = true;
        
        
        
    }

    public IEnumerator FadeOut(PlayerMove player)
    {
        
        player.stop = false;
        fader.gameObject.SetActive(true);
        isfaded = true;
        for (float i = 1.2f; i >= -0.2f; i-=0.1f)
        {
            fader.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.1f);

        }
        isfaded = false;
        fader.gameObject.SetActive(false);
        player.stop = true;
       
        

    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager instance = null;
    #region Singletone
    public static PortalManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@PortalManager");
            instance = go.AddComponent<PortalManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public GameObject LoadEnters(string scene)
    {
        Object enterpoint = Resources.Load($"Portals/{scene}/EnterPoints");
        GameObject enterpoints = (GameObject)Instantiate(enterpoint);

        return enterpoints;
    }
    public GameObject LoadSumms(string scene)
    {
        Object summonpoint = Resources.Load($"Portals/{scene}/SummonPoints");
        GameObject summonpoints = (GameObject)Instantiate(summonpoint);

        return summonpoints;
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

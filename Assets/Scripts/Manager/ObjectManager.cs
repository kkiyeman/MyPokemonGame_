using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance = null;

    #region Singletone
    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion
    public GameObject CreateCharacter()
    {
        Object charObj = Resources.Load($"Characters/Player");
        GameObject character = (GameObject)Instantiate(charObj);

        DontDestroyOnLoad(character);

        return character;
    }
    public GameObject CreateAudioManager()
    {
        Object am = Resources.Load($"Managers/AudioManager");
        GameObject amr = (GameObject)Instantiate(am);
        DontDestroyOnLoad(amr);

        return amr;

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

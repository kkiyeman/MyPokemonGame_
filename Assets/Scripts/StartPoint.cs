using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPoint : MonoBehaviour
{
    public string beforemapname;
    
   
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        if (beforemapname == SceneExecutor.instance.beforemapname)
        {
            PlayerMove.instance.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        }
        else
            return;
        StartCoroutine(UIManager.instance.FadeOut(PlayerMove.instance));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

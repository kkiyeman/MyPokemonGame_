using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;
    public float speed;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        //if(instance == null)
        //{
        //    DontDestroyOnLoad(this.gameObject);
        //    instance = this;
           
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (target.gameObject != null)
        //{
        //    targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        //    transform.position = targetPosition;
        //    //this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, speed * Time.deltaTime);
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour
{
    public string placeName;
    public int index;
    public Transform entrance;
    public Transform exit;

    private void Start()
    {
        PlaceManager.GetInstance().RegisterPlacePortalData(index,this) ;
    }
}

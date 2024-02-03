using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharectersSides : MonoBehaviour
{
    GameObject charecter;

    private void Start ()
    {
        charecter = GameObject.Find("Charecter");
    }
    private void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name!="KillZone" && col.gameObject.name != "Icicles")
        {
            charecter.GetComponent<CharecterControler>().changeDir();
            //Debug.Log(gameObject.name);
        }
    }
}

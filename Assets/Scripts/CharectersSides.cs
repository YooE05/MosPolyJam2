using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharectersSides : MonoBehaviour
{
    GameObject charecter;
    public GameObject effects;

    private void Start ()
    {
        charecter = GameObject.Find("Charecter");
        //effects = GameObject.Find("RocksEffects");
    }
    private void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "DryGrounds" && col.gameObject.GetComponent<BoxCollider>().isTrigger && gameObject.name == "DownSide")
        {
            GameObject HitEffects = Instantiate(effects, col.transform.position - new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(HitEffects, 1);
            col.gameObject.SetActive(false);
        }

        if(col.gameObject.name != "KillZone" && col.gameObject.name != "Icicles" && gameObject.name != "DownSide")
        {
            charecter.GetComponent<CharecterControler>().changeDir();
            //Debug.Log(gameObject.name);
        }
    }
}

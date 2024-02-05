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
        if(gameObject.name == "DownSide")
        {
            if(col.gameObject.tag == "DryGrounds" && col.gameObject.GetComponent<BoxCollider>().isTrigger)
            {
                GameObject HitEffects = Instantiate(effects, col.transform.position - new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, 0, 0)));
                Destroy(HitEffects, 1);
                col.gameObject.SetActive(false);

                charecter.GetComponent<CharecterControler>().setSlowSpeed();
            }
            else
                charecter.GetComponent<CharecterControler>().setNormalSpeed();

           // if(col.gameObject.name == "lowerPlantTile")

        }
        else
        if(col.gameObject.tag == "Wall")
        {
            charecter.GetComponent<CharecterControler>().changeDir();
        }
    }

    private void OnTriggerStay (Collider col)
    {
        if(gameObject.name == "DownSide")
        {
            if(col.gameObject.tag == "DryGrounds" && col.gameObject.GetComponent<BoxCollider>().isTrigger)
            {
                
                charecter.GetComponent<CharecterControler>().setSlowSpeed();
            }
        }
    }

    /*private void OnTriggerExit (Collider col)
    {
        if(gameObject.name == "DownSide")
        {
            if(col.gameObject.tag != "DryGrounds")
            {
                charecter.GetComponent<CharecterControler>().setNormalSpeed();
            }
        }
    }*/
}

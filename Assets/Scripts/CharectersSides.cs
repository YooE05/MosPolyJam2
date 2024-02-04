using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharectersSides : MonoBehaviour
{
    GameObject charecter;
    public GameObject effects;
    public int effectDir = -90;

    private void Start ()
    {
        charecter = GameObject.Find("Charecter");
        //effects = GameObject.Find("RocksEffects");
    }
    private void OnTriggerEnter (Collider col)
    {
        if(gameObject.name == "DownSide")
        {
<<<<<<< Updated upstream
            Debug.Log("asda");
            GameObject HitEffects = Instantiate(effects, col.transform.position - new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(HitEffects, 1);
        }

        if(col.gameObject.name != "KillZone" && col.gameObject.name != "Icicles" && gameObject.name != "DownSide")
=======
            if(col.gameObject.tag == "DryGrounds" && col.gameObject.GetComponent<BoxCollider>().isTrigger)
            {
                GameObject HitEffects = Instantiate(effects, col.transform.position - new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(effectDir, 0, 0)));
                Destroy(HitEffects, 1);
                col.gameObject.SetActive(false);
                charecter.GetComponent<CharecterControler>().setSlowSpeed();
            }
            else
            if(col.gameObject.tag != "DryGrounds")
            {
                charecter.GetComponent<CharecterControler>().setNormalSpeed();
            }
        }
        else
        if(col.gameObject.tag == "Wall")
>>>>>>> Stashed changes
        {
            charecter.GetComponent<CharecterControler>().changeDir();
            //Debug.Log(gameObject.name);
        }
    }

    private void OnTriggerExit (Collider col)
    {
        if(col.gameObject.tag == "DryGrounds" && col.gameObject.GetComponent<BoxCollider>().isTrigger && gameObject.name == "DownSide")
        {
            charecter.GetComponent<CharecterControler>().setSlowSpeed();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharecterControler : MonoBehaviour
{
    private bool checkFinish = false;

    GameObject eventSystem;
    GameObject charecterImage;

    private float speed = 3;

    private bool LeftOrRight = true;

    void Start ()
    {
        eventSystem = GameObject.Find("EventSystem");
        charecterImage = GameObject.Find("CharecterImage");
    }

    void Update ()
    {
        transform.position += (LeftOrRight ? -1 : 1) * transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter (Collider col)
    {
        if(col.tag == "Finish")
        {
            checkFinish = true;
            //eventSistem.GetComponent<other>().playFinishSound();
            eventSystem.GetComponent<other>().OpenWinPanel();
        }

        if(col.tag == "KillZone" || col.tag == "Icicles")
        {
            speed = 0;
            eventSystem.GetComponent<Buttons>()._RestartLevel();
        }
    }

    public void changeDir ()
    {
        LeftOrRight = !LeftOrRight;
        charecterImage.gameObject.transform.localScale = new Vector3((LeftOrRight ? .1f : -.1f),1f,.2f);
    }
}

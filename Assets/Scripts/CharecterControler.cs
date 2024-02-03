using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharecterControler : MonoBehaviour
{
    GameObject eventSystem;
    GameObject charecterImage;
    private Vector3 StartPos;

    private float speed = 3;

    private bool LeftOrRight = true;

    void Start ()
    {
        eventSystem = GameObject.Find("EventSystem");
        charecterImage = GameObject.Find("CharecterImage");
        StartPos= transform.position;
    }

    void Update ()
    {
        GameObject.Find("SeasonsCount").GetComponent<TMP_Text>().SetText("всего за " + GameObject.Find("SeasonManager").GetComponent<SeasonManager>().Get_countOfSeasonSwitch() + " сезонов!");
        transform.position += (LeftOrRight ? -1 : 1) * transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter (Collider col)
    {
        if(col.tag == "Finish")
        {
            eventSystem.GetComponent<other>().OpenWinPanel(GameObject.Find("SeasonManager").GetComponent<SeasonManager>().Get_countOfSeasonSwitch());
            speed = 0;
        }

        if(col.tag == "KillZone" || col.tag == "Icicles")
        {
            speed = 0;
            Restart();
        }
    }

    public void changeDir ()
    {
        LeftOrRight = !LeftOrRight;
        charecterImage.gameObject.transform.localScale = new Vector3((LeftOrRight ? .1f : -.1f), 1f, .2f);
    }

    public void Restart ()
    {
        transform.position = StartPos;
        LeftOrRight = true;
        charecterImage.gameObject.transform.localScale = new Vector3((LeftOrRight ? .1f : -.1f), 1f, .2f);
        speed = 3;

        eventSystem.GetComponent<IciclesANDDryGrounds>().Restart();
    }
}

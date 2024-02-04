<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
=======
using System;
using TMPro;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.EventSystems;

public class CharecterControler : MonoBehaviour
{
    GameObject eventSystem;
    GameObject charecterImage;

    private float speed = 3;

<<<<<<< Updated upstream
    private bool LeftOrRight = true;

=======
    [SerializeField]
    private float _startSpeed = 3;
    [SerializeField]
    private float _slowSpeed = 2;
    private float _currentSpeed;

    private bool isMovingToleft;

    [SerializeField]
    private bool isStartToRight;


    [SerializeField]
    private Collider _leftCollider;
    [SerializeField]
    private Collider _rightCollider;



>>>>>>> Stashed changes
    void Start ()
    {
        eventSystem = GameObject.Find("EventSystem");
        charecterImage = GameObject.Find("CharecterImage");
    }

<<<<<<< Updated upstream
    void Update ()
=======
    private void InitPlayer ()
>>>>>>> Stashed changes
    {
        transform.position += (LeftOrRight ? -1 : 1) * transform.right * speed * Time.deltaTime;
    }

<<<<<<< Updated upstream
    private void OnTriggerEnter (Collider col)
    {
        if(col.tag == "Finish")
=======
        _leftCollider.enabled = false;
        _rightCollider.enabled = false;

        //т.к. изначально спрайт повёрнут вправо
        if(!isStartToRight)
>>>>>>> Stashed changes
        {
            //eventSistem.GetComponent<other>().playFinishSound();
            eventSystem.GetComponent<other>().OpenWinPanel();
            speed = 0;
        }

        if(col.tag == "KillZone" || col.tag == "Icicles")
        {
            speed = 0;
            eventSystem.GetComponent<Buttons>()._RestartLevel();
        }
    }

<<<<<<< Updated upstream
    public void changeDir ()
    {
        LeftOrRight = !LeftOrRight;
        charecterImage.gameObject.transform.localScale = new Vector3((LeftOrRight ? .1f : -.1f), 1f, .2f);
=======
    void Update ()
    {
        transform.position += (isMovingToleft ? -1 : 1) * transform.right * _currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter (Collider col)
    {
        if(col.tag == "Finish")
        {
            _currentSpeed = 0;
            OnPlayerWin?.Invoke();
        }

        if(col.tag == "KillZone" || col.tag == "Icicles")
        {
            _currentSpeed = 0;

            Restart();
            OnPlayerDied?.Invoke();
        }
    }

    public void changeDir ()
    {
        isMovingToleft = !isMovingToleft;

        _leftCollider.enabled = isMovingToleft;
        _rightCollider.enabled = !isMovingToleft;

        Vector3 crntScale = charecterImage.gameObject.transform.localScale;
        charecterImage.gameObject.transform.localScale = new Vector3(crntScale.x * -1f, crntScale.y, crntScale.z);

    }

    public void Restart ()
    {
        transform.position = StartPos;
        isMovingToleft = !isStartToRight;

        Vector3 crntScale = charecterImage.gameObject.transform.localScale;
        charecterImage.gameObject.transform.localScale = new Vector3(Mathf.Abs(crntScale.x), crntScale.y, crntScale.z);

        InitPlayer();
>>>>>>> Stashed changes
    }

    public void setSlowSpeed ()
    {
        _currentSpeed = _slowSpeed;
    }
    public void setNormalSpeed ()
    {
        _currentSpeed = _startSpeed;
    }
}

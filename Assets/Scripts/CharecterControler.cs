using System;
using UnityEngine;

public class CharecterControler : MonoBehaviour
{
    public Action OnPlayerDied;
    public Action OnPlayerWin;

    GameObject eventSystem;
    GameObject charecterImage;
    private Vector3 StartPos;


    [SerializeField]
    private float _startSpeed = 3;
    private float _currentSpeed;

    private bool isMovingToleft;

    [SerializeField]
    private bool isStartToRight;


    [SerializeField]
    private Collider _leftCollider;
    [SerializeField]
    private Collider _rightCollider;



    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        charecterImage = GameObject.Find("CharacterView");
        InitPlayer();

        StartPos = transform.position;
    }

    private void InitPlayer()
    {
        _currentSpeed = _startSpeed;

        _leftCollider.enabled = false;
        _rightCollider.enabled = false;

        //т.к. изначально спрайт повёрнут вправо
        if (!isStartToRight)
        {
            isMovingToleft = true;
            _leftCollider.enabled = true;
            Vector3 crntScale = charecterImage.gameObject.transform.localScale;
            charecterImage.gameObject.transform.localScale = new Vector3(crntScale.x * -1f, crntScale.y, crntScale.z);
        }
        else
        {
            _rightCollider.enabled = true;
            isMovingToleft = false;
        }
    }

    void Update()
    {
        // GameObject.Find("SeasonsCount").GetComponent<TMP_Text>().SetText("всего за " + GameObject.Find("SeasonManager").GetComponent<SeasonManager>().Get_countOfSeasonSwitch() + " сезонов!");
        transform.position += (isMovingToleft ? -1 : 1) * transform.right * _currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish")
        {
            _currentSpeed = 0;
            OnPlayerWin?.Invoke();
        }

        if (col.tag == "KillZone" || col.tag == "Icicles")
        {
            _currentSpeed = 0;

            Restart();
            OnPlayerDied?.Invoke();
        }
    }

    public void changeDir()
    {
        isMovingToleft = !isMovingToleft;

        _leftCollider.enabled = isMovingToleft;
        _rightCollider.enabled = !isMovingToleft;

        Vector3 crntScale = charecterImage.gameObject.transform.localScale;
        charecterImage.gameObject.transform.localScale = new Vector3(crntScale.x * -1f, crntScale.y, crntScale.z);

    }

    public void Restart()
    {
        transform.position = StartPos;
        isMovingToleft = !isStartToRight;

        Vector3 crntScale = charecterImage.gameObject.transform.localScale;
        charecterImage.gameObject.transform.localScale = new Vector3(Mathf.Abs(crntScale.x), crntScale.y, crntScale.z);

        InitPlayer();
    }
}

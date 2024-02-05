using System;
using UnityEngine;

public class CharecterControler : MonoBehaviour
{
    public Action OnPlayerDied;
    public Action OnPlayerWin;

    private GameObject charecterImage;
    private Animator animator;
    private Vector3 StartPos;

    [SerializeField]
    private float _fallRespawnDelay = 1.5f;


    [SerializeField]
    private float _startSpeed = 3;
    [SerializeField]
    private float _slowSpeed = 1.5f;

    private float _currentSpeed;

    private bool isMovingToleft;

    [SerializeField]
    private bool isStartToRight;


    [SerializeField]
    private Collider _leftCollider;
    [SerializeField]
    private Collider _rightCollider;
    private bool _canMove;

    void Awake()
    {
        _canMove = true;
        charecterImage = GameObject.Find("CharacterView");
        animator = GetComponent<Animator>();
        InitPlayer();

        StartPos = transform.position;
    }

    private void StopAnimation()
    {
        animator.enabled = false;
    }
    private void StartAnimation()
    {
        animator.enabled = true;
    }

    public void StopMoving()
    {
        StopAnimation();
        _canMove = false;
    }

    public void StartMoving()
    {
        StartAnimation();
        _canMove = true;
    }



    private void InitPlayer()
    {
        charecterImage.SetActive(true);
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
        if (_canMove)
        {
            transform.position += (isMovingToleft ? -1 : 1) * transform.right * _currentSpeed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider col)
    {

        switch (col.tag)
        {
            case "Finish":
                {
                    AudioManager.Instance.PlaySound("finish");
                    _currentSpeed = 0;
                    charecterImage.SetActive(false);
                    OnPlayerWin?.Invoke();
                    break;
                }
            case "KillZone":
                {
                    AudioManager.Instance.PlaySound("fallDeath");

                    Invoke("PlayerDieActions", _fallRespawnDelay);
                    break;
                }
            case "Water":
                {
                    AudioManager.Instance.PlaySound("waterDeath");
                    PlayerDieActions();
                    break;
                }
            case "Icicles":
                {
                    AudioManager.Instance.PlaySound("iciclesDeath");
                    PlayerDieActions();
                    break;
                }
            default:
                break;
        }

    }

    private void PlayerDieActions()
    {
        _currentSpeed = 0;
        Restart();
        OnPlayerDied?.Invoke();
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

    public void setSlowSpeed()
    {
        _currentSpeed = _slowSpeed;
    }
    public void setNormalSpeed()
    {
        _currentSpeed = _startSpeed;
    }
}

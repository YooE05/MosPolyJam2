using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterIceManager : MonoBehaviour, ISeasonListener
{
    [SerializeField] private Transform _waterParentObject;
    [SerializeField] private float _iceGrewDelay;

    private List<Collider> _deathWaterCollliders = new();
    private List<IceCollider> _iceCollliders = new();

    private bool _isMoveUp;

    private void Awake()
    {
        _deathWaterCollliders.AddRange(_waterParentObject.GetComponentsInChildren<Collider>());
        _iceCollliders.AddRange(_waterParentObject.GetComponentsInChildren<IceCollider>());

    }

    public void SeasonChangeAction(SeasonType seasonType)
    {
        switch (seasonType)
        {
            case SeasonType.Spring:
                {
                    //опустить лёд
                    _isMoveUp = false;
                    MoveIce();
                    break;
                }
            case SeasonType.Summer:
                {
                    //убрать всю воду
                    for (int i = 0; i < _deathWaterCollliders.Count; i++)
                    {
                        _deathWaterCollliders[i].enabled = false;
                    }
                    for (int i = 0; i < _iceCollliders.Count; i++)
                    {
                        _iceCollliders[i].Collider.enabled = false;
                    }

                    break;
                }
            case SeasonType.Autumn:
                {
                    //включить всю воду
                    for (int i = 0; i < _deathWaterCollliders.Count; i++)
                    {
                        _deathWaterCollliders[i].enabled = true;
                    }
                    for (int i = 0; i < _iceCollliders.Count; i++)
                    {
                        _iceCollliders[i].Collider.enabled = true;
                    }
                    break;
                }
            case SeasonType.Winter:
                {
                    //поднять лёд
                    _isMoveUp = true;
                    MoveIce();
                    break;
                }
            default:
                break;
        }
    }
    public void MoveIce()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeIcePosition());

    }

    IEnumerator ChangeIcePosition()
    {
        List<Vector3> iceStartPositions = new();
        foreach (var iceCollider in _iceCollliders)
        {
            iceStartPositions.Add(iceCollider.CurrentPos);
        }

        float crntTime = 0f;
        if (_isMoveUp)
        {
            while (crntTime < _iceGrewDelay)
            {
                for (int i = 0; i < _iceCollliders.Count; i++)
                {
                    _iceCollliders[i].transform.localPosition = Vector3.Lerp(iceStartPositions[i], _iceCollliders[i].UpperPoint, crntTime / _iceGrewDelay);
                }
                crntTime += Time.deltaTime;
                yield return null;
            }

            for (int i = 0; i < _iceCollliders.Count; i++)
            {
                _iceCollliders[i].transform.localPosition = _iceCollliders[i].UpperPoint;
            }


        }
        else
        {
            while (crntTime < _iceGrewDelay)
            {
                for (int i = 0; i < _iceCollliders.Count; i++)
                {
                    _iceCollliders[i].transform.localPosition = Vector3.Lerp(iceStartPositions[i], _iceCollliders[i].LowerPoint, crntTime / _iceGrewDelay);
                }
                crntTime += Time.deltaTime;
                yield return null;
            }

            for (int i = 0; i < _iceCollliders.Count; i++)
            {
                _iceCollliders[i].transform.localPosition = _iceCollliders[i].LowerPoint;
            }
        }
        yield return null;
    }

}


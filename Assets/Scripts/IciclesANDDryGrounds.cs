using System;
using System.Collections.Generic;
using UnityEngine;

public class IciclesANDDryGrounds : MonoBehaviour, ISeasonListener
{
    [HideInInspector]
    public GameObject[] DryGrounds;

    [HideInInspector]
    public GameObject[] Icicles;


    private List<DryWall> _dryWalls = new();

    void Awake()
    {
        DryGrounds = GameObject.FindGameObjectsWithTag("DryGrounds");
        foreach (var dryGround in DryGrounds)
        {
            if (dryGround.GetComponent<DryWall>())
            {
                _dryWalls.Add(dryGround.GetComponent<DryWall>());
            }
        }


        Icicles = GameObject.FindGameObjectsWithTag("Icicles");
    }

    internal void RestoreDryEarth()
    {
        for (int i = 0; i < DryGrounds.Length; i++)
        {
            DryGrounds[i].gameObject.SetActive(true);
        }
    }

    public void SeasonChangeAction(SeasonType seasonType)
    {
        for (int i = 0; i < Icicles.Length; i++)
        {
            Icicles[i].GetComponent<Collider>().enabled = false;//.SetActive(false);
        }

        for (int i = 0; i < DryGrounds.Length; i++)
        {
            DryGrounds[i].GetComponent<BoxCollider>().isTrigger = false;
        }
        for (int i = 0; i < _dryWalls.Count; i++)
        {
            _dryWalls[i]._wallGO.SetActive(true);
        }


        switch (seasonType)
        {
            case SeasonType.Spring:
                {
                    break;
                }
            case SeasonType.Summer:
                {
                    for (int i = 0; i < DryGrounds.Length; i++)
                    {
                        DryGrounds[i].GetComponent<BoxCollider>().isTrigger = true;
                    }

                    for (int i = 0; i < _dryWalls.Count; i++)
                    {
                        _dryWalls[i]._wallGO.SetActive(false);
                    }
                    break;
                }
            case SeasonType.Autumn:
                {
                    break;
                }
            case SeasonType.Winter:
                {
                    for (int i = 0; i < Icicles.Length; i++)
                    {
                        Icicles[i].GetComponent<Collider>().enabled = false;
                    }
                    break;
                }
            default:
                break;
        }
    }

    public void Restart()
    {
        for (int i = 0; i < DryGrounds.Length; i++)
        {
            DryGrounds[i].gameObject.SetActive(true);
        }
    }
}

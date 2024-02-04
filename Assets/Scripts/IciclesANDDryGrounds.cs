using System;
using UnityEngine;

public class IciclesANDDryGrounds : MonoBehaviour, ISeasonListener
{
    [HideInInspector]
    public GameObject[] DryGrounds;

    [HideInInspector]
    public GameObject[] Icicles;

    void Awake()
    {
        DryGrounds = GameObject.FindGameObjectsWithTag("DryGrounds");
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
            Icicles[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < DryGrounds.Length; i++)
        {
            DryGrounds[i].GetComponent<BoxCollider>().isTrigger = false;
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
                        Icicles[i].gameObject.SetActive(true);
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

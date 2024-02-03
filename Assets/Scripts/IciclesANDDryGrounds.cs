using UnityEngine;

public class IciclesANDDryGrounds : MonoBehaviour, ISeasonListener
{
    public GameObject[] DryGrounds;
    public GameObject[] Icicles;

    void Awake ()
    {
        DryGrounds = GameObject.FindGameObjectsWithTag("DryGrounds");
        Icicles = GameObject.FindGameObjectsWithTag("Icicles");
    }

    public void SeasonChangeAction (SeasonType seasonType)
    {
        switch(seasonType)
        {
            case SeasonType.Spring:
                {
                    for(int i = 0; i < Icicles.Length; i++)
                    {
                        Icicles[i].gameObject.SetActive(false);
                    }
                    break;
                }
            case SeasonType.Summer:
                {
                    for(int i = 0; i < DryGrounds.Length; i++)
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
                    for(int i = 0; i < DryGrounds.Length; i++)
                    {
                        DryGrounds[i].GetComponent<BoxCollider>().isTrigger = false;
                    }

                    for(int i = 0; i < Icicles.Length; i++)
                    {
                        Icicles[i].gameObject.SetActive(true);
                    }
                    break;
                }
            default:
                break;
        }
    }

    public void Restart ()
    {
        for(int i = 0; i < DryGrounds.Length; i++)
            if(DryGrounds[i].gameObject.active == false)
            {
                DryGrounds[i].gameObject.SetActive(true);
            }
        //Debug.Log(DryGrounds.Length);
    }
}

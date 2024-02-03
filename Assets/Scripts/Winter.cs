using UnityEngine;

public class Winter : MonoBehaviour
{
    public GameObject[] DryGrounds;
    public GameObject[] Icicles;

    void Awake ()
    {
        DryGrounds = GameObject.FindGameObjectsWithTag("DryGrounds");
        Icicles = GameObject.FindGameObjectsWithTag("Icicles");
    }

    public void _SelectWinter ()
    {
        for(int i = 0; i < DryGrounds.Length; i++)
        {
            DryGrounds[i].GetComponent<BoxCollider>().enabled = true;
            DryGrounds[i].transform.Find("Dry").gameObject.SetActive(false);
            DryGrounds[i].transform.Find("Normal").gameObject.SetActive(true);
        }

        for(int i = 0; i < Icicles.Length; i++)
        {
            Icicles[i].gameObject.SetActive(true);
        }
    }
}

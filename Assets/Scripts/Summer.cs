using UnityEngine;

public class Summer : MonoBehaviour
{
    public GameObject[] DryGrounds;
    public GameObject[] Icicles;

    void Awake ()
    {
        DryGrounds = GameObject.FindGameObjectsWithTag("DryGrounds");
        Icicles = GameObject.FindGameObjectsWithTag("Icicles");
    }

    public void _SelectSummer ()
    {
        for(int i = 0; i < DryGrounds.Length; i++)
        {
            DryGrounds[i].GetComponent<BoxCollider>().isTrigger = true;
            DryGrounds[i].transform.Find("Dry").gameObject.SetActive(true);
            DryGrounds[i].transform.Find("Normal").gameObject.SetActive(false);
        }

        for(int i = 0; i < Icicles.Length; i++)
        {
            Icicles[i].gameObject.SetActive(false);
        }
    }
}

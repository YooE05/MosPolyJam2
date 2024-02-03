using TMPro;
using UnityEngine;

public class other : MonoBehaviour
{
    public GameObject WinPanel;

    void Start ()
    {
        WinPanel = GameObject.Find("WinPanel");

        if(WinPanel != null)
        {
            //WinPanel.SetActive(false);
        }
    }

    public void OpenWinPanel (int seasonsCount)
    {
        GameObject.Find("SeasonsCount").GetComponent<TMP_Text>().SetText("всего за "+seasonsCount.ToString()+" сезонов!");
        WinPanel.SetActive(true);
    }
}

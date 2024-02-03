using UnityEngine;

public class other : MonoBehaviour
{
    public GameObject WinPanel;

    void Start ()
    {
        WinPanel = GameObject.Find("WinPanel");

        if(WinPanel != null)
        {
            WinPanel.SetActive(false);
        }
    }

    public void OpenWinPanel ()
    {
        WinPanel.SetActive(true);
    }
}

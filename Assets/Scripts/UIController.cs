using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private SeasonManager _seasonManager;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _playScreenPanel;

    [SerializeField]
    private TextMeshProUGUI _seasonCounterTxt; 



    void Awake()
    {
        _winPanel.SetActive(false);
        _playScreenPanel.SetActive(true);
    }

    public void OpenWinPanel(int seasonsCount)
    {
        _playScreenPanel.SetActive(false);
        _seasonCounterTxt.SetText("всего за "+seasonsCount.ToString()+" сезонов!");
        _winPanel.SetActive(true);
    }
}

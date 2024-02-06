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

    [SerializeField]
    private TextMeshProUGUI _inventationTxt;

    [SerializeField]
    private InventationsConfig _inventationConfig;



    void Awake()
    {
        _winPanel.SetActive(false);
        _playScreenPanel.SetActive(true);

        _inventationTxt.SetText("вы придумали " + _inventationConfig.GetRandomInventation() + "!");
    }

    public void OpenWinPanel(int seasonsCount)
    {
        _playScreenPanel.SetActive(false);

       // _inventationTxt.SetText("вы придумали " + _inventationConfig.GetRandomInventation() + "!");

        string strAddition;

        switch (seasonsCount % 10)
        {
            case 1:
                {
                    strAddition = " сезон";
                    break;
                }
            case 2:
                {
                    strAddition = " сезона";
                    break;
                }
            case 3:
                {
                    strAddition = " сезона";
                    break;
                }
            case 4:
                {
                    strAddition = " сезона";
                    break;
                }
            case 5:
                {
                    strAddition = " сезонов";
                    break;
                }
            case 6:
                {
                    strAddition = " сезонов";
                    break;
                }
            case 7:
                {
                    strAddition = " сезонов";
                    break;
                }
            case 8:
                {
                    strAddition = " сезонов";
                    break;
                }
            case 9:
                {
                    strAddition = " сезонов";
                    break;
                }
            case 0:
                {
                    strAddition = " сезонов";
                    break;
                }

            default:
                {
                    strAddition = " сезонов";
                    break;
                }
        }

        _seasonCounterTxt.SetText("всего за " + seasonsCount.ToString() + strAddition);
        _winPanel.SetActive(true);
    }
}

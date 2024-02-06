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

        _inventationTxt.SetText("�� ��������� " + _inventationConfig.GetRandomInventation() + "!");
    }

    public void OpenWinPanel(int seasonsCount)
    {
        _playScreenPanel.SetActive(false);

       // _inventationTxt.SetText("�� ��������� " + _inventationConfig.GetRandomInventation() + "!");

        string strAddition;

        switch (seasonsCount % 10)
        {
            case 1:
                {
                    strAddition = " �����";
                    break;
                }
            case 2:
                {
                    strAddition = " ������";
                    break;
                }
            case 3:
                {
                    strAddition = " ������";
                    break;
                }
            case 4:
                {
                    strAddition = " ������";
                    break;
                }
            case 5:
                {
                    strAddition = " �������";
                    break;
                }
            case 6:
                {
                    strAddition = " �������";
                    break;
                }
            case 7:
                {
                    strAddition = " �������";
                    break;
                }
            case 8:
                {
                    strAddition = " �������";
                    break;
                }
            case 9:
                {
                    strAddition = " �������";
                    break;
                }
            case 0:
                {
                    strAddition = " �������";
                    break;
                }

            default:
                {
                    strAddition = " �������";
                    break;
                }
        }

        _seasonCounterTxt.SetText("����� �� " + seasonsCount.ToString() + strAddition);
        _winPanel.SetActive(true);
    }
}

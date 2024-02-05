using UnityEngine;

public class PlayerFinishObserwer : MonoBehaviour
{
    [SerializeField]
    private UIController _uiController;
    [SerializeField]
    private SeasonManager _seasonManager;
    [SerializeField]
    private CharecterControler _characterController;

    private void OnEnable()
    {
        _characterController.OnPlayerWin += ShowWinPanel;
    }

    private void OnDisable()
    {
        _characterController.OnPlayerWin -= ShowWinPanel;
    }

    private void ShowWinPanel()
    {
        _seasonManager.IsCanSwitch = false;
        _uiController.OpenWinPanel(_seasonManager.GetCountOfSeasons());
    }

}

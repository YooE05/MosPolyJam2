using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private TutorialManager _tutorialManager;

    private void Awake()
    {
        _tutorialManager = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_tutorialManager)
        {
            if (other.tag == "rightSide"|| other.tag == "leftSide")
            {
                _tutorialManager.AdvanceTutorialStage();
                Destroy(gameObject);
            }
        }

    }
}

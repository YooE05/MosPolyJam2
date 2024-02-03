using System.Collections.Generic;
using UnityEngine;

public class PlantsManager : MonoBehaviour, ISeasonListener
{
    [SerializeField] private Transform _plantsRoot;

    private List<Collider> _plantsColliders = new();

    private void Awake()
    {
        _plantsColliders.AddRange(_plantsRoot.GetComponentsInChildren<Collider>());
    }

    public void SeasonChangeAction(SeasonType seasonType)
    {
        switch (seasonType)
        {
            case SeasonType.Spring:
                {
                    for (int i = 0; i < _plantsColliders.Count; i++)
                    {
                        _plantsColliders[i].enabled = true;
                    }
                    break;
                }
            case SeasonType.Summer:
                {
                    for (int i = 0; i < _plantsColliders.Count; i++)
                    {
                        _plantsColliders[i].enabled = true;
                    }
                    break;
                }
            case SeasonType.Autumn:
                {
                    for (int i = 0; i < _plantsColliders.Count; i++)
                    {
                        _plantsColliders[i].enabled = false;
                    }
                    break;
                }
            case SeasonType.Winter:
                {
                    for (int i = 0; i < _plantsColliders.Count; i++)
                    {
                        _plantsColliders[i].enabled = false;
                    }
                    break;
                }
            default:
                break;
        }
    }
}

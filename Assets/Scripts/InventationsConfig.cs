using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InventationNamesConfig", menuName = "Scriptable Objects/InventationNamesConfig", order = 2)]
public class InventationsConfig : ScriptableObject
{
    [field:SerializeField]
    public List<string> InvNames { get; private set; }

    public string GetRandomInventation()
    {
        return InvNames[Random.Range(0, InvNames.Count)];
    }


}

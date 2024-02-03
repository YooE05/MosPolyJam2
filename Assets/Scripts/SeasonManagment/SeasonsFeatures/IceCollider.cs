using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollider : MonoBehaviour
{
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public Vector3 LowerPoint { get; private set; }
    [field: SerializeField] public Vector3 UpperPoint { get; private set; }
    public Vector3 CurrentPos { get => gameObject.transform.localPosition; }
}

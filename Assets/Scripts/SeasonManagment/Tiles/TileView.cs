using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TileView : MonoBehaviour
{
    [field: SerializeField] public SpriteRenderer SpringSpriteRenderer { get; private set; }
    [field: SerializeField] public SpriteRenderer SummerSpriteRenderer { get; private set; }
    [field: SerializeField] public SpriteRenderer AutumeSpriteRenderer { get; private set; }
    [field: SerializeField] public SpriteRenderer WinterSpriteRenderer { get; private set; }
}

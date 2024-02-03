using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilesRendererCollector : MonoBehaviour
{

    private List<SpriteRenderer> SpringSpriteRenderer { get; } = new();
    private List<SpriteRenderer> SummerSpriteRenderer { get; } = new();
    private List<SpriteRenderer> AutumeSpriteRenderer { get; } = new();
    private List<SpriteRenderer> WinterSpriteRenderer { get; } = new();

    public List<List<SpriteRenderer>> AllSpriteRenderers { get; } = new();


    private void Awake()
    {
        foreach (var rootGO in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            var tilesView = rootGO.GetComponentsInChildren<TileView>();
            foreach (var tile in tilesView)
            {
                SpringSpriteRenderer.Add(tile.SpringSpriteRenderer);
                SummerSpriteRenderer.Add(tile.SummerSpriteRenderer);
                AutumeSpriteRenderer.Add(tile.AutumeSpriteRenderer);
                WinterSpriteRenderer.Add(tile.WinterSpriteRenderer);
            }
        }

        AllSpriteRenderers.Add(SpringSpriteRenderer);
        AllSpriteRenderers.Add(SummerSpriteRenderer);
        AllSpriteRenderers.Add(AutumeSpriteRenderer);
        AllSpriteRenderers.Add(WinterSpriteRenderer);

    }
}

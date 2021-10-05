using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int playerSortingOrder = 0;

    protected SpriteRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool flip)
    {
        myRenderer.flipY = flip;
    }

    public void RenderBehindHead(bool behind)
    {
        myRenderer.sortingOrder = playerSortingOrder + (behind ? -1 : 1);
    }
}
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int playerSortingOrder = 0;

    protected SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool flip)
    {
        renderer.flipY = flip;
    }

    public void RenderBehindHead(bool behind)
    {
        renderer.sortingOrder = playerSortingOrder + (behind ? -1 : 1);
    }
}
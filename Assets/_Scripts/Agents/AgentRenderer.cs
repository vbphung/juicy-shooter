using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    protected SpriteRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 pointerInput)
    {
        var direction = (Vector3)pointerInput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        if (result.z != 0)
            myRenderer.flipX = result.z > 0;
    }
}
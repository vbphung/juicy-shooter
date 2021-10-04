using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;

    private void Start()
    {
        SetCursorIcon();
    }

    private void SetCursorIcon()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);
    }
}
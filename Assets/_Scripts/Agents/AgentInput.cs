using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }
    [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonPressed { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonReleased { get; set; }

    private Camera mainCamera;
    private bool fireButtonDown;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    private void GetMovementInput()
    {
        OnMovementKeyPress?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePos);
        OnPointerPositionChanged?.Invoke(mouseInWorldSpace);
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (!fireButtonDown)
            {
                fireButtonDown = true;
                OnFireButtonPressed?.Invoke();
            }
        }
        else if (fireButtonDown)
        {
            fireButtonDown = false;
            OnFireButtonReleased?.Invoke();
        }
    }
}

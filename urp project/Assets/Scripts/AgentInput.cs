using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }

    private void Update()
    {
        GetMovementInput();
    }

    private void GetMovementInput()
    {
        OnMovementKeyPress?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}

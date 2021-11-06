using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [SerializeField] protected MovementDataSO movementData;

    [field: SerializeField] public UnityEvent<float> OnVelocityChanged { get; set; }

    protected Rigidbody2D myRigidbody;
    protected float currentSpeed = 0;
    protected Vector2 currentDirection = new Vector2(0, 0);
    protected bool isKnockedBack = false;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnVelocityChanged?.Invoke(currentSpeed);
        if (!isKnockedBack)
            myRigidbody.velocity = currentDirection.normalized * currentSpeed;
    }

    public void MoveAgent(Vector2 moveInput)
    {
        currentDirection = moveInput;
        currentSpeed = CalculateSpeed(moveInput);
    }

    public void StopImmediately()
    {
        currentSpeed = 0;
        myRigidbody.velocity = Vector2.zero;
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if (moveInput.magnitude > 0)
            currentSpeed += movementData.Acceleration * Time.deltaTime;
        else
            currentSpeed -= movementData.Deacceleration * Time.deltaTime;

        return Mathf.Clamp(currentSpeed, 0, movementData.MaxSpeed);
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        if (!isKnockedBack)
        {
            isKnockedBack = true;
            StartCoroutine(KnockBackCoroutine(direction, power, duration));
        }
    }

    private void ResetKnockBack()
    {
        StopAllCoroutines();
        ResetKnockBackParameter();
    }

    private IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration)
    {
        myRigidbody.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockBackParameter();
    }

    private void ResetKnockBackParameter()
    {
        currentSpeed = 0;
        myRigidbody.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
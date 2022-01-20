using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] public UnityEvent onPlayerSpotted;

    public override bool MakeDecision()
    {
        var direction = enemyBrain.Target.transform.position - transform.position;
        var hit = Physics2D.Raycast(transform.position, direction, distance, raycastMask);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            onPlayerSpotted?.Invoke();
            return true;
        }
        return false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject && enemyBrain != null && enemyBrain.Target != null)
        {
            Gizmos.color = Color.red;

            var direction = (enemyBrain.Target.transform.position - transform.position).normalized;
            Gizmos.DrawRay(transform.position, direction * distance);
        }
    }
#endif
}
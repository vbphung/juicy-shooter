using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aIMovementData.Direction = Vector2.zero;
        aIMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);

        aIActionData.Attack = true;
        enemyBrain.Attack();
    }
}
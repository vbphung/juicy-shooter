using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        aIMovementData.Direction = Vector2.zero;
        aIMovementData.PointOfInterest = transform.position;
        enemyBrain.Move(aIMovementData.Direction, aIMovementData.PointOfInterest);
    }
}
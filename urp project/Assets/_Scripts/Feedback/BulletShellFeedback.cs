using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletShellFeedback : ObjectPool
{
    [SerializeField] private float flyDuration;
    [SerializeField] private float flyStrength;

    public void SpawnBulletShell()
    {
        var shell = SpawnObject();
        MoveShell(shell);
    }

    private void MoveShell(GameObject shell)
    {
        shell.transform.DOComplete();
        var randomDirection = Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection;

        var moveDirection = (Vector2)transform.position + randomDirection * flyStrength;
    }
}
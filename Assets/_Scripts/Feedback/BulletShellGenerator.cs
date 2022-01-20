using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletShellGenerator : ObjectPool
{
    [SerializeField] private float flyDuration;
    [SerializeField] private float flyStrength;
    [SerializeField] private float shellLifeTime;

    public void SpawnBulletShell()
    {
        var shell = SpawnObject();
        MoveShell(shell);
        StartCoroutine(WaitToDestroyShell(shell));
    }

    private void MoveShell(GameObject shell)
    {
        shell.transform.DOComplete();
        var randomDirection = Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection;

        var moveDirection = (Vector2)transform.position + randomDirection * flyStrength;
        shell.transform.DOMove(moveDirection, flyDuration).OnComplete(() => shell.GetComponent<AudioSource>().Play());
        shell.transform.DORotate(new Vector3(0, 0, Random.Range(0f, 360f)), flyDuration);
    }

    private IEnumerator WaitToDestroyShell(GameObject shell)
    {
        yield return new WaitForSeconds(shellLifeTime);
        Destroy(shell);
    }
}
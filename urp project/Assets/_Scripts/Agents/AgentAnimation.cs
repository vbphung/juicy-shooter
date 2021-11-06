using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimation : MonoBehaviour
{
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalkAnimation(bool walk)
    {
        animator.SetBool("walk", walk);
    }

    public void Animate(float speed)
    {
        SetWalkAnimation(speed != 0);
    }

    public void PlayDeadAnimation()
    {
        animator.SetTrigger("dead");
    }
}

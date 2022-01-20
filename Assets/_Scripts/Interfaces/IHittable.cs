using UnityEngine;
using UnityEngine.Events;

public interface IHittable
{
    UnityEvent OnGetHit { get; set; }
    void GetHit(float damage, GameObject damageDealer);
}
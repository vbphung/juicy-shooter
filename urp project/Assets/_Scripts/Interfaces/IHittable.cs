using UnityEngine;
using UnityEngine.Events;

public interface IHittable
{
    UnityEvent OnGetHit { get; set; }
    void GetHit(int damage, GameObject damageDealer);
}
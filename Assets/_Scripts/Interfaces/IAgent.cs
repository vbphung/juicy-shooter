using UnityEngine;
using UnityEngine.Events;

public interface IAgent
{
    float Health { get; set; }
    UnityEvent OnGetHit { get; set; }
    UnityEvent OnDie { get; set; }
}
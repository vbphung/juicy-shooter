using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Data", menuName = "Item/Resource Data", order = 0)]
public class ResourceDataSO : ScriptableObject
{
    [field: SerializeField] public ResourceType Type { get; private set; }

    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;

    public int Amount { get => Random.Range(minAmount, maxAmount + 1); }
}

public enum ResourceType
{
    None,
    Health,
    Ammo
}
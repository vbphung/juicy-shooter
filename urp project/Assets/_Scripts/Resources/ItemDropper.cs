using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnData> dropItems = new List<ItemSpawnData>();
    [SerializeField] [Range(0, 1)] private float dropChance;

    private float[] itemWeights;

    private void Start()
    {
        itemWeights = dropItems.Select(item => item.rate).ToArray();
    }

    public void DropItem()
    {
        var dropValue = Random.value;
        if (dropValue < dropChance)
        {
            var index = GetWeightIndex();
            Instantiate(dropItems[index].itemPrefab, transform.position, Quaternion.identity);
        }
    }

    private int GetWeightIndex()
    {
        float sum = 0f;
        for (int i = 0; i < itemWeights.Length; ++i)
            sum += itemWeights[i];

        float randomValue = Random.Range(0, sum);

        float tempSum = 0;
        for (int i = 0; i < dropItems.Count; ++i)
        {
            if (randomValue >= tempSum && randomValue < tempSum + itemWeights[i])
                return i;

            tempSum += itemWeights[i];
        }

        return 0;
    }
}

[Serializable]
public struct ItemSpawnData
{
    [Range(0, 1)] public float rate;
    public GameObject itemPrefab;
}
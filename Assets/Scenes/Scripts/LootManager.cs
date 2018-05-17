using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootManager : MonoBehaviour
{

    public List<Loot> loot = new List<Loot>();
    public List<GameObject> spawnPoints = new List<GameObject>();



    void Start()
    {
        for (int i = 0; i < loot.Count; i++)
        {
            if (Random.value * 100 < loot[i].spawnChance)
            {
                Instantiate(loot[i].lootObject, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity);


                Debug.Log(loot[i].lootObject.name + " has spawned in the location: " + loot[i].lootObject.transform.position);
                Debug.Log("spawn chance is: " + loot[i].spawnChance + "%");
            }
        }
    }
}

[System.Serializable]
public class Loot
{
    public GameObject lootObject;
    public float spawnChance;
    public float sellingPrice;
}

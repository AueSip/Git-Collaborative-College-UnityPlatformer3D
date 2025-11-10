
using System.Collections.Generic;
using UnityEngine;

public class Script_Vampire_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Script_Game_Manager gameInstance;

   

    List<GameObject> VampireSpawns = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void GetVampireSpawns(GameObject player)
{
        VampireSpawns.Clear();

    foreach (Transform child in player.transform)
    {
        // Optional: only add objects that start with "VampireSpawn"
        if (child.CompareTag("VampireSpawner"))
        {
            VampireSpawns.Add(child.gameObject);
        }
    }
}


    public void SpawnChosenVampireAtRandom(GameObject vampire, GameObject player)
    {
        Vector3 pos = VampireSpawns[Random.Range(0, VampireSpawns.Count)].transform.position;
        vampire.transform.SetPositionAndRotation(pos, transform.rotation);
        vampire.transform.LookAt(player.transform, Vector3.right);
        vampire.GetComponent<Script_NPC>().SetVampireActive(true);
    }



}


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
        Transform temp = player.transform;
        Quaternion rotDir = Quaternion.Euler(
            player.transform.eulerAngles.x,
            player.transform.eulerAngles.y + 90f,
            player.transform.eulerAngles.z
        );
        temp.SetPositionAndRotation(player.transform.position, rotDir);
        vampire.transform.LookAt(temp, Vector3.up);
        vampire.transform.rotation = Quaternion.Euler(
            vampire.transform.eulerAngles.x,
            vampire.transform.eulerAngles.y + 90f,
            vampire.transform.eulerAngles.z);
        vampire.GetComponent<Script_NPC>().SetVampireActive(true);
    }



}

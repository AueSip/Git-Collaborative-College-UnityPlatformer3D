using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Script_ShopManager))]
public class Script_Game_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pf_Generator;

    public GameObject pf_Player;
    public GameObject pf_GasStation;

     public float vampireSpawnWait_Min;
    public float vampireSpawnWait_Max;
    public int genDeactivatableCount;
    public List<Transform> generator_SpawnLocations;

    GameObject[] pf_GeneratorList;
    public List<GameObject> pf_NPCS;

    List<GameObject> spawnedNPCS = new List<GameObject>();

    private Script_ShopManager shop_Manager_System;

    private Script_Vampire_Manager vampire_Manager_System;
    int generatorsDeactivated;

    private bool powerIsOut;
    public float powerOutageDelayMin;

    public float powerOutageDelayMax;

    int generatorsReactivated;

    int index;

    void Start()
    {
        shop_Manager_System = GetComponent<Script_ShopManager>();
        vampire_Manager_System = GetComponent<Script_Vampire_Manager>();
        SpawnGenerators();
        SpawnNPCS();


        PowerActive();
        
    }

    void FixedUpdate()
    {

    }

    private async void InitTest()
    {   
        float num = Random.Range(powerOutageDelayMin, powerOutageDelayMax);
        await Awaitable.WaitForSecondsAsync(num);
        PowerOutage();
    }
    void SpawnGenerators()
    {
        index = 0;
         pf_GeneratorList = new GameObject[generator_SpawnLocations.Count()];
        foreach (Transform spawn in generator_SpawnLocations)
        {   
            GameObject gen = Instantiate(pf_Generator, spawn.position, spawn.rotation);
            pf_GeneratorList[index] = gen;
            index++;

        };
         
        
    }



    //DeactivatesGenerators using a randomiser + the spawned Generators on the map
    public void PowerOutage()
    {   
        //When Power Is out enables vampires and causes them to spawn around player at random
        powerIsOut = true;
        VampireSpawnLoop();


        List<int> shuffledIndexes = Enumerable.Range(0, pf_GeneratorList.Length).OrderBy(x => Random.value).ToList();
         print("LIGHTS OUT");
        generatorsReactivated = 0;

        //This will hide npcs once power goes out
        HideNPCPositions();
        for (int i = 0; i < genDeactivatableCount; i++)
        {
            pf_GeneratorList[shuffledIndexes[i]].GetComponent<Script_Interactable_Generator>().DeactivateGenerator();
            generatorsDeactivated++;
        }
        ;

        pf_GasStation.GetComponent<Script_GasStationStatus>().ToggleLight(false);


        //Debug
        print("Gens Deactivated: " + generatorsDeactivated);
    }


    //Event to occur when deactivated gen is interacted with
    public void GeneratorReactivated()
    {
        generatorsDeactivated--;
        generatorsReactivated++;

        if (generatorsReactivated == genDeactivatableCount)
        {
            PowerActive();
        }
    }

    //Starts the game with the gas station active and initiates the timer until outage
    public void PowerActive()
    {
        powerIsOut = false;
        pf_GasStation.GetComponent<Script_GasStationStatus>().ToggleLight(true);
        InitTest();
        UpdateShopManager();
    }

    //Updates the location of the npcs 
    public void UpdateShopManager()
    {
        HideNPCPositions();
        spawnedNPCS = shop_Manager_System.UpdateNPCPositions(spawnedNPCS);
    }

    public void HideNPCPositions()
    {
        foreach (GameObject npc in spawnedNPCS)
        {   
            Vector3 newPos;
            newPos = new Vector3(npc.transform.position.x, npc.transform.position.y  - 500, npc.transform.position.z);
            npc.transform.position = newPos;
           
        }
    }

    //spawns NPCS
    public void SpawnNPCS()
    {
        int indx = 0;
        foreach (GameObject npc in pf_NPCS)
        {

            GameObject clone = Instantiate(npc, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            clone.name = indx.ToString();
            spawnedNPCS.Add(clone);
            indx++;

        }
        List<int> shuffledIndexes = Enumerable.Range(0, spawnedNPCS.Count).OrderBy(x => Random.value).ToList();
        for (int dex = 0; dex < 3; dex++)
        {
            spawnedNPCS[shuffledIndexes[dex]].GetComponent<Script_NPC>().SetIsVampire(true);
        }
        

    }

    public void RemoveNPC(GameObject npc)
    {
        spawnedNPCS.Remove(npc);
    }

  


    public void GetAndSpawnVampire()
    {
        vampire_Manager_System.GetVampireSpawns(pf_Player);
        List<GameObject> tempVampireList = new List<GameObject>();
        foreach (GameObject npc in spawnedNPCS)
        {
            if (npc.GetComponent<Script_NPC>().GetIsVampire())
            {
                tempVampireList.Add(npc);
            }


        }
        vampire_Manager_System.SpawnChosenVampireAtRandom(tempVampireList[Random.Range(0, tempVampireList.Count)], pf_Player);


    }
    
    public async void VampireSpawnLoop()
    {
        await Awaitable.WaitForSecondsAsync(Random.Range(vampireSpawnWait_Min, vampireSpawnWait_Max));
        if (powerIsOut)
        {
            GetAndSpawnVampire();
            VampireSpawnLoop();
        }
        

    }


    




}

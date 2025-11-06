using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Script_Game_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pf_Generator;

    public int genDeactivatableCount;
    public List<Transform> generator_SpawnLocations;

    GameObject[] pf_GeneratorList;
    public List<GameObject> pf_NPCS;

    public int generatorsDeactivated;

    public int generatorsReactivated;

    int index;

    void Start()
    {
        SpawnGenerators();
        InitTest();
    }

    void FixedUpdate()
    {

    }

    private async void InitTest()
    {
        await Awaitable.WaitForSecondsAsync(5f);
        PowerOutage();
    }
    void SpawnGenerators()
    {
        index = 0;
         pf_GeneratorList = new GameObject[generator_SpawnLocations.Count()];
        foreach (Transform spawn in generator_SpawnLocations)
        {   
            GameObject gen = Instantiate(pf_Generator, spawn.position, spawn.rotation);
            print("Added");
            pf_GeneratorList[index] = gen;
            index++;

        };
         
        
    }



    //DeactivatesGenerators using a randomiser + the spawned Generators on the map
    public void PowerOutage()
    {      
        List<int> shuffledIndexes = Enumerable.Range(0, pf_GeneratorList.Length).OrderBy(x => Random.value).ToList();
         print("LIGHTS OUT");
        generatorsReactivated = 0;


        for (int i = 0; i < genDeactivatableCount; i++)
        {
            pf_GeneratorList[shuffledIndexes[i]].GetComponent<Script_Interactable_Generator>().DeactivateGenerator();
            generatorsDeactivated++;
        }
        ;

        //Debug
        print("Gens Deactivated: " + generatorsDeactivated);
    }

    
    //Event to occur when deactivated gen is interacted with
    public void GeneratorReactivated()
    {
        generatorsDeactivated--;
        generatorsReactivated++;
    }



    




}

using System.Collections.Generic;
using UnityEngine;

public class Script_ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public List<Transform> npc_GasStationLocations;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> UpdateNPCPositions(List<GameObject> pf_NPCS)
    {
        GameObject first = pf_NPCS[0];
        pf_NPCS.RemoveAt(0);
        pf_NPCS.Add(first);

        for (int i = 0; i < pf_NPCS.Count; i++)
        {
            pf_NPCS[i].transform.SetPositionAndRotation(npc_GasStationLocations[i].position, npc_GasStationLocations[i].rotation);
            pf_NPCS[i].GetComponent<Script_NPC>().SetInteractable(false);
        };
        pf_NPCS[0].GetComponent<Script_NPC>().SetInteractable(true);

        foreach(GameObject npc in pf_NPCS)
        {
             npc.GetComponent<Script_NPC>().SetVampireActive(false);
        }
        return pf_NPCS;
    }
    

}   

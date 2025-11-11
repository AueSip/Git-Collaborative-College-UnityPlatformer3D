using System.Collections.Generic;
using UnityEngine;

public class Script_NPC : Script_Interactable_Base
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string item_to_want;

    private Script_NPC_Audio npc_Audio;
    bool vampireActive;
    public string item_to_give;
    public List<string> itemList = new List<string>(){"femboymilk", "biscuit", "pill"};
    private GameObject interactedPlayer;

    bool isVampire;
    public override void Interacted(GameObject player)
    {
        interactedPlayer = player;
        if (GetInteractable())
        {
            if (interactedPlayer.GetComponent<Script_PlayerController>().GetInventoryItem() == item_to_want)
            {   
                interactedPlayer.GetComponent<Script_PlayerController>().SetInventoryItem("");
                //disables itneractivity after being interacted with
                UpdateItemToWant();
                npc_Audio.PlayFinishedList();
                gameInstance.UpdateShopManager();


            }
            else
            {
                print("I WANT: " + item_to_want);
            }
            
            
           
        }
        
    }

    public override void InitialisationOfObject()
    {
        base.InitialisationOfObject();
        npc_Audio = GameObject.FindFirstObjectByType<Script_NPC_Audio>();
        UpdateItemToWant();

    }
       
   

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateItemToWant()
    {
        item_to_want = itemList[Random.Range(0, itemList.Count)];
        item_to_give = item_to_want;
    }


    public void VampireSpawned()
    {
        SetVampireActive(true);
    }

    public bool GetIsVampire()
    {
        return isVampire;
    }

    public bool SetIsVampire(bool vamp)
    {
        isVampire = vamp;
        return isVampire;
    }



    public void SetVampireActive(bool active)
    {
        vampireActive = active;

    }

    public bool GetIsVampireActive()
    {
        return vampireActive;
    }

    public string GetItemToWant()
    {
        return item_to_want;
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.GetComponentInParent<Script_StakeProjectile>() == null)
        {
            return;
        }
        print(other);
        if (other.GetComponentInParent<Script_StakeProjectile>().GetActive())
        {       
            other.GetComponentInParent<Script_StakeProjectile>().Disable();
            gameInstance.RemoveNPC(this.gameObject);
        }

    }
    
    public void PlayAppearAtTill()
    {
        npc_Audio.WaitToPlayRequest(npc_Audio.PlayAppearList(), item_to_want, itemList);
    }
}

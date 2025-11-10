using UnityEngine;

public class Script_Interactable_Charger: Script_Interactable_Base
{

    private Script_PlayerFlashlight fl;

    //Interactivity Can Be Taken From Child
   
   private GameObject interactedPlayer;
    public override void Interacted(GameObject player)
    {
        interactedPlayer = player;
        if (GetInteractable())
        {
            fl = player.GetComponent<Script_PlayerFlashlight>();
            
            fl.StartCharge();
        }
        
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}

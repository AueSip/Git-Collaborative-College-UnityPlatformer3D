using UnityEngine;

public class Script_Interactable_Object : Script_Interactable_Base
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string item_to_add;

    private GameObject interactedPlayer;
    public override void Interacted(GameObject player)
    {
        interactedPlayer = player;
        if (GetInteractable())
        {
            print("PICKED UP: " + item_to_add);
            interactedPlayer.GetComponent<Script_PlayerController>().SetInventoryItem(item_to_add);
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

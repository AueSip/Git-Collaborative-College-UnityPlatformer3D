using System.Collections.Generic;
using UnityEngine;

public class Script_Interact : MonoBehaviour
{


    private Script_UI_Handler ui_Handler;
    List<Script_Interactable_Base> Overlaps = new List<Script_Interactable_Base>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui_Handler = GameObject.Find("Canvas").GetComponent<Script_UI_Handler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    private void OnTriggerEnter(Collider other)
    {
       

        var interactable = other.GetComponentInParent<Script_Interactable_Base>();
        if (interactable != null)
        {
            if (!Overlaps.Contains(interactable))
            {
                Overlaps.Add(interactable);

                if (interactable.GetComponent<Script_NPC>() != null && interactable.GetInteractable())
                {
                    var str = interactable.GetComponent<Script_NPC>().GetItemToWant();
                    ui_Handler.SetNPCWant(str);
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponentInParent<Script_Interactable_Base>();
        if (interactable != null)
        {
            Overlaps.Remove(interactable);
            if (interactable.GetComponent<Script_NPC>() != null)
            {
                ui_Handler.SetNPCWant("");
            }
        }
    }

    public void CallInteract(GameObject player)
    {
        print("Button Press");
        foreach (Script_Interactable_Base sc in Overlaps)
        {
            if (sc != null)
            {
                Script_Interactable_Base obj = sc;
                obj.Interacted(player);
            }
            
        }
    }
}

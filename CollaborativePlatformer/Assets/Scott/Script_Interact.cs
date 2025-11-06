using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Script_Interact : MonoBehaviour
{   
    
    List<Script_Interactable_Base> Overlaps = new List<Script_Interactable_Base>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   

    private void OnTriggerEnter(Collider other)
    {
        print(other);

        var interactable = other.GetComponentInParent<Script_Interactable_Base>();
        if (interactable != null)
        {
            if (!Overlaps.Contains(interactable))
            {
                print("Added" + interactable);
                Overlaps.Add(interactable);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponentInParent<Script_Interactable_Base>();
        if (interactable != null)
        {
            Overlaps.Remove(interactable);
            print("Other Removed");
        }
    }

    public void CallInteract()
    {
        print("Button Press");
        foreach (Script_Interactable_Base sc in Overlaps)
        {
            if (sc != null)
            {
                Script_Interactable_Base obj = sc;
                obj.Interacted();
            }
            
        }
    }
}

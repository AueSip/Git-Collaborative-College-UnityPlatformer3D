using UnityEngine;

public class Script_Interactable_Base : MonoBehaviour
{

    public bool interactable;
   

    public Script_Game_Manager gameInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameInstance = FindFirstObjectByType<Script_Game_Manager>();
    }


    //Interactivity Can Be Taken From Child
    public bool SetInteractable(bool value)
    {
        return interactable = value;
    }

    public bool GetInteractable()
    {
        return interactable;
    }
    
    public virtual void Interacted()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

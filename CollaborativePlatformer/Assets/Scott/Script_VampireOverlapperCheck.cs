using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_VampireOverlapperCheck : MonoBehaviour
{

    bool lookingAtVampire;

    public float aggroTime = 0f;

    public Script_Music_Manager music_Manager;
    
    Awaitable waitingTime;
    List<Script_NPC> Overlaps = new();
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
        
        var interactable = other.GetComponentInParent<Script_NPC>();
        if (interactable != null)
        {
            print("OVERLAPPED A NPCS");
            if (!Overlaps.Contains(interactable) && (interactable.GetIsVampireActive()))
            {
                print("OVERLAPPED A VAMP");
                Overlaps.Add(interactable);
                lookingAtVampire = true;
                music_Manager.StartVampireNear();
                TimeUntilDeath();
            }
        }
      

    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponentInParent<Script_NPC>();
        if (interactable != null)
        {   
            if (interactable.GetIsVampireActive())
            {
                lookingAtVampire = false;
                waitingTime.Cancel();
                music_Manager.StopVampireAggro();

            }
            Overlaps.Remove(interactable);
        }
    }

    public async void TimeUntilDeath()
    {
        waitingTime =  Awaitable.WaitForSecondsAsync(aggroTime);
        await waitingTime;
        CallDeath();
    }

    //Calls the death once looking has reached its required time
    public void CallDeath()
    {
       if (lookingAtVampire)
        {
            print("YOU DIED");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

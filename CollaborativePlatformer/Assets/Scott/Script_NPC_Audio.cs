
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]



public class Script_NPC_Audio : MonoBehaviour
{
    public List<AudioClip> request_List;
    public List<AudioClip> appear_List;
    public List<AudioClip> finished_List;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource asource;
    void Start()
    {
        asource = GetComponent<AudioSource>();
        asource.spatialBlend = 0;
        asource.maxDistance = 60;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayRequestSound(string itemName, List<string> itemList)
    {
        int i = itemList.IndexOf(itemName);
        asource.clip = request_List[i];
        asource.Play();

    }

    public float PlayAppearList()
    {
        asource.clip = appear_List[Random.Range(0, appear_List.Count - 1)];
        asource.Play();
        return asource.clip.length;
    }

    public void PlayFinishedList()
    {
        asource.clip = finished_List[Random.Range(0, finished_List.Count - 1)];
        asource.Play();

    }

    public async void WaitToPlayRequest(float time, string itemName, List<string> itemList)
    {
        await Awaitable.WaitForSecondsAsync(time);
        PlayRequestSound(itemName, itemList);

    }
}
    

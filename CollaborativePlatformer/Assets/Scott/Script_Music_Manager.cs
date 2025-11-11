using UnityEngine;

public class Script_Music_Manager : MonoBehaviour
{
    public AudioSource music_GasStation;
    public AudioSource music_PowerOutage;

    public AudioSource music_VampireNear;

    public AudioSource music_VampireAggro;

    public float fadeDuration =2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckAudioPlaying(AudioSource audio)
    {

        return audio.isPlaying;
    }


    public void FadeOutAudio(AudioSource audio)
    {
        StartCoroutine(AudioHelper.FadeOut(audio, fadeDuration));
    }

    public void FadeInAudio(AudioSource audio)
    {
        StartCoroutine(AudioHelper.FadeIn(audio, fadeDuration));
    }

    public void StartGasStationTracks()
    {  
        FadeOutAudio(music_PowerOutage);
        FadeOutAudio(music_VampireAggro);
        FadeOutAudio(music_VampireNear);
        FadeInAudio(music_GasStation);
       
    }

    public void StartNightTimeTrack()
    {
        
        FadeInAudio(music_PowerOutage);
        FadeOutAudio(music_GasStation);
        
    }
    

    public void StartVampireNear()
    {
        if (!CheckVolume(music_VampireNear))
        {
             FadeInAudio(music_VampireNear);
        }
           
        
    }

    public void StopVampireNear()
    {
        FadeOutAudio(music_VampireNear);
    }
    public void StartVampireAggro()
    {

        if (!CheckVolume(music_VampireAggro))
        {
            FadeInAudio(music_VampireAggro);
        }
    }
    public void StopVampireAggro()
    {
        FadeOutAudio(music_VampireAggro);
    }

    public bool CheckVolume(AudioSource audio)
    {
        return audio.volume >= 0.2f;
    }
}   


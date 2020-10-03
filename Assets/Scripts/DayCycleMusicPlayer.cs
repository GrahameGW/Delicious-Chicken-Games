using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCycleMusicPlayer : MonoBehaviour
{
    public static DayCycleMusicPlayer instance;

    [SerializeField]
    private GlobalState globalState;

    [SerializeField]
    private BroadcastSchedule broadcastSchedule;

    [SerializeField]
    private AudioClip morningClip, eveningClip;

    private AudioClip broadCastClip;
    private AudioSource audioSource;
    private Scene lastScene;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        
        audioSource = GetComponent<AudioSource>();
        broadCastClip = broadcastSchedule.musicSlot.clip;
        
        SetClipBasedOnTimeOfDay();

        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    private void SetClipBasedOnTimeOfDay()
    {
        switch (globalState.currentTime)
        {
            case TimeOfDay.Morning: audioSource.clip = morningClip;
                break;
            case TimeOfDay.Broadcast: audioSource.clip = broadCastClip;
                break;
            case TimeOfDay.Evening: audioSource.clip = eveningClip;
                break;
            default:
                Debug.LogError("Invalid time of day");
                break;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip oldClip = audioSource?.clip;
        SetClipBasedOnTimeOfDay();
        if (oldClip != audioSource.clip)
        {
            audioSource.Play();
        }
    }

}

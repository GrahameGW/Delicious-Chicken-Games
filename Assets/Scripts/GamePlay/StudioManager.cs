using UnityEngine;

public class StudioManager : MonoBehaviour
{
    public static StudioManager Instance { get; private set; }

    [SerializeField] StudioState state = default;
    [SerializeField] GameObject player = default;
    private SpriteRenderer playerSprite;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else {
            Destroy(Instance);
            Instance = this;
        }

        playerSprite = player.GetComponentInChildren<SpriteRenderer>();
        OpenStudio();
    }

    public void OpenStudio()
    {
        LoadState();
    }

    public void LeaveStudio()
    {
        SaveState();
    }

    private void SaveState()
    {
        state.playerPosition = player.transform.position;
        state.playerLocalScale = player.transform.localScale;
        state.playerFaceLeft = playerSprite.flipX;
    }

    private void LoadState()
    {
        player.transform.position = state.playerPosition;
        player.transform.localScale = state.playerLocalScale;
        playerSprite.flipX = state.playerFaceLeft;
    }




}

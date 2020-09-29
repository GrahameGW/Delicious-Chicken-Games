using UnityEngine;

public class StartNewGame : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GlobalState startingState = default;

    [SerializeField] StudioState studioState = default;
    [SerializeField] StudioState defaultStudio = default;

    public void NewGame()
    {
        startingState.Copy(globalState);
        defaultStudio.Copy(studioState);
    }
}

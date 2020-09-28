using UnityEngine;

public class StartNewGame : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GlobalState startingState = default;

    public void NewGame()
    {
       GlobalState.Copy(startingState, globalState);
    }
}

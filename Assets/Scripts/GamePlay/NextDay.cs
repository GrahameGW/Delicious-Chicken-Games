using UnityEngine;

public class NextDay : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    
    public void Next()
    {
        globalState.currentDay++;
        globalState.currentTime = TimeOfDay.Morning;
        globalState.playedAMDialog = false;
        globalState.playedPMDialog = false;
}
}

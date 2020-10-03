using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitIcon : InteractiveObject
{
    [SerializeField] ScheduleManager scheduleManager = default;

    public override void Execute()
    {
        scheduleManager.Save();
        actionDescription = scheduleManager.GetSaved();
        actionText.text = actionDescription;
    }
}

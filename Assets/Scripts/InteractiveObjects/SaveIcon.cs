using UnityEngine;

public class SaveIcon : InteractiveObject
{
    [SerializeField] ScheduleManager scheduleManager = default;

    public override void Execute()
    {
        scheduleManager.Save();
        actionDescription = scheduleManager.GetSaved();
        actionText.text = actionDescription;
    }
}

using UnityEngine;

public static class StateExtensions
{
    [ContextMenu("SaveJSON")]
    public static void Copy(this StudioState from, StudioState to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this GlobalState from, GlobalState to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }
}

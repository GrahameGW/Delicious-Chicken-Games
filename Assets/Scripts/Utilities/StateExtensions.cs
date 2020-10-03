using UnityEngine;

public static class StateExtensions
{
    [ContextMenu("SaveJSON")]
    public static void Copy(this ScriptableObject from, ScriptableObject to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }
    /*
    [ContextMenu("SaveJSON")]
    public static void Copy(this GlobalState from, GlobalState to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this DialogueOrganizer from, DialogueOrganizer to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this LerasArc from, LerasArc to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this LuisArc from, LuisArc to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this BucksArc from, BucksArc to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this BroadcastItems from, BroadcastItems to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }

    [ContextMenu("SaveJSON")]
    public static void Copy(this CarlaArc from, CarlaArc to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/PotionData.json", potion);
    }
    */
}

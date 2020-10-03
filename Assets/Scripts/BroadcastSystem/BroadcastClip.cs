using UnityEngine;

public abstract class BroadcastClip : ScriptableObject
{
    public new string name;
    public AudioClip clip;
    [TextArea]
    public string dialog;
    public YarnProgram yarn;
}

using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/NPC")]
public class NPC : ScriptableObject
{
    public new string name;
    public float approvalScore = 0.0f;

}

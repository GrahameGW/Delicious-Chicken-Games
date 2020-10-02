using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Studio State")]
public class StudioState : ScriptableObject
{
    public Vector2 playerPosition;
    public Vector2 playerLocalScale;
    public bool playerFaceLeft = false;
    public bool mailChecked = false;
}

using UnityEngine;

[CreateAssetMenu(fileName = "PosSettings", menuName = "PP/Pos Settings")]
public class PosSettings : ScriptableObject
{
    [Header("Info")]
    public string notification;

    [Header("Misc")]
    public string toScene;
}

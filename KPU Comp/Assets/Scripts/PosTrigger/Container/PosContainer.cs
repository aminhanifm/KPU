using System.Collections.Generic;
 
using UnityEngine;
 
[CreateAssetMenu(fileName = "PosSettingsContainer", menuName = "PP/Pos Settings Container")]
public class PosContainer : ScriptableObject
{

    [SerializeField]
    private StringClassDictionary stringClassStore = StringClassDictionary.New<StringClassDictionary>();
    public Dictionary<string, PosSettings> Store
    {
        get { return stringClassStore.dictionary; }
    }
}


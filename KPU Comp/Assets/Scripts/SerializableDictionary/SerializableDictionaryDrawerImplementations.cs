using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

// ---------------
//  String => Int
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(StringIntDictionary))]
public class StringIntDictionaryDrawer : SerializableDictionaryDrawer<string, int> {
    protected override SerializableKeyValueTemplate<string, int> GetTemplate() {
        return GetGenericTemplate<SerializableStringIntTemplate>();
    }
}
internal class SerializableStringIntTemplate : SerializableKeyValueTemplate<string, int> {}
 
// ---------------
//  GameObject => Float
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(GameObjectFloatDictionary))]
public class GameObjectFloatDictionaryDrawer : SerializableDictionaryDrawer<GameObject, float> {
    protected override SerializableKeyValueTemplate<GameObject, float> GetTemplate() {
        return GetGenericTemplate<SerializableGameObjectFloatTemplate>();
    }
}
internal class SerializableGameObjectFloatTemplate : SerializableKeyValueTemplate<GameObject, float> {}


// ---------------
//  string => Class
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(StringClassDictionary))]
public class StringClassDictionaryDrawer : SerializableDictionaryDrawer<string, PosSettings>
{
    protected override SerializableKeyValueTemplate<string, PosSettings> GetTemplate()
    {
        return GetGenericTemplate<SerializableStringClassTemplate>();
    }
}
internal class SerializableStringClassTemplate : SerializableKeyValueTemplate<string, PosSettings> { }
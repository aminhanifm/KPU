using System;
 
using UnityEngine;
 
// ---------------
//  String => Int
// ---------------
[Serializable]
public class StringIntDictionary : SerializableDictionary<string, int> {}
 
// ---------------
//  GameObject => Float
// ---------------
[Serializable]
public class GameObjectFloatDictionary : SerializableDictionary<GameObject, float> {}


[Serializable]
public class StringClassDictionary : SerializableDictionary<string, PosSettings> { }

// ---------------
//  String => Class
// ---------------
//[Serializable]
//public class StringClassDictionary<T> : SerializableDictionary<string, T> { }

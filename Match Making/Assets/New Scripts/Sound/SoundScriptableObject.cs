using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/SoundScriptableObject")]
public class SoundScriptableObject : ScriptableObject
{
    public Sounds[] audioList;
}

[Serializable]
public struct Sounds
{
    public SoundType soundType;
    public AudioClip audio;
}


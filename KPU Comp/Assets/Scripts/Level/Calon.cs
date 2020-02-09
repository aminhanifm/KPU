using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Calon Components", menuName = "Calon/Calon Components")]
public class Calon : ScriptableObject
{
    public Sprite foto;
    public string nama;
    public string jabatan;
    public List<string> visi;
    public List<string> misi;

}

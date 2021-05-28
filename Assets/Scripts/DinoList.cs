using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dinosaurs", menuName = "DinoList")]
public class DinoList :ScriptableObject
{
    public List<DinoScriptable> dino;
}

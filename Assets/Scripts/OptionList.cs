using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Options",menuName ="OptionList")]

public class OptionList: ScriptableObject
{

  public List<OptionScriptable> options;

}

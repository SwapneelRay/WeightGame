﻿using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionScriptable
{   public Name name;
    public Sprite optionSprite;
    public Sprite optionHolderSprite;
    public int weight;
    
}

public enum Name{

    Tiger,
    Hippo,
    Lion,
    Giraffe,
    Elephant,
    Zebra


}
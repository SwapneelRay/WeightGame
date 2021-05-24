using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
    public Name Aname;
    public int weight;
    public Text text;

    public bool inHolder=false;

    private Action<int,bool,bool> OnDropCallBack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InititailizeOption(int weight,Name Aname,Action<int,bool,bool> _Ondropcallback) {
        this.Aname = Aname;
        this.weight = weight;
        text.text = weight.ToString();
        OnDropCallBack = _Ondropcallback;
    }

    public void OnSlotDrop(bool value)
    {


        if (OnDropCallBack != null)
        {

            OnDropCallBack(weight,value,inHolder);
        }



    }
    public void InholderSetter(bool setter) {

        this.inHolder = setter;
    }
}

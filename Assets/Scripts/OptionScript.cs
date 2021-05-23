using System;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour
{
    public Name Aname;
    public int weight;

    private Action OnDropCallBack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InititailizeOption(int weight,Name Aname,Action _Ondropcallback) {
        this.Aname = Aname;
        this.weight = weight;
        OnDropCallBack = _Ondropcallback;
    }

    public void OnSlotDrop()
    {


        if (OnDropCallBack != null)
        {

            OnDropCallBack();
        }



    }
}

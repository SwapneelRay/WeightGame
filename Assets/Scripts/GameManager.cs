using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class GameManager : MonoBehaviour
{
   // public DinosaurList dinosaurList;
    public OptionList optionList;
    [SerializeField] GameObject dinosaur;
    [SerializeField] GameObject optionHolderpf;
    [SerializeField] Transform optionPanel;
    [SerializeField] Text animalWeightText;
    int totalweight=0;
    int itemsInPlace;
    public int dinoweight;
    [SerializeField] GameObject Menupanel;
    
    [SerializeField] GameObject Scale;
   // [SerializeField] GameObject dummy;

    // Start is called before the first frame update
    void Start()
    {
        DinoInstantiate();
        OptionInstantiate();
        //   Instantiate(dummy);
        ScaleRotator();
       
    }

    private void DinoInstantiate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OptionInstantiate() {
        foreach (var item in optionList.options)
        
        {
            var optionHolder=Instantiate(optionHolderpf,optionPanel);
            optionHolder.transform.SetParent(optionPanel);
            optionHolder.GetComponent<Image>().sprite = item.optionHolderSprite;
            optionHolder.GetComponent<SlotScript>().InititailizeOptionHolder(item.Aname);

            var option = optionHolder.transform.GetChild(0);
            option.GetComponent<Image>().sprite = item.optionSprite;
            option.GetComponent<OptionScript>().InititailizeOption(item.weight,item.Aname,OnDropCall);
            option.GetComponent<OptionScript>().Aname = item.Aname;


        }

    }

    void OnDropCall(int weight,bool dropOnHolder,bool inHolder) {

        if (dropOnHolder && !inHolder) { totalweight += weight; itemsInPlace++; }
        else if (!dropOnHolder&&inHolder) { totalweight -= weight;itemsInPlace--; }
        else if (dropOnHolder && inHolder){ return; }

        animalWeightText.text = totalweight.ToString();

        /* if (itemsInPlace >= 3)
         {

             if (dinoweight > totalweight) { Scale.transform.DORotate(new Vector3(0, 0, 10), 2f); }
             else if(dinoweight < totalweight) { Scale.transform.DORotate(new Vector3(0, 0, -10), 2f); }


         }
         else { Scale.transform.DORotate(new Vector3(0, 0, 0), 2f); }*/
        ScaleRotator();
    }


    void ScaleRotator() {

      int weightDiff=  dinoweight - totalweight;
        if (weightDiff > 0) { Scale.transform.DORotate(new Vector3(0, 0, weightDiff * 0.02f), 2f); }
        else if (weightDiff < 0) { Scale.transform.DORotate(new Vector3(0, 0, weightDiff * 0.1f), 2f); }
        else if (weightDiff == 0) { Menupanel.SetActive(true); }
    }

    public void Replay() {
        Menupanel.SetActive(false);


    }

    public void Next() {

        Menupanel.SetActive(false);

    }
}

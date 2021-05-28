using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class GameManager : MonoBehaviour
{
    public DinoList dinosaurList;
    public OptionList optionList;
    [SerializeField] GameObject dinosaur;
    [SerializeField] GameObject optionHolderpf;
    [SerializeField] Transform optionPanel;
    [SerializeField] Text animalWeightText;
    [SerializeField] Text dinoWeightText;
    int totalweight=0;
    int itemsInPlace;
    public int dinoweight;
    int index = 0;
    [SerializeField] GameObject Menupanel;
    [SerializeField] GameObject Gamepanel;
    int maxOptions;
    
    [SerializeField] GameObject Scale;
    GameObject[] options= new GameObject[6];

   // [SerializeField] GameObject dummy;

    // Start is called before the first frame update
    void Start()
    {
       OptionSetter();
       // maxOptions = 6;
        DinoInstantiate();
      //  OptionInstantiate(optionList);
        //   Instantiate(dummy);
        ScaleRotator();
       
    }

    private void DinoInstantiate()
    {
        dinoweight = dinosaurList.dino[index].weight;
        dinosaur.GetComponent<Image>().sprite = dinosaurList.dino[index].dinoSprite;
        dinoWeightText.text = dinoweight.ToString();
        totalweight = 0;
        animalWeightText.text = totalweight.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OptionInstantiate(OptionList temp) {

        temp.options = ShuffleList.ShuffleListItems<OptionScriptable>(temp.options);
        int tempvalue=0;
        

        foreach (var item in temp.options)
        
        {
            var optionHolder=Instantiate(optionHolderpf,optionPanel);
            optionHolder.transform.SetParent(optionPanel);
            optionHolder.GetComponent<Image>().sprite = item.optionHolderSprite;
            optionHolder.GetComponent<SlotScript>().InititailizeOptionHolder(item.Aname);

            var option = optionHolder.transform.GetChild(0);
          //  
            option.GetComponent<Image>().sprite = item.optionSprite;
            option.GetComponent<OptionScript>().InititailizeOption(item.weight,item.Aname,OnDropCall);
            option.GetComponent<OptionScript>().Aname = item.Aname;

            options[tempvalue] = option.gameObject;
            tempvalue++;

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
        if (weightDiff >= 0) { Scale.transform.DORotate(new Vector3(0, 0, weightDiff * 0.02f), 2f);
            if (weightDiff == 0&&itemsInPlace>=3) { StartCoroutine(MenuActivator(true, 2.5f));


            }
        }
        else if (weightDiff < 0) { Scale.transform.DORotate(new Vector3(0, 0, weightDiff * 0.1f), 2f); }
         
    }

    IEnumerator  MenuActivator(bool state,float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        Menupanel.SetActive(state);
    }

   


    void OptionSetter()
    {
        List<OptionScriptable> templist = new List<OptionScriptable>();
       
        templist.AddRange(optionList.options);
        
        List<OptionScriptable> finallist = new List<OptionScriptable>();
        int tempweight = dinoweight;
        //int totaloptions = 0;

        // System.Random r = new System.Random();


       
            // Fix the first element as A[i] 
            for (int i = 0; i < templist.Count - 2; i++)
            {
            
            // Fix the second element as A[j] 
            for (int j = i + 1; j < templist.Count - 1; j++)
                {
                
                // Now look for the third number 
                for (int k = j + 1; k < templist.Count; k++)
                    {
                    
                    if (templist[i].weight + templist[j].weight + templist[k].weight == tempweight)
                        {
                       
                        finallist.Add(templist[i]);
                        templist.RemoveAt(i);
                            finallist.Add(templist[j]);
                        templist.RemoveAt(j);
                            finallist.Add(templist[k]);
                        templist.RemoveAt(k);
                       // continue;
                        }
                    }
                }
            }
            System.Random r = new System.Random();
        while (finallist.Count < 6)
        {
            int rIndex = r.Next(0,templist.Count);
            finallist.Add(templist[rIndex]);
            templist.RemoveAt(rIndex);


        }
        Debug.Log(finallist.Count);
        OptionList op = new OptionList();
        op.options = finallist;
        print(op.options.Count);
        OptionInstantiate(op);
    }
    public void Replay()
    {
        StartCoroutine(MenuActivator(false, 0f));
        DinoInstantiate();

        DestroyOptions();
        OptionSetter();
    }

    public void Next()
    {
        StartCoroutine(MenuActivator(false, 0f));
        index++;
        if (index < dinosaurList.dino.Count) { DinoInstantiate();
        DestroyOptions();
        OptionSetter(); }
        else { Gamepanel.SetActive(true); }
       

        


    }

    void DestroyOptions() {
        int temp = 0;
        foreach (Transform item in optionPanel)
        {

            options[temp].GetComponent<OptionScript>().ResetParent();

            Destroy(item.gameObject);
            temp++;
        }


    }
}

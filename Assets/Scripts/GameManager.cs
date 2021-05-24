using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public OptionList optionList;
    [SerializeField] GameObject dinosaur;
    [SerializeField] GameObject optionHolderpf;
    [SerializeField] Transform optionPanel;
    [SerializeField] Text animalWeightText;
    int totalweight;
    int itemsInPlace;
    public int dinoweight;

    [SerializeField] GameObject Scale;

    // Start is called before the first frame update
    void Start()
    {
        OptionInstantiate();
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

        if (itemsInPlace >= 3)
        {

            if (dinoweight > totalweight) { Scale.transform.DORotate(new Vector3(0, 0, 10), 2f); }
            else { Scale.transform.DORotate(new Vector3(0, 0, -10), 2f); }


        }
        else { Scale.transform.DORotate(new Vector3(0, 0, 0), 2f); }
    }
}

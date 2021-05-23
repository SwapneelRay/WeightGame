using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public OptionList optionList;
    [SerializeField] GameObject dinosaur;
    [SerializeField] GameObject optionHolderpf;
    [SerializeField] Transform OptionPanel;
    [SerializeField] Text Animalweight;

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
            var optionHolder=Instantiate(optionHolderpf,OptionPanel);
            optionHolder.transform.SetParent(OptionPanel);
            optionHolder.GetComponent<Image>().sprite = item.optionHolderSprite;
            optionHolder.GetComponent<SlotScript>().InititailizeOptionHolder(item.Aname);

            var option = optionHolder.transform.GetChild(0);
            option.GetComponent<Image>().sprite = item.optionSprite;
            option.GetComponent<OptionScript>().InititailizeOption(item.weight,item.Aname,OnDropCall);
            option.GetComponent<OptionScript>().Aname = item.Aname;


        }

    }

    void OnDropCall() {

        Animalweight.text = "";

    }
}

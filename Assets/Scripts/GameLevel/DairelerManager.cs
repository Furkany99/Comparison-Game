using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DairelerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] onayDizisi;
     
    void Start()
    {
        onayScaleKapat();
    
    }

    public void onayScaleKapat()
    {
        foreach(GameObject onay in onayDizisi)
        {
            onay.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

    }


    public void onayScaleAc(int hangiOnay)
    {
        onayDizisi[hangiOnay].GetComponent<RectTransform>().DOScale(1,0.3f);

        if(hangiOnay%5==0)
        {
            onayScaleKapat();
        }
    }


   

   
}

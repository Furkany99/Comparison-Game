using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    
    [SerializeField]
    private Text süreTxt;

    int kalanSüre;
    bool süreSaysinMi;

    GameManager gameManager;

    private void Awake() 
    {
        gameManager=Object.FindObjectOfType<GameManager>();    
    }

    void Start()
    {
        kalanSüre=90;
        süreSaysinMi=true;
       
        
    }

    public void süreyiBaslat()
    {
        StartCoroutine(süre());
    }

    IEnumerator süre()
    {
        while(süreSaysinMi)
        {
            yield return new WaitForSeconds(1f);

            if(kalanSüre<10)
            {
                süreTxt.text="0"+ kalanSüre.ToString();

            }else
            {
                 süreTxt.text=kalanSüre.ToString();
            }


            if(kalanSüre<=0)
            {
                süreSaysinMi=false;
                süreTxt.text="";
                gameManager.OyunuBitir();
            }

            kalanSüre--;
        }
    }

   
}

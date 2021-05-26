using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{   
    [SerializeField]
    private Text dogruAdetTxt,yanlisAdetTxt,puanTxt;

   int puanSure=10;
   bool sureBittiMi=true;
   int toplamPuan1,yazdirilacakPuan,artisPuan1;

   private void Awake() 
   {
       sureBittiMi=true;
   }



    public void SonuclarıGoster(int dogruAdet,int yanlisAdet,int puan)
    {
        dogruAdetTxt.text=dogruAdet.ToString();
        yanlisAdetTxt.text=yanlisAdet.ToString();
        puanTxt.text=puan.ToString();
        toplamPuan1=puan;
        artisPuan1=toplamPuan1/10;

        StartCoroutine(PuaniYazdir());


    }

    IEnumerator PuaniYazdir()
    {
        while (sureBittiMi)
        {
            yield return new WaitForSeconds(0.1f);

            yazdirilacakPuan+=artisPuan1;

            if(yazdirilacakPuan>=toplamPuan1)
            {
                yazdirilacakPuan=toplamPuan1;
            }

            puanTxt.text=yazdirilacakPuan.ToString();

            if(puanSure<=0)
            {
                sureBittiMi=false;
            }

            puanSure--;
        }
    }
   
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");

    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GeriSayımManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayım;

    [SerializeField]
    private Text GeriSayımText;

    GameManager gameManager;

    private void Awake() 
    {
        gameManager=Object.FindObjectOfType<GameManager>();    
    }

    void Start()
    {

        StartCoroutine(GeriSay());
        
    }

    IEnumerator GeriSay()
    {
        GeriSayımText.text="3";
        yield return new WaitForSeconds(0.3f);

        GeriSayım.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayım.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

        GeriSayımText.text="2";
        yield return new WaitForSeconds(0.3f);

        GeriSayım.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayım.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

        GeriSayımText.text="1";
        yield return new WaitForSeconds(0.3f);

        GeriSayım.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayım.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

       StopAllCoroutines();

        gameManager.OyunBasla(); 


    }

   
  
}

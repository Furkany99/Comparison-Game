using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Hareket : MonoBehaviour
{
    
    [SerializeField]  
    private Transform hareketEt;
    [SerializeField]
    private Transform Button;
    private void Start()
    {
        hareketEt.transform.GetComponent<RectTransform>().DOLocalMoveX(0f,1f).SetEase(Ease.Flash);
        Button.transform.GetComponent<RectTransform>().DOLocalMoveY(-240f,1f).SetEase(Ease.Flash);

    }


    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }

}


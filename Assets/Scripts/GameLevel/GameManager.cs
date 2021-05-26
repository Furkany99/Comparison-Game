using System.Security.Cryptography;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject pausebttn;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject pauseButtonManage;

    [SerializeField]
    private GameObject puan;

    [SerializeField]
    private GameObject puanTxt;

    [SerializeField]
    private GameObject süre;
   
    [SerializeField]
    private GameObject süreTxt;

    [SerializeField]
    private GameObject yazi,buyukSayiyiSec;

    [SerializeField]
    private GameObject ustDD,altDD;

    [SerializeField]
    private Text ustTxt,altTxt,PuanTxtt;

    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager truefalseManager;
    SonucManager sonucManager;

    int kacinciOyun,oyunSayac;

    int ustDeger,altDeger;

    int buyukDeger;
    int butonDegeri;

    int toplamPuan,artisPuan;

    int dogruAdet,yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi,dogruSesi,yanlisSesi,bitisSesi;

    private void Awake() 
    {
        timerManager=Object.FindObjectOfType<TimerManager>();    
        dairelerManager=Object.FindObjectOfType<DairelerManager>();
        truefalseManager=Object.FindObjectOfType<TrueFalseManager>();

        audioSource=GetComponent<AudioSource>();
    }

   
    void Start()
    {
        kacinciOyun=0;
        oyunSayac=0;
        toplamPuan=0;
        altTxt.text="";
        ustTxt.text="";
        PuanTxtt.text="0";


        
     SoruEkraniniGuncelle();

    }

    void SoruEkraniniGuncelle()
    {
        
        pausebttn.GetComponent<CanvasGroup>().DOFade(1,1f);
        puan.GetComponent<CanvasGroup>().DOFade(1,1f);
        puanTxt.GetComponent<CanvasGroup>().DOFade(1,1f);
        süre.GetComponent<CanvasGroup>().DOFade(1,1f);
        süreTxt.GetComponent<CanvasGroup>().DOFade(1,1f);
        yazi.GetComponent<CanvasGroup>().DOFade(1,1f);

        ustDD.GetComponent<RectTransform>().DOLocalMoveX(0,1f).SetEase(Ease.OutBack);
        altDD.GetComponent<RectTransform>().DOLocalMoveX(0,1f).SetEase(Ease.OutBack);


    }

    public void OyunBasla()
    {

        audioSource.PlayOneShot(baslangicSesi);

        yazi.GetComponent<CanvasGroup>().DOFade(0,1f);
        buyukSayiyiSec.GetComponent<CanvasGroup>().DOFade(1,1.5f);

        KacinciOyun();

        

        timerManager.süreyiBaslat();

    }


    void KacinciOyun()
    {
        if(oyunSayac<5)
        {
            kacinciOyun=1;
            artisPuan=25;
        } 
        else if(oyunSayac>=5 && oyunSayac<10)
        {
            kacinciOyun=2;
            artisPuan=50;
        }
        else if(oyunSayac>=10 && oyunSayac<15)
        {
            kacinciOyun=3;
            artisPuan=75;
        }
        else if(oyunSayac>=15 && oyunSayac<20)
        {
            kacinciOyun=4;
            artisPuan=100;
        }
        else if(oyunSayac>=20 && oyunSayac<25)
        {
            kacinciOyun=5;
            artisPuan=125;
        }
        else
        {
            kacinciOyun=Random.Range(1,6);
            artisPuan=150;
        }

        switch (kacinciOyun)
        {
            case 1:
            BirinciFonksiyon();
            break;

            case 2:
            İkinciFonksiyon();
            break;

            case 3:
            UcuncuFonksiyon();
            break;

            case 4:
            DorduncuFonksiyon();
            break;

            case 5:
            BesinciFonksiyon();
            break;



            
        }
    }
   
   

   void BirinciFonksiyon()

    {
       int rastgeleDeger=Random.Range(0,50);

       if(rastgeleDeger<=25)
       {
           ustDeger=Random.Range(2,50);
           altDeger=ustDeger+Random.Range(1,10);

       }
       else
       {
           ustDeger=Random.Range(2,50);
           altDeger=Mathf.Abs(ustDeger-Random.Range(1,10));

       }

       if (ustDeger>altDeger)
       {
           buyukDeger=ustDeger;
       }
       else if(ustDeger<altDeger)
       {
           buyukDeger=altDeger;
       }
       if(ustDeger==altDeger)
       {
           BirinciFonksiyon();
           return;

       }
       
       ustTxt.text=ustDeger.ToString();
       altTxt.text=altDeger.ToString();

    }

   void İkinciFonksiyon()
   {
       int birinciSayi=Random.Range(1,10);
       int ikinciSayi=Random.Range(1,20);
       int ucuncuSayi=Random.Range(1,10);
       int dorduncuSayi=Random.Range(1,20);

       ustDeger=birinciSayi+ikinciSayi;
       altDeger=ucuncuSayi+dorduncuSayi;

       if(ustDeger>altDeger)
       {
           buyukDeger=ustDeger;
       }
       else if(ustDeger<altDeger)
       {
           buyukDeger=altDeger;
       }
       if(ustDeger==altDeger)
       {
           İkinciFonksiyon();
           return;
       }
       ustTxt.text=birinciSayi + "+" + ikinciSayi;
       altTxt.text=ucuncuSayi + "+" + dorduncuSayi;

   }
    void UcuncuFonksiyon()
    {
       int birinciSayi=Random.Range(15,30);
       int ikinciSayi=Random.Range(1,15);
       int ucuncuSayi=Random.Range(15,50);
       int dorduncuSayi=Random.Range(1,15);

       ustDeger=birinciSayi-ikinciSayi;
       altDeger=ucuncuSayi-dorduncuSayi;

       if(ustDeger>altDeger)
       {
           buyukDeger=ustDeger;
       }
       else if(ustDeger<altDeger)
       {
           buyukDeger=altDeger;
       }
       if(ustDeger==altDeger)
       {
           UcuncuFonksiyon();
           return;
       }
       ustTxt.text=birinciSayi + "-" + ikinciSayi;
       altTxt.text=ucuncuSayi + "-" + dorduncuSayi;
        

    }

    void DorduncuFonksiyon()
    {
       int birinciSayi=Random.Range(1,10);
       int ikinciSayi=Random.Range(1,10);
       int ucuncuSayi=Random.Range(1,10);
       int dorduncuSayi=Random.Range(1,10);

       ustDeger=birinciSayi*ikinciSayi;
       altDeger=ucuncuSayi*dorduncuSayi;

       if(ustDeger>altDeger)
       {
           buyukDeger=ustDeger;
       }
       else if(ustDeger<altDeger)
       {
           buyukDeger=altDeger;
       }
       if(ustDeger==altDeger)
       {
           DorduncuFonksiyon();
           return;
       }
       ustTxt.text=birinciSayi + " x " + ikinciSayi;
       altTxt.text=ucuncuSayi + " x " + dorduncuSayi;
        

    }

    void BesinciFonksiyon()
    {
       int bolen1=Random.Range(2,20);
       ustDeger=Random.Range(2,20);
       int bolunen1 = bolen1*ustDeger;

       int bolen2=Random.Range(2,20);
       altDeger=Random.Range(2,20);
       int bolunen2 = bolen2*altDeger;

       if(ustDeger>altDeger)
       {
           buyukDeger=ustDeger;
       }
       else if(ustDeger<altDeger)
       {
           buyukDeger=altDeger;
       }
       if(ustDeger==altDeger)
       {
           BesinciFonksiyon();
           return;
       }
       

       ustTxt.text=bolunen1 + " / " + bolen1;
       altTxt.text=bolunen2 + " / " + bolen2;

    }

    public void ButonDegerBelirle(string butonAdi)
    {
        if(butonAdi=="ustDD")
        {
            butonDegeri=ustDeger;
        }
        else if(butonAdi=="altDD")
        {
            butonDegeri=altDeger;
        }

        if(butonDegeri==buyukDeger)
        {

            truefalseManager.ScaleAc(true);
            
            dairelerManager.onayScaleAc(oyunSayac % 5);
            oyunSayac++;
            toplamPuan+= artisPuan;
            PuanTxtt.text=toplamPuan.ToString();

            dogruAdet++;
            audioSource.PlayOneShot(dogruSesi);
            KacinciOyun();
        }
        else
        {
            truefalseManager.ScaleAc(false);
            Hata();
            yanlisAdet++;
            audioSource.PlayOneShot(yanlisSesi);
            KacinciOyun();
            
        }

    }

    void Hata()
    {
        oyunSayac -= (oyunSayac % 5 + 5);

        if(oyunSayac<0)
        {
            oyunSayac=0;
        }

        dairelerManager.onayScaleKapat();
    }


    public void PausePaneliAc()
    {
        pauseButtonManage.SetActive(true);
    }


    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisSesi);

        sonucPaneli.SetActive(true);
        sonucManager=Object.FindObjectOfType<SonucManager>();

        sonucManager.SonuclarıGoster(dogruAdet,yanlisAdet,toplamPuan);

    }
}

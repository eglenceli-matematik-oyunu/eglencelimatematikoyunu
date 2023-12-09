using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BolmeOyunu : MonoBehaviour
{
    int sayi1;
    int sayi2;
    int toplam;
    int rastgele;
    int rastgele2;
    int rastgele3;

    public string LevelAdi;
    public string AnaMenuLevelAdi;

    public AudioClip trueSound;
    public AudioClip falseSound;
    public AudioClip failSound;

    public GameObject GameCanvas;
    public GameObject GameOverCanvas;
    public GameObject PauseCanvas;
    public GameObject BaslamaCanvas;

    public Text TxtSayi1;
    public Text TxtSayi2;
    public Text TxtA;
    public Text TxtB;
    public Text TxtC;
    public Text TxtPuan;
    public Text TxtSure;
    public Text TxtGOPuan;
    public Text TxtGOEnIyıPuan;
    public Text TxtBaslamaSure;

    public Button BtnA;
    public Button BtnB;
    public Button BtnC;

    public int sayiUstLimit;
    public int cevapOlusturmaUsLimit;
    public float oyunSuresi;

    int puan;
    int enPuan;
    float time_f;
    int time_i;

    int rast;

    public AudioSource source;

    bool click = false;

    void Start()
    {
        Time.timeScale = 1;

        BaslamaCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        PauseCanvas.SetActive(false);

        Invoke("OyunaBasla", 3f);

        time_f = oyunSuresi + 4;

        CreateQuestion();

        source.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("OyunDurdur", 0.4f);

            GameCanvas.SetActive(false);
            GameOverCanvas.SetActive(false);
            PauseCanvas.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        TxtBaslamaSure.text = (time_i - 11f).ToString();
        time_f = time_f - Time.deltaTime;
        time_i = (int)time_f;
        TxtSure.text = time_i.ToString();
        if (time_f <= 0)
        {
            GameOver();
            source.PlayOneShot(failSound);
        }
    }

    public void Btn_A_Click()
    {
        if (TxtA.text == toplam.ToString())
        {
            puan = puan + 10;
            TxtPuan.text = puan.ToString();

            TrueSoundEffect();

            time_f = oyunSuresi;
            time_i = (int)time_f;
            TxtSure.text = time_i.ToString();

            BtnA.GetComponent<Image>().color = Color.green;

            click = true;

            if (click == true)
            {
                BtnA.enabled = false;
                BtnB.enabled = false;
                BtnC.enabled = false;
            }

            Invoke("CreateQuestion", 1f);
        }
        else
        {
            BtnA.GetComponent<Image>().color = Color.red;

            FalseSoundEffect();

            if (TxtB.text == toplam.ToString())
            {
                BtnB.GetComponent<Image>().color = Color.green;
            }
            else if (TxtC.text == toplam.ToString())
            {
                BtnC.GetComponent<Image>().color = Color.green;
            }

            click = true;

            if (click == true)
            {
                BtnA.enabled = false;
                BtnB.enabled = false;
                BtnC.enabled = false;
            }

            Invoke("GameOver", 1f);
        }
    }

    public void Btn_B_Click()
    {
        if (TxtB.text == toplam.ToString())
        {
            puan = puan + 10;
            TxtPuan.text = puan.ToString();

            TrueSoundEffect();

            time_f = oyunSuresi;
            time_i = (int)time_f;
            TxtSure.text = time_i.ToString();

            BtnB.GetComponent<Image>().color = Color.green;

            click = true;

            if (click == true)
            {
                BtnA.enabled = false;
                BtnB.enabled = false;
                BtnC.enabled = false;
            }

            Invoke("CreateQuestion", 1f);
        }
        else
        {
            BtnB.GetComponent<Image>().color = Color.red;

            FalseSoundEffect();

            if (TxtA.text == toplam.ToString())
            {
                BtnA.GetComponent<Image>().color = Color.green;
            }
            else if (TxtC.text == toplam.ToString())
            {
                BtnC.GetComponent<Image>().color = Color.green;
            }

            click = true;

            if (click == true)
            {
                BtnA.enabled = false;
                BtnB.enabled = false;
                BtnC.enabled = false;
            }

            Invoke("GameOver", 1f);
        }
    }

    public void Btn_C_Click()
    {
        if (TxtC.text == toplam.ToString())
        {
            puan = puan + 10;
            TxtPuan.text = puan.ToString();

            TrueSoundEffect();

            time_f = oyunSuresi;
            time_i = (int)time_f;
            TxtSure.text = time_i.ToString();

            BtnC.GetComponent<Image>().color = Color.green;

            click = true;

            if (click == true)
            {
                BtnA.enabled = false;
                BtnB.enabled = false;
                BtnC.enabled = false;
            }

            Invoke("CreateQuestion", 1f);
        }
        else
        {
            BtnC.GetComponent<Image>().color = Color.red;

            FalseSoundEffect();

            if (TxtB.text == toplam.ToString())
            {
                BtnB.GetComponent<Image>().color = Color.green;
            }
            else if (TxtA.text == toplam.ToString())
            {
                BtnA.GetComponent<Image>().color = Color.green;
            }

            click = true;

            if (click == true)
            {
                BtnA.enabled = false;
                BtnB.enabled = false;
                BtnC.enabled = false;
            }

            Invoke("GameOver", 1f);
        }
    }

    void GameOver()
    {
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
        PauseCanvas.SetActive(false);

        TxtGOPuan.text = puan.ToString();
        if (puan > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", puan);
            enPuan = PlayerPrefs.GetInt("BestScore");
            TxtGOEnIyıPuan.text = enPuan.ToString();
        }
        else
        {
            enPuan = PlayerPrefs.GetInt("BestScore");
            TxtGOEnIyıPuan.text = enPuan.ToString();
        }
    }

    void OyunDurdur()
    {
        Time.timeScale = 0;
    }

    void OyunaBasla()
    {
        BaslamaCanvas.SetActive(false);
        Destroy(BaslamaCanvas);
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
    }

    void TrueSoundEffect()
    {
        source.PlayOneShot(trueSound);
    }

    void FalseSoundEffect()
    {
        source.PlayOneShot(falseSound);
    }

    public void BtnTekrarOynaClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LevelAdi);
    }

    public void BtnAnaMenuClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(AnaMenuLevelAdi);
    }

    public void OyunaDevamEtClick()
    {
        Time.timeScale = 1;
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
    }


    void CreateQuestion()
    {
        click = false;

        BtnA.enabled = true;
        BtnB.enabled = true;
        BtnC.enabled = true;

        BtnA.GetComponent<Image>().color = Color.white;
        BtnB.GetComponent<Image>().color = Color.white;
        BtnC.GetComponent<Image>().color = Color.white;

        sayi1 = Random.Range(10, sayiUstLimit);
        sayi2 = Random.Range(1, 20);
        rast = Random.Range(0, 1);
        if(rast==0)
        {
            if(sayi1 % sayi2 == 0)
            {
                toplam = sayi1 / sayi2;

                TxtSayi1.text = sayi1.ToString();
                TxtSayi2.text = sayi2.ToString();

                rastgele = Random.Range(0, 3);
                if (rastgele == 0)
                {
                    TxtA.text = toplam.ToString();
                    rastgele2 = Random.Range(0, cevapOlusturmaUsLimit);
                    rastgele3 = Random.Range(0, 2);
                    if (rastgele3 == 0)
                    {
                        TxtB.text = (toplam - rastgele2).ToString();
                        TxtC.text = (toplam + rastgele2).ToString();
                    }
                    else if (rastgele3 == 1)
                    {
                        TxtB.text = (toplam + rastgele2).ToString();
                        TxtC.text = (toplam - rastgele2).ToString();
                    }
                }
                else if (rastgele == 1)
                {
                    TxtB.text = toplam.ToString();
                    rastgele2 = Random.Range(0, cevapOlusturmaUsLimit);
                    rastgele3 = Random.Range(0, 2);
                    if (rastgele3 == 0)
                    {
                        TxtA.text = (toplam - rastgele2).ToString();
                        TxtC.text = (toplam + rastgele2).ToString();
                    }
                    else if (rastgele3 == 1)
                    {
                        TxtA.text = (toplam + rastgele2).ToString();
                        TxtC.text = (toplam - rastgele2).ToString();
                    }
                }
                else if (rastgele == 2)
                {
                    TxtC.text = toplam.ToString();
                    rastgele2 = Random.Range(0, cevapOlusturmaUsLimit);
                    rastgele3 = Random.Range(0, 2);
                    if (rastgele3 == 0)
                    {
                        TxtA.text = (toplam - rastgele2).ToString();
                        TxtB.text = (toplam + rastgele2).ToString();
                    }
                    else if (rastgele3 == 1)
                    {
                        TxtA.text = (toplam + rastgele2).ToString();
                        TxtB.text = (toplam - rastgele2).ToString();
                    }
                }
                if(TxtA.text == TxtB.text && TxtB.text == TxtC.text)
                {
                    CreateQuestion();
                }
            }
            else
            {
                CreateQuestion();
            }
        }
    }
}

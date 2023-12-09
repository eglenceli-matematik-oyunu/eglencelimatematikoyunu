using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject helpCanvas;
    public GameObject quitCanvas;

    public GameObject selectCanvas;

    public string toplamaKolaySahneAdi;
    public string toplamaOrtaSahneAdi;
    public string toplamaZorSahneAdi;

    public string cikarmaKolaySahneAdi;
    public string cikarmaOrtaSahneAdi;
    public string cikarmaZorSahneAdi;

    public string bolmeKolaySahneAdi;
    public string bolmeOrtaSahneAdi;
    public string bolmeZorSahneAdi;

    public string carpmaKolaySahneAdi;
    public string carpmaOrtaSahneAdi;
    public string carpmaZorSahneAdi;

    public string selectSceneName;

    AudioSource source;
    public AudioClip clickSound;

    void Start()
    {
        mainCanvas.SetActive(true);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);

        selectCanvas.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            mainCanvas.SetActive(true);
            helpCanvas.SetActive(false);
            quitCanvas.SetActive(false);

            selectCanvas.SetActive(false);
        }
    }


    public void BtnKolayClick()
    {
        if(selectSceneName == "Toplama")
        {
            SceneManager.LoadScene(toplamaKolaySahneAdi);
        }
        else if(selectSceneName == "Cikarma")
        {
            SceneManager.LoadScene(cikarmaKolaySahneAdi);
        }
        else if (selectSceneName == "Bolme")
        {
            SceneManager.LoadScene(bolmeKolaySahneAdi);
        }
        else if (selectSceneName == "Carpma")
        {
            SceneManager.LoadScene(carpmaKolaySahneAdi);
        }
    }

    public void BtnOrtaClick()
    {
        if (selectSceneName == "Toplama")
        {
            SceneManager.LoadScene(toplamaOrtaSahneAdi);
        }
        else if (selectSceneName == "Cikarma")
        {
            SceneManager.LoadScene(cikarmaOrtaSahneAdi);
        }
        else if (selectSceneName == "Bolme")
        {
            SceneManager.LoadScene(bolmeOrtaSahneAdi);
        }
        else if (selectSceneName == "Carpma")
        {
            SceneManager.LoadScene(carpmaOrtaSahneAdi);
        }
    }

    public void BtnZorClick()
    {
        if (selectSceneName == "Toplama")
        {
            SceneManager.LoadScene(toplamaZorSahneAdi);
        }
        else if (selectSceneName == "Cikarma")
        {
            SceneManager.LoadScene(cikarmaZorSahneAdi);
        }
        else if (selectSceneName == "Bolme")
        {
            SceneManager.LoadScene(bolmeZorSahneAdi);
        }
        else if (selectSceneName == "Carpma")
        {
            SceneManager.LoadScene(carpmaZorSahneAdi);
        }
    }

    /* Main Menu Buttons*/
    public void Btn_Toplama_Click()
    {
        mainCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);

        selectCanvas.SetActive(true);

        selectSceneName = "Toplama";

        source.PlayOneShot(clickSound);
    }

    public void Btn_Cikarma_Click()
    {
        mainCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);

        selectCanvas.SetActive(true);

        selectSceneName = "Cikarma";

        source.PlayOneShot(clickSound);
    }

    public void Btn_Bolme_Click()
    {
        mainCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);

        selectCanvas.SetActive(true);

        selectSceneName = "Bolme";

        source.PlayOneShot(clickSound);
    }

    public void Btn_Carpma_Click()
    {
        mainCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);

        selectCanvas.SetActive(true);

        selectSceneName = "Carpma";

        source.PlayOneShot(clickSound);
    }

    public void Btn_Help_Click()
    {
        mainCanvas.SetActive(false);
        helpCanvas.SetActive(true);
        quitCanvas.SetActive(false);

        source.PlayOneShot(clickSound);
    }

    public void Btn_Quit_Click()
    {
        mainCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(true);


        selectCanvas.SetActive(false);

        source.PlayOneShot(clickSound);
    }



    /* Help Menu Buttons*/
    public void Btn_MainMenu_Click()
    {
        mainCanvas.SetActive(true);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);

        selectCanvas.SetActive(false);

        source.PlayOneShot(clickSound);
    }

    public void Btn_Facebook_Click()
    {
        Application.OpenURL("https://www.facebook.com/bkoyun2014/");
    }

    public void Btn_Twitter_Click()
    {
        Application.OpenURL("https://twitter.com/BKOyun2014");
    }

    public void Btn_Instagram_Click()
    {
        Application.OpenURL("https://www.instagram.com/bkoyun/");
    }



    /* Quit Menu Buttons*/
    public void Btn_Evet_Click()
    {
        Application.Quit();
    }

    public void Btn_Hayır_Click()
    {
        mainCanvas.SetActive(true);
        helpCanvas.SetActive(false);
        quitCanvas.SetActive(false);
    }

}

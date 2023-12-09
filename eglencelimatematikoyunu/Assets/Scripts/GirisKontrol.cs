using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GirisKontrol : MonoBehaviour
{

    public Text TxtBekleme;

    void Start()
    {
        TxtBekleme.text = "";
    }

    void Update()
    {

    }

    public void BtnEnglishClick()
    {
        SceneManager.LoadScene("MainSceneE");
        TxtBekleme.text = "Loading...";
    }

    public void BtnTurkishClick()
    {
        SceneManager.LoadScene("MainSceneT");
        TxtBekleme.text = "Yükleniyor...";
    }
}

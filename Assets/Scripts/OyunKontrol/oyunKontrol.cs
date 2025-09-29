using TMPro;
using UnityEngine;

public class oyunKontrol : MonoBehaviour
{

    private TextMeshProUGUI puanText;
    public TextMeshProUGUI skorText;
    public TextMeshProUGUI bestSkorText;

    public TextMeshProUGUI skorText_end;
    public TextMeshProUGUI bestSkorText_end;
    public int puan = 0;
    private int bestSkor = 0;

    void Start()
    {
        GameObject puanObjesi = GameObject.Find("skor");
        if (puanObjesi != null)
        {
            puanText = puanObjesi.GetComponent<TextMeshProUGUI>();
        }

        // Best skoru hafızadan çek
        bestSkor = PlayerPrefs.GetInt("BestSkor", 0);
        bestSkorText.text = "En İyi Skor : " + bestSkor.ToString();
        bestSkorText_end.text = "En İyi Skor : " + bestSkor.ToString();
    }

    public void PuanEkle(int miktar)
    {
        puan += miktar;
        puanText.text = puan.ToString();
        skorText.text = "Skor : " + puan.ToString();
        skorText_end.text = "Skor : " + puan.ToString();

        // Yeni skor best'ten büyükse güncelle
        if (puan > bestSkor)
        {
            bestSkor = puan;
            PlayerPrefs.SetInt("BestSkor", bestSkor);
            PlayerPrefs.Save();

            bestSkorText.text = "En İyi Skor : " + bestSkor.ToString();
            bestSkorText_end.text = "En İyi Skor : " + bestSkor.ToString();
        }
    }
}

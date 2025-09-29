using TMPro;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public GameObject mainMenuPanel;

    void Start()
    {
        // En iyi skoru PlayerPrefs'ten al ve UI'da göster
        int bestScore = PlayerPrefs.GetInt("BestSkor", 0);
        bestScoreText.text = "EN YÜKSEK SKOR : " + bestScore.ToString();
    }


    public void StartGame()
    {
        sesKontrol.instance.MouseClick(); // Mouse tıklama sesi
        // Oyun sahnesini başlat
        UnityEngine.SceneManagement.SceneManager.LoadScene("level_1");
    }

    public void QuitGame()
    {
        sesKontrol.instance.MouseClick(); // Mouse tıklama sesi

        // Oyundan çık
        Application.Quit();
    }




}

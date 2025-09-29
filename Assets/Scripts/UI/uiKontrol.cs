using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class uiKontrol : MonoBehaviour
{
    [Header("UI Ayarları")]
    public GameObject pausePanel;
    public GameObject oyunSonuPaneli;

    public TextMeshProUGUI durdurText;

    bool oyunDuraklatildi = false;

    private InputSystem_Actions controls;

    //instance
    public static uiKontrol instance;


    void Awake()
    {
        controls = new InputSystem_Actions();

        // Escape'e basıldığında çalışacak
        controls.UI.Cancel.performed += ctx => OyunDuraklat();

        instance = this;

    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();





    public void OyunDuraklat()
    {
        oyunDuraklatildi = !oyunDuraklatildi;
        if (oyunDuraklatildi)
        {
            sesKontrol.instance.MouseClick(); // Mouse tıklama sesi
            Time.timeScale = 0f; // Oyunu duraklat
            pausePanel.SetActive(true); // Pause panelini aç
            durdurText.text = "DEVAM ET";
        }
        else
        {
            sesKontrol.instance.MouseClick(); // Mouse tıklama sesi
            Time.timeScale = 1f; // Oyunu devam ettir
            pausePanel.SetActive(false); // Pause panelini kapat
            durdurText.text = "DURDUR";
        }
    }

    public void pausepanelAc()
    {
        if (!oyunDuraklatildi)
        {
            OyunDuraklat();
        }

        else if (oyunDuraklatildi)
        {
            OyunDuraklat();
        }
    }

    public void pausePanelKapat()
    {
        if (oyunDuraklatildi)
        {
            OyunDuraklat();
        }
    }


    public void tekrarOyna()
    {
        sesKontrol.instance.MouseClick(); // Mouse tıklama sesi
        Time.timeScale = 1f; // Zamanı normal hızına getir
        oyunSonuPaneli.SetActive(false); // Oyun sonu panelini kapat
        // Oyun sahnesini yeniden başlatma
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void oyunBitti()
    {
        oyunSonuPaneli.SetActive(true); // Oyun sonu panelini aç
        Time.timeScale = 0f; // Oyunu duraklat
    }

    public void anaMenuyeDon()
    {
        sesKontrol.instance.MouseClick(); // Mouse tıklama sesi
        Time.timeScale = 1f; // Zamanı normal hızına getir
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine dön
    }
}

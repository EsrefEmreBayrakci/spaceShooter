using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

public class oyuncuKontrol : MonoBehaviour
{
    [Header("Can Sistemi")]
    [SerializeField] private int maxCan = 100;
    [SerializeField] private int mevcutCan;




    [Header("Hareket Ayarları")]
    public float hareketHizi = 5f;
    [SerializeField] float minX = -4f;
    [SerializeField] float maxX = 4f;
    [SerializeField] float minY = -7f;
    [SerializeField] float maxY = 2f;

    [Header("Mermi Ayarları")]
    [SerializeField] GameObject mermiPrefab;
    [SerializeField] Transform mermiNoktasi;
    [SerializeField] float atesGecikme = 0.25f;

    [Header("Efekt Ayarları")]
    [SerializeField] private GameObject efektPrefab; // hasar efekti prefabı

    [Header("Görsel Ayarlar")]
    [SerializeField] private Image canBar; // Can çubuğu UI elementi

    [SerializeField] private Image mermiBar; // mermi çubuğu UI elementi

    [Header("Mermi Limiti Sistemi")]
    [SerializeField] private int maxMermi = 20;
    [SerializeField] private int mevcutMermi;
    [SerializeField] private float mermiDolmaSuresi = 0.5f;

    [Header("Mobil Kontroller")]
    public Joystick joystick; // FloatingJoystick referansı
    public Button atesButonu;
    private bool mobilAteşEt = false;

    private float mermiDolmaZamanlayici;


    private SpriteRenderer sr;
    private Coroutine hasarEfektiCoroutine;


    private Rigidbody2D rb;
    private InputAction yatayInput;
    private InputAction dikeyInput;
    private InputAction atesInput;
    private float atesZamani = 0f;

    public static oyuncuKontrol instance;

    public enum GirdiTuru { Bilgisayar, Mobil }
    [SerializeField] private GirdiTuru girdiTuru = GirdiTuru.Bilgisayar;
    void Awake()
    {
        if (girdiTuru == GirdiTuru.Bilgisayar)
        {
            // Klavye ve gamepad input tanımları
            yatayInput = new InputAction("Yatay", InputActionType.Value);
            yatayInput.AddCompositeBinding("1DAxis")
                .With("Negative", "<Keyboard>/a")
                .With("Positive", "<Keyboard>/d");
            yatayInput.AddCompositeBinding("1DAxis")
                .With("Negative", "<Gamepad>/leftStick/left")
                .With("Positive", "<Gamepad>/leftStick/right");
            yatayInput.Enable();

            dikeyInput = new InputAction("Dikey", InputActionType.Value);
            dikeyInput.AddCompositeBinding("1DAxis")
                .With("Negative", "<Keyboard>/s")
                .With("Positive", "<Keyboard>/w");
            dikeyInput.AddCompositeBinding("1DAxis")
                .With("Negative", "<Gamepad>/leftStick/down")
                .With("Positive", "<Gamepad>/leftStick/up");
            dikeyInput.Enable();

            atesInput = new InputAction("Ates", InputActionType.Button);
            atesInput.AddBinding("<Keyboard>/space");
            atesInput.AddBinding("<Gamepad>/buttonSouth"); // A tuşu
            atesInput.Enable();
        }

        instance = this;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mevcutCan = maxCan;
        mevcutMermi = maxMermi;

        sr = GetComponentInChildren<SpriteRenderer>();
        CanGuncelle();
        mermiGuncelle();

        if (girdiTuru == GirdiTuru.Mobil && atesButonu != null)
        {
            atesButonu.onClick.AddListener(() =>
            {
                mobilAteşEt = true;
            });
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            hasarAl(10);
            GameObject efekt = Instantiate(efektPrefab, collision.transform.position, Quaternion.identity);
            Destroy(efekt, 1f); // 1 saniye sonra efekt objesini yok et
            sesKontrol.instance.Meteorpatlama(); // Meteor patlama sesi
            Destroy(collision.gameObject); // Çarpan objeyi yok et
        }

        else if (collision.gameObject.CompareTag("EnemyMermi"))
        {
            hasarAl(10);

            Destroy(collision.gameObject); // Düşmanı yok et
        }



    }



    public void hasarAl(int hasarMiktari = 10)
    {
        mevcutCan -= hasarMiktari;
        mevcutCan = Mathf.Max(mevcutCan, 0);

        // Kırmızı hasar efekti
        if (hasarEfektiCoroutine != null)
            StopCoroutine(hasarEfektiCoroutine);
        hasarEfektiCoroutine = StartCoroutine(HasarEfekti());



        CanGuncelle(); // Can çubuğunu güncelle

        if (mevcutCan <= 0)
        {
            Destroy(gameObject); // Oyuncu yok ediliyor
            sesKontrol.instance.PlayerPatlama(); // Oyuncu patlama sesi
            uiKontrol.instance.oyunBitti(); // Oyun bittiğinde UI kontrolüne bildir
        }
    }


    IEnumerator HasarEfekti()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.5f); // 0.5 saniye kırmızı kalsın
        sr.color = Color.white;
    }


    void FixedUpdate()
    {
        Hareket();

        mermiFirlat();

        MermiZamanlaDol();
        mermiGuncelle(); // Mermi çubuğunu güncelle

    }

    private void MermiZamanlaDol()
    {
        if (mevcutMermi < maxMermi)
        {
            mermiDolmaZamanlayici += Time.deltaTime;

            if (mermiDolmaZamanlayici >= mermiDolmaSuresi)
            {
                mevcutMermi++;
                mermiDolmaZamanlayici = 0f;
            }
        }
    }


    private void Hareket()
    {
        Vector2 hareket = Vector2.zero;

        if (girdiTuru == GirdiTuru.Bilgisayar)
        {
            float yatay = yatayInput.ReadValue<float>();
            float dikey = dikeyInput.ReadValue<float>();
            hareket = new Vector2(yatay, dikey).normalized;
        }
        else if (girdiTuru == GirdiTuru.Mobil && joystick != null)
        {
            hareket = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        }

        Vector2 hedefHiz = hareket * hareketHizi;
        Vector2 yeniPozisyon = rb.position + hedefHiz * Time.fixedDeltaTime;

        yeniPozisyon.x = Mathf.Clamp(yeniPozisyon.x, minX, maxX);
        yeniPozisyon.y = Mathf.Clamp(yeniPozisyon.y, minY, maxY);

        rb.MovePosition(yeniPozisyon);
    }


    void OnDestroy()
    {
        yatayInput.Disable();
        yatayInput.Dispose();
        dikeyInput.Disable();
        dikeyInput.Dispose();
        atesInput.Disable();
        atesInput.Dispose();
    }

    private void mermiFirlat()
    {
        bool atesEt = false;

        if (girdiTuru == GirdiTuru.Bilgisayar)
            atesEt = atesInput.ReadValue<float>() > 0;
        else if (girdiTuru == GirdiTuru.Mobil)
        {
            atesEt = mobilAteşEt;
            mobilAteşEt = false;
        }

        if (atesEt && Time.time >= atesZamani && mevcutMermi > 0)
        {
            Instantiate(mermiPrefab, mermiNoktasi.position, Quaternion.identity);
            mevcutMermi--;
            atesZamani = Time.time + atesGecikme;
            mermiDolmaZamanlayici = 0f;
            sesKontrol.instance.BulletSound();
        }
    }


    public void mermiGuncelle()
    {
        // Mermi çubuğunu güncelle
        if (mermiBar != null)
        {
            mermiBar.fillAmount = (float)mevcutMermi / maxMermi;
        }
    }

    public void CanGuncelle()
    {
        // Can çubuğunu güncelle
        if (canBar != null)
        {
            canBar.fillAmount = (float)mevcutCan / maxCan;
        }
    }


}

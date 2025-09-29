using UnityEngine;

public class mermiKontrol : MonoBehaviour
{
    [SerializeField] float mermiHizi = 10f;
    [SerializeField] GameObject efektPrefab; // mermi çarptığında efekt prefabı

    public static mermiKontrol instance;


    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        transform.Translate(Vector2.up * mermiHizi * Time.deltaTime);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Efekt(collision);


    }

    public void Efekt(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            // Mermi çarptığında efekt oluştur
            GameObject efekt = Instantiate(efektPrefab, collision.transform.position, Quaternion.identity);
            Destroy(efekt, 1f); // 1 saniye sonra efekt objesini yok et

            sesKontrol.instance.Meteorpatlama(); // Meteor patlama sesi
            Destroy(collision.gameObject);
            Destroy(gameObject); // mermi bir şeye çarptığında yok et
        }
    }


    // kamera dışında kaldığında mermiyi yok et
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

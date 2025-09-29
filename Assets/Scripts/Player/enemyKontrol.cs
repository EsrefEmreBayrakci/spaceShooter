using UnityEngine;

public class enemyKontrol : MonoBehaviour
{



    [SerializeField] GameObject efektPrefab; // hasar efekti prefabı

    public float hareketHizi = 2f;
    public float xHareketHizi = 1f;
    public float xDalgaGenisligi = 1f;

    public float minX = -4f;
    public float maxX = 4f;

    private float xOffset;

    void Start()
    {
        // Rastgele bir offset ile başlasın ki hepsi aynı dalgada olmasın
        xOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Aşağıya hareket
        transform.Translate(Vector2.down * hareketHizi * Time.deltaTime);

        // X yönünde hafif sağa/sola sinus dalgası şeklinde hareket
        float xDalga = Mathf.Sin(Time.time * xHareketHizi + xOffset) * xDalgaGenisligi;

        float yeniX = transform.position.x + xDalga * Time.deltaTime;
        float clampedX = Mathf.Clamp(yeniX, minX, maxX);

        transform.position = new Vector2(clampedX, transform.position.y);

        Destroy(gameObject, 7f); // 7 saniye sonra düşmanı yok et
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        //tagı playermermi olan bir objeye çarparsa
        if (collision.gameObject.CompareTag("PlayerMermi"))
        {
            // Düşmanı yok et
            Destroy(gameObject);
            sesKontrol.instance.EnemyPatlama(); // Düşman patlama sesi
            Destroy(collision.gameObject); // Mermiyi yok et
            GameObject efekt = Instantiate(efektPrefab, collision.transform.position, Quaternion.identity);
            Destroy(efekt, 1f); // 1 saniye sonra efekt objesini yok et




        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncuya hasar ver
            oyuncuKontrol player = collision.gameObject.GetComponent<oyuncuKontrol>();
            if (player != null)
            {
                player.hasarAl();
                GameObject efekt = Instantiate(efektPrefab, transform.position, Quaternion.identity);
                Destroy(efekt, 1f); // 1 saniye sonra efekt objesini yok et
                sesKontrol.instance.EnemyPatlama(); // Düşman patlama sesi
                Destroy(gameObject); // Düşmanı yok et
            }
        }

    }
}

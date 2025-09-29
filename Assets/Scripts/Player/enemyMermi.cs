using UnityEngine;

public class enemyMermi : MonoBehaviour
{
    [Header("Ateş Ayarları")]
    public GameObject mermiPrefab;
    public Transform atisNoktasi;
    public float atisAraligi = 1.5f;
    public float mermiHizi = 5f;

    private float sonrakiAtesZamani;

    void Update()
    {
        if (Time.time >= sonrakiAtesZamani)
        {
            AtesEt();
            sonrakiAtesZamani = Time.time + atisAraligi;
        }
    }

    void AtesEt()
    {
        GameObject mermi = Instantiate(mermiPrefab, atisNoktasi.position, Quaternion.identity);

        // Sabit yön: Aşağı doğru (veya ileriye doğru)
        Rigidbody2D rb = mermi.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * mermiHizi;


    }


}

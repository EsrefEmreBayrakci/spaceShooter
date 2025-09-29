using UnityEngine;

public class enemyMermiPrefab : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Player mermisine çarparsa
        if (collision.gameObject.CompareTag("Player"))
        {
            // Efekt oluştur

            Destroy(gameObject); // Enemy mermisini yok et
        }

        else if (collision.gameObject.CompareTag("PlayerMermi"))
        {
            Destroy(collision.gameObject); // Player mermisini yok et
            Destroy(gameObject); // Enemy mermisini yok et
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Kamera dışında kaldığında enemy mermisini yok et
    }
}

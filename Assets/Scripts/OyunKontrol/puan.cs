using UnityEngine;

public class puan : MonoBehaviour
{
    private oyunKontrol kontrol;

    void Start()
    {
        kontrol = FindFirstObjectByType<oyunKontrol>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            kontrol.PuanEkle(10);

        }
        else if (collision.gameObject.CompareTag("Meteor"))
        {
            kontrol.PuanEkle(5);

        }
    }
}

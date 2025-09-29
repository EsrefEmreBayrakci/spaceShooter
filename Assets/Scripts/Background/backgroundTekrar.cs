using UnityEngine;

public class backgroundTekrar : MonoBehaviour
{
    [SerializeField] float yukseklik = 20.48f; // Arka planın yüksekliği
    void Update()
    {
        if (transform.position.y <= -yukseklik)
        {
            // Arka planın konumunu yukarı taşı
            Vector2 yeniKonum = new Vector2(0, yukseklik * 2);
            transform.position = (Vector2)transform.position + yeniKonum;
        }
    }
}

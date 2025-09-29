using UnityEngine;

public class Gezegen : MonoBehaviour
{
    public float hareketHizi = 2f;


    void Update()
    {
        transform.Translate(Vector2.down * hareketHizi * Time.deltaTime);


    }


    // kamera dışında kaldığında gezegeni yok et
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}



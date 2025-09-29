using UnityEngine;

public class nesneHareket : MonoBehaviour
{
    [SerializeField] float baslangicHizi = 0.3f;
    [SerializeField] float maksimumHiz = 3f;
    [SerializeField] float hizlanmaOrani = 0.1f; // saniyede ne kadar hızlanacak

    private float mevcutHiz;

    void Start()
    {
        mevcutHiz = baslangicHizi;
    }

    void Update()
    {
        // Hızı yavaş yavaş artır
        mevcutHiz = Mathf.Min(maksimumHiz, mevcutHiz + hizlanmaOrani * Time.deltaTime);

        // Nesneyi hareket ettir
        transform.Translate(Vector2.down * mevcutHiz * Time.deltaTime);
    }
}

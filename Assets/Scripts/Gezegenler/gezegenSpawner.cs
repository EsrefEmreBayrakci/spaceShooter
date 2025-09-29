using UnityEngine;

public class gezegenSpawner : MonoBehaviour
{
    [Header("Gezegen Prefabları")]
    public GameObject[] gezegenPrefabs;

    [Header("Spawn Ayarları")]
    public float spawnAralikMin = 2f;
    public float spawnAralikMax = 5f;

    public float minSpawnLimit = 0.5f; // minimum sınır
    public float spawnAzalmaOrani = 0.05f; // her seferde ne kadar azalacak

    public float spawnMinX = -4f;
    public float spawnMaxX = 4f;
    public float spawnY = 9f;

    void Start()
    {
        Invoke(nameof(SpawnGezegen), Random.Range(spawnAralikMin, spawnAralikMax));
    }

    void SpawnGezegen()
    {
        int index = Random.Range(0, gezegenPrefabs.Length);
        GameObject prefab = gezegenPrefabs[index];

        float x = Random.Range(spawnMinX, spawnMaxX);
        Vector2 spawnPozisyon = new Vector2(x, spawnY);

        Instantiate(prefab, spawnPozisyon, Quaternion.identity);

        // Spawn aralıklarını küçült 
        spawnAralikMin = Mathf.Max(minSpawnLimit, spawnAralikMin - spawnAzalmaOrani);
        spawnAralikMax = Mathf.Max(minSpawnLimit + 0.5f, spawnAralikMax - spawnAzalmaOrani);

        // Yeni aralıkla tekrar çağır
        Invoke(nameof(SpawnGezegen), Random.Range(spawnAralikMin, spawnAralikMax));
    }
}

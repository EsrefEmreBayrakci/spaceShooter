using UnityEngine;

public class sesKontrol : MonoBehaviour
{
    public static sesKontrol instance;

    [SerializeField] AudioSource mouse;
    [SerializeField] AudioSource meteor;
    [SerializeField] AudioSource enemy;
    [SerializeField] AudioSource player;

    [SerializeField] AudioSource Bullet;


    private void Awake()
    {
        instance = this;
    }

    public void MouseClick()
    {
        mouse.Play();
    }

    public void Meteorpatlama()
    {
        meteor.Play();
    }

    public void EnemyPatlama()
    {
        enemy.Play();
    }

    public void PlayerPatlama()
    {
        player.Play();
    }

    public void BulletSound()
    {
        Bullet.Play();
    }
}

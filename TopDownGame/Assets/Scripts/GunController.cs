using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public bool canFire;

    public bool canThrow;
    public bool isThrowing;

    public BulletController bullet;
    public Grenade grenade;

    public float nadesLeft;

    public float bulletSpeed;
    public float throwSpeed;

    public AudioClip ShootSound;
    public AudioClip ThrowSound;
    public AudioClip ExplosionSound;
    public AudioClip NadeReadySound;
    private AudioSource m_AudioSource;

    public InGameMenu menu;

    public GameObject NadeReady;
    public GameObject NadeUnready;

    public float fireDelay;
    private float shotCounter;

    public float throwDelay;
    private float throwCounter;

    public Transform firePoint;
    public Transform throwPoint;

    public PlayerController playercontroler;

    public PointScript pointScript;

    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
        NadeReady.SetActive(true);
        NadeUnready.SetActive(false);
        menu = FindObjectOfType<InGameMenu>();
        pointScript = FindObjectOfType<PointScript>();
        playercontroler = FindObjectOfType<PlayerController>();
    }

    void Update () {
        if (menu.paused)
        {
            canFire = false;
            canThrow = false;
        }
        else if (!menu.paused) {
            if (!playercontroler.sprinting)
            {
                canFire = true;
                canThrow = true;
            }
        }

        if (canFire)
        {
            if (isFiring)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
            {
                shotCounter = fireDelay;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.bulletSpeed = bulletSpeed;
                m_AudioSource.PlayOneShot(ShootSound);
            }
        } else {
                    shotCounter = 0;
                }

        }

        if (canThrow && nadesLeft > 0)
        {
            throwCounter -= Time.deltaTime;
            if (isThrowing)
            {
                if (throwCounter <= 0)
                {
                    throwCounter = throwDelay;
                    Grenade newGrenade = Instantiate(grenade, throwPoint.position, throwPoint.rotation) as Grenade;
                    newGrenade.GetComponent<Rigidbody>().AddForce(throwPoint.forward * throwSpeed, ForceMode.Impulse);
                    m_AudioSource.PlayOneShot(ThrowSound);
                    NadeReady.SetActive(false);
                    NadeUnready.SetActive(true);
                    nadesLeft = nadesLeft - 1;
                    pointScript.NadeLeftDisplay.text = nadesLeft.ToString();
                    StartCoroutine(ImageResetter());
                }
            }
        }
    }

    IEnumerator ImageResetter()
    {
        yield return new WaitForSeconds(throwCounter - 0.01f);
        NadeReady.SetActive(true);

        if(nadesLeft >= 1)
        {
            m_AudioSource.PlayOneShot(NadeReadySound);
        }

        NadeUnready.SetActive(false);
    }

    public void ExplosionSoundPlayer()
    {
        m_AudioSource.PlayOneShot(ExplosionSound);
    }
}

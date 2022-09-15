using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    Camera cam;
    [Range(0, 50)]
    public int range;
    public ParticleSystem burst;
    public float damage = 50;
    public AudioSource audioSource;

    [Range(10, 20), SerializeField]
    int maxBullets;
    public int currentBullets = 30;
    public AudioSource reloadAudioSource;
    public TMP_Text bullteText;
    int bulltes;
    bool reloading = false;
    public AudioSource emptyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        bulltes = maxBullets;
        UpdateBulletText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !reloading)
        {
            if (bulltes > 0)
                Shoot();
            else
                emptyAudioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.R) && !reloading && (bulltes != maxBullets))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        bulltes--;
        RaycastHit hit;
        PlayFX();
        UpdateBulletText();

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            NPCHealthManager nPCHealthManager = hit.transform.GetComponent<NPCHealthManager>();

            if (nPCHealthManager != null)
            {
                nPCHealthManager.TakeDamage(damage);
            }
        }

        if(bulltes <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    void PlayFX()
    {
        burst.Play();
        audioSource.Play();
    }

    public void UpdateBulletText()
    {
        bullteText.text = bulltes.ToString() + "/" + currentBullets.ToString(); 
    }

    IEnumerator Reload()
    {
        reloading = true;
        reloadAudioSource.Play();
        currentBullets += bulltes - maxBullets;


        yield return new WaitForSeconds(reloadAudioSource.clip.length);
        reloading = false;
        bulltes = maxBullets;

        if (currentBullets < 0)
        {
            currentBullets = 0; 
            bulltes = 0;
        }

        UpdateBulletText();
    }
}

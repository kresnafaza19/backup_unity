using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;                  
    public float timeBetweenBullets = 0.15f;        
    public float range = 100f;  
    public int nBullet = 1;                           

    public GameObject gunLineObj;
    float timer;                                    
    Ray shootRay = new Ray();                                   
    RaycastHit shootHit;                            
    int shootableMask;                             
    ParticleSystem gunParticles;                    
    LineRenderer gunLine;    
    List<LineRenderer> gunLines = new List<LineRenderer>();                       
    AudioSource gunAudio;                           
    Light gunLight;                                 
    float effectsDisplayTime = 0.2f;
    GameObject player;
    PlayerPower pp;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLines.Add(gunLine);

        gunAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gunLight = GetComponent<Light>();
        pp = player.GetComponent<PlayerPower>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }

        this.damagePerShot = pp.GetPower();
    }

    public void DisableEffects()
    {
          for (int i=0; i<nBullet; i++)
        {
            gunLines[i].enabled = false;
        }
        gunLight.enabled = false;
    }

    public void AddBullet(){
    // add gun line 
        GameObject bull1 = Instantiate(gunLineObj);
        GameObject bull2 = Instantiate(gunLineObj);

        LineRenderer lineRenderer = bull1.GetComponent<LineRenderer>();
        LineRenderer lineRenderer2 = bull2.GetComponent<LineRenderer>();

        gunLines.Add(lineRenderer);
        gunLines.Add(lineRenderer2);
    }

     public void FireSpeedUp()
    {
        timeBetweenBullets -= 0.025f;
    }

    public void Shoot()
    {
          for (int i=0; i < nBullet; i++){
            timer = 0f;

            gunAudio.Play();

            gunLight.enabled = true;

            gunParticles.Stop();
            gunParticles.Play();

            gunLines[i].enabled = true;
            gunLines[i].SetPosition(0, transform.position);

            shootRay.origin = transform.position;

            if (i == 0){
                shootRay.direction = transform.forward;
            } else if (i % 2 == 1) {
                shootRay.direction = Quaternion.Euler(0, 30 * (int)Math.Ceiling((decimal)i/2), 0) * transform.forward;
            } else {
                shootRay.direction = Quaternion.Euler(0, -30 * (int)Math.Ceiling((decimal)i/2), 0) * transform.forward;
            }

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }

                gunLines[i].SetPosition(1, shootHit.point);
            }
            else
            {
                gunLines[i].SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
          }
    }
}
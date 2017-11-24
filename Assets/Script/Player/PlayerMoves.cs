using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour, ITakeDamage
{

    // Moves //

    public float spdShip;
    public float maxSpd;
    public float straffMaxSpeed;
    public float straffTime = 0f;

    private Rigidbody rbShip;
    private float smoothXVelocity;
    private float smoothYVelocity;

    private float currentVelocity;
    public Animator animPlayer, animUI;

    // Shot //

    public GameObject projectileToShoot;
    public float projectileSpd;
    public Transform rightCanonSpawn;
    //public Transform leftCanonSpawn;
    public GameObject shot;
    private AudioClip shotSnd;

    private GameObject projectileRight;
    //private GameObject projectileLeft;

    // Health //

    public int Basehealth;
    private int CurHealth;          
    private int HeartIndex;         

    // Feedback //

    public ParticleSystem psSpeed;
    public ParticleSystemRenderer psrSpeed;
    public ParticleSystem.EmissionModule emissionSpeed;
    public GameObject explosionEffect;
    public Transform graphicSpawn;
    private float cooldownParticle;

    public Color jaugeColorStart, jaugeColorMid, jaugeColorEnd;
    // Fuel Gauge //

    public Image fuelGauge;
    public float currentFuel;
    public float maxFuel;
    public float fuelTime;
    public float fuelLost;
    private float currentFuelTime;

 

    void Awake()
    {
        rbShip = GetComponent<Rigidbody>();
        psSpeed = GetComponent<ParticleSystem>();
        emissionSpeed = psSpeed.emission;
        psrSpeed = GetComponent<ParticleSystemRenderer>();
        currentFuelTime = fuelTime;
    }

    private void Start()
    {
        LevelManager.Instance.AddGlobalScore(0f);
        CurHealth = Basehealth;
        currentFuel = maxFuel;
        //Debug.Log(Input.GetJoystickNames()[0]);
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = rbShip.velocity;

        if (rbShip.velocity.z > maxSpd)
        {
            newVelocity.z = maxSpd;
        }
        else
        {
            newVelocity.z += spdShip * Time.deltaTime;
        }

        float targetVelocityX = Input.GetAxis("Horizontal") * straffMaxSpeed;
        newVelocity.x = Mathf.SmoothDamp(newVelocity.x, targetVelocityX, ref smoothXVelocity, Time.deltaTime);
        rbShip.velocity = newVelocity;

        float targetVelocityY = Input.GetAxis("Vertical") * straffMaxSpeed;
        newVelocity.y = Mathf.SmoothDamp(newVelocity.y, targetVelocityY, ref smoothXVelocity, Time.deltaTime);
        rbShip.velocity = newVelocity;


        cooldownParticle -= Time.deltaTime;
        if (cooldownParticle <= 0)
        {
            SetSpeedParticleValue();
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            animPlayer.SetBool("Right", true);
        }
        else
        {
            animPlayer.SetBool("Right", false);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            animPlayer.SetBool("Left", true);
        }
        else
        {
            animPlayer.SetBool("Left", false);
        }

        currentVelocity = newVelocity.z;

    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
        if(currentFuelTime > 0)
        {
            currentFuelTime -= Time.deltaTime;
            
        }
        else if(currentFuelTime <= 0)
        {
            currentFuel -= fuelLost;
            currentFuelTime = fuelTime;
            fuelGauge.fillAmount = Mathf.Max(0,currentFuel/maxFuel);
            if(currentFuel <=0)
            {
                Kill();
            }
        }

        if(fuelGauge.fillAmount >= 0.8f)
        {
            fuelGauge.color = jaugeColorStart;
            animUI.SetBool("CriticalState", false);
        }
        else if(fuelGauge.fillAmount >= 0.4)
        {
            fuelGauge.color = jaugeColorMid;
            animUI.SetBool("CriticalState", false);
        }
        else
        {
            fuelGauge.color = jaugeColorEnd;
            animUI.SetBool("CriticalState", true);
        }
    
    }

    void Shoot()
    {
        AudioSource shotSnd = shot.GetComponent<AudioSource>();
        shotSnd.Play();

        projectileRight = Instantiate(projectileToShoot, rightCanonSpawn.position, rightCanonSpawn.rotation);
        //projectileLeft = Instantiate(projectileToShoot, leftCanonSpawn.position, leftCanonSpawn.rotation);

        projectileRight.GetComponent<Rigidbody>().velocity = transform.forward * rbShip.velocity.z * projectileSpd;
        //projectileLeft.GetComponent<Rigidbody>().velocity = transform.forward * rbShip.velocity.z * projectileSpd;

        Destroy(projectileRight, 2.0f);
        //Destroy(projectileLeft, 2.0f);
    }

    public void Boost(float boostValue)
    {
        maxSpd += boostValue;
        //Debug.Log(spdShip);
    }

    public void TakeDamage(int damage)
    {

        CurHealth -= damage;
        //Debug.Log("HIT");

        
        //Hearts[HeartIndex].SetActive(false);    
       // HeartIndex--;                           

       if (CurHealth <= 0)
        {
            Kill();
        }

    }

    private void Kill()
    {
        CameraManager.Instance.UnParentCamera();
        CameraManager.Instance.PlayDeathSound();
        LevelManager.Instance.UnShowTuto();
        LevelManager.Instance.LevelEnd(true);
        GameObject explosion = Instantiate(explosionEffect, graphicSpawn.position, graphicSpawn.rotation);
        explosion.transform.parent = null;
        Destroy(this.gameObject);
        //Debug.Log("Death");

    }

    void SetSpeedParticleValue()
    {
        cooldownParticle += 1.5f;
        emissionSpeed.rateOverTime = rbShip.velocity.z * 3;
        psrSpeed.lengthScale = rbShip.velocity.z * 5;
    }

    public void Collectable (float itemValue)
    {
        LevelManager.Instance.AddGlobalScore(itemValue);
    }

    public void FuelBoost(float fuelGained)
    {
        currentFuel += fuelGained;

        if(currentFuel > maxFuel)
        {
            currentFuel = maxFuel;
        }

        fuelGauge.fillAmount = Mathf.Max(0, currentFuel / maxFuel);

    }

    public float ReturnVelocity()
    {
       return currentVelocity*3;
    }
}



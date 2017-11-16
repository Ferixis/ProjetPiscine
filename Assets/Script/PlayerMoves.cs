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

    public Animator animPlayer;

    // Shot //

    public GameObject projectileToShoot;
    public float projectileSpd;
    public Transform rightCanonSpawn;
    public Transform leftCanonSpawn;
    public GameObject shot;
    private AudioClip shotSnd;

    private GameObject projectileRight;
    private GameObject projectileLeft;

    // Health //

    public int Basehealth;          
    private int CurHealth;          
    private int HeartIndex;         
    public GameObject Heart1;       
    public GameObject Heart2;       
    public GameObject Heart3;       
    private List<GameObject> Hearts;    

    // Ring Boost // 

    public float boostValue;
    public float ringBonus;
    

    // Score //

    private float cooldown;
    private float scoreAdded;

    // Collectable //

    public float itemValue;

    // Feedback //

    public ParticleSystem psSpeed;
    public ParticleSystemRenderer psrSpeed;
    public ParticleSystem.EmissionModule emissionSpeed;
    private float cooldownParticle;

    void Awake()
    {
        rbShip = GetComponent<Rigidbody>();
        psSpeed = GetComponent<ParticleSystem>();
        emissionSpeed = psSpeed.emission;
        psrSpeed = GetComponent<ParticleSystemRenderer>();
    }

    private void Start()
    {
        Hearts = new List<GameObject>();
        CurHealth = Basehealth;
        HeartIndex = CurHealth - 1; 
        Hearts.Add(Heart1);         
        Hearts.Add(Heart2);
        Hearts.Add(Heart3);
        cooldown = 0f;
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

        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            ScoreAdding();

        }

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

    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

    void LateUpdate()
    {
        //Debug.Log(rbShip.velocity.z);
    }

    void Shoot()
    {
        AudioSource shotSnd = shot.GetComponent<AudioSource>();
        shotSnd.Play();

        projectileRight = Instantiate(projectileToShoot, rightCanonSpawn.position, rightCanonSpawn.rotation);
        projectileLeft = Instantiate(projectileToShoot, leftCanonSpawn.position, leftCanonSpawn.rotation);

        projectileRight.GetComponent<Rigidbody>().velocity = transform.forward * rbShip.velocity.z * projectileSpd;
        projectileLeft.GetComponent<Rigidbody>().velocity = transform.forward * rbShip.velocity.z * projectileSpd;

        Destroy(projectileRight, 2.0f);
        Destroy(projectileLeft, 2.0f);
    }

    public void Boost()
    {
        scoreAdded += ringBonus;
        spdShip += boostValue;
        LevelManager.Instance.AddGlobalScore(scoreAdded);
        //Debug.Log(spdShip);
    }

    public void TakeDamage(int damage)
    {

        CurHealth -= damage;
        Debug.Log("HIT");

        Hearts[HeartIndex].SetActive(false);    
        HeartIndex--;                           

        if (CurHealth <= 0)
        {
            Kill();
        }

    }

    private void Kill()
    {
        CameraManager.Instance.UnParentCamera();
        Destroy(this.gameObject);
        Debug.Log("Death");

    }

    void ScoreAdding()
    {
        cooldown += 1f;
        scoreAdded = rbShip.velocity.z * 10;
        LevelManager.Instance.AddGlobalScore(scoreAdded);
    }

    void SetSpeedParticleValue()
    {
        cooldownParticle += 1.5f;
        emissionSpeed.rateOverTime = rbShip.velocity.z * 3;
        psrSpeed.lengthScale = rbShip.velocity.z * 5;
    }

    public void Collectable ()
    {
        scoreAdded += itemValue;
        LevelManager.Instance.AddGlobalScore(scoreAdded);
    }
}



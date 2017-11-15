using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour,ITakeDamage {

    // Move //

	public float spdShip;
    public float maxSpd;
    public float straffMaxSpeed;
    public float straffTime = 0f;

    private Rigidbody rbShip;
    private float smoothXVelocity;
    private float smoothYVelocity;

    // Shot //

    public GameObject projectileToShoot;
    public float projectileSpd;
    public Transform rightCanonSpawn;
    public Transform leftCanonSpawn;
    public GameObject shot;
    private AudioClip shotSnd; 

    private GameObject projectileRight;
    private GameObject projectileLeft;

    private int CurHealth;

    // Speed Boost // 

    public float boostValue;

    void Awake () 
	{
		rbShip = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () 
	{
        Vector3 newVelocity = rbShip.velocity;
        if(rbShip.velocity.z > maxSpd)
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

    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void LateUpdate () 
	{
		//Debug.Log(rbShip.velocity.z);
	}

    void Shoot ()
    {
        AudioSource shotSnd = shot.GetComponent<AudioSource>();
        shotSnd.Play();

        projectileRight = Instantiate(projectileToShoot,rightCanonSpawn.position,rightCanonSpawn.rotation);
        projectileLeft = Instantiate(projectileToShoot, leftCanonSpawn.position, leftCanonSpawn.rotation);

        projectileRight.GetComponent<Rigidbody>().velocity = transform.forward * rbShip.velocity.z * projectileSpd;
        projectileLeft.GetComponent<Rigidbody>().velocity = transform.forward * rbShip.velocity.z * projectileSpd;

        Destroy(projectileRight, 2.0f);
        Destroy(projectileLeft, 2.0f);
    }

    public void Boost ()
    {
        spdShip += boostValue;
        //Debug.Log(spdShip);
    }

    public void TakeDamage(int damage)
    {

        CurHealth -= damage;
        Debug.Log("HIT");

        if(CurHealth <= 0)
        {
            Kill();
        }
       
    }

    private void Kill()
    {

        Destroy(this.gameObject);
        Debug.Log("Death");

    }




}



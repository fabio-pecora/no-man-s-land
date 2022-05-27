using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jammo : MonoBehaviour
{
    public static int level;
    public float currentTimer;
    public float targetTimer = 1;
    public bool alreadyPlayedAttack = false;
    public bool startTimer = false;
    //health
    static public int maxHealth = 100;
    public static int currentHealth;
    public HealthBarScript healthBar;

    //shield
    static public int maxShield = 50;
    static public int currentShield;
    public ShieldBarScript shieldBar;


    //damage
    static public float damage;
    public float damageLife = 0f;
    static public float damageUI = 0f;
    public static bool damageAbsorbed = false;


    public static int numOfKeys = 0;
    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
        level = 0;
        currentTimer = 0;
        currentHealth = maxHealth;
        healthBar.SetMAxHealth(maxHealth);

        numOfKeys = 0;

        currentShield = 0;
        shieldBar.SetMaxShield(maxShield);
    }

    // Update is called once per frame
    void Update()
    {
        
        healthBar.SetHealth(currentHealth);
        shieldBar.SetShield(currentShield);

        if (currentHealth < 0 && currentShield <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("LoseScene");
        }

        // start timer will be true after the enemy played the attack so that in some seconds 
        // the player is vurnerable again
        if(startTimer == true)
        {
            currentTimer += Time.deltaTime;
            if(currentTimer >= targetTimer)
            {
                startTimer = false;
                // we set the timer back to 0
                currentTimer = 0;
                // after one second I want the player to be able to get hit again
                // to allow other enemies to hit him
                alreadyPlayedAttack = false;
                
            }


        }

        //when currentTime is greater than the damagelife reset damage and damageAbsored back to false
        if (Time.time >= damageLife)
        {
            damage = 10;
            damageAbsorbed = false;
        }else
        {
            damageUI = damageLife - Time.time;
            //Debug.Log("Jammo " + damageUI);
        }



    }

    //increases the heal by the "value" passed in
    public void absorbHealthPowerUp(int value)
    {   
        if ((currentHealth + value) >= maxHealth)
        {
            currentHealth = maxHealth;
        }else{
            currentHealth += value;
        }
        shieldBar.SetShield(currentHealth);
    }

    //sets the shield to the "value" passed
    public void absorbShieldPowerUp(int value)
    {
        currentShield = value;
        shieldBar.SetShield(currentShield);
    }

    //damge is doubled and its effective for a certain amount of "time"
    public void absorbDamagePowerUp(float time)
    {
        damageAbsorbed = true;
        damage *= 2;
        damageLife = Time.time + time;
    }

    // the timers are used because the enemy after the collision playes the animaton. This make the enemy able to hit the player multiple times 
    // even if the collision that we want to detect is the first one. Using timers and booleans I managed to fix this.
    private void OnCollisionEnter(Collision other)
    {
        // beacuse we want to hit the player only once per enemy (because the attack is an explosion) so the enemy can only attack once
        if (alreadyPlayedAttack == false)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (Jammo.currentHealth > 0)
                {
                    // we attack and we save that we have already attacked so that in case of another collision
                    // with this enemy we will not loose other health
                    Jammo.currentHealth -= Enemy.explosionDamage;
                    alreadyPlayedAttack = true;
                    // we want to make the enemy vurnerable again in s1 second, we will do that setting the boolean
                    // alreadyPlayedAttack to false again in some seconds from the last attack.
                    startTimer = true;
                }

                if (currentShield <= 0)
                {
                    currentHealth -= 10;
                    healthBar.SetHealth(currentHealth);
                }
                else if (currentShield > 0)
                {
                    currentShield -= 25;
                    shieldBar.SetShield(currentShield);
                }

            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Teleporter")
        {
            level++;
            SceneManager.LoadScene("FinalFight");
        }

        if(other.gameObject.tag == "Key")
        {
            AudioManager.instance.Play("KeyCollection");
            numOfKeys++;
            Destroy(other.gameObject);
        }
        // we have triggered powerups 
        if (other.gameObject.tag == "PowerUp")//when it collides with a powerup container
        {
            //Debug.Log("collisionWithPowerup");
            //Getting the powerup type the container has
            PowerUp pScript = other.gameObject.GetComponent<PowerUp>();
            AudioManager.instance.Play("PowerUp");
            if (pScript.PowerUpType().tag == "Damage")
            {
                //Debug.Log("damage powerup");
                absorbDamagePowerUp(30f);//double damge

            }
            if (pScript.PowerUpType().tag == "Health")
            {
                //Debug.Log("health powerup");
                absorbHealthPowerUp(25);//increase health by 25

            }
            if (pScript.PowerUpType().tag == "Shield")
            {
                //Debug.Log("shield powerup");
                absorbShieldPowerUp(50);//refills shield
            }
            Destroy(other.gameObject);//destroy the powerup container
            Destroy(pScript.PowerUpType());//destroy the powerup type
        }



    }

    private void playStep()
    {
        AudioManager.instance.Play("Step");
    }
}

using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Cooldown")]

    [SerializeField] private float attackCooldown = 2.0f;
    private float cooldownTimer = 0.0f;



    [Header("Ammo")]

    public int maxAmmo = 100;
    public int currentAmmo = 0;



    [Header("Prefabs")]

    public Transform firePoint;
    public GameObject bullet;



    [Header("GameObjects")]

    [SerializeField]
    private GameObject grenadePrefab = null;

    [SerializeField]
    private GameObject jetPack = null;

    [SerializeField]
    private GameObject grenadePoint = null;



    [Header("Sounds")]

    [SerializeField]
    private AudioClip shotSound;

    [SerializeField]
    private GameObject jetpackSound;

    private AudioSource audioSource;

    //RB
    private Rigidbody2D myRb;

    //FLOATS
    private float grenadeSpeed = 2.0f;
    private float jumpForceSpeed = 5.0f;

    //BOOLEANS
    private bool canUseGrenade;
    private bool canUseJetPack;
    private bool canAttack = true;
    private bool isGrounded;

    private bool hasGrenade;
    [SerializeField] private int maxGrenades = 5;
    [SerializeField] private int currentGrenades;

    private Animator animator;

    private bool canShootNextBullet = false;
    private float nextBullet = 0.1f;
    private float currentNextBullet = 0.0f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        myRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canUseJetPack)
        {
            UseJetPack();
        }

        //myRb.velocity = new Vector2(5, 0);
    }
    void Start()
    {
        jetpackSound.gameObject.SetActive(false);

        currentNextBullet = nextBullet;

        currentGrenades = maxGrenades;

        cooldownTimer = attackCooldown;

        AmmoAmount.ammoAmount = currentAmmo;

        //la currentAmmo es igual a la maxAmmo
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        if (!CutsceneController.isCutsceneOn)
        {
            AmmoAmount.ammoAmount = currentAmmo;

            currentNextBullet += Time.deltaTime;

            if (currentNextBullet >= nextBullet)
            {
                canShootNextBullet = true;
                currentNextBullet = 0.0f;
            }


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                myRb.AddForce(Vector2.up * jumpForceSpeed, ForceMode2D.Impulse);
            }

            if (Input.GetButton("Fire2"))
            {
                canUseJetPack = true;

                animator.SetBool("Jetpack", true);
            }

            if (Input.GetButtonUp("Fire2"))
            {
                

                canUseJetPack = false;

                animator.SetBool("Jetpack", false);
            }

            else
            {
                jetpackSound.gameObject.SetActive(false);
            }

            //restas el time.delta time....
            attackCooldown -= Time.deltaTime;

            //...hasta que sea 0
            if (attackCooldown <= 0)
                canAttack = true;

            //...ahí disparas::::::::::::::fijate que la currentAmmo sea mayor a 0
            if (Input.GetButton("Fire1") && (canAttack) && currentAmmo > 0 && canShootNextBullet)
            {
                audioSource.clip = shotSound;

                audioSource.Play();

                //llamo al metodo de disparar
                Shoot();

                //resto 1 a la munición
                currentAmmo -= 1;

                //AmmoAmount.ammoAmount -= 1;

                //el cooldown timer y attackcooldown se reinician
                cooldownTimer = attackCooldown;
            }
        }


        if (currentAmmo <= 0)
            canAttack = false;

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo <= 0)
        {
            Reload();
        }



        if (Input.GetKeyDown(KeyCode.G) && hasGrenade)
        {
            ShootGrenade();

            currentGrenades -= 1;
        }

        if (currentGrenades <= 0)
            hasGrenade = false;



        void Shoot()
        {
            if (!CutsceneController.isCutsceneOn)
            {
                if (canShootNextBullet)
                {
                    canShootNextBullet = false;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
            
        }
    }

    
    private void Reload()
    {
        currentAmmo = maxAmmo;
    }
    
    private void ShootGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadePoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * grenadeSpeed, ForceMode2D.Impulse);


    }
    
    private void UseJetPack()
    {
        if (!CutsceneController.isCutsceneOn)
        {
            GameObject jetpack = Instantiate(jetPack, transform.position, Quaternion.identity);
            Rigidbody2D rb2 = jetpack.GetComponent<Rigidbody2D>();

            rb2.AddForce(transform.up * 10, ForceMode2D.Force);

            jetpackSound.gameObject.SetActive(true);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade"))
        {
            hasGrenade = true;
        }
    }
}

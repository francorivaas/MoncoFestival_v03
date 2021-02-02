
using UnityEngine;
using UnityEngine.Animations;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private AudioClip step_1;
    [SerializeField] private AudioClip step_2;
    [SerializeField] private AudioClip step_3;

    private AudioSource audioSrc;

    [SerializeField] private float currentTimeToPlaySteps = 0.0f;
    [SerializeField] private float maxTimeToPlaySteps = 0.0f;

    public float speed = 5f;

    [SerializeField] private bool isGrounded;

    [SerializeField] private Transform firePoint;

    /*[SerializeField] private float timeToHeal = 10.0f;
    private float currentTimeToHeal;
    */

    private LifeController lifeController;

    private Animator animator;

    //private SpriteRenderer moncoSprite;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        //_lifeController.OnGetDamage += OnGetDamage;
        lifeController = GetComponent<LifeController>();
        lifeController.OnDeath.AddListener(OnDeathListener);
        lifeController.OnGetDamage += OnGetDamageHandler;
        //moncoSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentTimeToPlaySteps = maxTimeToPlaySteps;
    }

    public bool isAlive()
    {
        return lifeController.GetCurrentLife() > 0;
    }

    void Update()
    {
        /*Vector2 speedMov = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0);
        transform.Translate(speedMov);
        */
        
        //var direction = vector.zero

        if (!CutsceneController.isCutsceneOn)
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("IsWalking", true);
                /*var speedMov = */transform.position += transform.right * (speed * Time.deltaTime);

                currentTimeToPlaySteps += Time.deltaTime;
                
                if (currentTimeToPlaySteps >= maxTimeToPlaySteps && isGrounded)
                {
                    PlayStepSound();
                }
                    
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }


            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("IsWalking", true);
                transform.position += transform.right * (speed * Time.deltaTime);

                currentTimeToPlaySteps += Time.deltaTime;

                if (currentTimeToPlaySteps >= maxTimeToPlaySteps && isGrounded)
                {
                    PlayStepSound();
                }


                transform.rotation = Quaternion.Euler(0, 0, 0);
            }


            if (Input.GetKeyUp(KeyCode.A))
                animator.SetBool("IsWalking", false);
            if (Input.GetKeyUp(KeyCode.D))
                animator.SetBool("IsWalking", false);


            if (Input.GetKey(KeyCode.L))
                //lifeController.canTakeDamage = false;


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1;
            }

        }

        /*if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * (speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * (speed * Time.deltaTime);
        }
        */
    }

    private void PlayStepSound()
    {
        currentTimeToPlaySteps = 0.0f;

        int random = Random.Range(0, 3);

        switch (random)
        {
            case 1: audioSrc.clip = step_1;
                    break;

            case 2: audioSrc.clip = step_2;
                    break;

            case 3: audioSrc.clip = step_3;
                    break;
        }

        audioSrc.Play();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnDeathListener()
    {

    }

    void OnGetDamageHandler(float currentLife, float damage)
    {

    }
}


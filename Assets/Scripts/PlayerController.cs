using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;

    private float speedMilestoneCount;
    private float moveSpeedStore;

    public float jumpForce;
    public float gravityStrength;

    public float lenghtOfSlide;
    private float slideTime;
    private float originalHeight;
    public float reducedHeight;

    private Rigidbody myRigidbody;
    private CapsuleCollider myCollider;

    public bool grounded;
    public bool sliding;

    public LayerMask whatIsGround;
    public LayerMask whatIsObstacle;

    private Animator myAnimator;

    public AudioSource jumpSound;
    public AudioSource slideSound;

    private bool paused;

    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider>();

        theScoreManager = FindObjectOfType<ScoreManager>();

        originalHeight = myCollider.height;

        Vector3 gravityS = new Vector3(0, gravityStrength, 0);
        Physics.gravity = gravityS;

        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {        
        if (transform.position.z > speedMilestoneCount && moveSpeed < 6.5f)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone *= speedMultiplier;
            moveSpeed *= speedMultiplier;

            theScoreManager.SetPointsPerSecond(moveSpeed);
        }

         
        myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, moveSpeed);

        if (!sliding)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && !paused)
            {
                myRigidbody.velocity = new Vector3(0, jumpForce, myRigidbody.velocity.z);
                grounded = false;

                // Play jump sound
                jumpSound.Play();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && grounded && !paused)
            {
                sliding = true;
                slideTime = lenghtOfSlide;
                myCollider.height = reducedHeight;

                // Play slide sound
                slideSound.Play();
            }
        }
        else
        {
            slideTime -= Time.deltaTime;
            if (slideTime <= 0)
            {
                sliding = false;
                myCollider.height = originalHeight;
            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.z);
        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetBool("Sliding", sliding);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (1 << collision.gameObject.layer == whatIsGround)
        {
            grounded = true;
        }
    }

    // If the speed increases
    public void RestartPlayer()
    {
        moveSpeed = moveSpeedStore;
        speedMilestoneCount = speedIncreaseMilestone;
    }

    public void PauseState(bool state)
    {
        paused = state;
    }
}

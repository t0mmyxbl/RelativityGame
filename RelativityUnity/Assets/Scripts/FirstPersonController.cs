using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (CharacterController))]
    [RequireComponent(typeof (AudioSource))]
    public class FirstPersonController : MonoBehaviour
    {
        public float m_JumpSpeed;
        public MouseLook m_MouseLook;
        public Camera m_Camera;

		
	[SerializeField] private AudioSource ExternalSFXSource;

		[SerializeField] private bool m_IsWalking;
        [SerializeField] private float m_WalkSpeed;
        [SerializeField] private float m_RunSpeed;
        [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
        [SerializeField] private float m_GravityMultiplier;
        [SerializeField] private bool m_UseFovKick;
        [SerializeField] private FOVKick m_FovKick = new FOVKick();
        [SerializeField] private bool m_UseHeadBob;
        [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
        [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
        [SerializeField] private float m_StepInterval;
        [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
        [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
        [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.
        [SerializeField] private AudioClip OxygenFillSound;
	    [SerializeField] private AudioClip DoorSound;
		[SerializeField] private AudioClip DoorLockedSound;
		[SerializeField] private AudioClip KeyCardSound;

        private bool m_Jump;
        private Vector2 m_Input;
        private Vector3 m_MoveDir = Vector3.zero;
        private CharacterController m_CharacterController;
        private CollisionFlags m_CollisionFlags;
        private bool m_PreviouslyGrounded;
        private bool m_PreviouslyOnRoof;
        private Vector3 m_OriginalCameraPosition;
        private float m_StepCycle;
        private float m_NextStep;
        private bool m_Jumping;
        private AudioSource m_AudioSource;
        private PlayerGravity g;
        private OxygenLevels oxygenScript;
        private GameObject objectInteract;
        private bool isOnRoof;
        private int numKeycards;

        private static bool gameOver;
        private static bool playerDied;    

    // Use this for initialization
    private void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle/2f;
            m_Jumping = false;
            gameOver = false;
            playerDied = false;
            m_AudioSource = GetComponent<AudioSource>();
			m_MouseLook.Init(transform , m_Camera.transform);
            g = GetComponent<PlayerGravity>();
            oxygenScript = GetComponent<OxygenLevels>();
            numKeycards = 0;
    }


        // Update is called once per frame
        private void Update()
        {
        print(transform.rotation);
        if (gameOver)
        {
            SceneManager.LoadScene("EndScreen");
        }

        //set the character to be on the roof
        if ((m_CharacterController.collisionFlags == CollisionFlags.Above))
            isOnRoof = true;
        else
            isOnRoof = false;
        //rotate view used for mouse input
        RotateView ();

			// the jump state needs to read here to make sure it is not missed
            //if the player isnt jumping and the player presses the jump button, set jump to true
			if (!m_Jump) {
				m_Jump = CrossPlatformInputManager.GetButtonDown ("Jump");
			}

            //if the player was not grounded or on roof last frame but is in the current frame../
            if ((!m_PreviouslyGrounded && m_CharacterController.isGrounded) || (!m_PreviouslyOnRoof && isOnRoof)) {
                //start the jump bob cycle, play the landing sound, set the vertical movement to 0 and set it so the player isnt jumping
				StartCoroutine (m_JumpBob.DoBobCycle ());
				PlayLandingSound ();
				m_MoveDir.y = 0f;
				m_Jumping = false;
			}
            //if the character is not on the ground and is not jumping but was previously grounded, set the vertical movement to 0
			if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded) {
				m_MoveDir.y = 0f;
			}
            //same as above but for on roof
            if (!isOnRoof && !m_Jumping && m_PreviouslyOnRoof)
            {
                m_MoveDir.y = 0f;
            }

            m_PreviouslyGrounded = m_CharacterController.isGrounded;
            m_PreviouslyOnRoof = isOnRoof;

            if (Input.GetKeyDown(KeyCode.F))
                GrabObject();

        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.up, out hit,
                           m_CharacterController.height, layerMask, QueryTriggerInteraction.Ignore);
        if (hit.transform != null)
        {
            if ((m_CharacterController.isGrounded || isOnRoof) && hit.collider.gameObject.tag == "Killable")
            {
                gameOver = true;
                playerDied = true;
            }
        }

        if (m_CharacterController.transform.position.y < -5)
        {
            playerDied = true;
            gameOver = true;
        }

    }


        private void PlayLandingSound()
        {
            m_AudioSource.clip = m_LandSound;
            m_AudioSource.Play();
            m_NextStep = m_StepCycle + .5f;
        }


    private void FixedUpdate()
    {

        float speed;
        GetInput(out speed);
        // always move along the camera forward as it is the direction that it being aimed at
        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;

        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;

        if ((m_CharacterController.isGrounded || isOnRoof) && !m_Jumping)
        {
                m_MoveDir.y = g.gravity;


            if (m_Jump)
            {
                m_MoveDir.y = m_JumpSpeed;
                PlayJumpSound();
                m_Jump = false;
                m_Jumping = true;
            }

        }
        else
        {
            m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        }

        m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

        ProgressStepCycle(speed);
        UpdateCameraPosition(speed);

        m_MouseLook.UpdateCursorLock();

    }

    void GrabObject()
    {
        CheckRayCollision();
    }

    void CheckRayCollision()
    {
        Ray ray = m_Camera.ScreenPointToRay(new Vector3(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2, 0));

        int layerMask = 1 << 8;
        layerMask = ~layerMask;


        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            objectInteract = hit.transform.gameObject;

            if (objectInteract.tag == "Oxygen")
            {
                oxygenScript.FillOxygen();
				ExternalSFXSource.clip = OxygenFillSound;
				ExternalSFXSource.Play();
            }
            if (objectInteract.tag == "Door")
            {
				if (numKeycards <= 0 && objectInteract.GetComponent<ObjectProperties> ().IsLocked ()) {
					ExternalSFXSource.clip = DoorLockedSound;
					ExternalSFXSource.Play ();
				} else {
					if (numKeycards > 0 && objectInteract.GetComponent<ObjectProperties> ().IsLocked ()) {
						objectInteract.GetComponent<ObjectProperties> ().SetLocked (false);
						numKeycards -= 1; //door locked sound

					}
					if (!(objectInteract.GetComponent<ObjectProperties> ().IsLocked ())) {
						Animator animController = objectInteract.GetComponent<Animator> ();
						m_AudioSource.clip = DoorSound;
						m_AudioSource.Play ();
						animController.Play ("OpenDoor");
						StartCoroutine (Wait (animController));
						ExternalSFXSource.clip = DoorSound;
						ExternalSFXSource.Play ();
					}
				}
            }
            if (objectInteract.tag == "Final")
            {
                gameOver = true;
                playerDied = false;
            }
            if(objectInteract.tag == "keycard")
            {
                numKeycards += 1;
                Destroy(objectInteract);
				ExternalSFXSource.clip = KeyCardSound;
				ExternalSFXSource.Play ();
            }
        }


    }

    IEnumerator Wait(Animator animController)
    {

        yield return new WaitForSeconds(5);
        animController.Play("CloseDoor");

    }

    private void PlayJumpSound()
        {
            m_AudioSource.clip = m_JumpSound;
            m_AudioSource.Play();
        }

    private void GetInput(out float speed)
    {
        // Read input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //bool waswalking =isWalking;

#if !MOBILE_INPUT
        // On standalone builds, walk/run speed is modified by a key press.
        // keep track of whether or not the character is walking or running
        m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif
        // set the desired speed to be walking or running
        speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
        m_Input = new Vector2(horizontal, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        bool m_WasWalking = m_IsWalking;

        // handle speed change to give an fov kick
        // only if the player is going to a run, is running and the fovkick is to be used
        if (m_IsWalking != m_WasWalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
        {
            StopAllCoroutines();
            StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
        }
    }


    private void ProgressStepCycle(float speed)
        {

            if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
            {
                m_StepCycle += (m_CharacterController.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {

                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;

            PlayFootStepAudio();
        }


        private void PlayFootStepAudio()
        {
            if (!m_CharacterController.isGrounded && !isOnRoof)
            {
                return;
            }
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }


        private void UpdateCameraPosition(float speed) //////////////////////////////////////////////////////////////////////////////////
        {
            Vector3 newCameraPosition;
            if (!m_UseHeadBob)
            {        
                return;
            }
            if (m_CharacterController.velocity.magnitude > 0 && (m_CharacterController.isGrounded || isOnRoof))
            {
                m_Camera.transform.localPosition =
                    m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                      (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
            }
            else
            {
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
            }
            m_Camera.transform.localPosition = newCameraPosition;

        }

	private void RotateView(){
				m_MouseLook.LookRotation (transform, m_Camera.transform);
        }


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
        Rigidbody body = hit.collider.attachedRigidbody;
            //dont move the rigidbody if the character is on top of it
            if ((m_CollisionFlags == CollisionFlags.Below) || (m_CollisionFlags == CollisionFlags.Above))
            {
                return;
            }

            if (body == null || body.isKinematic)
            {
                return;
            }
            if (body.GetComponent<ObjectProperties>().IsPushable())
            {
                body.AddForceAtPosition(m_CharacterController.velocity * 0.8f, hit.point, ForceMode.Impulse);
            }
        }

        public static bool Get_gameOver()
        {
            return gameOver;
        }

        public static bool Get_Death()
        {
            return playerDied;
        }

        public void Set_gameOver(bool end, bool died)
        {
            gameOver = end;
            playerDied = died;
        }
		
    }

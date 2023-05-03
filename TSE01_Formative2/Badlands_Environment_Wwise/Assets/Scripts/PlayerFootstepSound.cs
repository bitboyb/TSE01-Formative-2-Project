using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;


public class PlayerFootstepSound : MonoBehaviour
{
    public AK.Wwise.Event footstepWalkSound;
    public AK.Wwise.Event footstepRunSound;

    public Transform centre;

    GroundCheck groundCheck;

    private float localSoundCooldownTime;
    private float walkingSoundCooldownTime;
    private float runningSoundCooldownTime;

    private string currentSurface;

    private bool Wpressed;
    private bool Apressed;
    private bool Spressed;
    private bool Dpressed;

    void Start()
    {
        Wpressed = false;
        Apressed = false;
        Spressed = false;
        Dpressed = false;

        groundCheck = GetComponentInChildren<GroundCheck>();

        walkingSoundCooldownTime = 0.7f;
        runningSoundCooldownTime = 0.4f;

        currentSurface = "";

    }

    void Update()
    {
        GroundSurfaceCheck();
        FootstepSounds();
    }

    void FootstepSounds()
    {
        if (Input.GetKeyDown(KeyCode.W)) { Wpressed = true; }
        if (Input.GetKeyDown(KeyCode.A)) { Apressed = true; }
        if (Input.GetKeyDown(KeyCode.S)) { Spressed = true; }
        if (Input.GetKeyDown(KeyCode.D)) { Dpressed = true; }

        if (Input.GetKeyUp(KeyCode.W)) { Wpressed = false; }
        if (Input.GetKeyUp(KeyCode.A)) { Apressed = false; }
        if (Input.GetKeyUp(KeyCode.S)) { Spressed = false; }
        if (Input.GetKeyUp(KeyCode.D)) { Dpressed = false; }

        if (!Input.GetKey(KeyCode.LeftShift) && (Wpressed == true || Apressed == true || Spressed == true || Dpressed == true))
        {
            //Debug.Log("Walking");

            if (Time.time - walkingSoundCooldownTime >= localSoundCooldownTime && groundCheck.isGrounded == true)
            {
                localSoundCooldownTime = Time.time;

                footstepWalkSound.Post(gameObject);
            }
        }

        //Looks for shift key while walking
        if ((Wpressed == true || Apressed == true || Spressed == true || Dpressed == true) && (Input.GetKey(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.LeftShift)))
        {
            //Debug.Log("Running");

            if (Time.time - runningSoundCooldownTime >= localSoundCooldownTime && groundCheck.isGrounded == true)
            {
                localSoundCooldownTime = Time.time;

                footstepRunSound.Post(gameObject);
            }
        }
    }

    void GroundSurfaceCheck()
    {
        //Debug.DrawLine(centre.position, centre.position + Vector3.down * 3, Color.blue);

        RaycastHit hit;
        if(Physics.Raycast (centre.position, Vector3.down, out hit, 3, 1<<9))
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Surface: Concrete" && currentSurface != "Surface: Concrete")
                {
                    //Debug.Log("Concrete");
                    AkSoundEngine.SetSwitch("Footstep_Surfaces", "Concrete", gameObject);
                    currentSurface = "Surface: Concrete";
                }

                if (hit.collider.gameObject.tag == "Surface: Sand" && currentSurface != "Surface: Sand")
                {
                    //Debug.Log("Sand");
                    AkSoundEngine.SetSwitch("Footstep_Surfaces", "Sand", gameObject);
                    currentSurface = "Surface: Sand";
                }

                if (hit.collider.gameObject.tag == "Surface: Metal" && currentSurface != "Surface: Metal")
                {
                    //Debug.Log("Metal");
                    AkSoundEngine.SetSwitch("Footstep_Surfaces", "Metal", gameObject);
                    currentSurface = "Surface: Metal";
                }

                if (hit.collider.gameObject.tag == "Surface: Rock" && currentSurface != "Surface: Rock")
                {
                    //Debug.Log("Rock");
                    AkSoundEngine.SetSwitch("Footstep_Surfaces", "Rock", gameObject);
                    currentSurface = "Surface: Rock";
                }

                if (hit.collider.gameObject.tag == "Surface: Wood" && currentSurface != "Surface: Wood")
                {
                    //Debug.Log("Wood");
                    AkSoundEngine.SetSwitch("Footstep_Surfaces", "Wood", gameObject);
                    currentSurface = "Surface: Wood";
                }

                if (hit.collider.gameObject.tag == "Untagged" && currentSurface != "Surface: Concrete")
                {
                    //Debug.Log("Default");
                    AkSoundEngine.SetSwitch("Footstep_Surfaces", "Concrete", gameObject);
                    currentSurface = "Surface: Concrete";
                }

            }
    }
}

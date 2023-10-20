using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float rotationSpeed = 5.0f;
    private bool playing;
    private Weapon weapon;
    public Animator animator;
    public LifeSystem lifeSystem;
    public GameObject cameraContainer;

    private void Start()
    {
        weapon = transform.GetComponentInChildren<Weapon>();

        Cursor.lockState = CursorLockMode.Locked;
        playing = true;
        
    }

    void Update()
    {
        if(playing){
            RotateWithMouse();

            Vector3 verticalInput = Input.GetAxis("Vertical") * transform.forward;
            Vector3 horizontalInput = Input.GetAxis("Horizontal") * transform.right;

            Vector3 move = (verticalInput + horizontalInput).normalized;
            controller.Move((move * Time.deltaTime * playerSpeed) + Physics.gravity);  
        }
        if(lifeSystem.life <= 0 && playing){
            playing = false;
            animator.SetTrigger("Death");
            Camera.main.enabled = false;
            cameraContainer.SetActive(true);
        }
    }

    void RotateWithMouse(){
        float hRotation = rotationSpeed * Input.GetAxis("Rotate X");

        transform.Rotate(0, hRotation, 0);
    }

    public void ChangeCanShoot(string canShoot){
        switch(canShoot){
            case "Yes":
                weapon.canShoot = true;
                break;
            case "No":
                weapon.canShoot = false;
                break;
        }
    }
}
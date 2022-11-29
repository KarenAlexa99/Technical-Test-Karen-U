using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Action OnGameOver;
    public Action OnWin;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask floorMask;

    [SerializeField] private float maxFuel = 4f;
    [SerializeField] private float jetpackForce = 0.5f;
    [SerializeField] private float rechargeRate;
    [SerializeField] private float dischargeRate;

    public float curFuel { get; set; }
    private Vector3 playerMovementInput;
    private Rigidbody playerBody;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    public void MovePlayer()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * playerSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.CheckSphere(groundChecker.position, 0.1f, floorMask))
                playerBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    public void JetpackMovement()
    {
        if (Input.GetMouseButtonDown(0) && curFuel > 0)
        {
            curFuel -= dischargeRate;
            playerBody.AddForce(Vector3.up * jetpackForce, ForceMode.Impulse);
        }
        else if (Physics.CheckSphere(groundChecker.position, 0.1f, floorMask) && curFuel < maxFuel)
        {
            curFuel += rechargeRate * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            OnGameOver();
        }

        if (other.CompareTag("Finish"))
        {
            OnWin();
        }

    }

}

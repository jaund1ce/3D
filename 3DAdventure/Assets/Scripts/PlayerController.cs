using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 100f;

    private bool isGrounded;

    private Rigidbody rb;
    private Transform playerCamera;
    private float xRotation = 0f;

    private HealthManager healthManager;
    private StaminaManager staminaManager;

    public float raycastDistance = 5f;
    public Text objectInfoText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;

        // HealthManager와 StaminaManager를 연결
        healthManager = GetComponent<HealthManager>();
        staminaManager = GetComponent<StaminaManager>();

        Cursor.lockState = CursorLockMode.Locked;

        objectInfoText.text = "";
    }

    void Update()
    {
        // WASD 움직임 및 달리기
        float speed = Input.GetKey(KeyCode.LeftShift) && staminaManager.HasStamina(0.1f) ? sprintSpeed : moveSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical).normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(move));

        if (speed == sprintSpeed)
        {
            staminaManager.UseStamina(staminaManager.staminaDecreaseRate * Time.deltaTime);
        }
        else
        {
            staminaManager.RecoverStamina();
        }

        // 마우스 회전
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        RaycastHit hit;

        // 카메라에서 Raycast를 쏴서 조사 가능한 오브젝트를 감지
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, raycastDistance))
        {
            InspectableObject inspectable = hit.collider.GetComponent<InspectableObject>();

            if (inspectable != null)
            {
                // 감지된 오브젝트의 정보를 텍스트로 표시
                objectInfoText.text = $"{inspectable.objectName}\n{inspectable.description}";
            }
            else
            {
                objectInfoText.text = "";  // 감지되지 않으면 텍스트 숨기기
            }
        }
        else
        {
            objectInfoText.text = "";  // Raycast가 아무것도 감지하지 못하면 텍스트 숨기기
        }
    }

    public void TakeDamage(float amount)
    {
        healthManager.TakeDamage(amount);
    }
    void OnCollisionEnter(Collision collision)
    {
        // 바닥에 닿으면 점프 가능
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

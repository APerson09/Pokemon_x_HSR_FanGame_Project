using UnityEngine;
using UnityEngine.InputSystem;

public class playerControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float gravity = -9.8f;
    private Vector2 moveInput;
    private Vector3 velocity;

    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }
    // Update is called once per frame
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Vector3 move = new Vector3(moveInput.x,0,moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
    }
}

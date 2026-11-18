using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour
{
   [SerializeField]
   private float moveSpeed;
   [SerializeField]
   private float jumpForce;
  private float moveInput;
   private bool jumpInput;
  private bool isGrounded;
  [SerializeField]
  private SpriteRenderer spriteRenderer;
  private Rigidbody2D rig;
   

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        moveInput = value;
       // Debug.Log(value);

    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValueAsButton();
       // Debug.Log(context.phase);
    }

    void FixedUpdate()
    {
        rig.linearVelocityX = moveInput * moveSpeed;
        CheckIfGrounded();
        
        if (jumpInput && isGrounded)
        {
            jumpInput = false;
            rig.linearVelocityY = jumpForce;
            
        }
        //αλλαγή κατεύθυνσης sprite ανάλογα με την κίνηση
        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }
    }
    void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}

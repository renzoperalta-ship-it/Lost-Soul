using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerInputs.OnMove += HandleMove;
        PlayerInputs.OnJump += HandleJump;
    }

    private void OnDisable()
    {
        PlayerInputs.OnMove -= HandleMove;
        PlayerInputs.OnJump -= HandleJump;
    }

    private void HandleMove(Vector2 input)
    {
        moveInput = input;
    }

    private void HandleJump()
    {
        if (enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    #region Detección de Suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
            Debug.Log("Estoy tocando el suelo");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = false;
            Debug.Log(" Aire");
        }
    }
    #endregion
}
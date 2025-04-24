using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //COMPONENTES
    private Rigidbody2D m_rigidbody2D;
    private GatherInput m_gatherInput;
    private Transform m_transform;
    private Animator m_animator;

    //VALORES
    [SerializeField] private float speed;
    private int direction = 1;
    private int idSpeed;
    [SerializeField] private float jumpForce;

    void Start()
    {
        m_gatherInput = GetComponent<GatherInput>();
        m_transform = GetComponent<Transform>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        idSpeed = Animator.StringToHash("Speed");
    }
    private void Update()
    {
        SetAnimatorValue();

    }

    private void SetAnimatorValue()
    {
        m_animator.SetFloat(idSpeed, Mathf.Abs(m_rigidbody2D.linearVelocityX));   // RUN animacion
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }



    private void Move()
    {
        Flip();
        m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherInput.ValueX, m_rigidbody2D.linearVelocityY);  // RUN movimiento
        
    }

    private void Flip()
    {
        if(m_gatherInput.ValueX * direction < 0)
        {
            m_transform.localScale = new Vector3(-m_transform.localScale.x, 1, 1);  // FLIP cambio de direccion
            direction *= -1;
        }
    }
    private void Jump()
    {
        if (m_gatherInput.IsJumping)
        {
            m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherInput.ValueX, jumpForce);
        }
        m_gatherInput.IsJumping = false;
    }
}

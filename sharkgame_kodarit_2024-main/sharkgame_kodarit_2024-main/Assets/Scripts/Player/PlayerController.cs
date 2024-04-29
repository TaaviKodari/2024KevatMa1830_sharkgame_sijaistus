using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private MainInput controls;
    public Transform gunTransform;

    void Awake()
    {
        controls = new MainInput();
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameManager.Instance.player = this;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Aim();
        Shoot();
    }
    
    private void Move()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = moveInput * 5 * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }

    private void Shoot()
    {
        if (controls.Player.Shoot.triggered)
        {
            GameObject ammo = AmmoPoolManager.Instance.GetAmmo();
            ammo.transform.position = gunTransform.position;
            ammo.transform.rotation = gunTransform.rotation;
        }
    }

    private void Aim()
    {
        Vector2 aimInput = controls.Player.Aim.ReadValue<Vector2>();
        Vector2 aimDirection = aimInput;

        if (UsingMouse())
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0;
            aimDirection = mousePosition - gunTransform.position;
        }

        if (aimDirection.sqrMagnitude > 0.1)
        {
            float angle = Mathf.Atan2(aimDirection.x, -aimDirection.y) * Mathf.Rad2Deg;
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private bool UsingMouse()
    {
        if (Mouse.current.delta.ReadValue().sqrMagnitude > 0.1)
        {
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipPlayer : CharacterBase
{


    [Header("Components")]
    [SerializeField] private HealthBase healthShip;
    [SerializeField] private AttackShipPlayer attackShip;
    [SerializeField] private Rigidbody2D rb2D;


    [Header("Input")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerShipActions inputActions;


    [Header("Setting Moviment")]
    [SerializeField] private float speedShip = 5;
    [SerializeField] private float speedRotation = 100f;
    [SerializeField] private Vector2 moviment = Vector2.zero;

  

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        attackShip = GetComponent<AttackShipPlayer>();
        healthShip = GetComponent<HealthBase>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.enabled = true;
        inputActions = new PlayerShipActions();
        inputActions.Enable();
    }
    private void OnDisable()
    {
        playerInput.enabled = false;
        inputActions.Disable();
    }
    private void Start()
    {
        StaticSetPlayer.SittingCharactersActive(this);
    }
    private void Update()
    {
        if (!canMoveShip) return;
        InputMoviment(inputActions.Player.move.ReadValue<Vector2>());
        InpuntsActions();
    }
    private void FixedUpdate()
    {
        if (!canMoveShip) return;

        ApplyMoviment();
    }
    void InpuntsActions()
    {
        if (inputActions.Player.Shooter.WasPressedThisFrame())
        {
            ShooterCannon();
        }
        if (inputActions.Player.ChangeCannon.WasPressedThisFrame())
        {
            ChangeSlectedCannons();
        }
    }
    public void InputMoviment(Vector2 InputDirectionMovi)
    {
        moviment = InputDirectionMovi;
    }
    void ApplyMoviment()
    {
        if (moviment.magnitude > 0)
        {

            transform.Rotate(-Vector3.forward, moviment.x * speedRotation * Time.deltaTime);
            Vector3 velocity = Vector3.down * moviment.y * speedShip * Time.deltaTime;
            transform.Translate(velocity);
        }
        else
        {
            moviment = Vector2.zero;
        }
    }

    void ShooterCannon()
    {
        attackShip.ShooterAtack();
    }
    void ChangeSlectedCannons()
    {
        attackShip.ChangerCannon();
    }
    public override void Hit(DamageObject DO)
    {
        healthShip.SubtractDamage(DO._damage);
    }
}

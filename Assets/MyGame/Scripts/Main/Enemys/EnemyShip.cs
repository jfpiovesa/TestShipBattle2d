using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyShipType
{
    Shooter,
    Chaser
}
public class EnemyShip : CharacterBase
{


    [Header("Components")]
    [SerializeField] private HealthBase healthShip;
    [SerializeField] private AttackEnemyShip attackShip;
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Setting Moviment")]
    [SerializeField] private float speedShip = 5;
    [SerializeField] private float rotateShip = 10;
    Vector3 direction = Vector2.zero;


    [Header("Attributes")]
    [SerializeField] private bool shooterActive = false;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] poinsPatrol;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        attackShip = GetComponent<AttackEnemyShip>();
        healthShip = GetComponent<HealthBase>();

    }
    private void Update()
    {
        if (player == null) return;
        if (!canMoveShip) return;
        if (healthShip.isDead) return;

        if (attackShip.EnemyShipType == EnemyShipType.Shooter)
        {
            MovimentFallowPlayerShooter();
            ShooterCannon();
        }
        else
        {

            MovimentFallowPlayerChase();

        }

    }
    public void SetupInfoEnemys(Transform[] PatrolList, Transform isPlayer)
    {
        poinsPatrol = PatrolList;
        player = isPlayer;
    }
    void MovimentFallowPlayerShooter()
    {

        if (!shooterActive)
        {
            direction = CalculateFallowPlayerDirection();

        };
        transform.rotation = RotationFallowPlayer();

        transform.Translate(direction * speedShip * Time.deltaTime, Space.World);
    }
    void MovimentFallowPlayerChase()
    {

        direction = CalculateFallowPlayerDirection();
        transform.rotation = RotationFallowPlayer();
        transform.Translate(direction * speedShip * Time.deltaTime, Space.World);
    }
    void ShooterCannon()
    {
        if (attackShip.frontPlayer || attackShip.LeftPlayer || attackShip.righttPlayer)
        {
            if (shooterActive) return;
            StartCoroutine(DelayAttack());
        }
    }
    IEnumerator DelayAttack()
    {
        shooterActive = true;
        canMoveShip = false;
        yield return new WaitForSeconds(1.3f);
        if (attackShip.frontPlayer || attackShip.LeftPlayer || attackShip.righttPlayer)
        {
            attackShip.ShooterAtack();
        }
        shooterActive = false;
        canMoveShip = true;
    }
    Vector2 CalculateNewDirection()
    {
        float deviationAngle = 45f;

        Quaternion deviationRotation = Quaternion.Euler(0, 0, deviationAngle);
        Vector2 newDirection = deviationRotation * transform.up;

        return newDirection.normalized;
    }
    Vector2 CalculateFallowPlayerDirection()
    {
        Vector2 newDirection = player.position - transform.position;
        return newDirection.normalized;
    }
    Quaternion RotationFallowPlayer()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateShip * Time.deltaTime);
        return rotation;

    }
    public override void Hit(DamageObject DO)
    {
        healthShip.SubtractDamage(DO._damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (healthShip.isDead) return;
        if (attackShip.EnemyShipType == EnemyShipType.Shooter) return;
        if (collision.collider.CompareTag("Player"))
        {

            IDamageObject<DamageObject> damagableObject = collision.collider.gameObject.GetComponent(typeof(IDamageObject<DamageObject>)) as IDamageObject<DamageObject>;
            if (damagableObject != null && damagableObject != (this.gameObject.GetComponent(typeof(IDamageObject<DamageObject>)) as IDamageObject<DamageObject>))
            {
                damagableObject.Hit(attackShip.damageObjectContacteShipChaser);
                GameObject vfx = Instantiate(attackShip.damageObjectContacteShipChaser._prefabEfectColision, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Destroy(this.gameObject);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    [SerializeField, Space(5)] public DamageObject damageCannonAttack;
    [SerializeField, Space(5)] private float shotFoce = 10;
    [SerializeField, Space(5)] private Transform positionSpawnProjectil;
    [SerializeField, Space(5)] private Animator animator;
    [SerializeField, Space(5)] public GameObject target;
    [Space(5)] public bool canAttack = true;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ActiveThisCanno(bool value)
    {
        damageCannonAttack._activeAtcak = value;
        target.SetActive(value);
    }
    public void StartShootCannol()
    {
        if (!canAttack) return;
        StartCoroutine(RequestStartShooter());
    }
    IEnumerator RequestStartShooter()
    {
        canAttack = false;
        target.SetActive(false);

        animator.SetTrigger("Shooter");
        float time = animator.GetCurrentAnimatorStateInfo(0).length / 2f;
        yield return new WaitForSeconds(time);
        SpawnShootProjectilBall();

        canAttack = true;

        if (damageCannonAttack._activeAtcak)
        {
            target.SetActive(true);
        }

    }
    void SpawnShootProjectilBall()
    {
        GameObject projectilBall = Instantiate(damageCannonAttack._prefabProjectile, positionSpawnProjectil.position,Quaternion.identity);
        GameObject parent = GetComponentInParent(typeof(IDamageObject<DamageObject>)).gameObject;
        projectilBall.GetComponent<Rigidbody2D>().AddForce(-transform.up * shotFoce, ForceMode2D.Impulse);
        projectilBall.GetComponent<ProjectilBall>().SetUpInfo(damageCannonAttack, parent);
    }

}

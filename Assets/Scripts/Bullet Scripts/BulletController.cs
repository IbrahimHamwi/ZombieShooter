using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector] public int damage;
    private float speed = 60f;
    private float default_Time_Alive = 2f;
    private WaitForSeconds wait_For_Time_Alive = new WaitForSeconds(2f);
    private IEnumerator coroutineDeactivate;
    private Vector3 direction;
    public GameObject rocket_Explosion;
    void Start()
    {
        if (this.tag == TagManager.ROCKET_MISSLE_TAG)
        {
            speed = 8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        coroutineDeactivate = WaitForDeactivate();
        StartCoroutine(coroutineDeactivate);
    }
    private void OnDisable()
    {
        if (coroutineDeactivate != null)
        {
            StopCoroutine(coroutineDeactivate);
        }
    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
    IEnumerator WaitForDeactivate()
    {
        yield return wait_For_Time_Alive;
        gameObject.SetActive(false);
    }
    public void ExplosionFX()
    {
        Instantiate(rocket_Explosion, transform.position, Quaternion.identity);
    }
}

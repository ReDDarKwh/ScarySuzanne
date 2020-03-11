using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public LayerMask enemyLayerMask;
    public Transform monsterScarePos;
    public MonsterManager monsterManager;

    public AudioSource audioSource;

    public AudioClip spoopyJumpSound;

    public GameObject[] hands;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var monster = other.GetComponent<Enemy>();
        if (monster != null)
        {
            hands[0].SetActive(false);
            hands[1].SetActive(false);

            monsterManager.enabled = false;
            var nav = monster.GetComponentInParent<NavMeshAgent>();
            nav.enabled = false;
            monster.transform.parent.SetParent(monsterScarePos);
            monster.transform.parent.transform.localPosition = Vector3.zero;
            monster.transform.parent.transform.localRotation = Quaternion.identity;

            monster.GetComponentInParent<Shake>().ShakeThat();

            audioSource.PlayOneShot(spoopyJumpSound);

            StartCoroutine("GameOverManItGameOver");
        };
    }

    private IEnumerator GameOverManItGameOver() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

}

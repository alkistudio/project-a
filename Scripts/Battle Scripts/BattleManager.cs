using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public BattleSceneTransition battleSceneTransition;
    [SerializeField] GameObject battlePlayerObject;
    [SerializeField] GameObject battleEnemyObject;

    GameObject attacker;
    GameObject target;
    float attackerIchor;
    float targetIchor;
    public GameObject playerWeapon;
    public GameObject enemyWeapon;
    public GameObject[] weapons;
    TextMeshProUGUI ichorMeter;
    private void Awake()
    {
        attacker = battleSceneTransition.attackingCharacter;
        target = battleSceneTransition.receivingCharacter;

        attackerIchor = battleSceneTransition.attackerIchor;
        targetIchor = battleSceneTransition.targetIchor;

        GameObject attackerClone = Instantiate(attacker.transform.GetChild(0).gameObject, battlePlayerObject.transform.position, (new Quaternion(0, 0, 0, 0)), battlePlayerObject.transform);
        GameObject targetClone = Instantiate(target.transform.GetChild(0).gameObject, battleEnemyObject.transform.position, (new Quaternion(0, 0, 0, 0)), battleEnemyObject.transform);

    }
    void Start()
    {
        DeactivateAllRootGameObjects();

        playerWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon");
        enemyWeapon = GameObject.FindGameObjectWithTag("EnemyWeapon");

        playerWeapon.GetComponent<ApplyDamage>().battleManager = this.gameObject;
        playerWeapon.GetComponent<ApplyDamage>().enemy = battleEnemyObject;
    }

    void Update()
    {
        ichorMeter.text = attackerIchor.ToString() + "Th";
    }

    public void DeactivateAllRootGameObjects()
    {
        Scene mainScene = SceneManager.GetSceneByName("SampleScene");
        GameObject[] rootObjects = mainScene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            // Set the GameObject and its children inactive
            obj.SetActive(false);
        }
    }
}

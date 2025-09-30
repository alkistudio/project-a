using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "battleSceneTransition", menuName = "Custom/battleSceneTransition")]
public class BattleSceneTransition : ScriptableObject
{
    public GameObject attackingCharacter;
    public GameObject receivingCharacter;

    public float attackerIchor;
    public float targetIchor;
}

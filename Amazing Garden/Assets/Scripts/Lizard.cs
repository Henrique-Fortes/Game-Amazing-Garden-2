using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>()) //se o lizard encontrar um objeto de defesa no caminho, chama o metodo attack
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}

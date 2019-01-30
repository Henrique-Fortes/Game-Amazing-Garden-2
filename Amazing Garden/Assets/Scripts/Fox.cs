using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>()) //se encontrar um objeto do tipo gravestone, settrigger "jumptrigger"
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>()) //se o lizard encontrar um objeto de defesa no caminho, chama o metodo attack
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}

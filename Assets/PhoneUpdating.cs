using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUpdating : MonoBehaviour {

  
    /// Script pequeno só pra manter o celular na mão do jogador no fixedupdate


    [SerializeField] private Transform phoneLocation;

	void FixedUpdate () {

        gameObject.transform.position = phoneLocation.transform.position;
        gameObject.transform.rotation = phoneLocation.transform.rotation;

	}
}

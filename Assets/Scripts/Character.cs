using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Script Player
/// Esse script vai ser utilizado para reconhecer o input do usuário
/// Script localizado em characters/player
/// Por: Leonardo Delafiori
/// </>

public class Character : MonoBehaviour {

    #region Main variables
    public static bool phoneUp = false; //Essa variavel vai ser essencial para analizar se o player está com o celular ativo
    private Animator armAnim;
    private GameObject arm;
    private float inputCooldown;
    [SerializeField] private float resetInputCooldown;

    // Blur control variables
    float blurValue = 0.0f;
    [SerializeField] private Transform blur;
    private Renderer rendBlur;

    //Camera animation variables
    private GameObject camera;
    private Animator camAnim;
    #endregion

    void Start () {

        arm = GameObject.FindGameObjectWithTag("Arm"); // Pegando o gameobject do braço a partir de uma tag no unity
        armAnim = arm.GetComponent<Animator>(); //Pegando o animator a partir do game object
        rendBlur = blur.GetComponent<Renderer>(); //Pegando o elemento do renderer
        rendBlur.material.SetFloat("_blurSizeXY", blurValue);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camAnim = camera.GetComponent<Animator>();
	}
	

	void Update () {
		
        //Verificando se o player apertou "E"
        if(Input.GetKeyUp(KeyCode.E) && inputCooldown <= 0)
        {
            inputCooldown = resetInputCooldown;
            //Deixando a imagem com blur
            if (!phoneUp)
            {
                StartCoroutine(Blurring());
            } else
            {
                StartCoroutine(UnBlurring());
            }
            //Fim de blur
            phoneUp = !phoneUp;
            armAnim.SetBool("PhoneUp", phoneUp);
            camAnim.SetBool("PhoneUp", phoneUp);
        } else
        {
            inputCooldown -= Time.deltaTime;
        }
	}

    #region Blurring and Unblurring
    IEnumerator Blurring()
    {
        bool pronto = false;
        while (!pronto)
        {
            blurValue += 0.1f;
            yield return new WaitForSeconds(0.0001f);
            rendBlur.material.SetFloat("_blurSizeXY", blurValue);
            if (blurValue > 4)
            {
                pronto = true;
            }    
        }
    }

    IEnumerator UnBlurring()
    {
        bool pronto = false;
        while (!pronto)
        {
            blurValue -= 0.1f;
            yield return new WaitForSeconds(0.0001f);
            rendBlur.material.SetFloat("_blurSizeXY", blurValue);
            if (blurValue <= 0)
            {
                pronto = true;
            }
        }
    }
    #endregion
}

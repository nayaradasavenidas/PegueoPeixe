using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc ;
    public float entradaHorizontal;
    public GameObject pfLaser;

    public float tempoDeDisparo = 0.3f;
    public float podeDisparar = 0.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Metodo Start de "+this.name) ;
        veloc = 3.0f ;
        transform.position = new Vector3(-6f,0,0);
    }

    // Update is called once per frame
    void Update()
    {

    Movimento();



    if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
             Disparo();
        }
    }
    private void Movimento(){
        float entradaHorizontal = Input.GetAxis("Horizontal");
         transform.Translate(Vector3.right * entradaHorizontal * Time.deltaTime* veloc);
        if ( transform.position.y > 0){
            transform.position = new Vector3(transform.position.x,0,0);
        } else if ( transform.position.y < -3.75f){
            transform.position = new Vector3(transform.position.x,-3.75f,0);
        }
         float entradaVertical = Input.GetAxis("Vertical");
         transform.Translate(Vector3.up * entradaVertical * Time.deltaTime* veloc);
        if ( transform.position.x > 9.68f){
            transform.position = new Vector3( -9.68f,transform.position.y,0);
        } else if ( transform.position.x < -9.68f ){
            transform.position = new Vector3( 9.68f,transform.position.y,0);
        }
    }
    private void Disparo(){
        if ( Time.time >  podeDisparar ){
             Instantiate( pfLaser,transform.position + new Vector3 (2f,0.3f,0),Quaternion.identity);
            podeDisparar = Time.time +  tempoDeDisparo ;
             }
    }
   }
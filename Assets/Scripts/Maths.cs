using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths : MonoBehaviour
{
    public GameObject _baby;
    float _speed = 8.0f;
    float _rotationSpeed = 100f;
    Vector3 _mosquitoPosition;
    Vector3 _babyPosition;

    void CalculDistance()
    {
        // recupère les coordonnées de position respectifs du moustique et du bébé
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;
        // {..}
        Debug.Log("Calculons la distance entre le moustique et le bébé !");
    }

    // Update is called once per frame
    void Update()
    {
        // detecte et quantifie la pression exercée sur les touches directionnelles
        // les valeurs oscillants entre -1 et 1
        float translation = Input.GetAxis("Vertical") * _speed;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;

        // Time.deltaTime rend les mouvements plus fluides en utilisant une échelle 
        //par seconde plutôt que par frame 
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, rotation);

        if (Input.GetKeyDown(KeyCode.Space)) // lance la méthode CalculDistance si la touche "Espace" est appuyée
        {
            CalculDistance();
        }
    }
}
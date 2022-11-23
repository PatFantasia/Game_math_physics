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

    float CalculateDistance()
    {
        // recup�re les coordonn�es de position
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;

        float distance = Mathf.Sqrt(
                            Mathf.Pow((_babyPosition.x - _mosquitoPosition.x), 2) + Mathf.Pow((_babyPosition.y - _mosquitoPosition.y), 2));
        return distance;
    }

    void CalculateAngle()
    {
        // Vecteur directeur du gameObject moustique
        Vector3 mosquitoDirectorVector = this.transform.up;
        // Vecteur allant du moustique vers le b�b�
        Vector3 targetVector = _baby.transform.position - this.transform.position;

        // il n'est pas neccessaire dans le pr�sent cas d'ajouter les coordonn�es de l'axe z puisque nous travaillons dans un rep�re 2D
        float dotProduct = (mosquitoDirectorVector.x * targetVector.x) + (mosquitoDirectorVector.y * targetVector.y);
        float angle = Mathf.Acos(dotProduct / (mosquitoDirectorVector.magnitude * targetVector.magnitude));

        //option de debogage pour visualiser les vecteurs
        Debug.DrawRay(this.transform.position, mosquitoDirectorVector * 5, Color.yellow, 5);
        Debug.DrawRay(this.transform.position, targetVector, Color.blue, 5);
    }


    // Update is called once per frame
    void Update()
    {
        // detecte et quantifie la pression exerc�e sur les touches directionnelles
        // les valeurs oscillants entre -1 et 1
        float translation = Input.GetAxis("Vertical") * _speed;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;

        // Time.deltaTime rend les mouvements plus fluides en utilisant une �chelle 
        //par seconde plut�t que par frame 
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, rotation);

        if (Input.GetKeyDown(KeyCode.Space)) // execute les diff�rentes m�thodes si la touche "Espace" est appuy�e
        {
            //Debug.Log(" Distance : " + CalculateDistance());
            CalculateAngle();
        }
    }

}

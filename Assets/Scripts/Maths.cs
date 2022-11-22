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

    void CalculateDistance()
    {
        // recupère les coordonnées de position
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;

        float distance = Mathf.Sqrt(
                            Mathf.Pow((_babyPosition.x - _mosquitoPosition.x), 2) + Mathf.Pow((_babyPosition.y - _mosquitoPosition.y), 2));

        Debug.DrawLine(this.transform.position, _babyPosition, Color.white, 10); // affiche pendant 10sec un vecteur de couleur blanche du moustique au bébé
        Debug.Log(" Calcul Distance " + distance);
        Debug.Log(" Unity Distance " + Vector3.Distance(_mosquitoPosition, _babyPosition));
    }

     void CalculateAngle()
    {
        // Pour calculer le Cos -1, vous disposer de la méthode  Mathf.ACos()
        // Vecteur directeur du gameObject moustique
        Vector3 mosquitoDirectorVector =  this.transform.up;
        // Pour le calcul de la norme d'un vecteur utilisez la propriété magnitude. Exemple : _babyPosition.magnitude;

        // Vecteur allant du moustique vers le bébé
        Vector3 targetVector = _baby.transform.position - this.transform.position;

        Debug.Log("Donnez moi l'angle d'attack :) ! ");
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

        if (Input.GetKeyDown(KeyCode.Space)) // execute les différentes méthodes si la touche "Espace" est appuyée
        {
            //CalculateDistance(); Désactivons pour le moment cette méthode
            CalculateAngle();
        }
    }
}
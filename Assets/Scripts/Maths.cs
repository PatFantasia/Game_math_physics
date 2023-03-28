using UnityEngine;

public class Maths : MonoBehaviour
{
    // [SerializeField] : Permet d'accéder à une variable privée depuis l'inspector
    [SerializeField] private GameObject _baby;
    private float _speed = 8.0f;
    private float _rotationSpeed = 100f;
    private Vector3 _mosquitoPosition;
    private Vector3 _babyPosition;

    private void CalculDistance()
    {
        // recupère les coordonnées de position
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;

        float distance = Mathf.Sqrt(
                            Mathf.Pow((_babyPosition.x - _mosquitoPosition.x), 2) + Mathf.Pow((_babyPosition.y - _mosquitoPosition.y), 2));

        Debug.DrawLine(this.transform.position, _babyPosition, Color.white, 10); // affiche pendant 10 secondes un vecteur directeur de couleur blanche du moustique au bébé
        Debug.Log(" Calcul Distance " + distance);
        Debug.Log(" Unity Distance " + Vector3.Distance(_mosquitoPosition, _babyPosition));
    }
    
    // methode native de unity s'exécutant une fois par frame
    private void Update()
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
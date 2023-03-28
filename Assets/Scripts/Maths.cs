using UnityEngine;

public class Maths : MonoBehaviour
{
    [SerializeField] private GameObject _baby;
    private float _speed = 8.0f;
    private float _rotationSpeed = 100f;
    private Vector3 _mosquitoPosition;
    private Vector3 _babyPosition;


    private float CalculateDistance()
    {
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;

        float distance = Mathf.Sqrt(
                            Mathf.Pow((_babyPosition.x - _mosquitoPosition.x), 2) + Mathf.Pow((_babyPosition.y - _mosquitoPosition.y), 2));
        return distance;
    }

    private void CalculateAngle()
    {
        // Vecteur directeur du gameObject moustique
        Vector3 mosquitoDirectorVector = this.transform.up;
        // Vecteur allant du moustique vers le bébé
        Vector3 targetVector = _baby.transform.position - this.transform.position;

        // il n'est pas neccessaire dans le présent cas d'ajouter les coordonnées de l'axe z puisque nous travaillons dans un repère 2D
        float dotProduct = (mosquitoDirectorVector.x * targetVector.x) + (mosquitoDirectorVector.y * targetVector.y);
        float angle = Mathf.Acos(dotProduct / (mosquitoDirectorVector.magnitude * targetVector.magnitude));

        //option de debogage pour visualiser les vecteurs
        Debug.DrawRay(this.transform.position, mosquitoDirectorVector * 5, Color.yellow, 5);
        Debug.DrawRay(this.transform.position, targetVector, Color.blue, 5);
    }


    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * _speed;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, rotation);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //Debug.Log(" Distance : " + CalculateDistance());
            CalculateAngle();
        }
    }

}

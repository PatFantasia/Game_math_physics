using UnityEngine;

public class Maths : MonoBehaviour
{
    [SerializeField] private GameObject _baby;
    private float _speed = 8.0f;
    private float _rotationSpeed = 100f;
    private Vector3 _mosquitoPosition;
    private Vector3 _babyPosition;

    private void CalculateDistance()
    {
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;

        float distance = Mathf.Sqrt(
                            Mathf.Pow((_babyPosition.x - _mosquitoPosition.x), 2) + Mathf.Pow((_babyPosition.y - _mosquitoPosition.y), 2));

        Debug.DrawLine(this.transform.position, _babyPosition, Color.white, 10);
        Debug.Log(" Calcul Distance " + distance);
        Debug.Log(" Unity Distance " + Vector3.Distance(_mosquitoPosition, _babyPosition));
    }

    private void CalculateAngle()
    {
        // Pour calculer le Cos -1, vous disposer de la méthode  Mathf.ACos()

        // Vecteur directeur du gameObject moustique
        Vector3 mosquitoDirectorVector =  this.transform.up;
        // Pour le calcul de la norme d'un vecteur utilisez la propriété magnitude. Exemple : _babyPosition.magnitude;

        // Vecteur allant du moustique vers le bébé
        Vector3 targetVector = _baby.transform.position - this.transform.position;

        Debug.Log("Donnez moi l'angle d'attack :) ! ");
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
            //CalculateDistance(); Désactivons pour le moment cette méthode
            CalculateAngle();
        }
    }
}
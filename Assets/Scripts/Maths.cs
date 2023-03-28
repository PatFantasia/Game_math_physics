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
        // recup�re les coordonn�es de position respectifs du moustique et du b�b�
        _mosquitoPosition = this.transform.position;
        _babyPosition = _baby.transform.position;
        // {..}
        Debug.Log("Calculons la distance entre le moustique et le b�b� !");
    }

    // methode native de unity s'exécutant une fois par frame
    private void Update()
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

        if (Input.GetKeyDown(KeyCode.Space)) // lance la m�thode CalculDistance si la touche "Espace" est appuy�e
        {
            CalculDistance();
        }
    }
}
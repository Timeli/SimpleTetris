using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    [SerializeField]
    private FXMove _fxMove;

    public void Activate() =>
        _fxMove.gameObject.SetActive(true);

    public void Deactivate() => 
        _fxMove.gameObject.SetActive(false);
}

using Managers;
using UnityEngine;

namespace Items
{
  public class CoinItem : MonoBehaviour
  {
    [SerializeField] private protected GameObject _onPickUpVFX;
    [SerializeField] private protected AudioClip _onPickUpSFX;
    [SerializeField] private protected Vector3 _vfxPositionOffset = new Vector3(0f, 1f, -1f);

    private CoinManager _coinManager;
    private bool _isTaken;

    public void Construct(CoinManager coinManager)
    {
      _coinManager = coinManager;
    }


    private void OnTriggerEnter(Collider other)
    {
      if (!other.TryGetComponent<BoatTrigger>(out _) || _isTaken)
        return;

      PickUp(other.transform);
    }

    private void PickUp(Transform otherTransform)
    {
      _isTaken = true;
      _coinManager.CollectCoin();

      var pickUpVFX = Instantiate(_onPickUpVFX, otherTransform);
      pickUpVFX.transform.localPosition = _vfxPositionOffset;
      
      SoundManager.Instance.PlaySFX(_onPickUpSFX);
      Destroy(gameObject);
    }
  }
}
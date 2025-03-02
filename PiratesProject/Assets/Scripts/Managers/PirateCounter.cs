using UnityEngine;

namespace Managers
{
    public class PirateCounter : MonoBehaviour
    {
        [field: SerializeField]public int Count { private set; get; }
        public int[] CountPirateLevel = new []{0,2,4,7};
        private void Start()
        {
            EventManager.Current.OnChangedCountPirate += OnChangedCountPirate;
        }

        private void OnChangedCountPirate(int value)
        {
            Count += value;
            if (Count > CountPirateLevel[^1])
            {
                Count = CountPirateLevel[^1];
            }
        
            if (Count <= 0)
            {
                Count = 0;
                EventManager.Current.GameLose();
                //return;
            }
        
            EventManager.Current.ChangedCurrentValue(Count);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class StatsContainer : MonoBehaviour
    {
        [SerializeField] private Slider _damage;
        [SerializeField] private Slider _hp;
        [SerializeField] private Slider _speed;
        [SerializeField] private Slider _shotCount;

        public void SetDamage(float value, float maxValue)
        {
            _damage.value = value;
            _damage.maxValue = maxValue;
        }

        public void SetHp(float value, float maxValue)
        {
            _hp.value = value;
            _hp.maxValue = maxValue;
        }

        public void SetSpeed(float value, float maxValue)
        {
            _speed.value = value;
            _speed.maxValue = maxValue;
        }

        public void SetShotCount(float value, float maxValue)
        {
            _shotCount.value = value;
            _shotCount.maxValue = maxValue;
        }
    }
}
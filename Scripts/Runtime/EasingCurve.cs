using System;
using UnityEngine;

namespace Ransom
{
    [System.Serializable]
    public struct EasingCurve : IEquatable<EasingCurve>
    {
        #region Fields
        [Header("SETTINGS")]
        [SerializeField] private bool _useCurve;

        [Space]
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private Easings.Functions _easing;
        #endregion Fields

        #region Properties
        public bool UseCurve => _useCurve;
        public AnimationCurve Curve => _curve;
        public Easings.Functions Easing => _easing;
        #endregion Properties

        #region Methods
        public override bool Equals(object obj)
        {
            return ((obj is EasingCurve curve) && Equals(curve));
            // if (obj is EasingCurve curve) return Equals(curve);
            // return false;
        }

        public bool Equals(EasingCurve ec)
        {
            if (ec.UseCurve) { return _curve == ec.Curve; }
            return _easing == ec.Easing;
        }

        public override int GetHashCode()
        {
            if (_useCurve) { return _curve.GetHashCode(); }
            return _easing.GetHashCode();
        }

        public override string ToString()
        {
            return $"<color>Curve:</color> <color=cyan>{_curve}</color> | <color>Easing:</color> <color=cyan>{_easing}</color>";
        }
        
        public static bool operator ==(EasingCurve lhs, EasingCurve rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(EasingCurve lhs, EasingCurve rhs) => !lhs.Equals(rhs);

        #endregion Methods
    }
}

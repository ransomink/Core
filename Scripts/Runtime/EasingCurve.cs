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
            if (obj is EasingCurve curve) return Equals(curve);
            return false;
        }

        public bool Equals(EasingCurve ec)
        {
            if (!ec.UseCurve) return _easing == ec.Easing;
            return _curve == ec.Curve;
        }

        public override int GetHashCode() => (_curve, _easing).GetHashCode();

        public override string ToString() => $"Curve: {_curve} | Easing: {_easing}";
        
        public static bool operator ==(EasingCurve lhs, EasingCurve rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(EasingCurve lhs, EasingCurve rhs) => !(lhs.Equals(rhs));

        #endregion Methods
    }
}

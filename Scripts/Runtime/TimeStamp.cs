using System;
using UnityEngine;

namespace Ransom
{
    [Serializable]
    public struct TimeStamp
    {
        [SerializeField] private int   _day;
        [SerializeField] private float _hour;
        [SerializeField] private float _minutes;
        [SerializeField] private float _seconds;

        private DateTime _dateTime;

        public DateTime DateTime => _dateTime;

        public TimeStamp(DateTime dateTime)
        {
            _dateTime = dateTime;

            _day = dateTime.Day;
            _hour = dateTime.Hour;
            _minutes = dateTime.Minute;
            _seconds = dateTime.Second;
        }

        [ContextMenu("UpdateTime")]
        public void UpdateTime()
        {
            _dateTime = DateTime.Now;

            _day = _dateTime.Day;
            _hour = _dateTime.Hour;
            _minutes = _dateTime.Minute;
            _seconds = _dateTime.Second;
        }
        public void UpdateTime(DateTime dateTime)
        {
            _dateTime = dateTime;

            _day = dateTime.Day;
            _hour = dateTime.Hour;
            _minutes = dateTime.Minute;
            _seconds = dateTime.Second;
        }

        public override string ToString()
        {
            return _dateTime.ToString();
        }
    }
}

namespace Scrabble
{

    using System;

    /// <summary>
    /// Creates a tweenable value that updates its value over time.
    /// </summary>
    /// <typeparam name="T">Type of tweenable value.</typeparam>
    public class Tween<T> where T : IConvertible
    {
        /// <summary>
        /// Max value of tween.
        /// </summary>
        private readonly double _max;

        /// <summary>
        /// min value of tween.
        /// </summary>
        private readonly double _min;

        /// <summary>
        /// Indicator for tween direction.
        /// </summary>
        private readonly bool _positveDirection;

        /// <summary>
        /// Tween range.
        /// </summary>
        private readonly double _range;

        /// <summary>
        /// Current positional value.
        /// </summary>
        private double _value;

        /// <summary>
        /// Creates a tween that for a value that changes over a given time.
        /// </summary>
        /// <param name="time">Time to transition.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        public Tween(TimeSpan time, T min, T max)
        {
            _value = 0.0;
            _positveDirection = true;
            _min = (double)Convert.ChangeType(min, typeof(double));
            _max = (double)Convert.ChangeType(max, typeof(double));
            if (_max < _min)
            {
                var t = _min;
                _min = _max;
                _max = t;
                _positveDirection = false;
            }
            _range = _max - _min;
            TotalTime = time;

            CurrentTime = TimeSpan.Zero;
        }

        /// <summary>
        /// Current value of the tween.
        /// </summary>
        public T Value
        {
            get
            {
                if (_positveDirection)
                {
                    return (T)Convert.ChangeType((_value * _range) + _min, typeof(T));
                }
                return (T)Convert.ChangeType((_range - (_value * _range)) + _min, typeof(T));
            }
        }

        /// <summary>
        /// Returns true if tween is complete.
        /// </summary>
        public bool IsComplete
        {
            get { return Math.Abs(_value - 1.0) < double.Epsilon; }
        }

        /// <summary>
        /// Current tween time.
        /// </summary>
        public TimeSpan CurrentTime { get; private set; }

        /// <summary>
        /// Total time expected for tween.
        /// </summary>
        public TimeSpan TotalTime { get; private set; }

        /// <summary>
        /// Resets this tween to it origianal value.
        /// </summary>
        public void Reset()
        {
            _value = 0.0;
            CurrentTime = TimeSpan.Zero;
        }

        /// <summary>
        /// Forces the tween to finish.
        /// </summary>
        public void Finish()
        {
            _value = 1.0;
        }

        /// <summary>
        /// Updates this tween given a timespan.
        /// </summary>
        /// <param name="timeSpan">Time to update.</param>
        public void Update(TimeSpan timeSpan)
        {
            CurrentTime += timeSpan;
            _value =  Utilities.Clamp((CurrentTime.TotalMilliseconds / TotalTime.TotalMilliseconds), 0.0, 1.0);
        }


    }
}
using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// A wrapper for Unity's Time class.
    /// </summary>
    public class Time : Singleton<Time>
    {
        #region Fields
        [Header("TIME")]
        [ReadOnly][SerializeField] private float timeScale;
        [ReadOnly][SerializeField] private int   frameCount;
        [ReadOnly][SerializeField] private float timeSinceLevelLoad;
        [ReadOnly][SerializeField] private float realtimeSinceStartup;

        [Header("SCALED")]
        [ReadOnly][SerializeField] private float time;
        [ReadOnly][SerializeField] private float deltaTime;
        [ReadOnly][SerializeField] private float smoothDeltaTime;
        [ReadOnly][SerializeField] private float maximumDeltaTime;
        [ReadOnly][SerializeField] private float maximumParticleDeltaTime;
        [Space]
        [ReadOnly][SerializeField] private float fixedTime;
        [ReadOnly][SerializeField] private float fixedDeltaTime;


        [Header("UNSCALED")]
        [ReadOnly][SerializeField] private float unscaledTime;
        [ReadOnly][SerializeField] private float unscaledDeltaTime;
        [Space]
        [ReadOnly][SerializeField] private float fixedUnscaledTime;
        [ReadOnly][SerializeField] private float fixedUnscaledDeltaTime;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The scale at which time passes.
        /// </summary>
        public float TimeScale { get => timeScale; set => timeScale = value; }

        /// <summary>
        /// The total number of frames since the start of the game (Read Only).
        /// </summary>
        public int   FrameCount { get => frameCount; private set => frameCount = value; }

        /// <summary>
        /// The time since this frame started (Read Only). This is the time in seconds since the last non-additive scene has finished loading.
        /// </summary>
        public float TimeSinceLevelLoad { get => timeSinceLevelLoad; private set => timeSinceLevelLoad = value; }

        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// </summary>
        public float RealtimeSinceStartup { get => realtimeSinceStartup; private set => realtimeSinceStartup = value; }

        /// <summary>
        /// The time at the beginning of this frame (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float ScaledTime { get => time; private set => time = value; }

        /// <summary>
        /// The completion time in seconds since the last frame (Read Only).
        /// </summary>
        public float DeltaTime { get => deltaTime; private set => deltaTime = value; }

        /// <summary>
        /// A smoothed out Time.deltaTime (Read Only).
        /// </summary>
        public float SmoothDeltaTime { get => smoothDeltaTime; private set => smoothDeltaTime = value; }

        /// <summary>
        /// The maximum value of Time.deltaTime in any given frame. This is a time in seconds that limits the increase of Time.time between two frames.
        /// </summary>
        public float MaximumDeltaTime { get => maximumDeltaTime; set => maximumDeltaTime = value; }

        /// <summary>
        /// The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates.
        /// </summary>
        public float MaximumParticleDeltaTime { get => maximumParticleDeltaTime; set => maximumParticleDeltaTime = value; }

        /// <summary>
        /// The time the latest FixedUpdate has started (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedTime { get => fixedTime; private set => fixedTime = value; }

        /// <summary>
        /// The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's FixedUpdate) are performed.
        /// </summary>
        public float FixedDeltaTime { get => fixedDeltaTime; set => fixedDeltaTime = value; }

        /// <summary>
        /// The timeScale-independant time for this frame (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float UnscaledTime { get => unscaledTime; private set => unscaledTime = value; }

        /// <summary>
        /// The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public float UnscaledDeltaTime { get => unscaledDeltaTime; private set => unscaledDeltaTime = value; }

        /// <summary>
        /// The TimeScale-independant time the latest FixedUpdate has started (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedUnscaledTime { get => fixedUnscaledTime; private set => fixedUnscaledTime = value; }

        /// <summary>
        /// The timeScale-independent interval in seconds from the last fixed frame to the current one (Read Only).
        /// </summary>
        public float FixedUnscaledDeltaTime { get => fixedUnscaledDeltaTime; private set => fixedUnscaledDeltaTime = value; }
        #endregion Properties

        #region Constructors
        protected Time() {}
        #endregion Constructors

        #region Unity Callbacks
        // private void OnEnable()
        // {
        //     UnityEventDispatcher.OnFixedUpdate += OnFixedUpdate;
        //     UnityEventDispatcher.OnUpdate      += OnUpdate;
        // }

        // private void OnDisable()
        // {
        //     UnityEventDispatcher.OnFixedUpdate -= OnFixedUpdate;
        //     UnityEventDispatcher.OnUpdate      -= OnUpdate;
        // }

        public void OnFixedUpdate()
        {
            FixedTime              = UnityEngine.Time.fixedTime;
            FixedDeltaTime         = UnityEngine.Time.fixedDeltaTime;
            FixedUnscaledTime      = UnityEngine.Time.fixedUnscaledTime;
            FixedUnscaledDeltaTime = UnityEngine.Time.fixedUnscaledDeltaTime;
        }
        
        public void OnUpdate()
        {
            TimeScale                = UnityEngine.Time.timeScale;
            FrameCount               = UnityEngine.Time.frameCount;
            TimeSinceLevelLoad       = UnityEngine.Time.timeSinceLevelLoad;
            RealtimeSinceStartup     = UnityEngine.Time.realtimeSinceStartup;

            ScaledTime               = UnityEngine.Time.time;
            DeltaTime                = UnityEngine.Time.deltaTime;
            SmoothDeltaTime          = UnityEngine.Time.smoothDeltaTime;
            MaximumDeltaTime         = UnityEngine.Time.maximumDeltaTime;
            MaximumParticleDeltaTime = UnityEngine.Time.maximumParticleDeltaTime;
            
            UnscaledTime             = UnityEngine.Time.unscaledTime;
            UnscaledDeltaTime        = UnityEngine.Time.unscaledDeltaTime;
        }
        #endregion Unity Callbacks
    }
}

using UnityEngine;

namespace LikeADoom
{
    public class Targeting
    {
        private readonly DistanceChecker _checker;

        public Targeting(Transform target, DistanceChecker checker)
        {
            Target = target;
            _checker = checker;
            _checker.SetTarget(target);
        }

        public Transform Target { get; }

        public void Start() => _checker.StartChecking();
        public bool IsTargetClose => IsTargetAtDistance(DistanceChecker.Distance.Close);
        public bool IsTargetAtMediumDistance => IsTargetAtDistance(DistanceChecker.Distance.Medium);
        public bool IsTargetAtMediumDistanceOrClose => IsTargetCloserOrAt(DistanceChecker.Distance.Medium);
        public bool IsTargetAtMediumDistanceOrFurther => IsTargetFurtherOrAt(DistanceChecker.Distance.Medium);
        public bool IsTargetFar => IsTargetAtDistance(DistanceChecker.Distance.Far);

        private bool IsTargetAtDistance(DistanceChecker.Distance distance) =>
            _checker.GetDistance() == distance;
        private bool IsTargetCloserOrAt(DistanceChecker.Distance distance) =>
            _checker.GetDistance() <= distance;
        private bool IsTargetFurtherOrAt(DistanceChecker.Distance distance) =>
            _checker.GetDistance() >= distance;
    }
}
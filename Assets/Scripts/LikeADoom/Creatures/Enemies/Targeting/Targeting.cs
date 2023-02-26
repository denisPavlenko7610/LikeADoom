using UnityEngine;

namespace LikeADoom.LikeADoom.Creatures.Enemies.Targeting
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
        public bool IsTargetClose => IsTargetAtDistance(DistanceTypes.Close);
        public bool IsTargetAtMediumDistance => IsTargetAtDistance(DistanceTypes.Medium);
        public bool IsTargetAtMediumDistanceOrCloser => IsTargetCloserOrAt(DistanceTypes.Medium);
        public bool IsTargetAtMediumDistanceOrFurther => IsTargetFurtherOrAt(DistanceTypes.Medium);
        public bool IsTargetFar => IsTargetAtDistance(DistanceTypes.Far);

        private bool IsTargetAtDistance(DistanceTypes distance) =>
            _checker.GetDistance() == distance;
        private bool IsTargetCloserOrAt(DistanceTypes distance) =>
            _checker.GetDistance() <= distance;
        private bool IsTargetFurtherOrAt(DistanceTypes distance) =>
            _checker.GetDistance() >= distance;
    }
}
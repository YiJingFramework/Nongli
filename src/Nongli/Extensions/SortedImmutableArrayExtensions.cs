using System.Collections.Immutable;

namespace YiJingFramework.Nongli.Extensions;
internal static class SortedImmutableArrayExtensions
{
    public static int SortedFindFloor<T>(
        this ImmutableArray<T> array, T targetValue)
        where T : IComparable<T>
    {
        var leftIndex = 0;
        if (array[leftIndex].CompareTo(targetValue) > 0)
            return -1;

        var rightIndex = array.Length - 1;
        if (array[rightIndex].CompareTo(targetValue) <= 0)
            return rightIndex;

        for (; leftIndex != rightIndex - 1;)
        {
            var middleIndex = (leftIndex + rightIndex) / 2;
            if (array[middleIndex].CompareTo(targetValue) > 0)
                rightIndex = middleIndex;
            else
                leftIndex = middleIndex;
        }
        return leftIndex;
    }
}

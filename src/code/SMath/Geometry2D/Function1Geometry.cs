﻿using System.Numerics;

namespace SMath.Geometry2D
{
    public static class Function1Geometry
    {
        public static class TangentLine
        {
            public static (N A, N B, N C) FromX<N>(N x, N valueInX, N slopeInX)
                where N : INumberBase<N>
                => (-slopeInX, N.One, slopeInX * x - valueInX);

            public static class Slope
            {
                public static N FromX<N>(N derivativeInX)
                    where N : INumberBase<N>
                    => derivativeInX;
            }
        }

        public static class NormalLine
        {
            public static (N A, N B, N C) FromX<N>(N x, N valueInX, N slopeInX)
                where N : INumberBase<N>
                => x != N.Zero
                    ? (-slopeInX, N.One, slopeInX * x - valueInX)
                    : (N.One, N.Zero, N.Zero);

            public static class Slope
            {
                public static N FromX<N>(N derivativeInX)
                    where N : INumberBase<N>
                    => -N.One / derivativeInX;
            }
        }

        public static class Points
        {
            public static IEnumerable<(N X, N Y)> FromCount<N, NInt>(Func<N, N> function, N from, N to, NInt count)
                where N : INumberBase<N>, IComparisonOperators<N, N, bool>
                where NInt : IBinaryInteger<NInt>
                => FromStep(function, from, to, to - from / N.CreateChecked(count));

            public static IEnumerable<(N X, N Y)> FromStep<N>(Func<N, N> function, N from, N to, N xstep)
                where N : INumberBase<N>, IComparisonOperators<N, N, bool>
            {
                for (N x = from; x < to; x += xstep)
                    yield return (x, function(x));
            }
        }
    }
}

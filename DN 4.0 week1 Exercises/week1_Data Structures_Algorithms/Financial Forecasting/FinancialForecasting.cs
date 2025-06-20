using System;

// FinancialForecasting.cs
public static class FinancialForecasting
{
    public static double PredictFutureValue(double[] pastVal, int n)
    {
        if (pastVal == null || pastVal.Length == 0)
            throw new ArgumentException("Past values array cannot be null or empty.", nameof(pastVal));
        if (n < 0 || n >= pastVal.Length)
            throw new ArgumentOutOfRangeException(nameof(n), "Index n must be within the bounds of the array.");

        if (n == 0)
        {
            return pastVal[0];
        }
        return (1 + GrowthRate(pastVal, n)) * PredictFutureValue(pastVal, n - 1);
    }

    private static double GrowthRate(double[] pastVal, int n)
    {
        if (pastVal[n - 1] == 0)
            throw new DivideByZeroException("Cannot calculate growth rate with a zero previous value.");
        return (pastVal[n] - pastVal[n - 1]) / pastVal[n - 1];
    }
}

/*
COMPLEXITY:
Time Complexity: O(n).
*/

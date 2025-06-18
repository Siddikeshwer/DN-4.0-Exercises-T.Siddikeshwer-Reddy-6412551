class FinancialForecasting {
    public static double predictFutureValue(double[] pastVal, int n) {
        if (n == 0) {
            return pastVal[0];
        }
        return (1 + growthRate(pastVal, n)) * predictFutureValue(pastVal, n - 1);
    }

    private static double growthRate(double[] pastVal, int n) {
        return (pastVal[n] - pastVal[n - 1]) / pastVal[n - 1];
    }
}

/*

COMPLEXITY:
Time Complexity: O(n).

*/

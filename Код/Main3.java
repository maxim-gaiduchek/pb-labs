public class Main3 {

    public static void main(String[] args) {
        final double x = 0.56, error = 1.0e-4;
        int n = 0;
        double sum = 0, element = function(x, n++), diff = element;

        while (Math.abs(diff) > error) {
            sum += element;
            diff = element;
            element = function(x, n++);
            diff -= element;
        }

        System.out.println(sum);
    }

    private static double function(double x, int n) {
        return (n % 2 == 0 ? 1 : -1) * (Math.pow(x, 2 * n) + 1) / (Math.pow(2, n) + 1);
    }
}

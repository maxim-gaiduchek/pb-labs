public class Main3 {

    public static void main(String[] args) {
        double x = 0.56, error = 1.0e-4;
        double sum = 0, element = 0;
        int n = 1;

        while (Math.abs(element - (element = function(x, n++))) > error) {
            sum += element;
        }

        System.out.println(sum);
    }

    private static double function(double x, int n) {
        return (n % 2 == 0 ? 1 : -1) * ((Math.pow(x, 2 * n) + 1) / (Math.pow(2, n) + 1));
    }
}

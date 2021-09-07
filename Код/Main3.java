public class Main3 {

    public static void main(String[] args) {
        float x = 0.56f, error = 0.0001f;
        double sum = 0, element;
        int n = 1;

        while (Math.abs(element = function(x, n++)) > error) {
            sum += element;
        }

        System.out.println(sum);
    }

    private static double function(float x, int n) {
        return (n % 2 == 0 ? 1 : -1) * ((Math.pow(x, 2 * n) + 1) / (Math.pow(2, n) + 1));
    }
}

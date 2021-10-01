import java.util.Scanner;

public class Main4 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter x: ");
        double x = scanner.nextDouble();

        System.out.print("Enter n: ");
        int n = scanner.nextInt();

        scanner.close();

        double sum = 0;

        for (int i = 1; i <= n; i++) {
            sum += function(x, i);
        }

        System.out.println(sum);
    }

    private static double function(double x, int n) {
        return Math.pow(x, n - 1) / fact(n - 1);
    }

    private static long fact(int n) {
        return n == 0 ? 1 : (n * fact(n - 1));
    }
}

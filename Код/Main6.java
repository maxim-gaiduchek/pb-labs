import java.util.Scanner;

public class Main6 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a: ");
        int a = scanner.nextInt();

        System.out.print("Enter b: ");
        int b = scanner.nextInt();

        System.out.print("Enter c: ");
        int c = scanner.nextInt();

        scanner.close();

        System.out.println(gcd(gcd(a, b), c));
    }

    private static int gcd(int a, int b) {
        while(a % b != 0 && b % a != 0) {
            if (a > b) {
                a %= b;
            } else {
                b %= a;
            }
        }

        return Math.min(a, b);
    }
}

import java.util.Scanner;

public class Main6 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = input(scanner, "Enter a: ");
        int b = input(scanner, "Enter b: ");
        int c = input(scanner, "Enter c: ");

        scanner.close();

        System.out.println(gcd(gcd(a, b), c));
    }

    private static int input(Scanner scanner, String prompt) {
        System.out.print(prompt);

        return scanner.nextInt();
    }

    private static int gcd(int a, int b) {
        while (a % b != 0 && b % a != 0) {
            if (a > b) {
                a %= b;
            } else {
                b %= a;
            }
        }

        return Math.min(a, b);
    }
}

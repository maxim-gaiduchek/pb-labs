import java.util.Scanner;

public class Main1 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter M: ");
        float M = scanner.nextFloat();

        scanner.close();

        int a = (int) M;
        float b = M - a;

        float result = a / 1000f + Math.round(b * 1000);

        System.out.println(result);
    }
}

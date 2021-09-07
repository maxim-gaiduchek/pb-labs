import java.util.Scanner;

public class Main1 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter M: ");
        float M = scanner.nextFloat();

        scanner.close();

        float result = (int) ((M - (int) M) * 1000) + (int) M / 1000f;

        System.out.println(result);
    }
}

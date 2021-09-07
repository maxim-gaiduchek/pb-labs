import java.util.Scanner;

public class Main2 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter x: ");
        float x = scanner.nextFloat();

        System.out.print("Enter y: ");
        float y = scanner.nextFloat();

        scanner.close();

        if (Math.abs(y) >= x * x && Math.abs(x) >= y * y) { // |y| >= x^2 && |x| >= y^2
            System.out.println("The figure contains the point (" + x + "; " + y + ")");
        } else {
            System.out.println("The figure does not contain the point (" + x + "; " + y + ")");
        }
    }
}

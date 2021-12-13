import java.util.Scanner;

public class Main9 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        int n = scanner.nextInt();

        for (String word : text.split(" ")) {
            if (word.length() == n) {
                System.out.print(word + ", ");
            }
        }
    }
}

// I was made for lovin' you baby You were made for lovin' me

import java.util.Arrays;

public class Main7 {

    public static void main(String[] args) {
        int[] B = {3, 5, 327489, 2, -9, -30, 7};

        int min = B[0], minIndex = 0;

        for (int i = 1; i < B.length; i++) {
            if (min > B[i]) {
                min = B[i];
                minIndex = i;
            }
        }

        int max = B[0];

        for (int i = 1; i < B.length; i++) {
            if (max < B[i]) {
                max = B[i];
            }
        }

        System.out.println(max - min);

        B[minIndex] = B[B.length - 1];
        B[B.length - 1] = min;

        System.out.println(Arrays.toString(B));
    }
}

import java.util.Arrays;

public class Main8 {

    public static void main(String[] args) {
        int[][] A = {
                {1, 2, 3},
                {3, 1, 2},
                {2, 3, 1}
        };

        for (int i = 0; i < A.length - 1; i++) {
            for (int j = 0; j < A.length - i - 1; j++) {
                if (A[j][0] < A[j + 1][0]) {
                    int[] temp = A[j + 1];
                    A[j + 1] = A[j];
                    A[j] = temp;
                }
            }
        }

        int[] X = new int[A.length];

        for (int i = 0; i < A.length; i++) {
            X[i] = A[i][i];
        }

        System.out.println(Arrays.deepToString(A));
        System.out.println(Arrays.toString(X));
    }
}

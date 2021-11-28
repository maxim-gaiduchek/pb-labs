import java.util.Random;

public class Main8 {

    public static void main(String[] args) {
        int[][] A = createMatrix();

        System.out.println("Input matrix:");
        printMatrix(A);

        sortMatrix(A);
        System.out.println("Sorted matrix:");
        printMatrix(A);

        int[] X = getMainDiagonal(A);

        System.out.print("Diagonal elements of sorted matrix: ");
        printArray(X);
    }

    private static int[][] createMatrix() {
        Random random = new Random();

        int size = random.nextInt(1, 10);
        int[][] matrix = new int[size][size];

        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                matrix[i][j] = random.nextInt(10);
            }
        }

        return matrix;
    }

    private static void printArray(int[] arr) {
        for (int i : arr) {
            System.out.print(i + ", ");
        }
        System.out.println();
    }

    private static void printMatrix(int[][] matrix) {
        for (int[] arr : matrix) {
            for (int i : arr) {
                System.out.print(i + "\t");
            }
            System.out.println();
        }
        System.out.println();
    }

    private static void sortMatrix(int[][] matrix) {
        for (int i = 0; i < matrix.length - 1; i++) {
            for (int j = 0; j < matrix.length - i - 1; j++) {
                if (matrix[j][0] < matrix[j + 1][0]) {
                    int[] temp = matrix[j + 1];
                    matrix[j + 1] = matrix[j];
                    matrix[j] = temp;
                }
            }
        }
    }

    private static int[] getMainDiagonal(int[][] matrix) {
        int[] arr = new int[matrix.length];

        for (int i = 0; i < matrix.length; i++) {
            arr[i] = matrix[i][i];
        }

        return arr;
    }
}

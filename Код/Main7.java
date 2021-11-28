import java.util.Random;

public class Main7 {

    public static void main(String[] args) {
        int[] B = createArray();

        System.out.print("Input array: ");
        printArray(B);

        int minIndex = getMinIndex(B);
        int min = B[minIndex];
        int max = getMax(B);

        System.out.println("Min element: " + min);
        System.out.println("Max element: " + max);
        System.out.println("Difference: " + (max - min));

        swapMinAndLastElements(B, minIndex);

        System.out.print("Swapped min and last elements: ");
        printArray(B);
    }

    private static int[] createArray() {
        Random random = new Random();

        int size = random.nextInt(1, 20);
        int[] arr = new int[size];

        for (int i = 0; i < size; i++) {
            arr[i] = random.nextInt(10000);
        }

        return arr;
    }

    private static void printArray(int[] arr) {
        for (int i : arr) {
            System.out.print(i + ", ");
        }
        System.out.println();
    }

    private static int getMinIndex(int[] arr) {
        int min = arr[0], minIndex = 0;

        for (int i = 1; i < arr.length; i++) {
            if (min > arr[i]) {
                min = arr[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    private static int getMax(int[] arr) {
        int max = arr[0];

        for (int i = 1; i < arr.length; i++) {
            if (max < arr[i]) {
                max = arr[i];
            }
        }

        return max;
    }

    private static void swapMinAndLastElements(int[] B, int minIndex) {
        int min = B[minIndex];

        B[minIndex] = B[B.length - 1];
        B[B.length - 1] = min;
    }
}

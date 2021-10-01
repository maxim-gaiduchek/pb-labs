public class Main5 {

    public static void main(String[] args) {
        int len = 2;

        for (int num = 10; num < 10000; num++) {
            if (num == 100 || num == 1000) len++;

            int ams = 0;

            for (float div = 1; div <= num; div *= 10) {
                ams += Math.pow((int) (num / div) % 10, len);
            }

            if (num == ams) {
                System.out.println(num);
            }
        }
    }
}

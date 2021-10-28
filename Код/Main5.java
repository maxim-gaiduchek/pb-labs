public class Main5 {

    public static void main(String[] args) {
        for (int num = 10; num < 10000; num++) {
            int len = (int) Math.log10(num) + 1;
            int ams = 0;

            for (int div = 1; div <= num; div *= 10) {
                ams += Math.pow((float) ((num / div) % 10), len);
            }

            if (num == ams) {
                System.out.print(num + ", ");
            }
        }
    }
}

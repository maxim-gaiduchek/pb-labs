public class Main1 {

    public static void main(String[] args) {
        float M = 111.456f;

        int a = (int) M;
        float b = M - a;

        float result = a / 1000f + Math.round(b * 1000);

        System.out.println(result);
    }
}

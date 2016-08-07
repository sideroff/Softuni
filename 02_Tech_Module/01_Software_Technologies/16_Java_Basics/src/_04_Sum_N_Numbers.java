import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _04_Sum_N_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        long sum = 0;
        for (int i = 0; i < n; i++) {
            sum+=scanner.nextInt();
        }
        System.out.println(sum);
    }
}

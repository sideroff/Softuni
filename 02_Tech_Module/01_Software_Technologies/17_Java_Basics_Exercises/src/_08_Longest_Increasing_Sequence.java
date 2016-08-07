import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by ivans on 5.8.2016 г..
 */
public class _08_Longest_Increasing_Sequence {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        if(input !=null && !input.isEmpty()) {
            List<Integer> arr = Arrays.stream(
                    input
                            .split(" "))
                    .map(e -> Integer.parseInt(e))
                    .collect(Collectors.toList());
            int start = 0;
            int end = 1;
            int lenght = 1;
            for (int i = 0; i < arr.size(); i++) {
                int j = i + 1;
                while (j < arr.size() && arr.get(j - 1) < arr.get(j)) {
                    j++;
                }
                if (j - i > lenght) {
                    start = i;
                    end = j - 1;
                    lenght = j - i;
                    i = j - 1;
                }
            }
            for (int i = start; i <= end && i < arr.size(); i++) {
                System.out.print(arr.get(i) + " ");
            }
        }
    }
}

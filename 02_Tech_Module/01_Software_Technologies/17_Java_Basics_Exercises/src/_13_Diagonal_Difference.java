
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by ivans on 5.8.2016 г..
 */
public class _13_Diagonal_Difference {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        int[][] array = new int[n][];
        for (int i = 0; i < n; i++) {
            List<Integer> tempList =Arrays.stream(sc.nextLine().split(" ")).map(x->Integer.parseInt(x)).collect(Collectors.toList());
            array[i] = new int[tempList.size()];
            for (int j = 0; j < tempList.size(); j++) {
                array[i][j] = tempList.get(j);
            }
        }
        long leftDiagonalSum=0;
        long rightDiagonalSum=0;
        for (int i = 0; i < array.length; i++) {
            leftDiagonalSum += array[i][i];
            rightDiagonalSum += array[array.length-1-i][i];
        }
        System.out.println(Math.abs(leftDiagonalSum-rightDiagonalSum));
    }
}

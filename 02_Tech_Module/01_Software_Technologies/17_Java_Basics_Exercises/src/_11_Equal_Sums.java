import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by ivans on 5.8.2016 г..
 */
public class _11_Equal_Sums {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<Integer> arr = Arrays.stream(sc.nextLine().split(" ")).map(x -> Integer.parseInt(x)).collect(Collectors.toList());
        boolean hasFound = false;
        for (int i = 0; i < arr.size(); i++) {
            long leftSum = 0;
            long rightSum = 0;
            for (int j = 0; j < i; j++) {
                leftSum+=arr.get(j);
            }
            for (int k =i+1; k < arr.size(); k++) {
                rightSum+=arr.get(k);
            }
            if(leftSum==rightSum){
                hasFound=true;
                System.out.println(i);
                break;
            }
        }
        if (!hasFound) {
            System.out.println("no");
        }
    }
}

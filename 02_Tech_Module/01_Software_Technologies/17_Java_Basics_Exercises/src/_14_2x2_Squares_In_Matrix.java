import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by ivans on 7.8.2016 г..
 */
public class _14_2x2_Squares_In_Matrix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> dimensions = Arrays.stream(sc.nextLine().split(" ")).map(x->Integer.parseInt(x)).collect(Collectors.toList());
        Integer[][] array = new Integer[dimensions.get(0)][dimensions.get(1)];

        for (int i = 0; i < dimensions.get(0); i++) {
            List<Integer> tempList = Arrays.stream(sc.nextLine().split(" ")).map(Integer::parseInt).collect(Collectors.toList());

            for (int j = 0; j < tempList.size(); j++) {
                array[i][j] = tempList.get(j);
            }
        }
        Long maxSumOf3By3Square = Long.valueOf(0);
        int row = 0;
        int col = 0;
        for (int i = 0; i <= array.length-3; i++) {
            for (int j = 0; j <= array[i].length - 3; j++) {
                Long tempSum = Long.valueOf(0);
                tempSum+= array[i][j] + array[i][j+1] +   array[i][j+2] ;
                        tempSum+=      array[i+1][j] + array[i+1][j+1] + array[i+1][j+2];
                        tempSum+=     array[i+2][j] + array[i+2][j+1] + array[i+2][j+2];
                if(tempSum>maxSumOf3By3Square){
                    maxSumOf3By3Square = tempSum;
                    row=i;
                    col=j;
                }
            }
        }

        if(maxSumOf3By3Square!=0){
            System.out.println(maxSumOf3By3Square);
            System.out.println(array[row][col] +" "+ array[row][col+1] +" "+ array[row][col+2]);
            System.out.println(array[row+1][col] +" "+ array[row+1][col+1] +" "+ array[row+1][col+2]);
            System.out.println(array[row+2][col] +" "+ array[row+2][col+1] +" "+ array[row+2][col+2]);
        }
    }
}

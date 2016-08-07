import java.util.*;
import java.util.stream.Collectors;

/**
 * Created by ivans on 5.8.2016 г..
 */
public class _09_Most_Frequent_Number {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();

        if(input ==null || input.isEmpty()) {
            return;
        }

        List<Integer> arr = Arrays.stream(
                input
                .split(" "))
                .map(e -> Integer.parseInt(e))
                .collect(Collectors.toList());
        Map<Integer,Integer> map = new HashMap<Integer,Integer>();
        for (int i = 0; i < arr.size(); i++) {
            if(!map.containsKey(arr.get(i))){
                map.put(arr.get(i), 1);
            }
            else{
                map.put(arr.get(i),map.get(arr.get(i))+1);
            }
        }
        Integer key = null;
        Integer mostFreqent = 0;
        for (Integer element : arr) {

            if(map.get(element)>mostFreqent){
                key=element;
                mostFreqent=map.get(element);
            }
        }
        if(key!=null){
            System.out.println(key);
        }
    }
}

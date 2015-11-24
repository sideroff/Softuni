package com.company;


import java.util.*;
import java.util.stream.Collectors;

/**
 * Created by Siderov on 1.11.2015 ã..
 */
public class Lego_Blocks {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<List<Integer>> list1 = new ArrayList<List<Integer>>();
        Integer n = Integer.parseInt(sc.nextLine());
        Integer max = 0;
        for (int i = 0; i < n; i++) {
            list1.add(Arrays.stream(sc.nextLine().trim().split("\\s+")).map(Integer::parseInt).collect(Collectors.toList()));
        }
        List<List<Integer>> list2 = new ArrayList<List<Integer>>();
        for (int i = 0; i < n; i++) {
            list2.add(Arrays.stream(sc.nextLine().trim().split("\\s+")).map(Integer::parseInt).collect(Collectors.toList()));
        }
        for (int i = 0; i < n; i++) {
            if(max<list1.get(i).size()+list2.get(i).size()) max = list1.get(i).size()+list2.get(i).size();
        }
        boolean match = true;
        for (int i = 0; i < n; i++) {
            if(list1.get(i).size()+list2.get(i).size()==max) continue;
            match = false;
            break;
        }
        if(!match){
            int s = 0;
            for (int i = 0; i < n; i++) {
                s+=list1.get(i).size()+list2.get(i).size();
            }
            System.out.printf("The total number of cells is: %d", s);
        }
        else{
            for (int i = 0; i < n; i++) {
                Collections.reverse(list2.get(i));
            }
            for (int i = 0; i < n; i++) {
                System.out.print("[");
                String output = "";
                for (Integer integer : list1.get(i)) {
                    output+=String.format("%d, ",integer);
                }
                for (Integer integer : list2.get(i)) {
                    output+=String.format("%d, ",integer);
                }
                System.out.print(output.substring(0, output.length() - 2));
                System.out.println("]");
            }

        }




    }
}

package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


public class _4_Largest_Increasing_Sequence {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(" ");
        List<Integer> temp = new ArrayList<Integer>();
        List<Integer> max = new ArrayList<Integer>();
        temp.add(Integer.parseInt(input[0]));
        for (int i = 1; i < input.length; i++) {
            if(Integer.parseInt(input[i])==temp.get(temp.size()-1)+1) temp.add(Integer.parseInt(input[i]));
            else{
                if(temp.size()>max.size()){
                    max.clear();
                    for (Integer s : temp) {
                        max.add(s);
                    }
                }
                temp.clear();
                temp.add(Integer.parseInt(input[i]));
            }
        }
        if(temp.size()>max.size()){
            max.clear();
            for (Integer s : temp) {
                max.add(s);
            }
        }

        for (Integer s : max) {
            System.out.print(s + " ");
        }
    }
}

package com.company;

import java.util.Scanner;

import javax.swing.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by Siderov on 28.10.2015 ã..
 */
public class _11_Most_Frequent_Word {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Map<String,Integer> uniques = new HashMap<>();
        ArrayList<String> input = new ArrayList(Arrays.asList(sc.nextLine().toLowerCase().split(" ")));
        for (String s : input) {
            if(!uniques.containsKey(s))uniques.put(s, 1);
            else uniques.put(s, uniques.get(s)+1);
        }
        int max = 0;
        for (Map.Entry<String, Integer> entry : uniques.entrySet()) {
            if(max<entry.getValue()) max= entry.getValue();
        }

        for (Map.Entry<String, Integer> entry : uniques.entrySet()) {
            if(max==entry.getValue()){
                System.out.println(entry.getKey() + " -> "+ entry.getValue());
                break;
            }
        }
    }
}

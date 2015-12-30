package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Siderov on 20.10.2015 ã..
 */
public class _8_Odd_Or_Even_Pairs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        String[] parts = input.split(" ");
        List<Integer> list = new ArrayList<Integer>();

        for (int i = 0; i < parts.length; i++) {
            list.add(Integer.parseInt(parts[i]));
        }

        getPairs(list);

    }
    public static void getPairs(List<Integer> list){
        if(list.size()%2!=0){
            System.out.println("Invalid length");
            return;
        }
        for (int i = 0; i < list.size()-1; i+=2) {
             if(list.get(i)%2==0&&list.get(i+1)%2==0){
                 System.out.printf("%d, %d -> both are even\r\n", list.get(i), list.get(i + 1));
             }
            else if(list.get(i)%2!=0&&list.get(i+1)%2!=0) {
                 System.out.printf("%d, %d -> both are odd\r\n", list.get(i), list.get(i + 1));
             }
            else{
                 System.out.printf("%d, %d -> different\r\n", list.get(i), list.get(i + 1));
             }
        }

    }
}

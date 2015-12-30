package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Siderov on 21.10.2015 �..
 */
public class _13_First_Even_First_Odd {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        String[] parts = input.split(" ");
        char a = 'b';
        List<Integer> list = new ArrayList<Integer>();
        for (int i = 0; i < parts.length; i++) {
            list.add(Integer.parseInt(parts[i]));
        }
        input = sc.nextLine();
        parts = input.split(" ");
        List<Integer> gets = new ArrayList<Integer>();
        if (parts[2].equals("even")){
            for (int i = 0; i < list.size()&&gets.size()!=Integer.parseInt(parts[1]); i++) {
                if(list.get(i)%2==0){
                    gets.add(list.get(i));
                }
            }
        }
        else if(parts[2].equals("odd")){
            for (int i = 0; i < list.size()&&gets.size()!=Integer.parseInt(parts[1]); i++) {
                if(list.get(i)%2!=0){
                    gets.add(list.get(i));
                }
            }
        }
        for (Integer get : gets) {
            System.out.print(get+" ");
        }
    }
}

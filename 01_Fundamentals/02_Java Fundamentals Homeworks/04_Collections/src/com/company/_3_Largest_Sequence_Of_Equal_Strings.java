package com.company;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

//RUN USING CTRL+SHIFT+F10
//find largest substring
public class _3_Largest_Sequence_Of_Equal_Strings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(" ");
        List<String> temp = new ArrayList<String>();
        List<String> max = new ArrayList<String>();
        temp.add(input[0]);
        for (int i = 1; i < input.length; i++) {
            if(input[i].equals(temp.get(temp.size()-1))) temp.add(input[i]);
            else{
                if(temp.size()>max.size()){
                    max.clear();
                    for (String s : temp) {
                        max.add(s);
                    }
                }
                temp.clear();
                temp.add(input[i]);
            }
        }
        if(temp.size()>max.size()){
            max.clear();
            for (String s : temp) {
                max.add(s);
            }
        }

        for (String s : max) {
            System.out.print(s + " ");
        }
    }
}

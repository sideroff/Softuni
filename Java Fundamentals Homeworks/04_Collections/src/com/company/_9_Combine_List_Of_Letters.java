package com.company;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
//Run Using CTRL+Shift+F10
//get 2 list<char> -> foreach char in secondList { if firstList doesnt contain char -> firstlist.add(char);
public class _9_Combine_List_Of_Letters {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);

        ArrayList<Character> first = new ArrayList(Arrays.asList(console.nextLine().split("")));
        ArrayList<Character> second = new ArrayList(Arrays.asList(console.nextLine().split("")));
        for (int i = 0; i < second.size(); i++) {
            if(!first.contains(second.get(i))){
                first.add(second.get(i));
            }
        }
        for (int i = 0; i < first.size(); i++) {
            System.out.print(first.get(i) + " ");
        }

    }
}

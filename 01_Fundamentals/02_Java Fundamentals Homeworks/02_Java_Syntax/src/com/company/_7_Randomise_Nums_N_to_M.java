package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

//Run with CTRL+Shift+F10
//Get numbers from N to M in random order
public class _7_Randomise_Nums_N_to_M {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int m = sc.nextInt();
        if (n<m){
            int temp = n;
            n=m;
            m=temp;
        }
        Random rand = new Random();
        List<Integer> list = new ArrayList<Integer>();
        while(list.size()<n-m+1){
            int  r = rand.nextInt(n+1) + m;
            if(list.contains(r)){
                continue;
            }
            list.add(r);
        }
        for (Integer integer : list) {
            System.out.print(integer +" ");
        }
    }
}

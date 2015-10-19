package com.company;

import java.util.Scanner;
// œ”— ¿… — CTRL+SHIFT+F10

/**
 * Created by Siderov on 19.10.2015 „..
 */
//Get average of 3 ints using method, format output to 2 digits after floating point;
public class _8_Get_Average {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        int b = sc.nextInt();
        int c = sc.nextInt();
        System.out.printf("%.2f",getAverage(a,b,c));
    }
    public static float getAverage(int a, int b, int c){
        return (a+b+c)/3f;
    }
}

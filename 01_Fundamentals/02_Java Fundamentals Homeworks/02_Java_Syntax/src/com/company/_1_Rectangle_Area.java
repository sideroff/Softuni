package com.company;

import java.util.Scanner;
    //Run using CTRL+SHIFT+F10
    //Task - get rectangle area.
public class _1_Rectangle_Area {

    public static void main(String[] args) {
	    Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        int b = sc.nextInt();
        System.out.println(getAreaOfRectangle(a,b));
    }
    public static int getAreaOfRectangle(int a, int b){
        return a*b;
    }

}

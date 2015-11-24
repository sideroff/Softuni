package com.company;

import java.util.Scanner;

//Run using CTRL+SHIFT+F10
//Task - get triangle area using 3 points(x,y)

public class _2_Triangle_Area {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int ax = sc.nextInt();
        int ay = sc.nextInt();

        int bx = sc.nextInt();
        int by = sc.nextInt();

        int cx = sc.nextInt();
        int cy = sc.nextInt();

        System.out.println(getTriangleArea(ax, ay, bx, by, cx, cy));
    }
    public static int getTriangleArea(int ax, int ay, int bx, int by, int cx, int cy){
        return Math.abs(ax * (by - cy) + bx * (cy - ay) + cx * (ay - by))/2;
    }
}

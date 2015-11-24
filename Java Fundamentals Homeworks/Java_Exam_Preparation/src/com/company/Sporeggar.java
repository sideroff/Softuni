package com.company;
import java.util.Scanner;

/**
 * Created by Siderov on 2.11.2015 ã..
 */
public class Sporeggar {
    public static int hp= 5800;
    public static int glowcaps = 0;
    public static boolean sporeggarReached = true;
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        while(!input.equals("Sporeggar")){
            for (int i = 0; i < input.length()-1; i++) {
                if(input.charAt(i)=='L'){
                    heal(200);
                    continue;
                }
                hp-=input.charAt(i);
                if(isDead())
                {
                    sporeggarReached = false;
                    break;
                }
            }
            if(isDead()) break;
            glowcaps += Integer.parseInt(input.charAt(input.length()-1)+"");
            input=sc.nextLine();
        }
        if(isDead()){
            System.out.printf("Died. Glowcaps: %d",glowcaps);
        }
        else if(sporeggarReached && glowcaps-30>=0){
            System.out.printf("Health left: %d\n", hp);
            System.out.printf("Bought the sporebat. Glowcaps left: %d\n",glowcaps-30);
        }
        else if(sporeggarReached && glowcaps-30<0){
            System.out.printf("Health left: %d\n", hp);
            System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.\n",30-glowcaps);
        }

    }
    public static void heal(int value){
        hp+=value;
    }
    public static boolean isDead(){
        if(hp<=0) return true;
        return false;
    }
}

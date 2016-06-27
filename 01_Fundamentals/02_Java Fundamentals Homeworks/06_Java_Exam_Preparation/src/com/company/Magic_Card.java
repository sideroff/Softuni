package com.company;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
/**
 * Created by Siderov on 3.11.2015 ã..
 */
public class Magic_Card {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] cards = sc.nextLine().split(" ");
        String parity = sc.nextLine();
        String magicCard = sc.nextLine();
        Integer sum = 0;
        Integer start=0;
        if(parity.equals("odd")) start = 1;
        else if(parity.equals("even")) start =0;

        for(int i = start;i<cards.length;i+=2){
            Integer s = 0;
            if("1023456789".contains(cards[i].substring(0, cards[i].length() - 1))){
                s=Integer.parseInt(cards[i].substring(0,cards[i].length()-1));
            }
            else if("A".contains(cards[i].substring(0, cards[i].length() - 1))){
                s=15;
            }
            else if("K".contains(cards[i].substring(0, cards[i].length() - 1))){
                s=14;
            }
            else if("Q".contains(cards[i].substring(0, cards[i].length() - 1))){
                s=13;
            }
            else if("J".contains(cards[i].substring(0, cards[i].length() - 1))){
                s=12;
            }
            String magicFace = magicCard.substring(0,magicCard.length()-1);
            String magicSuit = magicCard.substring(magicCard.length()-1,magicCard.length());
            String cardFace = cards[i].substring(0,cards[i].length()-1);
            String cardSuit = cards[i].substring(cards[i].length() - 1, cards[i].length());

            if(magicFace.equals(cardFace)){
                sum+=30*s;
            }
            else if(magicSuit.equals(cardSuit)){
                sum+=20*s;
            }
            else{
                sum+=10*s;
            }
        }
        System.out.println(sum);

    }
}
